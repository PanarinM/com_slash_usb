from serial import Serial, PARITY_EVEN, SerialException


class we2107(object):
    def __init__(self, comnumb):
        self.ser = Serial()
        self.ser.baudrate = 2400
        self.ser.port = 'COM{}'.format(comnumb)
        self.ser.parity = PARITY_EVEN
        self.ser.stopbits = 1
        self.ser.open()

    def read_data(self):
        self.ser.write(b';S15;')
        self.ser.write(b'MSV?;')
        data = self.ser.readline()
        return data[0]+data[1]*255+data[2]

    def __del__(self):
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
