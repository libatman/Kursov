using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.Diagnostics;
using System.Data.SQLite;

namespace FirstPartKursov
{
    public partial class Otchety : Form
    {
        public Otchety()
        {
            InitializeComponent();
        }

        private void бДToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClassForms.db.Show();
            this.Hide();
        }

        private void написатьНовоеСообщениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClassForms.newmess.Show();
            this.Hide();
        }


        private void контактыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClassForms.contacts.Show();
            this.Hide();
        }

        private void продаваемостьТоваровToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void популярностьПоставщиковToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void продаваемостьПоФилиаламToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void результативностьМенеджеровToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void перераспределениеТоваровToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClassForms.doc_red.Show();
            this.Hide();
        }

        private void заказТоваровToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClassForms.doc_order.Show();
            this.Hide();
        }

        private void бонусToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //запуск программы Альматеи
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = @"idz-guitar.exe";
            p.Start();
        }

        private void почтаToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            NastroikiPochty np = new NastroikiPochty();
            np.ShowDialog();
        }

        private void главноеОкноToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClassForms.sf.Show();
            this.Hide();
        }

        private void Otchety_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void Otchety_Load(object sender, EventArgs e)
        {
            bt_open_file.Visible = false;
        }
        /// <summary>
        /// Этот метод ищет путь к последнему созданному отчету из определенной категории
        /// </summary>
        /// <param name="type">Категория отчета: 1-продаваемость товаров, 2- популярность поставщиков, 3- продаваемость по филиалам, 4- результативность менеджеров, 5- продаваемость дисков</param>
        /// <returns></returns>
        string find_path_file(string type)
        {
            string max_id;
            string name;
            using (SQLiteConnection connect = new SQLiteConnection(@"Data Source=bd_kursov.sqlite;Version=3;New=False;Compress=True;"))
            {
                connect.Open();
                using (SQLiteCommand fmd = connect.CreateCommand())
                {
                    fmd.CommandText = @"SELECT MAX(id_otchety) as m from otchety where otchety.type=" + type + ";";
                    fmd.CommandType = CommandType.Text;
                    SQLiteDataReader r = fmd.ExecuteReader();
                    max_id = r["m"].ToString();
                    r.Close();
                    fmd.CommandText = @"SELECT file_name as n from otchety where otchety.id_otchety=" + max_id + ";";
                    fmd.CommandType = CommandType.Text;
                    SQLiteDataReader r1 = fmd.ExecuteReader();
                    name = r1["n"].ToString();

                }
            }
            return name;
        }

        Excel_document excel1 = new Excel_document();
        int flag = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                switch (flag)
                {
                    case 1:
                        {
                            Excel.Application excelapp = new Excel.Application();
                            excelapp.Workbooks.Open(ClassForms.sf.filePath.filepathUser + @"Отчеты\Otchet1_" + DateTime.Now.ToShortDateString() + ".xls");
                            excelapp.Visible = true;
                        }
                        break;
                    case 2:
                        {
                            Excel.Application excelapp = new Excel.Application();
                            excelapp.Workbooks.Open(ClassForms.sf.filePath.filepathUser + @"Отчеты\Otchet2_" + DateTime.Now.ToShortDateString() + ".xls");
                            excelapp.Visible = true;
                        } break;
                    case 3:
                        {
                            Excel.Application excelapp = new Excel.Application();
                            excelapp.Workbooks.Open(ClassForms.sf.filePath.filepathUser + @"Отчеты\Otchet3_" + DateTime.Now.ToShortDateString() + ".xls");
                            excelapp.Visible = true;
                        } break;
                    case 4:
                        {
                            Excel.Application excelapp = new Excel.Application();
                            excelapp.Workbooks.Open(ClassForms.sf.filePath.filepathUser + @"Отчеты\Otchet4_" + DateTime.Now.ToShortDateString() + ".xls");
                            excelapp.Visible = true;
                        } break;
                    case 5:
                        {
                            Excel.Application excelapp = new Excel.Application();
                            excelapp.Workbooks.Open(ClassForms.sf.filePath.filepathUser + @"Отчеты\Otchet5_" + DateTime.Now.ToShortDateString() + ".xls");
                            excelapp.Visible = true;
                        } break;
                    default: MessageBox.Show("Файл не был создан"); break;
                }
            }
            catch
            {
                MessageBox.Show("Невозможно открыть файл.");
            }


        }
        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Bitmap bmp = new Bitmap(pb_otchet.Width, pb_otchet.Height);
                switch (cb_otchet.Text)
                {
                    case "Продаваемость товаров":
                        {
                            bt_open_file.Visible = false;
                            excel1.set_table_excel(excel1.sell_goods(), "Наименование товара", "Количество проданных, шт", ClassForms.sf.filePath.filepathUser + @"Отчеты\Otchet1_" + DateTime.Now.ToShortDateString() + ".xls", "1", "Продаваемость товаров");
                            flag = 1;
                            bmp = new Bitmap(ClassForms.sf.filePath.filepathUser + @"Отчеты\" + find_path_file("1"));
                            pb_otchet.Image = bmp;
                            bt_open_file.Visible = true;
                            ClassForms.sf.label1.Text += Environment.NewLine+"Построен отчет 'Продаваемость товаров' ( " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString() + " )";
                            ClassForms.sf.label1.Refresh();
                            
                        }
                        break;
                    case "Популярность поставщиков":
                        {
                            bt_open_file.Visible = false;
                            excel1.set_table_excel(excel1.popular_providers(), "Наименование провайдера", "Количество заказов", ClassForms.sf.filePath.filepathUser + @"Отчеты\Otchet2_" + DateTime.Now.ToShortDateString() + ".xls", "2", "Популярность поставщиков");
                            flag = 2;
                            bmp = new Bitmap(ClassForms.sf.filePath.filepathUser + @"Отчеты\" + find_path_file("2"));
                            pb_otchet.Image = bmp;
                            bt_open_file.Visible = true;
                            ClassForms.sf.label1.Text += Environment.NewLine + "Построен отчет 'Популярность поставщиков' ( " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString() + " )";
                            ClassForms.sf.label1.Refresh();
                        }
                        break;
                    case "Продаваемость по филиалам":
                        {
                            bt_open_file.Visible = false;

                            excel1.set_table_excel(excel1.sell_offices(), "Адрес филиала", "Количество продаж", ClassForms.sf.filePath.filepathUser + @"Отчеты\Otchet3_" + DateTime.Now.ToShortDateString() + ".xls", "3", "Продаваемость по филиалам");
                            flag = 3;
                            bmp = new Bitmap(ClassForms.sf.filePath.filepathUser + @"Отчеты\" + find_path_file("3"));
                            pb_otchet.Image = bmp;
                            bt_open_file.Visible = true;
                            ClassForms.sf.label1.Text += Environment.NewLine + "Построен отчет 'Продаваемость по филиалам' ( " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString() + " )";
                            ClassForms.sf.label1.Refresh();
                        }
                        break;
                    case "Результативность менеджеров":
                        {
                            bt_open_file.Visible = false;

                            excel1.set_table_excel(excel1.result_manager(), "ФИО менеджера", "Количество осуществленных продаж", ClassForms.sf.filePath.filepathUser + @"Отчеты\Otchet4_" + DateTime.Now.ToShortDateString() + ".xls", "4", "Результативность менеджеров");
                            flag = 4;
                            bmp = new Bitmap(ClassForms.sf.filePath.filepathUser + @"Отчеты\" + find_path_file("4"));
                            pb_otchet.Image = bmp;
                            bt_open_file.Visible = true;
                            ClassForms.sf.label1.Text += Environment.NewLine + "Построен отчет 'Результативность менеджеров' ( " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString() + " )";
                            ClassForms.sf.label1.Refresh();
                        }
                        break;
                    case "Продаваемость дисков":
                        {
                            bt_open_file.Visible = false;
                            excel1.set_table_excel(excel1.sell_disks(), "месяц", "Количество проданных дисков, шт.", ClassForms.sf.filePath.filepathUser + @"Отчеты\Otchet5_" + DateTime.Now.ToShortDateString() + ".xls", "5", "Продаваемость дисков");
                            flag = 5;
                            bmp = new Bitmap(ClassForms.sf.filePath.filepathUser + @"Отчеты\" + find_path_file("5"));
                            pb_otchet.Image = bmp;
                            bt_open_file.Visible = true;
                            ClassForms.sf.label1.Text += Environment.NewLine + "Построен отчет 'Продаваемость дисков' ( " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString() + " )";
                            ClassForms.sf.label1.Refresh();
                        }
                        break;
                }
            }
            catch
            {
                MessageBox.Show("Ошибка! Отчет не был построен.");
            }
        }

        private void входящиеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClassForms.inputmessages.Show();
            this.Hide();
        }

        private void отчетыToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}   

