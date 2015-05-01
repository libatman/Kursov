using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
//using Excel = Microsoft.Office.Interop.Excel;
//using System.Threading.Tasks;
namespace FirstPartKursov
{
    class check_table
    {
        public void read_selling()
        {
            Encoding enc = Encoding.GetEncoding(1251);
            string[] array_selling = File.ReadAllLines(@"sell.txt",enc);
            int id_storage;
            foreach(string i in array_selling)
            {
                string[] array_selling_string = i.Split(' ');

                using (SQLiteConnection connect = new SQLiteConnection(@"Data Source=bd_kursov.sqlite;Version=3;New=False;Compress=True;"))
                {
                    connect.Open();
                    using (SQLiteCommand fmd = connect.CreateCommand())
                    {
                        fmd.CommandText = @"SELECT id_office FROM manager WHERE id_manager=" + array_selling_string[6].ToString() + ";";
                        fmd.CommandType = CommandType.Text;
                        SQLiteDataReader r = fmd.ExecuteReader();

                        id_storage = Convert.ToInt32(r["id_office"]);
                    }


                    if (count_goods(array_selling_string[5], id_storage.ToString()) >= Convert.ToInt32(array_selling_string[1]))
                    {
                        SQLiteCommand sc;
                        sc = connect.CreateCommand();
                        sc.CommandText = "INSERT INTO 'selling'('date','amount','sum_of_sale','comment','number_of_disk','id_goods','id_manager') VALUES ('" + array_selling_string[0] + "' , " + array_selling_string[1] + " , " + array_selling_string[2].ToString() + " , '" + array_selling_string[3] + "' , " + array_selling_string[4] + " , " + array_selling_string[5] + " , " + array_selling_string[6] + ");";
                        sc.ExecuteNonQuery();
                    }
                    else
                    {
                        ordering_or_redistribution( array_selling_string[5], id_storage.ToString(), connect);
                    }
                }


            }
        }
        public int count_goods(string id_goods, string id_storage)
        {

            using (SQLiteConnection connect = new SQLiteConnection(@"Data Source=bd_kursov.sqlite;Version=3;New=False;Compress=True;"))
            {
                connect.Open();
                int amount;
                using (SQLiteCommand fmd = connect.CreateCommand())
                {
                    fmd.CommandText = @"SELECT amount_goods FROM storage WHERE id_goods=" + id_goods.ToString() + " and id_office=" + id_storage.ToString() + ";";
                    fmd.CommandType = CommandType.Text;
                    SQLiteDataReader r = fmd.ExecuteReader();

                    amount = Convert.ToInt32(r["amount_goods"]);
                    return amount;
                }
            }

        }
        public void ordering_or_redistribution(string id_goods, string id_storage, SQLiteConnection connect)
        {
            if (count_goods(id_goods, id_storage) == 0)
            {
                int id_storage_donor;
            
                    using (SQLiteCommand fmd = connect.CreateCommand())
                    {
                        fmd.CommandText = @"SELECT id_office FROM storage WHERE id_goods =" + id_goods.ToString() + " and amount_goods=(SELECT MAX(amount_goods) FROM storage);";
                        fmd.CommandType = CommandType.Text;
                        SQLiteDataReader r = fmd.ExecuteReader();

                        id_storage_donor= Convert.ToInt32(r["id_office"]);

                    }

                    if (count_goods(id_goods, id_storage_donor.ToString()) > 1)
                    {
                        SQLiteCommand sc;
                        sc = connect.CreateCommand();
                        sc.CommandText = "INSERT INTO 'redistribution_goods' ( 'amount_goods','id_goods','id_storage_old','id_storage_new') VALUES (1,1," + id_storage_donor.ToString() + "," + id_storage.ToString() + ");";
                        sc.ExecuteNonQuery();

                        // вызов функций печати документов распределения.
                    }
                    else if (count_goods(id_goods, id_storage_donor.ToString()) < 2)
                    {
                        int id_provider;
                        using (SQLiteCommand fmd = connect.CreateCommand())
                        {
                            fmd.CommandText = @"SELECT id_provider FROM goods WHERE id_goods =" + id_goods.ToString() + ";";
                            fmd.CommandType = CommandType.Text;
                            SQLiteDataReader r = fmd.ExecuteReader();

                            id_provider = Convert.ToInt32(r["id_provider"]);

                        }

                        //вызов функции печати  документа  о заказе товара
                        SQLiteCommand sc;
                        sc = connect.CreateCommand();
                        sc.CommandText = "INSERT INTO 'ordering_goods' ( 'amount_goods','id_goods','id_provider','id_storage_in') VALUES (15,"+id_goods.ToString() +","+id_provider.ToString() +","+ id_storage +");";
                        sc.ExecuteNonQuery();
                    }
               

            }
        }
    }
}
