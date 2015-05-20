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
        CreateDocument doc_new = new CreateDocument();
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
        public string[,] array_sell_excel(string file_name)
        {

            Excel.Application ObjWorkExcel = new Excel.Application();
            Excel.Workbook ObjWorkBook = ObjWorkExcel.Workbooks.Open(System.Windows.Forms.Application.StartupPath + @"\Отчеты о продажах\" + file_name, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
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
        public void read_selling(string file_name)
        {

            string[,] array_selling = array_sell_excel(file_name);
            var id_storage = 0;
            for (int i = 0; i < array_selling.GetLength(1); i++)
            {
                using (SQLiteConnection connect = new SQLiteConnection(@"Data Source=bd_kursov.sqlite;Version=3;New=False;Compress=True;"))
                {
                    connect.Open();
                    using (SQLiteCommand fmd = connect.CreateCommand())
                    {
                        fmd.CommandText = @"SELECT id_storage FROM storage WHERE id_goods =" + array_selling[7, i].ToString() + " and id_office=(SELECT id_office FROM manager WHERE id_manager=" + array_selling[8, i].ToString() + ");";
                        fmd.CommandType = CommandType.Text;
                        SQLiteDataReader r = fmd.ExecuteReader();

                        id_storage = Convert.ToInt32((r["id_storage"] is DBNull) ? null : r["id_storage"]);
                    }


                    if (count_goods(array_selling[7, i].ToString(), id_storage.ToString()) >= Convert.ToInt32(array_selling[3, i]))
                    {
                        SQLiteCommand sc;
                        sc = connect.CreateCommand();
                        sc.CommandText = "INSERT INTO 'selling'('day','month','year','amount','sum_of_sale','comment','number_of_disk','id_goods','id_manager') VALUES (" + array_selling[0, i].ToString() + " , '" + array_selling[1, i].ToString() + "' , " + array_selling[2, i].ToString() + " , " + array_selling[3, i].ToString() + " , " + array_selling[4, i].ToString() + " , '" + array_selling[5, i].ToString() + "' , " + array_selling[6, i].ToString() + " , " + array_selling[7, i].ToString() + " , " + array_selling[8, i].ToString() + ");";
                        sc.ExecuteNonQuery();
                        if (count_goods(array_selling[7, i].ToString(), id_storage.ToString()) == 0)
                        {
                            ordering_or_redistribution(array_selling[7, i].ToString(), id_storage.ToString(), connect);
                        }
                    }
                }


            }

            ClassForms.sf.label1.Text += Environment.NewLine + "База данных обновлена. Добавлены данные о продажах.";
            ClassForms.sf.label1.Refresh();
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
                string name_goods1;
                string email_out;
                string email_in;
                string currency;
                string price1;

                using (SQLiteCommand fmd = connect.CreateCommand())
                {
                    fmd.CommandText = @"SELECT id_storage, name_goods, price, currency FROM storage,goods WHERE storage.id_goods =" + id_goods.ToString() + " and amount_goods=(SELECT MAX(amount_goods) FROM storage);";
                    fmd.CommandType = CommandType.Text;
                    SQLiteDataReader r = fmd.ExecuteReader();
                    id_storage_donor = Convert.ToInt32((r["id_storage"] is DBNull) ? null : r["id_storage"]);
                    //id_storage_donor= Convert.ToInt32(r["id_storage"]);
                    name_goods1 = r["name_goods"].ToString();
                    price1 = r["price"].ToString();
                    currency = r["currency"].ToString();
                    r.Close();

                    fmd.CommandText = @"SELECT email from office where id_office=( select id_office from storage where id_storage=" + id_storage.ToString() + ");";
                    fmd.CommandType = CommandType.Text;
                    SQLiteDataReader r1 = fmd.ExecuteReader();
                    email_in = r1["email"].ToString();
                    r1.Close();

                    fmd.CommandText = @"SELECT email from office where id_office=( select id_office from storage where id_storage=" + id_storage_donor.ToString() + ");";
                    fmd.CommandType = CommandType.Text;
                    SQLiteDataReader r2 = fmd.ExecuteReader();
                    email_out = r2["email"].ToString();

                }

                if (count_goods(id_goods, id_storage_donor.ToString()) > 5)
                {
                    SQLiteCommand sc;
                    sc = connect.CreateCommand();
                    sc.CommandText = "INSERT INTO 'redistribution_goods' ( 'amount_goods','id_goods','id_storage_old','id_storage_new') VALUES (1,1," + id_storage_donor.ToString() + "," + id_storage.ToString() + ");";
                    sc.ExecuteNonQuery();

                    // вызов функций печати документов распределения.
                    List<string> goods = new List<string>();
                    goods.Add(name_goods1.ToString() + "|шт|" + "3" + "|" + currency.ToString() + "|" + price1.ToString());
                    doc_new.createDocument_Command(goods, email_out, email_in);
                    doc_new.createDocument_Invoice(goods, id_storage_donor);
                }
                else if (count_goods(id_goods, id_storage_donor.ToString()) < 2)
                {
                    int id_provider;
                    string name_goods;
                    string price;
                    string amount_goods;
                    string currency_goods;
                    string email_provider;
                    string name_provider;
                    using (SQLiteCommand fmd = connect.CreateCommand())
                    {
                        fmd.CommandText = @"SELECT id_provider, name_goods, price,currency FROM goods WHERE id_goods =" + id_goods.ToString() + ";";
                        fmd.CommandType = CommandType.Text;
                        SQLiteDataReader r = fmd.ExecuteReader();

                        id_provider = Convert.ToInt32(r["id_provider"]);
                        name_goods = r["name_goods"].ToString();
                        price = r["price"].ToString();
                        currency_goods = r["currency"].ToString();
                        r.Close();

                        fmd.CommandText = @"SELECT email_provider, name_provider FROM provider WHERE id_provider =" + id_provider.ToString() + ";";
                        fmd.CommandType = CommandType.Text;
                        SQLiteDataReader r1 = fmd.ExecuteReader();
                        email_provider = r1["email_provider"].ToString();
                        name_provider = r1["name_provider"].ToString();

                    }

                    //вызов функции печати  документа  о заказе товара
                    SQLiteCommand sc;
                    sc = connect.CreateCommand();
                    sc.CommandText = "INSERT INTO 'ordering_goods' ( 'amount_goods','id_goods','id_provider','id_storage_in') VALUES (15," + id_goods.ToString() + "," + id_provider.ToString() + "," + id_storage + ");";
                    sc.ExecuteNonQuery();
                    List<string> goods = new List<string>();
                    goods.Add(name_goods + "|" + currency_goods + "|" + price);
                    doc_new.createDocument_order(goods, email_provider, name_provider);
                }


            }
        }
    }
}
