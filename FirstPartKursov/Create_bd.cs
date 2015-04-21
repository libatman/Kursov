using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;

namespace FirstPartKursov
{
    class create_bd
    {
        private SQLiteConnection sql;
        private SQLiteCommand sc;
        private SQLiteDataAdapter DB;
        private DataSet DS = new DataSet();
        private DataTable DT = new DataTable();
        public void CreateBase()
        {
            SQLiteConnection.CreateFile(@"bd_kursov.sqlite");
        }
        private void SetConnection()
        {
            sql = new SQLiteConnection(@"Data Source=bd_kursov.sqlite;Version=3;New=False;Compress=True;");
        }
        public void ExecuteQuery(string txtQuery)// любой запрос.
        {
            SetConnection();
            sql.Open();
            sc = sql.CreateCommand();
            sc.CommandText = txtQuery;
            sc.ExecuteNonQuery();
            sql.Close();
        }
        public void table_create()
        {
            CreateBase();
            SetConnection();
            sql.Open();
            SQLiteCommand pragma = new SQLiteCommand("PRAGMA foreign_keys = 1;", sql);
            pragma.ExecuteNonQuery();
            sc = sql.CreateCommand();
            sc.CommandText = "create table office(id_office INTEGER PRIMARY KEY NOT NULL, address TEXT NOT NULL, email TEXT NOT NULL)";
            sc.ExecuteNonQuery();
            sc = sql.CreateCommand();
            sc.CommandText = "create table manager(id_manager INTEGER PRIMARY KEY NOT NULL, FIO TEXT NOT NULL, id_office INTEGER NOT NULL, FOREIGN KEY(id_office) REFERENCES office (id_office))";
            sc.ExecuteNonQuery();
            sc = sql.CreateCommand();
            sc.CommandText = "create table provider(id_provider INTEGER PRIMARY KEY NOT NULL, name_provider TEXT NOT NULL, email_provider TEXT NOT NULL)";
            sc.ExecuteNonQuery();
            sc = sql.CreateCommand();
            sc.CommandText = "create table goods(id_goods INTEGER PRIMARY KEY NOT NULL, name_goods TEXT NOT NULL, surrency TEXT NOT NULL, price INTEGER NOT NULL,id_provider INTEGER NOT NULL, FOREIGN KEY(id_provider) REFERENCES provider (id_provider))";
            sc.ExecuteNonQuery();
            sc = sql.CreateCommand();
            sc.CommandText = "create table storage(id_office INTEGER PRIMARY KEY NOT NULL,id_goods INTEGER NOT NULL, amount_goods INTEGER NOT NULL, FOREIGN KEY(id_office) REFERENCES office (id_office),FOREIGN KEY(id_goods) REFERENCES goods (id_goods))";
            sc.ExecuteNonQuery();
            sc = sql.CreateCommand();
            sc.CommandText = "create table ordering_goods(id_ordering INTEGER PRIMARY KEY NOT NULL, amount_goods INTEGER NOT NULL, id_goods INTEGER NOT NULL,id_provider INTEGER NOT NULL, FOREIGN KEY(id_goods) REFERENCES goods (id_goods),FOREIGN KEY(id_provider) REFERENCES provider (id_provider))";
            sc.ExecuteNonQuery();
            sc = sql.CreateCommand();
            sc.CommandText = "create table redistribution_goods(id_redistribution INTEGER PRIMARY KEY NOT NULL, amount_goods INTEGER NOT NULL, id_goods INTEGER NOT NULL,id_storage_old INTEGER NOT NULL,id_storage_new INTEGER NOT NULL, FOREIGN KEY(id_goods) REFERENCES goods (id_goods),FOREIGN KEY(id_storage_old) REFERENCES storage(id_office),FOREIGN KEY(id_storage_new) REFERENCES storage(id_office))";
            sc.ExecuteNonQuery();
            sc = sql.CreateCommand();
            sc.CommandText = "create table selling(id_selling INTEGER PRIMARY KEY NOT NULL, date TEXT NOT NULL,amount INTEGER NOT NULL,sum_of_sale INTEGER NOT NULL,comment TEXT ,number_of_disk INTEGER NOT NULL, id_goods INTEGER NOT NULL,id_manager INTEGER NOT NULL, FOREIGN KEY(id_goods) REFERENCES goods(id_goods),FOREIGN KEY(id_manager) REFERENCES manager(id_manager))";
            sc.ExecuteNonQuery();
            sc = sql.CreateCommand();
            sc.CommandText = "create table info(main_email TEXT NOT NULL)";
            sc.ExecuteNonQuery();
            sql.Close();

        }
        public void table_insert()
        {
            SetConnection();
            sql.Open();
            sc = sql.CreateCommand();
            sc.CommandText = "INSERT INTO 'office' ('id_office', 'address','email') VALUES (1, 'филатова4','anastasySher222@bk.ru');";
            sc.ExecuteNonQuery();
            sc = sql.CreateCommand();
            sc.CommandText = "INSERT INTO 'office' ('id_office', 'address','email') VALUES (2, 'филатова6','anastasySher222@bk.ru');";
            sc.ExecuteNonQuery();
            sc = sql.CreateCommand();
            sc.CommandText = "INSERT INTO 'office' ('id_office', 'address','email') VALUES (3, 'филатова9','nikolaiuhvarov@mail.ru');";
            sc.ExecuteNonQuery();
            sc = sql.CreateCommand();
            sc.CommandText = "INSERT INTO 'manager' ('id_manager', 'FIO','id_office') VALUES (1, 'Щербакова', 1);";
            sc.ExecuteNonQuery();
            sc.CommandText = "INSERT INTO 'manager' ('id_manager', 'FIO','id_office') VALUES (2, 'Семёнова', 2);";
            sc.ExecuteNonQuery();
            sc = sql.CreateCommand();
            sc.CommandText = "INSERT INTO 'provider' ('id_provider', 'name_provider','email_provider') VALUES (1, 'Hohner','anastasySher222@mail.ru');";
            sc.ExecuteNonQuery();
            sc = sql.CreateCommand();
            sc.CommandText = "INSERT INTO 'provider' ('id_provider', 'name_provider','email_provider') VALUES (2, 'Lisa','liza.deer@yandex.ru');";
            sc.ExecuteNonQuery();
            sc = sql.CreateCommand();
            sc.CommandText = "insert into 'goods' ('id_goods', 'name_goods','surrency','price','id_provider') values (1, 'гитара','rub',4999,1);";
            sc.ExecuteNonQuery();
            sc = sql.CreateCommand();
            sc.CommandText = "INSERT INTO 'storage' ('id_office', 'id_goods','amount_goods') VALUES (1, 1,10);";
            sc.ExecuteNonQuery();
            sc.CommandText = "INSERT INTO 'storage' ('id_office', 'id_goods','amount_goods') VALUES (2, 1,0);";
            sc.ExecuteNonQuery();
            sc = sql.CreateCommand();
            sc.CommandText = "INSERT INTO 'ordering_goods' ('id_ordering', 'amount_goods','id_goods','id_provider') VALUES (1,15,1,1);";
            sc.ExecuteNonQuery();
            sc = sql.CreateCommand();
            sc.CommandText = "INSERT INTO 'redistribution_goods' ('id_redistribution', 'amount_goods','id_goods','id_storage_old','id_storage_new') VALUES (1,3,1,1,2);";
            sc.ExecuteNonQuery();
            sc = sql.CreateCommand();
            sc.CommandText = "INSERT INTO 'selling' ('id_selling', 'date','amount','sum_of_sale','comment','number_of_disk','id_goods','id_manager') VALUES (1,'22/02/15',1,4999,'скидки нет',1,1,1);";
            sc.ExecuteNonQuery();
            sc = sql.CreateCommand();
            sc.CommandText = "INSERT INTO 'info' ('main_email') VALUES ('ofis_tsentralnyy@mail.ru');";
            sc.ExecuteNonQuery();
            sql.Close();
        }
        public DataTable table_select(string name_table)
        {
            SetConnection();
            sql.Open();
            SQLiteCommand sc = new SQLiteCommand();
            sc.CommandText = @"SELECT * FROM " + name_table + ";";
            SQLiteDataReader sdr = sc.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(sdr);
            sdr.Close();
            sql.Close();
            return dt;

        }

