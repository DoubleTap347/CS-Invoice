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

        invoicestorage[] invoice = new invoicestorage[100];
        invoicestorage invoice 1 = new invoicestorage();

        int count;
        string[] StringStorage = new string[20];
        customerstorage[] customers = new customerstorage[100];

        public DataDineFrm()
        {
            InitializeComponent();
            customers[0] = customer1;
            customers[1] = customer2;
            customers[2] = customer3;
            count = 3;
            //OutputCustomer(5);
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
            tabControl1.SelectedTab = tabPage4;
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

        private void button10_Click(object sender, EventArgs e)
        {
            Application.Exit(); //Clicking on the X button doesn't completely close everything. Adding this was a temprary fix.
        }

        private void button5_Click(object sender, EventArgs e) //Register as customer
        {
            string TempString;
            string s = ", ";
            if (count <= customers.Length)
            {
                customers[count] = new customerstorage(count, txt_Name.Text, txt_Address.Text, txt_Email.Text, 1, "14 / 06 / 14", 145, "20 / 06 / 14");
                // customers[count] = new customerstorage(count, txt_Name.Text, txt_Address, txt_Email, txt_Date, txt_Costs, txt_DueDate);
                //customers[count]  = new customerstorage(1, "Bill", "10 street", "billfrank@live.com", 1, "14 / 06 / 14", 145, "20 / 06 / 14");

                TempString = lbl_YourName.Text + s + txt_Name.Text + s + txt_Address.Text + s + txt_Email.Text + s + txt_Date.Text + s + txt_Costs.Text + s + txt_DueDate.Text;
                txtBoxResults.AppendText(TempString + Environment.NewLine);
                count++;
            }
        }

        private void button8_Click_2(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_SearchName_Click(object sender, EventArgs e) // Search Name
        {

            for (int i = 0; i < count; i++)
            { 
   
                if (customers[i].name == txt_SearchName.Text)
                {
                    //txtBoxSearchResult.AppendText(customers[i].name + Environment.NewLine);
                    OutputCustomer(i);
                }

                
            }
        }

        private void OutputCustomer(int CustID)  {

            string TempString;
            string s = ", ";
            int i = CustID;

            if ((CustID > count) && (CustID > 0)) {
                MessageBox.Show ("WTF man?");
            } else    {
                TempString = customers[i].name + s + customers[i].Address + customers[i].email + s + customers[i].Date + s + customers[i].Costs + s + customers[i].Due_Date;
                txtBoxSearchResult.AppendText(TempString + Environment.NewLine);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            pictureBox1.ImageLocation = openFileDialog1.FileName;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage4;
        }

        private void btn_SearchId_Click(object sender, EventArgs e) //Button Search
        {
            for (int i = 0; i < count; i++)
            {
                if (customers[i].invoice_id == Convert.ToInt32(txt_SearchId.Text))
                {
                    //txtBoxSearchResult.AppendText(customers[i].name + Environment.NewLine);
                    OutputCustomer(i);
                }
            }
        }
        private void DataDineFrm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
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
    public class invoicestorage
    {

    }
}
