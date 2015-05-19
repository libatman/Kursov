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
    class Excel_document
    {
        public List<string> sell_goods()
        {
            List<string> goods_count = new List<string>();
            using (SQLiteConnection connect = new SQLiteConnection(@"Data Source=bd_kursov.sqlite;Version=3;New=False;Compress=True;"))
            {
                connect.Open();
                using (SQLiteCommand fmd = connect.CreateCommand())
                {
                    fmd.CommandText = @"SELECT goods.name_goods, 
                                       SUM(selling.amount)  as s
                                       FROM goods 
                                       JOIN selling 
                                       ON selling.id_goods = goods.id_goods
                                       GROUP BY goods.name_goods";
                    
                    fmd.CommandType = CommandType.Text;
                    SQLiteDataReader r = fmd.ExecuteReader();
                    while (r.Read())
                    {
                        goods_count.Add(Convert.ToString(r["name_goods"]) + "|" + Convert.ToString(r["s"]));
                    }
                }
            }
            return goods_count;

        }

        public List<string> popular_providers()
        {
            List<string> popular_p = new List<string>();
            using (SQLiteConnection connect = new SQLiteConnection(@"Data Source=bd_kursov.sqlite;Version=3;New=False;Compress=True;"))
            {
                connect.Open();
                using (SQLiteCommand fmd = connect.CreateCommand())
                {
                    // на всякий случай: популярность поставщиков: наименование число продаж их товаров

                    //                    fmd.CommandText = @"SELECT  provider.id_provider as ip,provider.name_provider as pp, 
                    //                                      COUNT(selling.id_selling)  as s
                    //                                      FROM provider, selling
                    //                                      WHERE selling.id_goods =(SELECT goods.id_goods FROM goods
                    //                                      where goods.id_provider=ip)
                    //                                      GROUP BY provider.name_provider";
                    // наименование + кол-во заказов у него
                    fmd.CommandText = @"SELECT provider.name_provider as np, 
                                      COUNT(ordering_goods.id_ordering)  as s
                                      FROM provider
                                      JOIN ordering_goods on ordering_goods.id_provider=provider.id_provider
                                      GROUP BY provider.name_provider;";

                    fmd.CommandType = CommandType.Text;
                    SQLiteDataReader r = fmd.ExecuteReader();
                    while (r.Read())
                    {
                        popular_p.Add(Convert.ToString(r["np"]) + "|" + Convert.ToString(r["s"]));
                    }
                }
            }
            return popular_p;

        }

        public List<string> sell_offices()
        {
            List<string> offices = new List<string>();
            using (SQLiteConnection connect = new SQLiteConnection(@"Data Source=bd_kursov.sqlite;Version=3;New=False;Compress=True;"))
            {
                connect.Open();
                using (SQLiteCommand fmd = connect.CreateCommand())
                {
//                    fmd.CommandText = @"SELECT  o.id_office as io, o.address as ss, 
//                                       COUNT(selling.id_selling)  as s
//                                       FROM office as o
//                                       JOIN selling 
//                                       ON selling.id_manager = (select manager.id_manager from manager where manager.id_office=io)
//                                       GROUP BY o.address";
                    fmd.CommandText = @"SELECT o.id_office, o.address as os, COUNT(s.id_selling) as ss
                                        FROM office AS o 
                                        LEFT JOIN manager AS m
                                        ON m.id_office = o.id_office
                                        LEFT JOIN selling AS s
                                        ON s.id_manager = m.id_manager 
                                        GROUP BY o.id_office, o.address";

                    fmd.CommandType = CommandType.Text;
                    SQLiteDataReader r = fmd.ExecuteReader();
                    while (r.Read())
                    {
                        offices.Add(Convert.ToString(r["os"]) + "|" + Convert.ToString(r["ss"]));
                    }
                }
            }

            return offices;
        }

        public List<string> result_manager()
        {
            List<string> result = new List<string>();
            using (SQLiteConnection connect = new SQLiteConnection(@"Data Source=bd_kursov.sqlite;Version=3;New=False;Compress=True;"))
            {
                connect.Open();
                using (SQLiteCommand fmd = connect.CreateCommand())
                {
                    // имя менеджера и кол-во осуществленных им продаж
                    fmd.CommandText = @"SELECT m.FIO as name, m.id_manager as id, COUNT(selling.id_selling) as ss
                                        FROM manager AS m 
                                        JOIN selling 
                                        ON selling.id_manager = id                                       
                                        GROUP BY m.FIO";

                    fmd.CommandType = CommandType.Text;
                    SQLiteDataReader r = fmd.ExecuteReader();
                    while (r.Read())
                    {
                        result.Add(Convert.ToString(r["name"]) + "|" + Convert.ToString(r["ss"]));
                    }
                }
            }

            return result;
        }

        public List<string> sell_disks()
        {
            List<string> disk = new List<string>();
            using (SQLiteConnection connect = new SQLiteConnection(@"Data Source=bd_kursov.sqlite;Version=3;New=False;Compress=True;"))
            {
                connect.Open();
                using (SQLiteCommand fmd = connect.CreateCommand())
                {
                    // месяцы и проданные диски за эти месяцы
                    fmd.CommandText = @"SELECT s.month as m,SUM(s.number_of_disk) as ss
                                        FROM selling AS s                         
                                        GROUP BY s.month";

                    fmd.CommandType = CommandType.Text;
                    SQLiteDataReader r = fmd.ExecuteReader();
                    while (r.Read())
                    {
                        disk.Add(Convert.ToString(r["m"]) + "|" + Convert.ToString(r["ss"]));
                    }
                }
            }

            return disk;
        }

         public void set_table_excel(List<string> list, string name_col1, string name_col2,string path,string otchet)
        {
           Excel.Application ObjExcel = new Microsoft.Office.Interop.Excel.Application();
           Excel.Workbook ObjWorkBook;
           Excel.Worksheet ObjWorkSheet;
            //Книга.
            ObjWorkBook = ObjExcel.Workbooks.Add(Type.Missing);
            //Таблица.
            ObjWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)ObjWorkBook.Worksheets[1];
            ObjWorkSheet.Cells.ColumnWidth = 30;
            ObjWorkSheet.Cells[1, 1] = name_col1;           
            ObjWorkSheet.Cells[1, 2] = name_col2;
            int j = 2;
            foreach( string i in list)
            {
               string[] row= i.Split('|');
               ObjWorkSheet.Cells[j, 1] = row[0];
               ObjWorkSheet.Cells[j, 2] = row[1];
               j++;
            }
            int len = list.Count()+1;
            Excel.Range chartRange;
            Excel.ChartObjects xlCharts = (Excel.ChartObjects)ObjWorkSheet.ChartObjects(Type.Missing);
            Excel.ChartObject myChart = (Excel.ChartObject)xlCharts.Add(10, 80, 300, 250);
            Excel.Chart chartPage = myChart.Chart;

            chartRange = ObjWorkSheet.get_Range("A1", "B"+len.ToString());
            chartPage.SetSourceData(chartRange, System.Reflection.Missing.Value);
            chartPage.ChartType = Excel.XlChartType.xlLineMarkers;

            //xlColumnClustered;

            chartPage.Export(ClassForms.sf.filePath.filepathUser + @"Отчеты\otchet_" + otchet + "_" + DateTime.Now.ToShortDateString() + ".bmp", "BMP", System.Reflection.Missing.Value);
 

            ObjWorkBook.SaveAs(path);
            ObjExcel.Quit();


        }

        
    }


     
    }

