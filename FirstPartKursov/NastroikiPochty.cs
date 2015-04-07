using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenPop.Pop3;

namespace FirstPartKursov
{
    public partial class NastroikiPochty : Form
    {
        public NastroikiPochty()
        {
            InitializeComponent();
        }
        string email;
        string password;
        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                email = value;
            }
        }

        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Email = textBox1.Text;
            Password = textBox2.Text;

            try
            {
                using (Pop3Client client = new Pop3Client())
                {
                    client.Connect("pop." + Email.Split('@')[1], 995, true);
                    client.Authenticate(Email.Split('@')[0], Password);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error!");
            }
            this.Close();

        }

        private void NastroikiPochty_Load(object sender, EventArgs e)
        {

        }
    }
}
