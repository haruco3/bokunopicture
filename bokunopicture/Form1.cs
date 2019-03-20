using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// This is the code for your desktop app.
// Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.

namespace bokunopicture
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.AllowDrop = true;
        }

        public Form1(string img) : this()
        {
            Console.WriteLine(img);
            if (img != string.Empty)
            {
                try
                {
                    pictureBox1.Load(img);
                    scaleImage();
                }
                catch (System.NotSupportedException)
                {
                    MessageBox.Show("Error: File path in unsupported format");
                }
            }
        }

        private void scaleImage()
        {
            // Scale picture to fit inside window if image larger than window
            if (pictureBox1.Image.Width > pictureBox1.Width || pictureBox1.Image.Height > pictureBox1.Height)
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            else
                pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            this.Icon = Icon.FromHandle(bmp.GetHicon());
        }

        private void showButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Load(openFileDialog1.FileName);
                scaleImage();
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
        }

        private void backgroundButton_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.BackColor = colorDialog1.Color;
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_Layout(object sender, LayoutEventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                scaleImage();
            }
        }

        private void pictureBox1_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            pictureBox1.Image = Image.FromFile(files[0]);
            scaleImage();
        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
