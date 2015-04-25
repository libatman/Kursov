using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FirstPartKursov
{
    public partial class DataBase : Form
    {
        public DataBase()
        {
            InitializeComponent();
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
            ClassForms.doc.Show();
            this.Hide();
        }

        private void заказТоваровToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            ClassForms.doc.Show();
            this.Hide();
        }

        private void бонусToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            //запуск программы Альматеи
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
            create_bd bd = new create_bd();
            //SQLiteConnection.CreateFile(@"D:\универ\kursovaya\Kursov\FirstPartKursov\bd_kursov.sqlite");

            if(File.Exists(@"Data Source=bd_kursov.sqlite")!=true)

            {
                bd.table_create(); 
                bd.triggers();
                bd.table_insert();
                MessageBox.Show("база данных создана"); 
               
            }

            SQLiteConnection sql = new SQLiteConnection(@"Data Source=bd_kursov.sqlite;Version=3");

            SQLiteCommand sc;
            sql.Open();//  ПОДКЛЮЧЕНИЕ ОТКРЫТО
            check_table check = new check_table();
            check.read_selling();
            sc = sql.CreateCommand();
            sc.CommandText = @"SELECT * FROM office;";
            SQLiteDataReader sdr = sc.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(sdr);
            dataGridView8.DataSource = dt;

            //sc.CommandText = "INSERT INTO 'selling' ('id_selling', 'date','amount','sum_of_sale','comment','number_of_disk','id_goods','id_manager') VALUES (1,'22/02/15',1,4999,'скидки нет',1,1,1);";
            //sc.ExecuteNonQuery();

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

                       
            //MessageBox.Show(bd.ordering_or_redistribution(1,id).ToString());
            
        }

        private void DataBase_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

    }
}