        public List<string> addresses_postav()
        {
            List<string> addresses_p = new List<string>();
            using (SQLiteConnection connect = new SQLiteConnection(@"Data Source=bd_kursov.sqlite;Version=3;New=False;Compress=True;"))
            {
                connect.Open();
                using (SQLiteCommand fmd = connect.CreateCommand())
                {
                    fmd.CommandText = @"SELECT email_provider FROM provider";
                    fmd.CommandType = CommandType.Text;
                    SQLiteDataReader r = fmd.ExecuteReader();
                    while (r.Read())
                    {
                        addresses_p.Add(Convert.ToString(r["email_provider"]));

                    }
                }
            }
            return addresses_p;

        }

        public List<string> addresses_filial()
        {
            List<string> addresses_a = new List<string>();
            using (SQLiteConnection connect = new SQLiteConnection(@"Data Source=bd_kursov.sqlite;Version=3;New=False;Compress=True;"))
            {
                connect.Open();
                using (SQLiteCommand fmd = connect.CreateCommand())
                {
                    fmd.CommandText = @"SELECT email FROM office";
                    fmd.CommandType = CommandType.Text;
                    SQLiteDataReader r = fmd.ExecuteReader();
                    while (r.Read())
                    {
                        addresses_a.Add(Convert.ToString(r["email"]));

                    }
                }
            }
            return addresses_a;

        }

    }
}
