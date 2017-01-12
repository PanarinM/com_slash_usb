from serial_read import we2107
from tacho_read import ut372device
from tacho_acess_db import AccessConnect
from serial import SerialException
from os import listdir


def __db_choose():
    counter = 0
    dbfiles = []
    for file in listdir('.'):
        if file.endswith('.accdb'):
            counter += 1
            print('{}. {}'.format(counter, file))
            dbfiles.append(file)
    while True:
        userinput = int(input('Choose the DB file: '))
        if userinput > counter or userinput < 0:
            print('Wrong input!')
            continue
        else:
            return '.\\{}'.format(dbfiles[userinput-1])


if __name__ == "__main__":
    comnumb = input('Input COM port number: ')
    pathtodb = __db_choose()
    tacho = ut372device()
    try:
        pressure = we2107(comnumb)
    except SerialException:
        print('Wrong COM port')
        exit()
    tacho.connect()
    while True:
        db = AccessConnect(pathtodb, 'table')
        tacho_data = tacho.receive_package()
        if tacho_data[2] == 0:
            continue
        print('ut372: {} {} time: {}'.format(tacho_data[1], tacho_data[0], tacho_data[2]))
        db.add_record(tacho_data[2], 'ut372', tacho_data[1], tacho_data[0])
        c9c_data = pressure.read_data() if pressure.read_data() < 3500 else print('corrupt packet')
        print('c9c  : {} gram'.format(c9c_data))
        db.add_record(tacho_data[2], 'c9c', c9c_data, 'gram')
        print('------------------------------------------')
