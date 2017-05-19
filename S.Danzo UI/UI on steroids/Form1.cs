using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI_on_steroids
{

    public partial class DataDineFrm : Form
    {
        customerstorage customer1 = new customerstorage(1, "Bill", "10 street", "billfrank@live.com", 1, "14 / 06 / 14", 145, "20 / 06 / 14");
        customerstorage customer2 = new customerstorage(2, "Fred", "15 street", "fredfrank@live.com", 2, "23 / 06 / 14", 160, "26 / 06 / 14");
        customerstorage customer3 = new customerstorage(3, "Susan", "20 street", "susanmo@live.com", 3, "09 / 06 / 14", 180, "21 / 06 / 14");

        int count = 0;
        string[] StringStorage = new string[20];
        customerstorage[] customers = new customerstorage[10];

        public DataDineFrm()
        {
            InitializeComponent();
            customers[0] = customer1;
            customers[1] = customer2;
            customers[2] = customer3;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage2;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage1;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage3;
        }
        private void button8_Click(object sender, EventArgs e)
        {
            Application.Exit(); //Close(); using this meant the debugger kept running afterwards, so I used Application.Exit(); instead.
        }
        private void openFileDialog1_FileOk_1(object sender, CancelEventArgs e)
        {

        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            Application.Exit(); //Close(); using this meant the debugger kept running afterwards, so I used Application.Exit(); instead.
        }

        //private void button9_Click(object sender, EventArgs e)
        //{
        //    SaveFileDialog f = new SaveFileDialog();
        //    f.Filter = "JPG(*.JPG)|*.jpg";

        //    if (f.ShowDialog() == DialogResult.OK)
        //    {
        //        File = Image.FromFile(f.FileName);
        //        pictureBox1.Image = File;
        //    }
        //}

        private void button10_Click(object sender, EventArgs e)
        {
            Application.Exit(); //Clicking on the X button doesn't completely close everything. Adding this was a temprary fix.
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (count <= 20)
            {
                StringStorage[count] = lbl_YourName.Text + txtBoxName.Text + lbl_YourEmail + txtBoxEmail;
                txtBoxResults.AppendText(StringStorage[count] + Environment.NewLine);
                count++;
            }
        }

        private void button8_Click_2(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button12_Click(object sender, EventArgs e)
        {

            for (int i = 0; customers.Length < 3;)
            { 
                if (customers[i] != null)
                {
                    if (customers[i].name == txt_SearchName.Text)
                        {
                            txtBoxSearchResult.AppendText(customers[i] + Environment.NewLine);
                        }
                }
                i++;
            }

        }
        private void button11_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 2; i++)
            {
                if (customers[i].invoice_id == Convert.ToInt32(txt_SearchId))
                {
                    txtBoxSearchResult.AppendText(customers[i] + Environment.NewLine);
                }
            }
        }
        private void button7_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            pictureBox1.ImageLocation = openFileDialog1.FileName;
        }
}
    public class customerstorage
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string Address { get; set; }
        public string email { get; set; }
        public int invoice_id { get; set; }
        public string Date { get; set; }
        public int Costs { get; set; }
        public string Due_Date { get; set; }
        public customerstorage(int cust_id, string cust_name, string cust_Address, string cust_email, int inv_id, string inv_date, int inv_Costs, string inv_due_date)
        {
            Id = cust_id;
            name = cust_name;
            Address = cust_Address;
            email = cust_email;
            invoice_id = inv_id;
            Date = inv_date;
            Costs = inv_Costs;
            Due_Date = inv_due_date;
        }
    }
}
