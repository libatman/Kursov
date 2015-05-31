using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.IO;
using System.Xml.Serialization;
using System.Diagnostics;


namespace FirstPartKursov
{
    public partial class StartForm : Form
    {
        public StartForm()
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
            ClassForms.otchety.Show();
            this.Hide();
        }

        private void популярностьПоставщиковToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClassForms.otchety.Show();
            this.Hide();
        }

        private void продаваемостьПоФилиаламToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClassForms.otchety.Show();
            this.Hide();
        }

        private void результативностьМенеджеровToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClassForms.otchety.Show();
            this.Hide();
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
        public Client client;
        public void Client_r ()
        {
            if (File.Exists("mailinfo.xml"))
            {
                ClassForms.sf.client = des(client);
                ClassForms.inputmessages.runThread();
            }
            else
            {
                ClassForms.sf.client = new Client();
                NastroikiPochty np = new NastroikiPochty();
                np.ShowDialog();
                try
                {
                    ClassForms.sf.client.password = np.Password;
                    ClassForms.sf.client.login = np.Email.Split('@')[0];
                    ClassForms.sf.client.popserver = "pop." + np.Email.Split('@')[1];
                    ClassForms.sf.client.smtpserver = "smtp." + np.Email.Split('@')[1];
                    ser(ClassForms.sf.client);
                    ClassForms.inputmessages.runThread();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Проверьте входные данные и попробуйте снова!");
                    Client_r();
                }
            }
        }
        public FilePathUser filePath;
        public void Path_Check ()
        {
            if (File.Exists("pathInfo.xml"))
            {
                ClassForms.sf.filePath = desPath(filePath);
            }
            else
            {
                ClassForms.sf.filePath = new FilePathUser();
                SaveFileDialog x = new SaveFileDialog();
                x.Title = "Выберите путь сохранения для ваших отчетов, прикреплений и т.д.";
                x.FileName = "proba.txt";
                DialogResult result = x.ShowDialog();
                if (result != DialogResult.OK)
                    return;
                FileInfo file = new FileInfo(x.FileName);
                ClassForms.sf.filePath.filepathUser = x.FileName.Replace(@"proba.txt", "");
                serPath(ClassForms.sf.filePath);
                createPath(ClassForms.sf.filePath.filepathUser + "Документы на заказ товаров");
                createPath(ClassForms.sf.filePath.filepathUser + "Документы на перераспределение товаров");
                createPath(ClassForms.sf.filePath.filepathUser + "Отчеты");
                    
            }
           
        }
        
        Create_bd bd = new Create_bd();
        public void StartForm_Load(object sender, EventArgs e)
        {
            Client_r();
            Path_Check();
            label1.Text = "";
            label1.Text += Environment.NewLine + "Добро пожаловать, " + ClassForms.sf.client.login + "!";
            label1.Refresh();
         
            if (File.Exists(@"bd_kursov.sqlite") != true)
            {

                bd.table_create();
                bd.triggers();
                bd.table_insert();
                label1.Text += Environment.NewLine + "База данных создана.";
                label1.Refresh();
            }
          
        }

        public void ser(Client client)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Client));
            FileStream f = new FileStream(@"mailinfo.xml", FileMode.OpenOrCreate);
            using (StreamWriter sw = new StreamWriter(f))
            {
                serializer.Serialize(sw, client);
            }
            
        }

        public Client des(Client client)
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(Client));
            TextReader reader = new StreamReader(@"mailinfo.xml");
            object obj = deserializer.Deserialize(reader);
            client = (Client)obj;
            reader.Close();
            return client;
        }

        public void serPath(FilePathUser filePath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(FilePathUser));
            FileStream f = new FileStream(@"pathInfo.xml", FileMode.OpenOrCreate);
            using (StreamWriter sw = new StreamWriter(f))
            {
                serializer.Serialize(sw, filePath);
            }

        }

        public FilePathUser desPath(FilePathUser filePath)
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(FilePathUser));
            TextReader reader = new StreamReader(@"pathInfo.xml");
            object obj = deserializer.Deserialize(reader);
            filePath = (FilePathUser)obj;
            reader.Close();
            return filePath;
        }

        private void входящиеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClassForms.inputmessages.Show();
            this.Hide();
        }

        private void StartForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        /// <summary>
        /// создаст папку, которой нет на компьютере
        /// </summary>
        /// <param name="path"></param>
        public void createPath(string path) 
        {
            if (!(Directory.Exists(path)))
            {
                try
                {
                    Directory.CreateDirectory(path);
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message);
                }
            }
        }

        private void отчетыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClassForms.otchety.Show();
            this.Hide();
        }
    }
}
