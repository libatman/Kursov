using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace FirstPartKursov
{
    public partial class TheNewMessage : Form
    {
        public TheNewMessage()
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

        private void вернутьсяНаГлавнуюСтраницуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClassForms.sf.Show();
            this.Hide();
        }
        List<string> fileName = new List<string>();
        private void fresh()
        {
            textBox_Who.Clear();
            textBox_Subject.Clear();
            richTextBox_Body.Clear();
            if (fileName != null)
            {
                mylistatt.Items.Clear();
            }

        }
        string theme;
        string body;
        string[] addresses;
        private void button_Send_Click(object sender, EventArgs e)
        {
            try
            {
                theme = textBox_Subject.Text;
                body = richTextBox_Body.Text;
                if (textBox_Who.Text.Contains(','))
                {
                    addresses = textBox_Who.Text.Split(',');
                    for (int i = 0; i < addresses.Count(); i++)
                    {
                        MailClass.SendMail_Click1(addresses[i], ClassForms.sf.client.login, textBox_Subject.Text, richTextBox_Body.Text, ClassForms.sf.client.password, ClassForms.sf.client.smtpserver, fileName);
                    }
                }
                else
                {
                    MailClass.SendMail_Click1(textBox_Who.Text, ClassForms.sf.client.login, textBox_Subject.Text, richTextBox_Body.Text, ClassForms.sf.client.password, ClassForms.sf.client.smtpserver, fileName);
                }
                MessageBox.Show("Ваше сообщение отправлено!");
                fresh();

            }
            catch
            {
                MessageBox.Show("Ваше сообщение не отправлено. Проверьте данные.");
            }
            

        }

        int l = 0;
        List<string> items_f = new List<string>();
        ListBox mylistatt = new ListBox();
        private void button_Attach_Click(object sender, EventArgs e)
        {
            OpenFileDialog myFile = new OpenFileDialog();
            myFile.Title = " ";

            myFile.Filter = "All files (*.*)|*.*";
            if (myFile.ShowDialog() == DialogResult.OK)
            {
                fileName.Add(myFile.FileName);
                string Name_of_File = myFile.FileName;
                string[] array = Name_of_File.Split('\\');
                int count = array.Count();
                items_f.Add(array[count - 1]);
                mylistatt.Items.Add(items_f[l]);
                mylistatt.SelectedIndexChanged += mylistatt_selected;
                string[] sec_array = array[count - 1].Split('.');
                mylistatt.HorizontalScrollbar = true;
                mylistatt.Size = new System.Drawing.Size(220, 172);
                mylistatt.Location = new Point(30, 262);
                Controls.Add(mylistatt);
            }
            l++;
        }
        int selindex;
        private void mylistatt_selected(object sender, EventArgs e)
        {
            selindex = mylistatt.SelectedIndex;
            Button b = new Button();
            b.Location = new Point(30, 440);
            b.Size = new Size(120, 50);
            b.Text = "Удалить вложение";
            Controls.Add(b);
            b.Click += b_Click;
        }

        private void b_Click(object sender, EventArgs e)
        {
            items_f.RemoveAt(selindex);
            fileName.RemoveAt(selindex);
            mylistatt.Items.Clear();
            for (int i = 0; i < fileName.Count; i++)
            {
                mylistatt.Items.Add(items_f[i]);
            }
        }

        private void TheNewMessage_Load(object sender, EventArgs e)
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
        
    }
}
