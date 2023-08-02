using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace VMS_system.User
{
    public partial class Showdata : Form
    {
        SqlConnection conn;
        SqlCommand comm;
        SqlDataReader dreader;
        public Showdata()
        {
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Showdata_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Name_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string conString = @"Data Source = FGLAPNL207HFZT\SQLEXPRESS; Initial Catalog = Asptasks; Integrated Security = True";

            conn = new SqlConnection(conString);
            conn.Open();
            double a = Convert.ToDouble(textBox1.Text);
            textBox1.Text = (a + 1).ToString();
          

            try
            {
                comm = new SqlCommand("select e.visid,e.dates, e.vname, e.locn, e.mobno,e.purp,e.tomeet, e.laptop, e.det, e.intime, f.extime, g.img FROM VMS e inner join vmss f on e.visid=f.visid inner join images g on e.visid=g.visid where e.visid = " + Convert.ToInt32(textBox1.Text), conn);
                dreader = comm.ExecuteReader();
                if (dreader.Read())
                {
                    textBox12.Text = textBox1.Text;
                    textBox13.Text = dateTimePicker1.Text;
                    dateTimePicker1.Text = dreader[1].ToString();
                    textBox3.Text = dreader[2].ToString();
                    textBox4.Text = dreader[3].ToString();
                    textBox5.Text = dreader[4].ToString();
                    textBox6.Text = dreader[5].ToString();
                    textBox7.Text = dreader[6].ToString();
                    textBox8.Text = dreader[7].ToString();
                    textBox9.Text = dreader[8].ToString();
                    textBox10.Text = dreader[9].ToString();
                    textBox11.Text = dreader[10].ToString();
                    byte[]img = ((byte[])(dreader[11]));    
                   if (img == null)
                    {
                        pictureBox1.Image = null;
                    }
                   else
                    {
                        MemoryStream mstr = new MemoryStream(img);
                        pictureBox1.Image = System.Drawing.Image.FromStream(mstr);
                    } 
                }
            }catch(Exception ex) { }
}

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            formmain frm = new formmain();
            frm.Show();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string conString = @"Data Source = FGLAPNL207HFZT\SQLEXPRESS; Initial Catalog = Asptasks; Integrated Security = True";

            conn = new SqlConnection(conString);
            conn.Open();

            try
            {
                comm = new SqlCommand("select e.visid,e.dates, e.vname, e.locn, e.mobno,e.purp,e.tomeet, e.laptop, e.det, e.intime, f.extime, g.img FROM VMS e inner join vmss f on e.visid=f.visid inner join images g on e.visid=g.visid where e.dates = '" + dateTimePicker1.Text+ "' ", conn);
                dreader = comm.ExecuteReader();
                if (dreader.Read())
                {
                    textBox12.Text = textBox1.Text;
                    textBox13.Text = dateTimePicker1.Text;
                    textBox1.Text = dreader[0].ToString();
                    textBox3.Text = dreader[2].ToString();
                    textBox4.Text = dreader[3].ToString();
                    textBox5.Text = dreader[4].ToString();
                    textBox6.Text = dreader[5].ToString();
                    textBox7.Text = dreader[6].ToString();
                    textBox8.Text = dreader[7].ToString();
                    textBox9.Text = dreader[8].ToString();
                    textBox10.Text = dreader[9].ToString();
                    textBox11.Text = dreader[10].ToString();
                    byte[] img = ((byte[])(dreader[11]));
                    if (img == null)
                    {
                        pictureBox1.Image = null;
                    }
                    else
                    {
                        MemoryStream mstr = new MemoryStream(img);
                        pictureBox1.Image = System.Drawing.Image.FromStream(mstr);
                    }
                }
            }
            catch (Exception ex) { }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePicker1.Checked == false)
            {
                textBox6.Enabled = false;

            }
            else
            {
                textBox6.Enabled = true;

            }
        }
      

        //Rest of the code
            //Bitmap bmp;

      
        //Rest of the code
        Bitmap MemoryImage;
        public void GetPrintArea(Panel pnl)
        {
            MemoryImage = new Bitmap(pnl.Width, pnl.Height);
            pnl.DrawToBitmap(MemoryImage, new Rectangle(0, 0, pnl.Width, pnl.Height));
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            if (MemoryImage != null)
            {
                e.Graphics.DrawImage(MemoryImage, 0, 0);
                base.OnPaint(e);
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            

            //    Panel grd = new Panel();
            //    Bitmap bmp = new Bitmap(grd.Width, grd.Height, grd.CreateGraphics());
            //    grd.DrawToBitmap(bmp, new Rectangle(0, 0, grd.Width, grd.Height));
            //    RectangleF bounds = e.PageSettings.PrintableArea;
            //    float factor = ((float)bmp.Height / (float)bmp.Width);
            //    e.Graphics.DrawImage(bmp, bounds.Left, bounds.Top, bounds.Width, factor * bounds.Width);
            Rectangle pagearea = e.PageBounds;
            e.Graphics.DrawImage(MemoryImage, (pagearea.Width / 2) - (this.panel1.Width / 2), this.panel1.Location.Y);

        }

        public void Print(Panel pnl)
        {
            panel1 = pnl;
            GetPrintArea(pnl);
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            //Graphics g = this.CreateGraphics();
            //bmp = new Bitmap(this.Size.Width, this.Size.Height, g);
            //Graphics mg = Graphics.FromImage(bmp);
            //mg.CopyFromScreen(this.Location.X, this.Location.Y, 0, 0, this.Size);
            //printPreviewDialog1.ShowDialog();
            Print(this.panel1);
        }
    } }