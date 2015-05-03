﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;

namespace FirstPartKursov
{
    class Create_bd
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
            sc.CommandText = "create table office(id_office INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, address TEXT NOT NULL, email TEXT NOT NULL)";
            sc.ExecuteNonQuery();
            sc = sql.CreateCommand();
            sc.CommandText = "create table manager(id_manager INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, FIO TEXT NOT NULL, id_office INTEGER NOT NULL, FOREIGN KEY(id_office) REFERENCES office (id_office))";
            sc.ExecuteNonQuery();
            sc = sql.CreateCommand();
            sc.CommandText = "create table provider(id_provider INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, name_provider TEXT NOT NULL, email_provider TEXT NOT NULL)";
            sc.ExecuteNonQuery();
            sc = sql.CreateCommand();
            sc.CommandText = "create table goods(id_goods INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, name_goods TEXT NOT NULL, currency TEXT NOT NULL, price INTEGER NOT NULL,id_provider INTEGER NOT NULL, FOREIGN KEY(id_provider) REFERENCES provider (id_provider))";
            sc.ExecuteNonQuery();
            sc = sql.CreateCommand();
            sc.CommandText = "create table storage(id_storage INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,id_office INTEGER NOT NULL,id_goods INTEGER NOT NULL, amount_goods INTEGER NOT NULL, FOREIGN KEY(id_office) REFERENCES office (id_office),FOREIGN KEY(id_goods) REFERENCES goods (id_goods))";
            sc.ExecuteNonQuery();
            sc = sql.CreateCommand();
            sc.CommandText = "create table ordering_goods(id_ordering INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, amount_goods INTEGER NOT NULL,id_storage_in INTEGER NOT NULL, id_goods INTEGER NOT NULL,id_provider INTEGER NOT NULL, FOREIGN KEY(id_goods) REFERENCES goods (id_goods),FOREIGN KEY(id_provider) REFERENCES provider (id_provider))";
            sc.ExecuteNonQuery();
            sc = sql.CreateCommand();
            sc.CommandText = "create table redistribution_goods(id_redistribution INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, amount_goods INTEGER NOT NULL, id_goods INTEGER NOT NULL,id_storage_old INTEGER NOT NULL,id_storage_new INTEGER NOT NULL, FOREIGN KEY(id_goods) REFERENCES goods (id_goods),FOREIGN KEY(id_storage_old) REFERENCES storage(id_office),FOREIGN KEY(id_storage_new) REFERENCES storage(id_office))";
            sc.ExecuteNonQuery();
            sc = sql.CreateCommand();
            sc.CommandText = "create table selling(id_selling INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, date TEXT NOT NULL,amount INTEGER NOT NULL,sum_of_sale INTEGER NOT NULL,comment TEXT ,number_of_disk INTEGER NOT NULL, id_goods INTEGER NOT NULL,id_manager INTEGER NOT NULL, FOREIGN KEY(id_goods) REFERENCES goods(id_goods),FOREIGN KEY(id_manager) REFERENCES manager(id_manager))";
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
            sc.CommandText = "INSERT INTO 'office' ( 'address','email') VALUES ( 'филатова4','anastasySher222@bk.ru');";
            sc.ExecuteNonQuery();
            sc = sql.CreateCommand();
            sc.CommandText = "INSERT INTO 'office' ( 'address','email') VALUES ('филатова6','anastasySher222@bk.ru');";
            sc.ExecuteNonQuery();
            sc = sql.CreateCommand();
            sc.CommandText = "INSERT INTO 'office' ( 'address','email') VALUES ( 'филатова9','nikolaiuhvarov@mail.ru');";
            sc.ExecuteNonQuery();
            sc = sql.CreateCommand();
            sc.CommandText = "INSERT INTO 'manager' ( 'FIO','id_office') VALUES ( 'Щербакова', 1);";
            sc.ExecuteNonQuery();
            sc.CommandText = "INSERT INTO 'manager' ( 'FIO','id_office') VALUES ( 'Семёнова', 2);";
            sc.ExecuteNonQuery();
            sc = sql.CreateCommand();
            sc.CommandText = "INSERT INTO 'provider' ( 'name_provider','email_provider') VALUES ( 'Hohner','anastasySher222@mail.ru');";
            sc.ExecuteNonQuery();
            sc = sql.CreateCommand();
            sc.CommandText = "INSERT INTO 'provider' ( 'name_provider','email_provider') VALUES ( 'Lisa','liza.deer@yandex.ru');";
            sc.ExecuteNonQuery();
            sc = sql.CreateCommand();
            sc.CommandText = "insert into 'goods' ( 'name_goods','currency','price','id_provider') values ( 'гитара','rub',4999,1);";
            sc.ExecuteNonQuery();
            sc = sql.CreateCommand();
            sc.CommandText = "insert into 'goods' ( 'name_goods','currency','price','id_provider') values ( 'Саксофон','rub',10999,2);";
            sc.ExecuteNonQuery();
            sc = sql.CreateCommand();
            sc.CommandText = "insert into 'goods' ( 'name_goods','currency','price','id_provider') values ( 'Барабан','usd',100,2);";
            sc.ExecuteNonQuery();
            sc = sql.CreateCommand();
            sc.CommandText = "INSERT INTO 'storage' ('id_office', 'id_goods','amount_goods') VALUES (1, 3,21);";
            sc.ExecuteNonQuery();
            sc = sql.CreateCommand();
            sc.CommandText = "INSERT INTO 'storage' ('id_office', 'id_goods','amount_goods') VALUES (2, 2,80);";
            sc.ExecuteNonQuery();
            sc = sql.CreateCommand();
            sc.CommandText = "INSERT INTO 'storage' ('id_office', 'id_goods','amount_goods') VALUES (3, 1,31);";
            sc.ExecuteNonQuery();
            sc = sql.CreateCommand();
            sc.CommandText = "INSERT INTO 'storage' ('id_office', 'id_goods','amount_goods') VALUES (3, 2,38);";
            sc.ExecuteNonQuery();
            sc = sql.CreateCommand();
            //sc.CommandText = "INSERT INTO 'ordering_goods' ( 'amount_goods','id_goods','id_provider') VALUES (15,1,1);";
            //sc.ExecuteNonQuery();
            //sc = sql.CreateCommand();
           //
            //sc = sql.CreateCommand();
            //sc.CommandText = "INSERT INTO 'selling' ('date','amount','sum_of_sale','comment','number_of_disk','id_goods','id_manager') VALUES ('22/02/15',1,4999,'скидки нет',1,1,1);";
            //sc.ExecuteNonQuery();
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


