using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace VMS_system
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void contextMenuStrip1_VisibleChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Photofrm frm = new Photofrm();
            
            frm.MdiParent = this;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show();
            frm.Opacity = 0;
            this.Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ExitForm frm = new ExitForm();
            frm.MdiParent = this;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show();
            frm.Opacity = 0;
            this.Refresh();
        }

        private void showVisitorDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            User.frmuserregister fr = new User.frmuserregister();
            fr.MdiParent = this;
            fr.StartPosition = FormStartPosition.CenterScreen;
            fr.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        bool close = true;
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (close)
            {
                DialogResult result = MessageBox.Show("Are You Sure You Want To Exit", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    close = false;
                    Application.Exit();

                }
                else
                {
                    e.Cancel = true;
                }
            }
        }

        private void visitorInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

      
    }
}
