using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VMS_system.User
{
    public partial class formmain : Form
    {
        public formmain()
        {
            InitializeComponent();
        }

        private void formmain_Load(object sender, EventArgs e)
        {
            
        }
        public void Loaddata()
        {
            SqlConnection con = new SqlConnection(@"Data Source = FGLAPNL207HFZT\SQLEXPRESS; Initial Catalog = Asptasks; Integrated Security = True");
            SqlCommand cmd;
            SqlDataAdapter sda;
            SqlDataAdapter sda1;
            DataTable dt;
            sda = new SqlDataAdapter("select e.visid,e.dates, e.vname, e.locn, e.mobno,e.purp,e.tomeet, e.laptop, e.det, e.intime, f.extime, g.img FROM VMS e inner join vmss f on e.visid=f.visid inner join images g on e.visid=g.visid ", con);
      
            dt = new DataTable();
            sda.Fill(dt);
            
            dataGridView1.DataSource = dt;
      
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Loaddata();
          
        }

        public void Loaddata1()
        {
            SqlConnection con = new SqlConnection(@"Data Source = FGLAPNL207HFZT\SQLEXPRESS; Initial Catalog = Asptasks; Integrated Security = True");
            SqlCommand cmd;
            SqlDataAdapter sda;
            SqlDataAdapter sda1;
            DataTable dt;
            sda = new SqlDataAdapter("select e.visid,e.dates, e.vname, e.locn, e.mobno,e.purp,e.tomeet, e.laptop, e.det, e.intime, f.extime, g.img FROM VMS e inner join vmss f on e.visid=f.visid inner join images g on e.visid=g.visid where e.dates= '" + dateTimePicker1.Text+ "' ", con);
           // sda1 = new SqlDataAdapter("select e.visid, g.img FROM VMS e JOIN images g on e.visid=g.visid where e.dates= '"+dateTimePicker1.Text+"' ", con);
            dt = new DataTable();
            sda.Fill(dt);
           // sda1.Fill(dt);
            dataGridView1.DataSource = dt;
            //dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            //dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

        }

        public void Loaddata11()
        {
            SqlConnection con = new SqlConnection(@"Data Source = FGLAPNL207HFZT\SQLEXPRESS; Initial Catalog = Asptasks; Integrated Security = True");
            SqlCommand cmd;
            SqlDataAdapter sda;
            DataTable dt;
            sda = new SqlDataAdapter("select visid,dates, vname, locn, mobno,purp,tomeet, laptop, det, intime FROM VMS  where dates= '" + dateTimePicker1.Text + "' ", con);
            dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.AutoSizeRowsMode= DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }
        private void button2_Click(object sender, EventArgs e)
        {

            Loaddata1(); 
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Showdata frm = new Showdata();
            frm.Show();
        }
    }
}
