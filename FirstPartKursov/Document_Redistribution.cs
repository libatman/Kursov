using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FirstPartKursov
{
    public partial class Document_Redistribution : Form
    {
        public Document_Redistribution()
        {
            InitializeComponent();
        }

        private void главноеОкноToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClassForms.sf.Show();
            this.Hide();
        }

        private void написатьНовоеСообщениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClassForms.newmess.Show();
            this.Hide();
        }

        private void входящиеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClassForms.inputmessages.Show();
            this.Hide();
        }

        private void контактыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClassForms.contacts.Show();
            this.Hide();
        }

        private void бДToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClassForms.db.Show();
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
            ClassForms.np.Show();
            this.Hide();
        }

        private void Document_Redistribution_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = (char)0;
        }
        create_bd db = new create_bd();
        List<string> filials;
        List<string> goods;
        private void Document_Redistribution_Load(object sender, EventArgs e)
        {
            filials = db.addresses_filial();
            for (int i = 0; i < filials.Count; i++)
            {
                comboBox1.Items.Add(filials[i].Split('|')[0]);
                comboBox2.Items.Add(filials[i].Split('|')[0]);
            }
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
