using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

namespace RGB
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.Size = new Size(512,512);
            openFileDialog1.ShowDialog();
            Image my_Image = System.Drawing.Image.FromFile(openFileDialog1.FileName);
            pictureBox1.Image = my_Image;
            pictureBox1.Size = GetPictureDisplaySize(pictureBox1).Size;
            string my_Image_Info, Name, Size;
            Name = "Name:" + openFileDialog1.FileName + "\r\n\r\n";
            Size = "Width:" + my_Image.Width + "\r\n" + "Height:" + my_Image.Height;
            my_Image_Info = Name + Size;
            textBox1.Text = my_Image_Info;
        }

        public Rectangle GetPictureDisplaySize(PictureBox pbxImage)
        {
            if (pbxImage != null)
            {
                PropertyInfo ppiImageRect = pbxImage.GetType().GetProperty("ImageRectangle", BindingFlags.Instance | BindingFlags.NonPublic);
                return (Rectangle)ppiImageRect.GetValue(pbxImage, null);
            }
            return new Rectangle(0, 0, 1, 1);
        }



        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            Bitmap bmp = (Bitmap)pictureBox1.Image;
            try
            {
                Color pointColor = bmp.GetPixel(e.X, e.Y);
                X_Text.Text = e.X.ToString();
                Y_Text.Text = e.Y.ToString();
                R_Text.Text = pointColor.R.ToString();
                G_Text.Text = pointColor.G.ToString();
                B_Text.Text = pointColor.B.ToString();
                RGBBOX.BackColor = pointColor;
            }
            catch
            {

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Bitmap bmp = (Bitmap)pictureBox1.Image;
            try
            {
                int X = Convert.ToInt32(X_Text.Text);
                int Y= Convert.ToInt32(Y_Text.Text);
                Color pointColor = bmp.GetPixel(X, Y);

                R_Text.Text = pointColor.R.ToString();
                G_Text.Text = pointColor.G.ToString();
                B_Text.Text = pointColor.B.ToString();
                RGBBOX.BackColor = pointColor;
            }
            catch
            {

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
           
                RGBBOX.BackColor = Color.FromArgb(Convert.ToInt32(R_Text.Text), Convert.ToInt32(G_Text.Text), Convert.ToInt32(B_Text.Text)); ;
            }
            catch
            {

            }
        }
    }
}
