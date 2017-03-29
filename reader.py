import serial.tools.list_ports
from serial import SerialException
from serial import SerialTimeoutException
from sys import exit

from serial_read import we2107
from tacho_read import ut372device, DeviceIsNotConnected
from postgres_connect import PostgreConnect
from power_calc import PowerCalc


def __comchoose():
    """
    Lists availible COM ports. Then asks user to choose one
    :return: String with com port
    """
    comlist = serial.tools.list_ports.comports()
    for com in comlist:
        print('{}. {} {}'.format(comlist.index(com) + 1, com.device, com.description))
    if len(comlist) == 0:
        print('No COM devices found')
        input()
        exit()
    while True:
        userinp = int(input('Input COM number: '))
        if userinp > len(comlist) or userinp < 0:
            print('Wrong input')
            exit()
        else:
            return comlist[userinp-1].device


if __name__ == "__main__":
    arm = 0.13
    comnumb = str(__comchoose())
    try:
        db = PostgreConnect()
        db.close_connection()
    except:
        print('An error occured during the connection to database, make sure the service of PostgreSQL is up and running!')
        input()
        exit()
    try:
        pressure = we2107(comnumb)
    except SerialException:
        print('Wrong COM port for pressure device')
        input()
        exit()
    try:
        tacho = ut372device()
        print('Tachometer device was found by product ID = {} and vendor ID = {}'.format(tacho.product_id,
                                                                                         tacho.vendor_id))
    except DeviceIsNotConnected:
        print('Tachometer device was not found by specified product ID and vendor ID')
        input()
        exit()
    print('------------------------------------------')
    with PostgreConnect() as db:
        while True:
            tacho_data = tacho.receive_package()
            if tacho_data[2] is None or tacho_data[2] == 0:
                continue
            try:
                c9c_data = pressure.read_data() if pressure.read_data() < 3500 else print('corrupt package')
            except (SerialTimeoutException, SerialException):
                # c9c_data = 'read_write timeout'
                c9c_data = 'NULL'
            if c9c_data is None:
                c9c_data = 0
            db.add_record(tacho_data[2], c9c_data, 'gram', tacho_data[1], tacho_data[0])
            if tacho_data[0] == 'rpm':
                ###########
                power_ = PowerCalc(tacho_data[1], c9c_data, arm)
                power = power_.power()
                ###########
                output = """\rut372: {} {} | c9c: {} gram | power: {} | time: {}                                        """\
                    .format(tacho_data[1], tacho_data[0], c9c_data, power, tacho_data[2])
                print(output, end='')
            elif tacho_data[0] == 'count':
                output = """\rut372: {} {} | c9c: {} gram | time: {}  (switch tacho to rpm to get power values)         """\
                    .format(tacho_data[1], tacho_data[0], c9c_data, tacho_data[2])
                print(output, end='')
