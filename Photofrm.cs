using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;
using VMS_system.User;

namespace VMS_system
{
    public partial class Photofrm : Form
    {
        VideoCaptureDevice frame;
        FilterInfoCollection Devices;
        public Photofrm()
        {
            InitializeComponent();
        }

        void Start_cam()
        {
            Devices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            frame = new VideoCaptureDevice(Devices[0].MonikerString);
            frame.NewFrame += new AForge.Video.NewFrameEventHandler(NewFrame_event);
            frame.Start();
        }

        void NewFrame_event(object send, NewFrameEventArgs e)
        {
            try
            {
                pictureBox1.Image = (Image)e.Frame.Clone();
            }
            catch (Exception ex) { }
        }
        string output;

        private void button3_Click(object sender, EventArgs e)
        {
            Start_cam();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            frame.Stop();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            textBox1.Text = folderBrowserDialog1.SelectedPath;
            output = folderBrowserDialog1.SelectedPath;
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (output != "" && pictureBox1.Image != null)
            {
                pictureBox1.Image.Save(output + "\\Image.png");
                pictureBox2.Image = pictureBox1.Image;
            }
        }

        private void AutoIdNumber()
        {
            SqlConnection conn = new SqlConnection(@"Data Source = FGLAPNL207HFZT\SQLEXPRESS; Initial Catalog = Asptasks; Integrated Security = True");
            double val = 0;
            conn.Open();
            SqlCommand cmd = new SqlCommand("Select count (visid) from images", conn);
            int i = Convert.ToInt32(cmd.ExecuteScalar());
            conn.Close();
            i++;
            label2.Text = val + i.ToString();
        }

        private void Photofrm_Load(object sender, EventArgs e)
        {
            AutoIdNumber();
        }

        private void Photofrm_FormClosed(object sender, FormClosedEventArgs e)
        {
            frame.Stop();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source = FGLAPNL207HFZT\SQLEXPRESS; Initial Catalog = Asptasks; Integrated Security = True");
            SqlCommand cmd = new SqlCommand("Insert Into images (visid, img) Values('" + label2.Text + "',@Pic) ", con);
            MemoryStream stream = new MemoryStream();
            pictureBox2.Image.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
            byte[] pic = stream.ToArray();
            cmd.Parameters.AddWithValue("@Pic", pic);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
           
            this.Hide();
            homepage frm = new homepage();
           
            frm.Show();
           

        }

        private void Photofrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
        }
    }
}
