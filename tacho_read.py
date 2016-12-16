from time import sleep
import pywinusb.hid as hid
from msvcrt import kbhit
from datetime import datetime

lst = []
marker = False

descriptor = {
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


def sample_handler_count(data):
    global marker
    global descriptor
    global lst
    if not chr(data[2]) == '\x00':
        if marker:
            lst.append(chr(data[2]))
            if len(lst) == 27:
                positioning_count()
        if chr(data[2]) == '\n':
            marker = True


def positioning_count():
    global marker
    global lst
    deciphered_raw = []
    for i in range(1, len(lst) - 6, 2):
        try:
            deciphered_raw.append(descriptor[lst[i] + lst[i + 1]])
        except KeyError:
            lst.clear()
            marker = False
            return
    output_str = 'count {} time {}'
    count = deciphered_raw[:5]
    try:
        count = int(''.join(list(reversed(count))))
    except ValueError:
        count = float(''.join(list(reversed(count))))
    time = datetime.now()
    time = time.strftime('%d-%m-%Y %H:%M:%S')
    print(output_str.format(count, time))
    lst.clear()
    deciphered_raw.clear()


filter = hid.HidDeviceFilter(vendor_id=0x1a86, product_id=0xe008)
hid_device = filter.get_devices()

try:
    device = hid_device[0]
except IndexError:
    print('Device is not connected!')
    exit()


device.open()


device.set_raw_data_handler(sample_handler_count)


report = device.find_feature_reports()


buffer = [0x00] * 6
buffer[0] = 0x00
buffer[1] = 0x60
buffer[2] = 0x09
buffer[5] = 0x03


report[0].set_raw_data(buffer)
report[0].send()

while not kbhit() and device.is_plugged():
    # just keep the device opened to receive events
    sleep(0.5)
