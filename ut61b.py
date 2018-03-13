"""
Created on Sep 22, 2017

@author: Dmitry Melnichansky 4X1MD ex 4X5DM, 4Z7DTF
         https://github.com/4x1md
         http://www.qrz.com/db/4X1MD
         
@note: UT61E class which reads data packets from UNI-T UT61E using serial
       interface, parses them and returns as dictionary or as string in
       human readable form.
"""

from __future__ import print_function
import sys
import time
import datetime
import serial

SLEEP_TIME = 0.25
PORT = "COM3"

# Settings constants
BAUD_RATE = 2400
BITS = serial.EIGHTBITS
PARITY = serial.PARITY_NONE
STOP_BITS = serial.STOPBITS_ONE
DTR = True
RTS = False
TIMEOUT = 1
# Data packet ends with CR LF (\r \n) characters
EOL = b'\x0D\x0A'
RAW_DATA_LENGTH = 14
READ_RETRIES = 3

# BYTE 0 sign
# PLUS = 0x2b
# NEG = 0x2d
BYTE_0 = {
    0x2b: '+',
    0x2d: '-',
    0: '',
}

# Bytes containing digits
DIGIT_BYTES = (1, 2, 3, 4)
DIGIT_MASK = 0b00001111

# in addition, byte 1 can be "?" (0x3f) indicating value overflow
QST = {0x3f: '?'}

# BYTE 5 white space
# WHITE_SPACE = 0x20  # 0b00000100
BYTE_5 = {0x20: ' ', 0: 'false'}

# BYTE 6 Decimal point
# POS_1 = 0x31  # 0b10001100
# POS_2 = 0x32  # 0b01001100
# POS_3 = 0x33  # 0b00011100
# POS_4 = 0x34  # 0b00001100
BYTE_6 = {
    0x31: 0.001,
    0x32: 0.01,
    0x34: 0.1,
    0x30: 1,
    0: '',
}

# BYTE 7  Settings/ Pressend Buttons/ Binary flags, can be combined
"""WTFFFFFFF"""
BAR_GRPH = 0x1    # 0b10000000
HOLD = 0x2        # 0b01000000
RELATIVE = 0x4    # 0b00100000
AC = 0x8          # 0b00010000
DC = 0x10         # 0b00001000
AUTORANGE = 0x20  # 0b00000100

# BYTE 8 nano/low bat/autopowof/min/max
# NANO = 0x2     # 0b01000000
# LOW_BAT = 0x4  # 0b00100000
# APOWOFF = 0x8  # 0b00010000
# MIN = 0x10     # 0b00001000
# MAX = 0x20     # 0b00000100
BYTE_8 = {
    0x2: 'nano',
    0x4: 'low battery',
    0x8: 'auto power off',
    0x10: 'min',
    0x20: 'max',
    0: ''
}

# BYTE 9 Unit prefix
# PERCENT = 0x2  # 0b01000000
# DIODE = 0x4    # 0b00100000
# BEEP = 0x8     # 0b00010000
# MEGA = 0x10    # 0b00001000
# KILO = 0x20    # 0b00000100
# MILLI = 0x40   # 0b00000010
# MICRO = 0x80   # 0b00000001
BYTE_9 = {
    0x2: '%',
    0x4: 'diode',
    0x8: 'beep',
    0x10: 'M',
    0x20: 'k',
    0x40: 'm',
    0x80: 'u',
    0: ''
}

# BYTE 10 Unit
# FAHREN = 0x1   # 0b10000000
# DEGREE = 0x2   # 0b01000000
# FARAD = 0x4    # 0b00100000
# HERTZ = 0x8    # 0b00010000
# HFE = 0x10     # 0b00001000
# OHM = 0x20     # 0b00000100
# AMPERE = 0x40  # 0b00000010
# VOLT = 0x80    # 0b00000001
BYTE_10 = {
    0x1: 'fahrenheit',
    0x2: 'degree',
    0x4: 'farad',
    0x8: 'Hz',
    0x10: 'HFE',
    0x20: 'Ohm',
    0x40: 'A',
    0x80: 'V',
    0: ''
}

"""
┌───────────────────────────────────────────────────┐
│ Byte 11: bargraph value                    │
│   bit 0   : positive (0) or negative (1)   │
│   bit 1-6 : value as 7bit unsigned int     │
└───────────────────────────────────────────────────┘
"""


class UT61B(object):
    
    def __init__(self, port):
        self._port = port
        self._ser = serial.Serial(self._port, BAUD_RATE, BITS, PARITY, STOP_BITS, timeout=TIMEOUT)
        self._ser.setDTR(DTR)
        self._ser.setRTS(RTS)

    def read_raw_data(self):
        """Reads a new data packet from serial port.
        If the packet was valid returns array of integers.
        if the packet was not valid returns empty array.
        
        In order to get the last reading the input buffer is flushed
        before reading any data.
        
        If the first received packet contains less than 14 bytes, it is
        not complete and the reading is done again. Maximum number of
        retries is defined by READ_RETRIES value.
        """
        self._ser.reset_input_buffer()

        for x in range(READ_RETRIES):
            raw_data = self._ser.read_until(EOL, RAW_DATA_LENGTH)
            # If 14 bytes were read, the packet is valid and the loop ends.
            if len(raw_data) == RAW_DATA_LENGTH:
                break

        res = []
        
        # Check data validity
        if self.is_data_valid(raw_data):
            res = list(raw_data)
        
        return res

    def is_data_valid(self, raw_data):
        """Checks data validity:
        1. 14 bytes long
        2. Footer bytes 0x0D 0x0A"""
        # Data length
        if len(raw_data) != RAW_DATA_LENGTH:
            return False
        
        # End bytes
        if not raw_data.endswith(EOL):
            return False
        
        return True
    
    def read_hex_str_data(self):
        """Returns raw data represented as string with hexadecimal values."""
        data = self.read_raw_data()
        codes = ["%02X" % c for c in data]
        return " ".join(codes)
    
    def get_meas(self):
        """Returns received measurement as dictionary"""
        # res = MEAS_RES.copy()
        
        raw_data = self.read_raw_data()

        # Value
        val = 0
        for n in DIGIT_BYTES:
            digit = raw_data[n] & DIGIT_MASK
            val = val * 10 + digit
        val *= BYTE_6[raw_data[6]]

        res = "{}{} {} {}".format(
            BYTE_0[raw_data[0]],
            round(val, 2),
            BYTE_9[raw_data[9]],
            BYTE_10[raw_data[10]],
        )
        return res
    
    def __del__(self):
        if hasattr(self, '_ser'):
            self._ser.close()


if __name__ == '__main__':
    try:
        if len(sys.argv) > 1:
            port = sys.argv[1]
        else:
            port = PORT

        dmm = UT61B(port)
        meas = dmm.get_meas()
        sys.stdout.write(meas)

    except serial.SerialException as e:
        print("Serial port error.")
        print(e)
