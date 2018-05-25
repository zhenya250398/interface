using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DataCollectionApp
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "txt files (*.txt)|*.txt|Pictures (*.jpg)|*.jpg| Pictures (*.png)|*.png";
            dialog.ShowDialog();
            System.IO.FileStream fs = (System.IO.FileStream)dialog.OpenFile();
            FileInfo file = new FileInfo(fs.Name);
            StreamReader fr = new StreamReader(fs);
            string text = fr.ReadToEnd();
            richTextBox1.Text = Path.GetFullPath(fs.Name);
            string name = Path.GetFileNameWithoutExtension(Path.GetFullPath(fs.Name));
            string ext = Path.GetExtension(Path.GetFullPath(fs.Name));
            label3.Text = name;
            label4.Text = ext;
            DateTime creationDate = File.GetCreationTime(Path.GetFullPath(fs.Name));
            DateTime accessDate = File.GetLastWriteTime(Path.GetFullPath(fs.Name));
            label7.Text = creationDate.ToString();
            label8.Text = accessDate.ToString();
            if (ext.Equals(".txt"))
            {
                label10.Text = text;
                label10.Visible = true;
                label9.Visible = true;
            }
            label1.Visible = true;
            label2.Visible = true;
            label5.Visible = true;
            label6.Visible = true;
            if (ext.Equals(".png") || ext.Equals(".jpg"))
            {
                pictureBox1.Image = Image.FromFile(Path.GetFullPath(fs.Name));
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
