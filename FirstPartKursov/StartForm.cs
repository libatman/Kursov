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
            }
            else
            {
                ClassForms.sf.client = new Client();
                NastroikiPochty np = new NastroikiPochty();
                np.ShowDialog();
                ClassForms.sf.client.password = np.Password;
                ClassForms.sf.client.login = np.Email.Split('@')[0];
                ClassForms.sf.client.popserver = "pop." + np.Email.Split('@')[1];
                ClassForms.sf.client.smtpserver = "smtp." + np.Email.Split('@')[1];
                ser(ClassForms.sf.client);
            }
        }
       
        public void StartForm_Load(object sender, EventArgs e)
        {
            Client_r();
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

        private void входящиеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClassForms.inputmessages.Show();
            this.Hide();
        }

        private void StartForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
       
        
    }
}