        public void triggers()
        {
            SetConnection();
            sql.Open();
            sc = sql.CreateCommand();
            //триггер редактирует кол-во товара на складе storage при добавлении записи о продаже товара в таблице selling
            sc.CommandText = "CREATE TRIGGER sale_good BEFORE INSERT ON selling BEGIN UPDATE storage SET amount_goods = amount_goods-new.amount WHERE id_goods=new.id_goods and id_office=(SELECT id_office from manager where new.id_manager=id_manager); END;";
            sc.ExecuteNonQuery();
            // триггер редактирует кол-во товара на складе при перераспределении какого-либо товара в таблице redistribution_goods
            sc.CommandText = "CREATE TRIGGER redistribution BEFORE INSERT ON redistribution_goods BEGIN UPDATE storage SET amount_goods = amount_goods+new.amount_goods WHERE id_goods=new.id_goods and id_storage=new.id_storage_new; UPDATE storage SET amount_goods = amount_goods-new.amount_goods WHERE id_goods=new.id_goods and id_storage=new.id_storage_old; END;";
            sc.ExecuteNonQuery();

            // триггер редактирует кол-во товара на складе при заказе какого-либо товара в таблице ordering_goods
            sc.CommandText = "CREATE TRIGGER ordering BEFORE INSERT ON ordering_goods BEGIN UPDATE storage SET amount_goods = amount_goods+new.amount_goods WHERE id_goods=new.id_goods and id_office=new.id_storage_in; END;";
            sc.ExecuteNonQuery();


        }

