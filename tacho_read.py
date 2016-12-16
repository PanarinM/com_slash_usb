from time import sleep
import pywinusb.hid as hid
from msvcrt import kbhit
from datetime import datetime


class ut372device(object):
    def __init__(self):
        self.lst = []
        self.device = 'will further be overriden with device object'
        self.marker = False
        self.descriptor = {
            '7;': '0',
            '60': '1',
            '5>': '2',
            '7<': '3',
            '65': '4',
            '3=': '5',
            '3?': '6',
            '70': '7',
            '7?': '8',
            '7=': '9',
            '?;': '0.',
            '>0': '1.',
            '=>': '2.',
            '?<': '3.',
            '>5': '4.',
            ';=': '5.',
            ';?': '6.',
            '?0': '7.',
            '??': '8.',
            '?=': '9.',
            '00': '00',
            '78': 'conf',
            '86': 'bit',
        }

    def sample_handler_count(self, data):
        if not chr(data[2]) == '\x00':
            if self.marker:
                self.lst.append(chr(data[2]))
                if len(self.lst) == 27:
                    print(self._positioning_count())
            if chr(data[2]) == '\n':
                self.marker = True

    def _positioning_count(self):
        deciphered_raw = []
        for i in range(1, len(self.lst) - 6, 2):
            try:
                deciphered_raw.append(self.descriptor[self.lst[i] + self.lst[i + 1]])
            except KeyError:
                self.lst.clear()
                self.marker = False
                return
        output_str = 'count {} time {}'
        count = deciphered_raw[:5]
        try:
            count = int(''.join(list(reversed(count))))
        except ValueError:
            count = float(''.join(list(reversed(count))))
        time = datetime.now()
        time = time.strftime('%d-%m-%Y %H:%M:%S')
        output = output_str.format(count, time)
        self.lst.clear()
        return output

    def connect(self):
        devfilter = hid.HidDeviceFilter(vendor_id=0x1a86, product_id=0xe008)
        hid_device = devfilter.get_devices()

        try:
            self.device = hid_device[0]
        except IndexError:
            print('Device is not connected!')
            exit()
        self.device.open()
        self.device.set_raw_data_handler(self.sample_handler_count)
        self._send_init_packet()

    def _send_init_packet(self):
        report = self.device.find_feature_reports()

        buffer = [0x00] * 6
        buffer[0] = 0x00
        buffer[1] = 0x60
        buffer[2] = 0x09
        buffer[5] = 0x03

        report[0].set_raw_data(buffer)
        report[0].send()

    def receive_package(self):
        if ourdevice.device.is_plugged():
            sleep(0.3)

if __name__ == '__main__':
    ourdevice = ut372device()
    ourdevice.connect()
    while True:
        ourdevice.receive_package()
 