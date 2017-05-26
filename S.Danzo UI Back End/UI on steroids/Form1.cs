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
            tabControl3.SelectedTab = tabPage2; //tabcontrol
        }
        private void button1_Click(object sender, EventArgs e)
        {
            tabControl3.SelectedTab = tabPage1; //tabcontrol
        }
        private void button3_Click(object sender, EventArgs e)
        {
            tabControl3.SelectedTab = tabPage3; //tabcontrol
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
                //customers[count] = new customerstorage(count, txt_Name.Text, txt_Address, txt_Email, txt_Date, txt_Costs, txt_DueDate);
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
                    OutputCustomer(i);
                }
            }
        }
        private void OutputCustomer(int CustID) //Outputs the details to the textbox
        { 
            int i = CustID;

            if ((CustID > count) && (CustID > 0)) {
                MessageBox.Show ("WTF man?");
            } else    {
                //TempString =
                txt_UpdateName.Text = customers[i].name;
                txt_UpdateAddress.Text = customers[i].Address;
                txt_UpdateEmail.Text = customers[i].email;
                txt_UpdateDate.Text = customers[i].Date;
                txt_UpdateCosts.Text = Convert.ToString(customers[i].Costs);
                txt_UpdateDueDate.Text = customers[i].Due_Date;
                //txtBoxSearchResult.AppendText(TempString + Environment.NewLine);
                
                // I used s string to hold and write to the textbox
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            pictureBox1.ImageLocation = openFileDialog1.FileName;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            tabControl3.SelectedTab = tabPage4;
        }

        private void btn_SearchId_Click(object sender, EventArgs e) //Button Search
        {
            double results = 0;
            if (double.TryParse(txt_SearchId.Text, out results))
            {
                for (int i = 0; i < count; i++)
                {
                    if (customers[i].invoice_id == results)
                    {
                        //txtBoxSearchResult.AppendText(customers[i].name + Environment.NewLine);
                        OutputCustomer(i);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please enter a numeric into the Id search field");
            }
        }
        private void DataDineFrm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void btn_UpdateCust_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < count; i++)
            {
                if (customers[i].name == txt_SearchName.Text)
                {
                    OutputCustomer(i);
                }
            }
        }

        private void btn_SearchId_Click_1(object sender, EventArgs e)
        {
            for (int i = 0; i < count; i++)
            {
                if (customers[i].name == txt_SearchName.Text)
                {
                    OutputCustomer(i);
                }
            }
        }

        private void btn_TestData_Click(object sender, EventArgs e) //Adds sample data to make testing easier
        {
            txt_Name.Text = "Sean";
            txt_Address.Text = "14 trell";
            txt_Email.Text = "sean@rell";
            txt_Date.Text = "15th";
            txt_Costs.Text = "145.90";
            
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
        public double Costs { get; set; }
        public string Due_Date { get; set; }
        public customerstorage(int cust_id, string cust_name, string cust_Address, string cust_email, int inv_id, string inv_date, double inv_Costs, string inv_due_date)
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
        public int InvNumber { get; set; }
        public int InvPrice { get; set; }
        public int InvCustNum { get; set; }
        public string Desc { get; set; }
        public invoicestorage(int Inv_Num, int Inv_Price, int Inv_CustNum, string Inv_Desc)
        {
            InvNumber = Inv_Num;
            InvPrice = Inv_Price;
            InvCustNum = Inv_CustNum;
            Desc = Inv_Desc;
        }
    }
}
