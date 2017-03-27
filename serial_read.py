from serial import Serial, PARITY_EVEN, SerialException


class we2107(object):
    """
    class for pySerial c9c device, connected through we2107
    """
    def __init__(self, comnumb):
        self.ser = Serial()
        self.ser.baudrate = 2400
        self.ser.port = comnumb
        self.ser.parity = PARITY_EVEN
        self.ser.timeout = 5
        self.ser.write_timeout = 5
        self.ser.stopbits = 1
        self.ser.open()

    def read_data(self):
        """
        Sends serial command to device and then reads the output data
        :return: String with output data
        """
        self.ser.write(b';S15;')
        self.ser.write(b'MSV?;')
        data = self.ser.readline()
        return data[0]+data[1]*255+data[2]

    def __del__(self):
        """
        convenient close of serial port
        :return: None
        """
        self.ser.close()


if __name__ == '__main__':
    comnumb = input('Input COM port number: ')
    try:
        device = we2107(comnumb)
    except SerialException:
        print('Wrong COM port')
        exit()
    while True:
        print(device.read_data())
