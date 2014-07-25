using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CreativityPractice
{
    public partial class bigPictureForm : Form
    {
        public bigPictureForm()
        {
            InitializeComponent();
        }

        private void bigPictureForm_Load(object sender, EventArgs e)
        {
            this.Size = new System.Drawing.Size(pictureBox1.Image.Width + 18, pictureBox1.Image.Height + 35);
        }

        public void addPicture(Bitmap img)
        {
            pictureBox1.Image = img;
            this.Size = new System.Drawing.Size(img.Width + 50, img.Height + 100);
        }
    }
}
