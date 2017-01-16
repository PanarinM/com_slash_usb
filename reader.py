from serial_read import we2107
from pyodbc import Error
from tacho_read import ut372device, DeviceIsNotConnected
from tacho_acess_db import AccessConnect
import serial.tools.list_ports
from serial import SerialException
from os import listdir, path
from sys import exit


def __db_choose():
    """
    Lists *.accdb Access database files in the current folder. Then asks user to choose one
    :return: String with path to the DB
    """
    counter = 0
    dbfiles = []
    for file in listdir('.'):
        if file.endswith('.accdb'):
            counter += 1
            print('{}. {}'.format(counter, file))
            dbfiles.append(file)
    if counter == 0:
        print('No Accsess DB files found')
        input()
        exit()
    while True:
        userinput = int(input('Choose the DB file: '))
        if userinput > counter or userinput < 0:
            print('Wrong input!')
            continue
        else:
            return path.realpath('.\\{}'.format(dbfiles[userinput-1]))


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
    comnumb = str(__comchoose())
    pathtodb = __db_choose()
    try:
        db = AccessConnect(pathtodb, 'table')
    except Error:
        print('Error occured during the database connection. Check if Microsoft Access Driver is installed and availible')
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
    while True:
        tacho_data = tacho.receive_package()
        if tacho_data[2] is None or tacho_data[2] == 0:
            continue
        db.add_record(tacho_data[2], 'ut372', tacho_data[1], tacho_data[0])
        c9c_data = pressure.read_data() if pressure.read_data() < 3500 else print('corrupt packet')
        if c9c_data is not None:
            db.add_record(tacho_data[2], 'c9c', c9c_data, 'gram')
        elif c9c_data is None:
            c9c_data = 0
            db.add_record(tacho_data[2], 'c9c', c9c_data, 'gram')
        output = """\rut372: {} {} | c9c: {} gram | time: {}""".format(tacho_data[1], tacho_data[0], c9c_data, tacho_data[2])
        print(output, end='')
