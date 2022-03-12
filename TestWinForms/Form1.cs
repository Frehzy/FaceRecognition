using FaceRecognition;
using FaceRecognition.Enums;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace TestWinForms
{
    public partial class Form1 : Form
    {
        public DetectFace DetectFace { get; private set; }

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            comboBox1.DataSource = WebcamHelper.TakeAllWebCamera();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DetectFace = new DetectFace(comboBox1.SelectedIndex, pictureBox2, 0.05, 1280, 720, MethodTypeEnum.Sync);
            if (comboBox1.SelectedIndex >= 0)
            {
                DetectFace.Start();
                timer1.Start();
            }
        }

        private void button3_Click(object sender, EventArgs e) =>
            DetectFace.AddFace(textBox1.Text, pictureBox1.Image);

        private void button2_Click(object sender, EventArgs e) =>
            pictureBox1.Image = DetectFace.ScreenFace();

        private void button4_Click(object sender, EventArgs e)
        {
            DetectFace.Stop();
            DetectFace.ClearAllFace();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            string findname = DetectFace.FoundFace?.Name;
            label1.Text = findname;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            if (ofd.ShowDialog() == DialogResult.OK)
                pictureBox1.Image = new Bitmap(ofd.FileName);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DetectFace?.Dispose();
        }
    }
}
