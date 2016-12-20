from serial_read import we2107
from tacho_read import ut372device
from tacho_acess_db import AccessConnect
from os import path

if __name__ == "__main__":
    tacho = ut372device()
    pressure = we2107()
    tacho.connect()
    while True:
        pathtodb = path.realpath('.')+'\\'+'database.accdb'
        db = AccessConnect(pathtodb, 'table')
        # db = AccessConnect()
        tacho_data = tacho.receive_package()
        if tacho_data[2] == 0:
            continue
        # print(tacho_data)
        print('ut372: {} {} time: {}'.format(tacho_data[1], tacho_data[0], tacho_data[2]))
        db.add_record(tacho_data[2], 'ut372', tacho_data[1], tacho_data[0])

        c9c_data = pressure.read_data() if pressure.read_data() < 3500 else print('corrupt packet')
        # print(c9c_data)
        print('c9c  : {} gram'.format(c9c_data))
        db.add_record(tacho_data[2], 'c9c', c9c_data, 'gram')

        print('------------------------------------------')
