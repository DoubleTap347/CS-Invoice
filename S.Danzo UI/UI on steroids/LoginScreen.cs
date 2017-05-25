using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI_on_steroids;

namespace LoginScreenForm
{
    public partial class LoginScreen : Form
    {
        string username = "lister";
        string password = "1472";

        public LoginScreen()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if((UserBox.Text == username)&&(PassBox.Text == password))
            {
                MessageBox.Show("Login to the app was successful!");   //Cool feature but clicking okay everytime is annoying
                this.Hide();

                DataDineFrm ss = new DataDineFrm();
                ss.Show();
            }
            else {
                MessageBox.Show("Login details incorrect");
                PassBox.Text = "";
            }

            
            //LoginScreen ss = new LoginScreen();
            //ss.Show();
        }

        private void LoginScreen_Load(object sender, EventArgs e)
        {

        }

        private void UserBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void PassBox_TextChanged(object sender, EventArgs e)
        {

        }
    }

}