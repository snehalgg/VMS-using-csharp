using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Data.SqlClient;

namespace VMS_system
{
    public partial class homepage : Form
    {
        
        string laptop;
        public homepage()
        {
           
            InitializeComponent();
           
           
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            laptop = "yes";
            
            if (checkBox1.Checked == false)
            {
                textBox6.Enabled = false;
               
            }
            else
            {
                textBox6.Enabled = true;
               
            }
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            
        }

        private bool validation()
        {
            bool result = false;
            if (string.IsNullOrEmpty(textBox2.Text))
            {

                errorProvider1.Clear();
                errorProvider1.SetError(textBox2, "Name Required");
            }
            else if (string.IsNullOrEmpty(textBox3.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(textBox3, "Location Required");
            }
            else if (string.IsNullOrEmpty(textBox4.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(textBox4, "Phone NO Required");
            }
            else if (string.IsNullOrEmpty(textBox5.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(textBox5, "Purpose Required");
            }
            else if (comboBox1.SelectedIndex == -1)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(comboBox1, "Select Employee");
            }
            else
            {
                errorProvider1.Clear();
                result = true;
            }
            return result;

        }
        private void homepage_Load(object sender, EventArgs e)
        {
            
            AutoIdNumber();
            textBox8.Text = DateTime.Now.ToShortDateString();
                textBox7.Text= DateTime.Now.ToShortTimeString();
        }

        private void AutoIdNumber()
        {
            SqlConnection conn = new SqlConnection(@"Data Source = FGLAPNL207HFZT\SQLEXPRESS; Initial Catalog = Asptasks; Integrated Security = True");
            double val = 0;
            conn.Open();
            SqlCommand cmd = new SqlCommand("Select count (visid) from VMS", conn);
            int i = Convert.ToInt32(cmd.ExecuteScalar());
            conn.Close();
            i++;
           label11.Text = val + i.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {   if (validation())
            {
                Connection con = new Connection();
                con.dataSend("INSERT INTO VMS(visid,  dates, vname, locn, mobno, purp, tomeet, laptop, det, intime)VALUES('" + label11.Text + "', '" + textBox8.Text + "',  '" + textBox2.Text + "','" + textBox3.Text + "', " + textBox4.Text + ", '" + textBox5.Text + "','" + comboBox1.Text + "', '" + checkBox1.Checked + "', '" + textBox6.Text + "', '" + textBox7.Text + "'  )");


                MessageBox.Show("Welcome to FGII");
                ClearData();
                this.Hide();
                Photofrm frm = new Photofrm();


            } else
            {
                MessageBox.Show("Enter all details");
            }
            this.Refresh();

        }
        private void ClearData()
        {
            textBox8.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            comboBox1.Text = "";
            checkBox1.Checked = false;
            AutoIdNumber();
            textBox2.Focus();
          
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

           
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
