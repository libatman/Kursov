using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using OpenPop.Mime;

namespace FirstPartKursov
{
    public partial class TheMessage : Form
    {
        private OpenPop.Mime.Message message;

        int index;
        public TheMessage(OpenPop.Mime.Message message, int index)
        {
            InitializeComponent();
            this.message = message;
            this.index = index;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = (char)0;
        }

      

        List<string> list_att; ListBox listBox_atta;
        List<MessagePart> attachments;
        //Button button_pr; 
        Button button_sv;
        int selected_index;
        private void listBox_clicked(object sender, MouseEventArgs e)
        {
            selected_index = listBox_atta.SelectedIndex;
            //button_pr = new Button();
            //button_pr.Location = new Point(16, 360);
            //button_pr.Size = new Size(70, 25);
            button_sv = new Button();
            button_sv.Location = new Point(86, 360);
            button_sv.Size = new Size(90, 25);
            //Controls.Add(button_pr); 
            Controls.Add(button_sv);
            //button_pr.BackColor = Color.WhiteSmoke;
            button_sv.BackColor = Color.WhiteSmoke;
            //button_pr.Text = "Просмотр";
            button_sv.Text = "Сохранить";
            button_sv.Click += buttonsv_Click;
        }
        private SaveFileDialog saveFile;

        private void buttonsv_Click(object sender, EventArgs e)
        {
            this.saveFile = new System.Windows.Forms.SaveFileDialog();
            if (attachments[selected_index] != null)
            {
                saveFile.FileName = attachments[selected_index].FileName;
                DialogResult result = saveFile.ShowDialog();
                if (result != DialogResult.OK)
                    return;
                FileInfo file = new FileInfo(saveFile.FileName);
                if (file.Exists)
                {
                    file.Delete();
                }
                try
                {
                    attachments[selected_index].Save(file);
                    MessageBox.Show(this, "Файл сохранен!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, "Неудачно. Exception message: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show(this, "Прикрепление было пустым!");
            }
        }


        string address;
        public string Address
        {
            get
            {
                return address;
            }
            set
            {
                address = value;
            }
        }

        private void button_Back_Click(object sender, EventArgs e)
        {
            ClassForms.inputmessages.Show();
            this.Close();
        }

        private void button_Answer_Click(object sender, EventArgs e)
        {
            ClassForms.newmess.textBox_Who.Text = message.Headers.From.Address;
            ClassForms.newmess.Show();
            this.Close();

        }

        private void TheMessage_Load(object sender, EventArgs e)
        {
            textBox_Subject.Text = message.Headers.Subject;
            MessagePart mpPlain = message.FindFirstPlainTextVersion();
            message.FindAllAttachments();

            if (mpPlain != null)
            {
                Encoding enc = mpPlain.BodyEncoding;
                textBox_Body.Text = enc.GetString(mpPlain.Body);
            }
            label_From.Text = message.Headers.From.Address;
            label_From.Text += Environment.NewLine;
            label_From.Text += message.Headers.From.DisplayName;
            label_From.Text += Environment.NewLine;
            label_From.Text += message.Headers.DateSent.ToLocalTime();
            list_att = new List<string>();
            attachments = message.FindAllAttachments();
            bool hadattach = attachments.Count > 0;
            if (hadattach)
            {
                Label newLA = new Label();
                newLA.Location = new Point(16, 107);
                newLA.Text = "Прикрепления";
                newLA.Font = new System.Drawing.Font("Century Gothic", 9);
                listBox_atta = new ListBox();
                listBox_atta.MouseClick += listBox_clicked;
                listBox_atta.Location = new Point(16, 128);
                listBox_atta.Size = new Size(160, 240);
                listBox_atta.HorizontalScrollbar = true;
                Controls.Add(listBox_atta);
                Controls.Add(newLA);
                foreach (MessagePart attachment in attachments)
                {
                    list_att.Add(attachment.FileName);
                }
                for (int i = 0; i < list_att.Count; i++)
                {
                    listBox_atta.Items.Add(list_att[i]);
                }
            }

        }
    }
}
