from sys import argv
class AccessConnect:
    import pyodbc

    def __init__(self, database=r'C:\Users\Public\Documents\database.accdb', table=r'table'):
        self.database = database
        self.table = table

    def read_record(self, sdate, devices):
        """
        connects with odbc
        """
        connstr = r'DRIVER={Microsoft Access Driver (*.mdb, *.accdb)};DBQ='+self.database
        cnxn = self.pyodbc.connect(connstr)
        cur = cnxn.cursor()
        strsql = "SELECT dev_name,dev_state,dev_date FROM [{table}] where dev_date > #{date}# " \
                 "and dev_name IN ({device})".format(table=self.table, date=sdate, device=','.join(["'"+j+"'" for j in devices]))
        cur.execute(strsql)
        t = list(cur)
        cnxn.close()
        return t

    def add_record(self ,sdate, device, value, data_type):
        """
        connects with odbc
        """
        connstr = r'DRIVER={Microsoft Access Driver (*.mdb, *.accdb)};DBQ='+self.database
        cnxn = self.pyodbc.connect(connstr, autocommit=True)
        cur = cnxn.cursor()
        strsql = "insert into [{table}] (dev_name, dev_state, dev_date, dev_data_type) values('{name}', {state}, " \
                 "#{sdate}#, '{data_type}')".format(table=self.table, name=device, state=value, sdate=sdate, data_type=data_type)
        cur.execute(strsql)


if __name__ == '__main__':
    a = AccessConnect()
    # print(a.read_record('11/11/2011', ['jopa']))
    print(argv)
    record = [i for i in argv[1].split(';')]
    print(record)
    a.add_record(record[0], record[1], record[2], record[3])
    # print(record)
    # a.add_record()


    # FIX ARGV ATO VOZVRAT HUYNYA