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
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = @"idz-guitar.exe";
            p.Start();
        }

        private void почтаToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            NastroikiPochty np = new NastroikiPochty();
            np.ShowDialog();
        }

        private void Document_Redistribution_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void comboBox_filialsFROM_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = (char)0;
        }
        Create_bd db = new Create_bd();
        List<string> filials;
        List<string> goods;
        private void Document_Redistribution_Load(object sender, EventArgs e)
        {
            filials = db.addresses_filial();
            for (int i = 0; i < filials.Count; i++)
            {
                comboBox_filialsFROM.Items.Add(filials[i].Split('|')[0] + "|" + filials[i].Split('|')[1]);
                comboBox_filialsTO.Items.Add(filials[i].Split('|')[0] + "|" + filials[i].Split('|')[1]);
            }
        }

        private void comboBox_filialsFROM_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkedListBox_goods.Items.Clear();
            int id_prov = comboBox_filialsFROM.SelectedIndex + 1;
            goods = db.goods_storage(id_prov);
            
            for (int i = 0; i < goods.Count; i++)
            {
                checkedListBox_goods.Items.Add(goods[i]);
            }
        }
        List<string> goodsChecked = new List<string>();
        CreateDocument createDocument = new CreateDocument();
        private void button_toSend_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox_goods.Items.Count; i++)
            {
                if (checkedListBox_goods.GetItemCheckState(i) == CheckState.Checked)
                {
                    goodsChecked.Add(goods[i]);
                }
            }
            if (goodsChecked.Count > 0 && comboBox_filialsFROM.SelectedIndex >= 0 && comboBox_filialsTO.SelectedIndex >= 0)
            {
                createDocument.createDocument_Command(goodsChecked, comboBox_filialsFROM.SelectedItem.ToString(), comboBox_filialsTO.SelectedItem.ToString());
                createDocument.createDocument_Invoice(goodsChecked, comboBox_filialsTO.SelectedIndex + 1);
                List<string> filename = new List<string>();
                filename.Add(ClassForms.sf.filePath.filepathUser + "Документы на перераспределение товаров\\" + "Document_Command." + DateTime.Now.ToShortDateString() + ".odt");
                filename.Add(ClassForms.sf.filePath.filepathUser + "Документы на перераспределение товаров\\" + "Document_Invoice." + DateTime.Now.ToShortDateString() + ".pdf");
                MailClass.SendMail_Click(comboBox_filialsTO.SelectedItem.ToString().Split('|')[1], ClassForms.sf.client.login, "Перераспределение товаров", "", ClassForms.sf.client.password, ClassForms.sf.client.smtpserver, filename);
                MessageBox.Show("Отправлено!");
            }
            else
            {
                MessageBox.Show("Вы не выбрали все данные для заполнения документа. Пожлауйста, проверьте Ваши действия.");
            }
            
        }

        private void отчетыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClassForms.otchety.Show();
            this.Hide();
        }
    }
}
