﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Diagnostics;

namespace FirstPartKursov
{
    public partial class DataBase : Form
    {
        public DataBase()
        {
            InitializeComponent();
            backgroundWorker1.RunWorkerAsync();
        }

        private void написатьНовоеСообщениеToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            ClassForms.newmess.Show();
            this.Hide();
        }

        private void всеToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            ClassForms.inputmessages.Show();
            this.Hide();
        }

        private void контактыToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            ClassForms.contacts.Show();
            this.Hide();
        }

        private void бДToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            ClassForms.db.Show();
            this.Hide();
        }

        private void продаваемостьТоваровToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            ClassForms.otchety.Show();
            this.Hide();
        }

        private void популярностьПоставщиковToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            ClassForms.otchety.Show();
            this.Hide();
        }

        private void продаваемостьПоФилиаламToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            ClassForms.otchety.Show();
            this.Hide();
        }

        private void результативностьМенеджеровToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            ClassForms.otchety.Show();
            this.Hide();
        }

        private void перераспределениеТоваровToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            ClassForms.doc_red.Show();
            this.Hide();
        }

        private void заказТоваровToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            ClassForms.doc_order.Show();
            this.Hide();
        }

        private void бонусToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            //запуск программы Альматеи
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = @"idz-guitar.exe";
            p.Start();
        }

        private void почтаToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            NastroikiPochty np = new NastroikiPochty();
            np.ShowDialog();
        }

        private void главноеОкноToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClassForms.sf.Show();
            this.Hide();
        }

        private void DataBase_Load(object sender, EventArgs e)
        {
            
            SQLiteConnection sql = new SQLiteConnection(@"Data Source=bd_kursov.sqlite;Version=3");

            SQLiteCommand sc;
            sql.Open();//  ПОДКЛЮЧЕНИЕ ОТКРЫТО
            //Check_table check = new Check_table();
            //check.read_selling();
            sc = sql.CreateCommand();
            sc.CommandText = @"SELECT * FROM office;";
            SQLiteDataReader sdr = sc.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(sdr);
            dataGridView8.DataSource = dt;

            sc.CommandText = @"SELECT * FROM manager;";
            sdr = sc.ExecuteReader();
            dt = new DataTable();
            dt.Load(sdr);
            dataGridView2.DataSource = dt;

            sc.CommandText = @"SELECT * FROM provider;";
            sdr = sc.ExecuteReader();
            dt = new DataTable();
            dt.Load(sdr);
            dataGridView3.DataSource = dt;

            sc.CommandText = @"SELECT * FROM goods;";
            sdr = sc.ExecuteReader();
            dt = new DataTable();
            dt.Load(sdr);
            dataGridView4.DataSource = dt;

            sc.CommandText = @"SELECT * FROM storage;";
            sdr = sc.ExecuteReader();
            dt = new DataTable();
            dt.Load(sdr);
            dataGridView5.DataSource = dt;

            sc.CommandText = @"SELECT * FROM ordering_goods;";
            sdr = sc.ExecuteReader();
            dt = new DataTable();
            dt.Load(sdr);
            dataGridView6.DataSource = dt;

            sc.CommandText = @"SELECT * FROM redistribution_goods;";
            sdr = sc.ExecuteReader();
            dt = new DataTable();
            dt.Load(sdr);
            dataGridView7.DataSource = dt;

            sc.CommandText = @"SELECT * FROM selling;";
            sdr = sc.ExecuteReader();
            dt = new DataTable();
            dt.Load(sdr);
            dataGridView1.DataSource = dt;

            sdr.Close();
            sql.Close(); //ПОДКЛЮЧЕНИЕ ЗАКРЫТО

            
        }

        private void DataBase_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        Valuta v;
        string result;
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                v = new Valuta();
                string html = v.download_site();
                html.Trim();
                result = v.get_valute(html);
                Thread.Sleep(500);
                backgroundWorker1.ReportProgress(100, result);
            }
            catch (Exception ex)
            {
                result = "Error";
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            string result = (string)e.UserState;
            label1.Text = result;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }

        private void отчетыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClassForms.otchety.Show();
            this.Hide();
        }

    }
}
