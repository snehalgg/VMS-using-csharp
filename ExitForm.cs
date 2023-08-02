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

namespace VMS_system
{
    public partial class ExitForm : Form
    {   
        
        public ExitForm()
        {
           
            InitializeComponent();
        }

        private void ExitForm_Load(object sender, EventArgs e)
        {
            textBox1.Text = DateTime.Now.ToShortTimeString();
        }

        private void ClearData()
        { 
            
            textBox2.Clear();
        }

            private void button1_Click(object sender, EventArgs e)
        {
            Connection con = new Connection();
            con.dataSend("INSERT INTO vmss(visid, extime)VALUES('"+textBox2.Text+"', '"+textBox1.Text+"')");



            MessageBox.Show("Thank-you");
            ClearData();
        }
    }
}
