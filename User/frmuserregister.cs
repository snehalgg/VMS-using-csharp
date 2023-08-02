using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace VMS_system.User
{
    public partial class frmuserregister : Form
    {
        public frmuserregister()
        {
            InitializeComponent();
        }

        private void frmuserregister_Load(object sender, EventArgs e)
        {
            txtpassword.UseSystemPasswordChar = true;
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {   
            Connection con = new Connection();
            con.dataGet("select * from users where Uname = '" + txtusername.Text + "' and Pass = '" + txtpassword.Text + "' ");
            DataTable dt = new DataTable();
            con.sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                this.Hide();
                formmain frm = new formmain();
                frm.Show();


            }
            else
            {
                MessageBox.Show("Invalid Username & Password...|", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                txtpassword.UseSystemPasswordChar = false;
            }
            else
            {
                txtpassword.UseSystemPasswordChar = true;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            passchange fr = new passchange();
            fr.Show();
        }
    }
}
