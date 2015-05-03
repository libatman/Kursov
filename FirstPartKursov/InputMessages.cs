﻿using OpenPop.Mime;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace FirstPartKursov
{
    public partial class InputMessages : Form
    {
        public InputMessages()
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
        }

        private void почтаToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            ClassForms.np.ShowDialog();
        }

        private void главноеОкноToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClassForms.sf.Show();
            this.Hide();
        }

        List<string> list_message_output = new List<string>();
        public List<OpenPop.Mime.Message> listmessages = new List<OpenPop.Mime.Message>();
        public List<string> addresses_p;

        //public List<OpenPop.Mime.Message> listmessages;
        //public List<string> addresses_p; 
        Create_bd DataBase = new Create_bd();
        public List<string> addresses_a;

        private void InputMessages_Load(object sender, EventArgs e)
        {
            addresses_p = DataBase.addresses_providers();
            addresses_a = DataBase.addresses_filial();
            int countMessages = listmessages.Count;
            for (int i = 0; i < countMessages; i++)
            {
                list_message_output.Add((i + 1).ToString() + ", " + listmessages[i].Headers.From.DisplayName.ToString() + ", " + listmessages[i].Headers.From.MailAddress.Address + ", " + listmessages[i].Headers.DateSent.ToShortDateString() + ", " + listmessages[i].Headers.DateSent.ToShortTimeString());
                for (int j = 0; j < addresses_p.Count; j++)
                {
                    if (listmessages[i].Headers.From.MailAddress.Address.ToString() == addresses_p[j].Split('|')[1])
                    {
                        listBox2.Items.Add(list_message_output[i]);
                    }
                }
                for (int k = 0; k < addresses_a.Count; k++)
                {
                    if (listmessages[i].Headers.From.MailAddress.Address.ToString() == addresses_a[k].Split('|')[1])
                    {
                        listBox3.Items.Add(list_message_output[i]);
                    }
                }
                listBox1.Items.Add(list_message_output[i]);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        public TheMessage theMessage;
        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int selectedIndex = listBox1.SelectedIndex;
            list_message_output[selectedIndex] = (string)listBox1.SelectedItem;
            string[] array = list_message_output[listBox1.SelectedIndex].Split(',');
            selectedIndex = Convert.ToInt32(array[0].Trim()) - 1;
            theMessage = new TheMessage(listmessages[selectedIndex], selectedIndex);
            this.Hide();
            theMessage.ShowDialog();
        }

        private void входящиеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClassForms.inputmessages.Show();
            this.Hide();
        }

        private void InputMessages_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void listBox2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //int selectedIndex = listBox2.SelectedIndex;
            //list_message_output[selectedIndex] = (string)listBox2.SelectedItem;
            //if (list_message_output[listBox2.SelectedIndex][0] == '!')
            //{
            //    list_message_output[listBox2.SelectedIndex] = list_message_output[listBox2.SelectedIndex].Remove(0, 1);
            //}
            //string[] array = list_message_output[listBox2.SelectedIndex].Split(',');
            //selectedIndex = Convert.ToInt32(array[0].Trim()) - 1;
            //theMessage = new TheMessage(listmessages[selectedIndex], selectedIndex);
            //this.Hide();
            //theMessage.ShowDialog();
        }

        private void listBox3_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            listmessages = new List<OpenPop.Mime.Message>();
            fetchmess();
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            string result = (string)e.UserState;
            if (result == "Ok")
            {
                MessageBox.Show("Все сообщения скачаны успешно");
            }
            else
            {
                MessageBox.Show("При считывании сообщений произошли ошибки.");
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }

        string result;
        private void fetchmess()
        {
            StartForm s = new StartForm();
            s.Client_r();
            result = MailClass.FetchAllMessages(ClassForms.sf.client.popserver, 995, true, ClassForms.sf.client.login, ClassForms.sf.client.password, listmessages);
            backgroundWorker1.ReportProgress(100, result);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            listmessages.Clear();
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            list_message_output.Clear();
            
            result = MailClass.FetchAllMessages(ClassForms.sf.client.popserver, 995, true, ClassForms.sf.client.login, ClassForms.sf.client.password, listmessages);
            if (result == "Ok")
            {
                MessageBox.Show("Обновлено!");
            }
            else
            {
                MessageBox.Show("При считывании сообщений произошли ошибки.");
            }


            int countMessages = listmessages.Count;
            for (int i = 0; i < countMessages; i++)
            {
                list_message_output.Add((i + 1).ToString() + ", " + listmessages[i].Headers.From.DisplayName.ToString() + ", " + listmessages[i].Headers.From.MailAddress.Address + ", " + listmessages[i].Headers.DateSent.ToShortDateString() + ", " + listmessages[i].Headers.DateSent.ToShortTimeString());
                for (int j = 0; j < addresses_p.Count; j++)
                {
                    if (listmessages[i].Headers.From.MailAddress.Address.ToString() == addresses_p[j].Split('|')[1])
                    {
                        listBox2.Items.Add(list_message_output[i]);
                    }
                }
                for (int k = 0; k < addresses_a.Count; k++)
                {
                    if (listmessages[i].Headers.From.MailAddress.Address.ToString() == addresses_a[k].Split('|')[1])
                    {
                        listBox3.Items.Add(list_message_output[i]);
                    }
                }
                listBox1.Items.Add(list_message_output[i]);
            }
        }

    }
}
