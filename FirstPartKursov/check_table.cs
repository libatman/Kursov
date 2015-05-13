using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using Excel = Microsoft.Office.Interop.Excel;
using System.Threading.Tasks;
namespace FirstPartKursov
{
    class Check_table
    {
        public void sell_goods()
        {
            List<string> addresses_a = new List<string>();
            using (SQLiteConnection connect = new SQLiteConnection(@"Data Source=bd_kursov.sqlite;Version=3;New=False;Compress=True;"))
            {
                connect.Open();
                using (SQLiteCommand fmd = connect.CreateCommand())
                {
                    fmd.CommandText = @"SELECT name_goods, Sum(amount FROM selling where id_goods=(select id_goods from goods where name_goods=name_goods) FROM goods GROUP BY Sum;";
                    fmd.CommandType = CommandType.Text;
                    SQLiteDataReader r = fmd.ExecuteReader();
                    while (r.Read())
                    {
                        addresses_a.Add(Convert.ToString(r["address"]) + "|" + Convert.ToString(r["email"]));
                    }
                }
            }

        }
        public string[,] array_sell_excel()
        {
            //D:\универ\hello\Новая папка\Kursov\FirstPartKursov\bin\Debug\

            Excel.Application ObjWorkExcel = new Excel.Application();
            // Напиши свой путь на файл, что лежит в папке проекта :)
            Excel.Workbook ObjWorkBook = ObjWorkExcel.Workbooks.Open(@"C:\Users\Елизавета\Documents\Visual Studio 2013\Projects\FirstPartKursov\FirstPartKursov\a1.xlsx", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            Excel.Worksheet ObjWorkSheet = (Excel.Worksheet)ObjWorkBook.Sheets[1];
            var lastCell = ObjWorkSheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell);
            string[,] list = new string[lastCell.Column, lastCell.Row];
            for (int i = 0; i < lastCell.Column; i++)
                for (int j = 0; j < lastCell.Row; j++)
                    list[i, j] = ObjWorkSheet.Cells[j + 1, i + 1].Text.ToString();
            ObjWorkBook.Close(false, Type.Missing, Type.Missing);
            ObjWorkExcel.Quit();
            GC.Collect();
            return list;
        }
        public void read_selling()
        {
            //Encoding enc = Encoding.GetEncoding(1251);
            //string[] array_selling = File.ReadAllLines(@"sell.txt",enc);
            string[,] array_selling = array_sell_excel();
            var id_storage=0;
            for (int i = 0; i < array_selling.GetLength(1); i++)
            {
                //string[] array_selling_string = i.Split(' ');               
                using (SQLiteConnection connect = new SQLiteConnection(@"Data Source=bd_kursov.sqlite;Version=3;New=False;Compress=True;"))
                {
                    connect.Open();
                    using (SQLiteCommand fmd = connect.CreateCommand())
                    {
                        fmd.CommandText = @"SELECT id_storage FROM storage WHERE id_goods =" + array_selling[5, i].ToString() + " and id_office=(SELECT id_office FROM manager WHERE id_manager=" + array_selling[6, i].ToString() + ");";
                        fmd.CommandType = CommandType.Text;
                        SQLiteDataReader r = fmd.ExecuteReader();

                        id_storage = Convert.ToInt32((r["id_storage"] is DBNull) ? null : r["id_storage"]);
                    }


                    if (count_goods(array_selling[5, i].ToString(), id_storage.ToString()) >= Convert.ToInt32(array_selling[1, i]))
                    {
                        SQLiteCommand sc;
                        sc = connect.CreateCommand();
                        sc.CommandText = "INSERT INTO 'selling'('date','amount','sum_of_sale','comment','number_of_disk','id_goods','id_manager') VALUES ('" + array_selling[0, i] + "' , " + array_selling[1, i] + " , " + array_selling[2, i].ToString() + " , '" + array_selling[3, i] + "' , " + array_selling[4, i] + " , " + array_selling[5, i] + " , " + array_selling[6, i] + ");";
                        sc.ExecuteNonQuery();
                        if (count_goods(array_selling[5, i].ToString(), id_storage.ToString()) == 0)
                        {
                            ordering_or_redistribution(array_selling[5, i].ToString(), id_storage.ToString(), connect);
                        }
                    }
                }


            }
        }
        public int count_goods(string id_goods, string id_storage)
        {

            using (SQLiteConnection connect = new SQLiteConnection(@"Data Source=bd_kursov.sqlite;Version=3;New=False;Compress=True;"))
            {
                connect.Open();
                var amount = 0;
                using (SQLiteCommand fmd = connect.CreateCommand())
                {
                    fmd.CommandText = @"SELECT amount_goods FROM storage WHERE id_goods=" + id_goods.ToString() + " and id_storage=" + id_storage.ToString() + ";";
                    fmd.CommandType = CommandType.Text;
                    SQLiteDataReader r = fmd.ExecuteReader();
                    amount = Convert.ToInt32((r["amount_goods"] is DBNull) ? null : r["amount_goods"]);
                    //amount = Convert.ToInt32(r["amount_goods"]);
                    return amount;
                }
            }

        }
        public void ordering_or_redistribution(string id_goods, string id_storage, SQLiteConnection connect)
        {
            if (count_goods(id_goods, id_storage) == 0)
            {
                var id_storage_donor = 0;

                using (SQLiteCommand fmd = connect.CreateCommand())
                {
                    fmd.CommandText = @"SELECT id_storage FROM storage WHERE id_goods =" + id_goods.ToString() + " and amount_goods=(SELECT MAX(amount_goods) FROM storage);";
                    fmd.CommandType = CommandType.Text;
                    SQLiteDataReader r = fmd.ExecuteReader();
                    id_storage_donor = Convert.ToInt32((r["id_storage"] is DBNull) ? null : r["id_storage"]);
                    //id_storage_donor= Convert.ToInt32(r["id_storage"]);

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
                    sc.CommandText = "INSERT INTO 'ordering_goods' ( 'amount_goods','id_goods','id_provider','id_storage_in') VALUES (15," + id_goods.ToString() + "," + id_provider.ToString() + "," + id_storage + ");";
                    sc.ExecuteNonQuery();
                }


            }
        }
    }
}
