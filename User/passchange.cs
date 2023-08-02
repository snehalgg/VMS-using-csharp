using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VMS_system.User
{
    public partial class passchange : Form
    {
        public passchange()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to change password?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Connection con = new Connection();
                con.dataGet("select * from users where Uname = '" + textBox1.Text + "' and Pass = '" + textBox2.Text + "' ");
                DataTable dt = new DataTable();
                con.sda.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    if (textBox3.Text == textBox4.Text)
                    {
                        if (textBox3.Text.Length > 3)
                        {
                            con.dataSend("Update users set Pass='" + textBox3.Text + "' where Uname='" + textBox1.Text + "' and Pass='" + textBox2.Text + "'");
                            MessageBox.Show("Password changed succesfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            errorProvider1.SetError(textBox3, "Please enter minimum 4 character password");

                        }
                    }
                    else
                    {
                        errorProvider1.SetError(textBox3, "Passwords Mismatch");
                        errorProvider1.SetError(textBox4, "Passwords Mismatch");
                    }
                }
                else
                {
                    errorProvider1.SetError(textBox1, "Please check username & Password");
                    errorProvider1.SetError(textBox2, "Please check username & Password");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmuserregister frm = new frmuserregister();
            frm.Show();
        }
    }
}
