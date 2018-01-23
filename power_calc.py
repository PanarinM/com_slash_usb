import math
from decimal import Decimal, getcontext
from sys import argv, stdout


class PowerCalc(object):
    getcontext().prec = 6
    pi = Decimal(math.pi)
    g = Decimal(9.81)
    k = Decimal(g/1000)

    def __init__(self, rpm, force, arm):
        self.rpm = Decimal(rpm)
        self.force = Decimal(force)
        self.arm = Decimal(arm)

    def frequency(self):
        return (self.pi/30)*self.rpm

    def conv_force(self):
        return self.k * self.force

    def torque(self):
        return self.conv_force() * self.arm

    def power(self):
        return self.frequency()*self.torque()

if __name__ == '__main__':
    rpm, force, arm = argv[1].split(',')
    pc = PowerCalc(*argv[1].split(','))
    stdout.write(','.join([str(pc.power()), str(pc.torque())]))
#     power = PowerCalc(12.435, 250, 0.13)
#     print(power.pi)
#     print(power.g)
#     print(power.k)
#     print(power.rpm)
#     print(power.force)
#     print(power.arm)
#     print(power.frequency())
#     print(power.conv_force())
#     print(power.torque())
#     print(power.power())
