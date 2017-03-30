import psycopg2


class PostgreConnect(object):
    """
    main class to push data to PostgresDB
    """
    def __init__(self, table='data', user='postgres', password='postgres', dbname='com_slash_usb'):
        self.table = table
        self.user = user
        self.dbname = dbname
        self.password = password

    def __enter__(self):
        """
        context manager enter magic function
        :return:
        """
        self.conn = psycopg2.connect("dbname='{}' user='{}' host='localhost' password='{}'".format(
            self.dbname, self.user, self.password)
        )
        self.cursor = self.conn.cursor()
        return self

    def __exit__(self, exc_type, exc_val, exc_tb):
        """
        context manager exit magic function
        :param exc_type:
        :param exc_val:
        :param exc_tb:
        :return:
        """
        try:
            self.conn.close()
        except:
            pass

    def add_record(self, date, milliseconds, data1, type1, data2, type2, power=0):
        """
        function that adds a record for a specific date and time for a devices
        :param date: date and time of the record (datetime)
        :param milliseconds: milliseconds of datetime, integer value
        :param data1: data for the 1st device (float)
        :param type1: data type (string)
        :param data2: data for the 2nd device (float)
        :param type2: data type (string)
        :return:
        """
        sqlstr = "INSERT INTO {}(date_time, milliseconds, c9c, c9c_datatype, tacho, tacho_datatype, power)" \
                 " values ('{}','{}',{},'{}',{},'{}','{}')".format(
            self.table, date, milliseconds, data1, type1, data2, type2, power)
        self.cursor.execute(sqlstr)
        self.conn.commit()

    def close_connection(self):
        try:
            self.conn.close()
        except:
            pass