        public List<string> addresses_providers()
        {
            List<string> addresses_p = new List<string>();
            using (SQLiteConnection connect = new SQLiteConnection(@"Data Source=bd_kursov.sqlite;Version=3;New=False;Compress=True;"))
            {
                connect.Open();
                using (SQLiteCommand fmd = connect.CreateCommand())
                {
                    fmd.CommandText = @"SELECT name_provider, email_provider FROM provider";
                    fmd.CommandType = CommandType.Text;
                    SQLiteDataReader r = fmd.ExecuteReader();
                    while (r.Read())
                    {
                        addresses_p.Add(Convert.ToString(r["name_provider"]) + "|" + Convert.ToString(r["email_provider"]));

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
                    fmd.CommandText = @"SELECT address, email FROM office";
                    fmd.CommandType = CommandType.Text;
                    SQLiteDataReader r = fmd.ExecuteReader();
                    while (r.Read())
                    {
                        addresses_a.Add(Convert.ToString(r["address"]) + "|" + Convert.ToString(r["email"]));

                    }
                }
            }
            return addresses_a;

        }

        public List<string> goods(int id_pro)
        {
            List<string> goods = new List<string>();
            using (SQLiteConnection connect = new SQLiteConnection(@"Data Source=bd_kursov.sqlite;Version=3;New=False;Compress=True;"))
            {
                connect.Open();
                //id_goods, name_goods, surrency , price, id_provider
                using (SQLiteCommand fmd = connect.CreateCommand())
                {
                    fmd.CommandText = @"SELECT name_goods, currency, price FROM goods WHERE id_provider="+ id_pro + ";";
                    fmd.CommandType = CommandType.Text;
                    SQLiteDataReader r = fmd.ExecuteReader();
                    while (r.Read())
                    {
                        goods.Add(Convert.ToString(r["name_goods"]) + "|" + Convert.ToString(r["currency"])  + "|" + Convert.ToString(r["price"]));
                    }
                }
            }
            return goods;

        }

        public List<string> goods_storage(int id_off)
        {
            List<string> goods = new List<string>();
            int id_goods_sp = 0; int amount_goods_sp=0;
            
            using (SQLiteConnection connect = new SQLiteConnection(@"Data Source=bd_kursov.sqlite;Version=3;New=False;Compress=True;"))
            {
                connect.Open();
                //id_office', 'id_goods','amount_goods
                using (SQLiteCommand fmd = connect.CreateCommand())
                {
                    fmd.CommandText = @"SELECT id_goods, amount_goods FROM storage WHERE id_office="+id_off+";";
                    fmd.CommandType = CommandType.Text;
                    SQLiteDataReader r = fmd.ExecuteReader();
                    while (r.Read())
                    {
                        id_goods_sp = Convert.ToInt32(r["id_goods"]);
                        amount_goods_sp = Convert.ToInt32(r["amount_goods"]);
                        using (SQLiteConnection connect2 = new SQLiteConnection(@"Data Source=bd_kursov.sqlite;Version=3;New=False;Compress=True;"))
                        {
                            connect2.Open();
                            //id_office', 'id_goods','amount_goods
                            using (SQLiteCommand fmd2 = connect.CreateCommand())
                            {
                                fmd2.CommandText = @"SELECT name_goods, currency, price FROM goods WHERE id_goods=" + id_goods_sp + ";";
                                fmd2.CommandType = CommandType.Text;
                                SQLiteDataReader r2 = fmd2.ExecuteReader();
                                while (r2.Read())
                                {
                                    goods.Add(Convert.ToString(r2["name_goods"]) + "|" + "шт" + "|" + Convert.ToString(amount_goods_sp) + "|" + Convert.ToString(r2["currency"]) + "|" + Convert.ToString(r2["price"]));
                                }
                            }
                        }
                       
                    }
                }
            }
            

            
            return goods;

        }



    }
}
