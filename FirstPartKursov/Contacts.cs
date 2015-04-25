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
    public partial class Contacts : Form
    {
        public Contacts()
        {
            InitializeComponent();
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

        private void входящиеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClassForms.inputmessages.Show();
            this.Hide();
        }
        ListBox myListGroups;
        private void Contacts_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Филиалы");
            comboBox1.Items.Add("Поставщики");
            myListGroups = new ListBox(); //антипаттерн, который я потом опишу в записке : зачем я начала создавать это программно?

            myListGroups.Location = new Point(60, 100);

            myListGroups.Location = new Point(20, 60);

            myListGroups.Size = new Size(760, 540);
            myListGroups.HorizontalScrollbar = true;
            Controls.Add(myListGroups);
            myListGroups.Hide();
        }

        private void Contacts_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        List<string> addresses_p;
        List<string> addresses_f;
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                myListGroups.Items.Clear();
                myListGroups.Show();
                addresses_f = new create_bd().addresses_filial();
                for (int i = 0; i < addresses_f.Count; i++)
                {

                    myListGroups.Items.Add((i + 1).ToString() + ". " + addresses_f[i].Split('|')[0] + ": " + addresses_f[i].Split('|')[1]);
                }

            }
            else
            {
                myListGroups.Items.Clear();
                myListGroups.Show();
                addresses_p = new create_bd().addresses_postav();
                for (int i = 0; i < addresses_p.Count; i++)
                {

                    myListGroups.Items.Add((i + 1).ToString() + ". " + addresses_p[i].Split('|')[0] + ": " + addresses_p[i].Split('|')[1]);

                    myListGroups.Items.Add((i+1).ToString() + ". " + addresses_p[i].Split('|')[0] + ": " + addresses_p[i].Split('|')[1]);

                }
            }
        }

        private void label1_MouseEnter(object sender, EventArgs e)
        {
            Label l = (Label)sender;
            l.BackColor = Color.LightBlue;
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            Label l = (Label)sender;
            l.BackColor = Color.WhiteSmoke;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Hide();
            if (comboBox1.SelectedIndex == 0)
            {


                for  (int i = 0; i < addresses_f.Count; i++)

                {
                    if (i != addresses_f.Count - 1)
                    {
                        ClassForms.newmess.textBox1.Text += addresses_f[i].Split('|')[1] + ",";
                    }
                    else
                    {
                        ClassForms.newmess.textBox1.Text += addresses_f[i].Split('|')[1];
                    }
                }
            }
            else
            {
                for (int j = 0; j < addresses_p.Count; j++)
                {
                    if (j != addresses_p.Count - 1)
                    {
                        ClassForms.newmess.textBox1.Text += addresses_p[j].Split('|')[1] + ",";
                    }
                    else
                    {
                        ClassForms.newmess.textBox1.Text += addresses_p[j].Split('|')[1];
                    }
                }
            }
            ClassForms.newmess.Show();
        }

    }
}

