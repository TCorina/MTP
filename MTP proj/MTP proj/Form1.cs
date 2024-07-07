using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;


namespace MTP_proj
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUser.Text;
            string password = txtPass.Text;

            if (ValidateCredentials(username, password))
            {
                var form2 = new Form2();
                form2.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Username or password are incorrect");
            }


            
        }

        private bool ValidateCredentials(string user, string pass)
        {
            string[] lines = File.ReadAllLines("credentials.txt");
            foreach (var line in lines)
            {
                var parts = line.Split(':');
                if (parts.Length == 2)
                {
                    if (parts[0] == user && parts[1] == pass)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private void lblError_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtPass_Enter(object sender, EventArgs e)
        {
            if (txtPass.Text == "Password")
            {
                txtPass.Text = "";
                txtPass.PasswordChar = '*';
            }
        }
    }
}
