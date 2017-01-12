import pyodbc


class AccessConnect:
    """
    main class for data manipulations in DB
    """
    def __init__(self, database=r'C:\Users\Public\Documents\database.accdb', table=r'table'):
        self.database = database
        self.table = table

    def read_record(self, sdate, devices):
        """
        function that read a records for a specific date and time for a specific devices
        :param sdate: datetime object. Date of the required data
        :param devices: iteratable object of strings(list, set, dict, tuple, etc.). List of the devices
        :return: list of tuples with data from DB
        """
        connstr = r'DRIVER={Microsoft Access Driver (*.mdb, *.accdb)};DBQ='+self.database
        cnxn = pyodbc.connect(connstr)
        cur = cnxn.cursor()
        strsql = "SELECT dev_name,dev_state,dev_date FROM [{table}] where dev_date > #{date}# " \
                 "and dev_name IN ({device})".format(table=self.table, date=sdate, device=','.join(["'"+j+"'" for j in devices]))
        cur.execute(strsql)
        t = list(cur)
        cnxn.close()
        return t

    def add_record(self, sdate, device, value, data_type):
        """
        function that adds a record for a specific date and time for a specific device
        :param sdate: datetime object. Date for the record
        :param device: string object. Device name
        :param value: float object. Data from devic
        :param data_type: string object. Dimension of the value
        :return: None
        """
        connstr = r'DRIVER={Microsoft Access Driver (*.mdb, *.accdb)};DBQ='+self.database
        cnxn = pyodbc.connect(connstr, autocommit=True)
        cnxn.cursor()
        strsql = "insert into [{table}] (dev_name, dev_state, dev_date, dev_data_type) values('{name}', {state}, " \
                 "#{sdate}#, '{data_type}')".format(table=self.table, name=device, state=value, sdate=sdate, data_type=data_type)
        cnxn.execute(strsql)
        cnxn.commit()
        cnxn.close


if __name__ == '__main__':
    pass
    # mypath = path.realpath('.')
    # a = AccessConnect(mypath+'\\'+'database.accdb', 'table')
    # a.add_record('12/12/2016', 'jopa', 11, 'lel')
