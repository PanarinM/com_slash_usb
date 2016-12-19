from serial_read import we2107
from tacho_read import ut372device

if __name__ == "__main__":
    tacho = ut372device()
    pressure = we2107()
    tacho.connect()
    while True:
        tacho.receive_package()
        print(pressure.read_data() if pressure.read_data() < 3500 else print('corrupt packet'))