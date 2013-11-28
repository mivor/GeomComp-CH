using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeomComp
{
    public partial class Form1 : Form
    {
        private Image image;

        public Form1()
        {
            InitializeComponent();
            image = new Bitmap(pictureBox.Width, pictureBox.Height); // 250, 250
        }
        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(image, 0, 0);
        }
    }
}
