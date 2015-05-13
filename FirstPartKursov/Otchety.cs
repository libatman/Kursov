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

        private void всеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClassForms.inputmessages.Show();
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
            button1.Visible = false;
        }
        Excel_document excel1 = new Excel_document();
        int flag = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            switch (flag)
            {
                case 1:
                    {
                        Excel.Application excelapp = new Excel.Application();
                        excelapp.Workbooks.Open(ClassForms.sf.filePath.filepathUser+"Otchet1_" + DateTime.Now.ToShortDateString() + ".xls");
                        excelapp.Visible = true;
                        //excelapp.Quit();
                    }
                    break;
                case 2:
                    {
                        Excel.Application excelapp = new Excel.Application();
                        excelapp.Workbooks.Open(ClassForms.sf.filePath.filepathUser+"Otchet2_" + DateTime.Now.ToShortDateString() + ".xls");
                        excelapp.Visible = true;
                        //excelapp.Quit();
                    } break;
                case 3:
                    {
                        Excel.Application excelapp = new Excel.Application();
                        excelapp.Workbooks.Open(ClassForms.sf.filePath.filepathUser+"Otchet3_" + DateTime.Now.ToShortDateString() + ".xls");
                        excelapp.Visible = true;
                    } break;
                case 4:
                    {
                        Excel.Application excelapp = new Excel.Application();
                        excelapp.Workbooks.Open(ClassForms.sf.filePath.filepathUser+"Otchet4_" + DateTime.Now.ToShortDateString() + ".xls");
                        excelapp.Visible = true;
                    } break;
                case 5:
                    {
                        Excel.Application excelapp = new Excel.Application();
                        excelapp.Workbooks.Open(ClassForms.sf.filePath.filepathUser+"Otchet5_" + DateTime.Now.ToShortDateString() + ".xls");
                        excelapp.Visible = true;
                    } break;
                default: MessageBox.Show("Файл не был создан"); break;
            }


        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
             switch(comboBox1.Text)
             {
                 case "Продаваемость товаров":
                     {
                         button1.Visible = false;
                         excel1.set_table_excel(excel1.sell_goods(), "Наименование товара", "Количество проданных, шт", ClassForms.sf.filePath.filepathUser+@"Отчеты\Otchet1_" + DateTime.Now.ToShortDateString() + ".xls","1");
                         flag = 1;
                         pictureBox1.Image = new Bitmap(ClassForms.sf.filePath.filepathUser + @"Отчеты\otchet_" + "1_" + DateTime.Now.ToShortDateString() + ".bmp");
                         button1.Visible = true;
                     }
                     break;
                 case "Популярность поставщиков":
                     {
                         button1.Visible = false;
                         excel1.set_table_excel(excel1.popular_providers(), "Наименование провайдера", "Количество заказов", ClassForms.sf.filePath.filepathUser + @"Отчеты\Otchet2_" + DateTime.Now.ToShortDateString() + ".xls", "2");
                         flag = 2;
                         pictureBox1.Image = new Bitmap(ClassForms.sf.filePath.filepathUser + @"Отчеты\otchet_" + "2_" + DateTime.Now.ToShortDateString() + ".bmp");
                         button1.Visible = true;
                     }
                     break;
                 case "Продаваемость по филиалам":
                     {
                         button1.Visible = false;
                         excel1.set_table_excel(excel1.sell_offices(), "Адрес филиала", "Количество продаж", ClassForms.sf.filePath.filepathUser + @"Отчеты\Otchet3_" + DateTime.Now.ToShortDateString() + ".xls", "3");
                         flag = 3;
                         pictureBox1.Image = new Bitmap(ClassForms.sf.filePath.filepathUser + @"Отчеты\otchet_" + "3_" + DateTime.Now.ToShortDateString() + ".bmp");
                         button1.Visible = true;
                     }
                     break;
                 case "Результативность менеджеров":
                     {
                         button1.Visible = false;
                         excel1.set_table_excel(excel1.result_manager(), "ФИО менеджера", "Количество осуществленных продаж", ClassForms.sf.filePath.filepathUser + @"Отчеты\Otchet4_" + DateTime.Now.ToShortDateString() + ".xls", "4");
                         flag = 4;
                         pictureBox1.Image = new Bitmap(ClassForms.sf.filePath.filepathUser + @"Отчеты\otchet_" + "4_" + DateTime.Now.ToShortDateString() + ".bmp");
                         button1.Visible = true;
                     }
                     break;
                 case "Продаваемость дисков":
                     {
                         button1.Visible = false;
                         excel1.set_table_excel(excel1.sell_disks(), "месяц", "Количество проданных дисков, шт.", ClassForms.sf.filePath.filepathUser + @"Отчеты\Otchet5_" + DateTime.Now.ToShortDateString() + ".xls", "5");
                         flag = 5;
                         pictureBox1.Image = new Bitmap(ClassForms.sf.filePath.filepathUser + @"Отчеты\otchet_" + "5_" + DateTime.Now.ToShortDateString() + ".bmp");
                         button1.Visible = true;
                     }
                     break;
             }
        }
        }
        
    }

