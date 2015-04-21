using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
namespace FirstPartKursov
{
    class check_table
    {
        public void read_selling()
        {

        }
        public int count_goods(int id_goods, int id_storage)
        {

            using (SQLiteConnection connect = new SQLiteConnection(@"Data Source=bd_kursov.sqlite;Version=3;New=False;Compress=True;"))
            {
                connect.Open();
                using (SQLiteCommand fmd = connect.CreateCommand())
                {
                    fmd.CommandText = @"SELECT amount_goods FROM storage WHERE id_goods=" + id_goods.ToString() + " and id_office=" + id_storage + ";";
                    fmd.CommandType = CommandType.Text;
                    SQLiteDataReader r = fmd.ExecuteReader();

                    return Convert.ToInt32(r["amount_goods"]);
                }
            }

        }
        public void ordering_or_redistribution(int id_goods, int id_storage)
        {
            if (count_goods(id_goods, id_storage) == 0)
            {
                int id_storage_donors;
                using (SQLiteConnection connect = new SQLiteConnection(@"Data Source=bd_kursov.sqlite;Version=3;New=False;Compress=True;"))
                {
                    connect.Open();
                    using (SQLiteCommand fmd = connect.CreateCommand())
                    {
                        fmd.CommandText = @"SELECT id_office FROM storage WHERE id_goods =" + id_goods.ToString() + " and amount_goods=(SELECT MAX(amount_goods) FROM storage);";
                        fmd.CommandType = CommandType.Text;
                        SQLiteDataReader r = fmd.ExecuteReader();

                        id_storage_donors = Convert.ToInt32(r["id_office"]);

                    }
                }
                if (id_storage_donors > 1)
                {
                    SQLiteConnection sql = new SQLiteConnection(@"Data Source=bd_kursov.sqlite;Version=3;New=False;Compress=True;");
                    sql.Open();
                    SQLiteCommand sc;
                    sc = sql.CreateCommand();
                    sc.CommandText = "INSERT INTO 'redistribution_goods' ('id_redistribution', 'amount_goods','id_goods','id_storage_old','id_storage_new') VALUES (1,1,1," + id_storage_donors + "," + id_storage + ");";
                    sc.ExecuteNonQuery();
                    // вызов функций печати документов распределения.
                }
                else if (id_storage_donors < 2)
                {

                    //вызов функци заказа
                }

            }
        }
    }
}
