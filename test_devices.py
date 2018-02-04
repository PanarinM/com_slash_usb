from ut61b import UT61B
from tacho_read import ut372device
from serial_read import we2107

import sys

if __name__ == "__main__":
    if len(sys.argv) == 1:
        raise UserWarning("You didn't pass COM ports")
    else:
        ComVolt, ComAmp, ComPres = tuple(sys.argv[1].split(','))

    # test voltmeter
    voltmeter = UT61B(ComVolt)
    meas = voltmeter.get_meas()
    # test ampermeter
    ampermeter = UT61B(ComAmp)
    meas = ampermeter.get_meas()
    # test tachometer
    tachometer = ut372device()
    data = ('', '', '')
    while data[2] == '':
        data = tachometer.receive_package()
    data = ' '.join((str(x) for x in data))
    # test pressure device
    pressure_dev = we2107(ComPres)
    data = str(pressure_dev.read_data())
