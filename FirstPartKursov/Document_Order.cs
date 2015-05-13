using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace FirstPartKursov
{
    public partial class Document_Order : Form
    {
        public Document_Order()
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
            ClassForms.doc_red.Show();
            this.Hide();
        }

        private void заказТоваровToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
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

        private void Documents_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        CreateDocument createDocument = new CreateDocument();
        List<string> goodsChecked = new List<string>();
        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                if (checkedListBox1.GetItemCheckState(i) == CheckState.Checked)
                {
                    goodsChecked.Add(goods[i]);
                }
            }
            createDocument.createDocument_order(goodsChecked, comboBox2.SelectedItem.ToString(), comboBox1.SelectedItem.ToString());
            List<string> filename = new List<string>();
            filename.Add(ClassForms.sf.filePath.filepathUser + "Документы на заказ товаров\\" + "Document_Order." + DateTime.Now.ToShortDateString() + ".pdf");
            MailClass.SendMail_Click1(comboBox1.SelectedItem.ToString().Split('|')[1], ClassForms.sf.client.login, "Документ-заявка на товар", "", ClassForms.sf.client.password, ClassForms.sf.client.smtpserver, filename);
            MessageBox.Show("Done!");
            
        }

        List<string> providers;
        List<string> filials;
        List<string> goods;
        Create_bd db = new Create_bd();

        private void Document_Order_Load(object sender, EventArgs e)
        {
            providers = db.addresses_providers();
            filials = db.addresses_filial();
            for (int i = 0; i < providers.Count; i++)
            {
                comboBox1.Items.Add(providers[i].Split('|')[0] + "|" + providers[i].Split('|')[1]);
            }
            for (int j = 0; j < filials.Count; j++)
            {
                comboBox2.Items.Add("Адрес: " + filials[j].Split('|')[0]);
            }
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = (char)0;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkedListBox1.Items.Clear();
            int id_prov = comboBox1.SelectedIndex + 1;
            goods = db.goods(id_prov);
            for (int i = 0; i < goods.Count; i++)
            {
                checkedListBox1.Items.Add("Наименование: " + goods[i].Split('|')[0] + ". Валюта: " + goods[i].Split('|')[1] + ". Стоимость: " + goods[i].Split('|')[2]);
            }
        }
    }
}
