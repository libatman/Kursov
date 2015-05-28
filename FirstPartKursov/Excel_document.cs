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
        /// <summary>
        /// Этот метод вычисляет продаваемость товаров.
        /// </summary>
        /// <returns> список товаров и количество их продаж</returns>
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
        /// <summary>
        /// Этот метод вычисляет популярность поставщиков.
        /// </summary>
        /// <returns>сисок поставщиков и количество заказов у каждого из них</returns>
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
                                      LEFT JOIN ordering_goods on ordering_goods.id_provider=provider.id_provider
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
        /// <summary>
        /// Это метод вычисляет продаваемость по офисам.
        /// </summary>
        /// <returns>Список филиалов и количество продаж в каждом из них.</returns>
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
        /// <summary>
        /// Это метод вычисляет результативность менеджеров.
        /// </summary>
        /// <returns>Список менеджеров и количество продаж , осуществленных каждым из них.</returns>
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
                                        LEFT JOIN selling 
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
        /// <summary>
        /// Этот метод вычисляет продаваемость дисков по месяцам.
        /// </summary>
        /// <returns>Список месяцев и количество продаж жисков в каждый из них. </returns>
        public List<string> sell_disks()
        {
            List<string> disk = new List<string>();
            using (SQLiteConnection connect = new SQLiteConnection(@"Data Source=bd_kursov.sqlite;Version=3;New=False;Compress=True;"))
            {
                connect.Open();
                using (SQLiteCommand fmd = connect.CreateCommand())
                {
                    // месяцы и проданные диски за эти месяцы
                    fmd.CommandText = @"SELECT s.month as m,s.year as y,SUM(s.number_of_disk) as ss
                                        FROM selling AS s                         
                                        GROUP BY s.month and s.year";

                    fmd.CommandType = CommandType.Text;
                    SQLiteDataReader r = fmd.ExecuteReader();
                    while (r.Read())
                    {
                        disk.Add(Convert.ToString(r["m"]) +" "+ Convert.ToString(r["y"]) + "|" + Convert.ToString(r["ss"]));
                    }
                }
            }

            return disk;
        }
        /// <summary>
        /// Этот метод записывает информацию отчетов в excel файлы и строит график по полученной информации.
        /// </summary>
        /// <param name="list">список данных</param>
        /// <param name="name_col1">наименование первого стобца в таблице отчета</param>
        /// <param name="name_col2">наименование второго стобца в таблице отчета</param>
        /// <param name="path">путь для сохранения файла</param>
        /// <param name="otchet">тип отчета:1,2,3,4,5</param>
        /// <param name="name_graph">Имя графика(отчета)</param>
        public void set_table_excel(List<string> list, string name_col1, string name_col2, string path, string otchet, string name_graph)
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
                foreach (string i in list)
                {
                    string[] row = i.Split('|');
                    ObjWorkSheet.Cells[j, 1] = row[0];
                    ObjWorkSheet.Cells[j, 2] = row[1];
                    j++;
                }
                int len = list.Count() + 1;
                Excel.Range chartRange;
                Excel.ChartObjects xlCharts = (Excel.ChartObjects)ObjWorkSheet.ChartObjects(Type.Missing);
                Excel.ChartObject myChart = (Excel.ChartObject)xlCharts.Add(10, 80, 300, 250);
                Excel.Chart chartPage = myChart.Chart;

                chartRange = ObjWorkSheet.get_Range("A1", "B" + len.ToString());

                chartPage.HasTitle = true;
                chartPage.ChartTitle.Text = name_graph;
                chartPage.SetSourceData(chartRange, System.Reflection.Missing.Value);
                chartPage.ChartType = Excel.XlChartType.xlLineMarkers;
                string path_file = otchet + "_" + DateTime.Now.Minute.ToString() + "_" + DateTime.Now.Second.ToString() + "_" + DateTime.Now.ToShortDateString() + ".bmp";
                chartPage.Export(ClassForms.sf.filePath.filepathUser + @"Отчеты\otchet_" + path_file, "BMP", System.Reflection.Missing.Value);
                ObjWorkBook.SaveAs(path);
                ObjExcel.ActiveWorkbook.Close(false);
                ObjExcel.CheckAbort(Type.Missing);
                ObjExcel.Quit();
                ObjExcel = null;
                ObjWorkBook = null;
                ObjWorkSheet = null;
                chartPage = null;
                GC.Collect();
                using (SQLiteConnection connect = new SQLiteConnection(@"Data Source=bd_kursov.sqlite;Version=3;New=False;Compress=True;"))
                {
                    connect.Open();
                    using (SQLiteCommand fmd = connect.CreateCommand())
                    {
                        SQLiteCommand sc;
                        sc = connect.CreateCommand();
                        sc.CommandText = "INSERT INTO 'otchety'('type','file_name') VALUES ('" + otchet + "'," + "'otchet_" + path_file + "');";
                        sc.ExecuteNonQuery();
                    }

                }

            }
           

        }

        
    


     
    }

