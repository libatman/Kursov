using System;
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
        SQLiteConnection sql = new SQLiteConnection(@"Data Source=bd_kursov.sqlite;Version=3");

        SQLiteCommand sc;

        private void DataBase_Load(object sender, EventArgs e)
        {

            b_cancel_office_Click(sender, e);

            button9_Click(sender, e);

            button10_Click(sender, e);

            button11_Click(sender, e);

            button12_Click(sender, e);

            button13_Click(sender, e);

            button14_Click(sender, e);

            button15_Click(sender, e);
            
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
            catch
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

        private void входящиеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClassForms.inputmessages.Show();
            this.Hide();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox1.Text == "Введите  ключевое слово для поиска")
                textBox1.Clear();
        }

        private void textBox2_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox2.Text == "Введите  ключевое слово для поиска")
                textBox2.Clear();
        }

        private void textBox3_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox3.Text == "Введите  ключевое слово для поиска")
                textBox3.Clear();
        }

        private void textBox4_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox4.Text == "Введите  ключевое слово для поиска")
                textBox4.Clear();
        }

        private void textBox5_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox5.Text == "Введите  ключевое слово для поиска")
                textBox5.Clear();
        }

        private void textBox6_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox6.Text == "Введите  ключевое слово для поиска")
                textBox6.Clear();
        }

        private void textBox7_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox7.Text == "Введите  ключевое слово для поиска")
                textBox7.Clear();
        }

        private void textBox8_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox8.Text == "Введите  ключевое слово для поиска")
                textBox8.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sql.Open();
            sc = sql.CreateCommand();
            sc.CommandText = @"SELECT id_office as 'id_филиала', address as 'Адрес', email as 'Электронная почта' FROM office where address like '%" + textBox1.Text + "%'or email like'%" + textBox1.Text + "%';";
            SQLiteDataReader sdr = sc.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(sdr);
            dataGridView8.DataSource = dt;
            sdr.Close();
            sql.Close();
        }



        private void button2_Click(object sender, EventArgs e)
        {
            sql.Open();
            sc = sql.CreateCommand();
            sc.CommandText = @"SELECT id_manager as 'id_менеджера', FIO as 'ФИО', id_office as 'id_филиала' FROM manager where FIO like '%" + textBox2.Text + "%'or id_office like'%" + textBox2.Text + "%';";
            SQLiteDataReader sdr = sc.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(sdr);
            dataGridView2.DataSource = dt;
            sdr.Close();
            sql.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            sql.Open();
            sc = sql.CreateCommand();
            sc.CommandText = @"SELECT id_provider as 'id_поставщика', name_provider as 'Название фирмы', email_provider as 'Электронная почта' FROM provider where name_provider like '%" + textBox3.Text + "%'or email_provider like'%" + textBox3.Text + "%';";
            SQLiteDataReader sdr = sc.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(sdr);
            dataGridView3.DataSource = dt;
            sdr.Close();
            sql.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            sql.Open();
            sc = sql.CreateCommand();
            sc.CommandText = @"SELECT id_goods as 'id_товара', name_goods as'Наименование',currency as'Валюта', price as'Цена', id_provider as'id_поставщика' FROM goods where name_goods like '%" + textBox4.Text + "%'or currency like'%" + textBox4.Text + "%' or price like '%" + textBox4.Text + "%'or id_provider like'%" + textBox4.Text + "%';";
            SQLiteDataReader sdr = sc.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(sdr);
            dataGridView4.DataSource = dt;
            sdr.Close();
            sql.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            sql.Open();
            sc = sql.CreateCommand();
            sc.CommandText = @"SELECT id_storage as'id_склада',id_goods as'id_товара', amount_goods as'Количество товара' FROM storage where id_office like '%" + textBox5.Text + "%'or id_goods like'%" + textBox5.Text + "%' or amount_goods like '%" + textBox5.Text + "%';";
            SQLiteDataReader sdr = sc.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(sdr);
            dataGridView5.DataSource = dt;
            sdr.Close();
            sql.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            sql.Open();
            sc = sql.CreateCommand();
            sc.CommandText = @"SELECT id_selling as 'id_продажи', day as 'День', month as 'Месяц', year as'Год', id_goods as 'id_товара', amount as'Количество товара', sum_of_sale as'Стоимость', comment as 'Комментарий',number_of_disk as'Количество дисков с генератором аккордов', id_manager as 'id_менеджера' FROM selling where day like '%" + textBox8.Text + "%'or month like'%" + textBox8.Text + "%' or year like '%" + textBox8.Text + "%' or id_goods like '%" + textBox8.Text + "%' or id_manager like'%" + textBox8.Text + "%' or comment like '%" + textBox8.Text + "%' or sum_of_sale like '%" + textBox8.Text + "%' or number_of_disk like '%" + textBox8.Text + "%';";
            SQLiteDataReader sdr = sc.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(sdr);
            dataGridView1.DataSource = dt;
            sdr.Close();
            sql.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            sql.Open();
            sc = sql.CreateCommand();
            sc.CommandText = @"SELECT id_redistribution as'id_перераспределения', id_goods as'id_товара', amount_goods as'Количество товара', id_storage_old as'id_старого_склада', id_storage_new as'id_нового_склада' FROM redistribution_goods where amount_goods like '%" + textBox7.Text + "%'or id_goods like'%" + textBox7.Text + "%' or id_storage_old like '%" + textBox7.Text + "%'or id_storage_new like'%" + textBox7.Text + "%';";
            SQLiteDataReader sdr = sc.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(sdr);
            dataGridView7.DataSource = dt;
            sdr.Close();
            sql.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            sql.Open();
            sc = sql.CreateCommand();
            sc.CommandText = @"SELECT id_ordering as 'id_заказа', id_goods as 'id_товара', amount_goods as 'Количество товара',id_storage_in as 'id_склада' FROM ordering_goods where amount_goods like '%" + textBox6.Text + "%'or id_goods like'%" + textBox6.Text + "%' or id_storage_in like '%" + textBox6.Text + "%'or id_provider like'%" + textBox6.Text + "%';";
            SQLiteDataReader sdr = sc.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(sdr);
            dataGridView6.DataSource = dt;
            sdr.Close();
            sql.Close();
        }

        private void b_cancel_office_Click(object sender, EventArgs e)
        {
            sql.Open();
            sc = sql.CreateCommand();
            sc.CommandText = @"SELECT id_office as 'id_филиала', address as 'Адрес', email as 'Электронная почта' FROM office;";
            SQLiteDataReader sdr = sc.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(sdr);
            dataGridView8.DataSource = dt;
            sdr.Close();
            sql.Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {

            sql.Open();
            sc = sql.CreateCommand();
            sc.CommandText = @"SELECT id_manager as 'id_менеджера', FIO as 'ФИО', id_office as 'id_филиала' FROM manager;";
            SQLiteDataReader sdr = sc.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(sdr);
            dataGridView2.DataSource = dt;
            sdr.Close();
            sql.Close();
        }

        private void button10_Click(object sender, EventArgs e)
        {

            sql.Open();
            sc = sql.CreateCommand();
            sc.CommandText = @"SELECT id_provider as 'id_поставщика', name_provider as 'Название фирмы', email_provider as 'Электронная почта' FROM provider;";
            SQLiteDataReader sdr = sc.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(sdr);
            dataGridView3.DataSource = dt;
            sdr.Close();
            sql.Close();
        }

        private void button11_Click(object sender, EventArgs e)
        {

            sql.Open();
            sc = sql.CreateCommand();
            sc.CommandText = @"SELECT id_goods as 'id_товара', name_goods as'Наименование',currency as'Валюта', price as'Цена', id_provider as'id_поставщика'  FROM goods;";
            SQLiteDataReader sdr = sc.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(sdr);
            dataGridView4.DataSource = dt;
            sdr.Close();
            sql.Close();
        }

        private void button12_Click(object sender, EventArgs e)
        {

            sql.Open();
            sc = sql.CreateCommand();
            sc.CommandText = @"SELECT id_storage as'id_склада',id_goods as'id_товара', amount_goods as'Количество товара' FROM storage;";
            SQLiteDataReader sdr = sc.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(sdr);
            dataGridView5.DataSource = dt;
            sdr.Close();
            sql.Close();

        }

        private void button13_Click(object sender, EventArgs e)
        {

            sql.Open();
            sc = sql.CreateCommand();
            sc.CommandText = @"SELECT id_ordering as 'id_заказа', id_goods as 'id_товара', amount_goods as 'Количество товара',id_storage_in as 'id_склада'  FROM ordering_goods;";
            SQLiteDataReader sdr = sc.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(sdr);
            dataGridView6.DataSource = dt;
            sdr.Close();
            sql.Close();
        }

        private void button14_Click(object sender, EventArgs e)
        {

            sql.Open();
            sc = sql.CreateCommand();
            sc.CommandText = @"SELECT id_redistribution as'id_перераспределения', id_goods as'id_товара', amount_goods as'Количество товара', id_storage_old as'id_старого_склада', id_storage_new as'id_нового_склада' FROM redistribution_goods;";
            SQLiteDataReader sdr = sc.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(sdr);
            dataGridView7.DataSource = dt;
            sdr.Close();
            sql.Close();
        }

        private void button15_Click(object sender, EventArgs e)
        {

            sql.Open();
            sc = sql.CreateCommand();
            sc.CommandText = @"SELECT id_selling as 'id_продажи', day as 'День', month as 'Месяц', year as'Год', id_goods as 'id_товара', amount as'Количество товара', sum_of_sale as'Стоимость', comment as 'Комментарий',number_of_disk as'Количество дисков с генератором аккордов', id_manager as 'id_менеджера'  FROM selling;";
            SQLiteDataReader sdr = sc.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(sdr);
            dataGridView1.DataSource = dt;
            sdr.Close();
            sql.Close();
        }

        private void tabPage1_Leave(object sender, EventArgs e)
        {
            textBox1.Text = "Введите  ключевое слово для поиска";
        }

        private void tabPage2_Leave(object sender, EventArgs e)
        {
            textBox2.Text = "Введите  ключевое слово для поиска";
        }

        private void tabPage3_Leave(object sender, EventArgs e)
        {
            textBox3.Text = "Введите  ключевое слово для поиска";
        }

        private void tabPage4_Leave(object sender, EventArgs e)
        {
            textBox4.Text = "Введите  ключевое слово для поиска";
        }

        private void tabPage5_Leave(object sender, EventArgs e)
        {
            textBox5.Text = "Введите  ключевое слово для поиска";
        }

        private void tabPage6_Leave(object sender, EventArgs e)
        {
            textBox6.Text = "Введите  ключевое слово для поиска";
        }

        private void tabPage7_Leave(object sender, EventArgs e)
        {
            textBox7.Text = "Введите  ключевое слово для поиска";
        }

        private void tabPage8_Leave(object sender, EventArgs e)
        {
            textBox8.Text = "Введите  ключевое слово для поиска";
        }

        

       

    }
}
