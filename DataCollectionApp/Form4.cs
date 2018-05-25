using DataCollectionModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DataCollectionApp
{
    public partial class Form4 : Form
    {
        List<Employee> _employees = new List<Employee>();
        List<Department> _departments = new List<Department>();

        public Form4()
        {
            InitializeComponent();
            FileManager fileManager = new FileManager("база.xml");
            _employees = fileManager.LoadEmployees();
            _departments = fileManager.LoadDepartments();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int f = 0;
            foreach(var i in _employees)
            {
                if (i.FIO == textBox1.Text)
                {
                    if (i.Password == textBox2.Text.GetHashCode())
                    {
                        f = 1;
                        Form1 form1 = new Form1(this.textBox1.Text);
                        form1.ShowDialog();
                    }
                }

            }
            if (f == 0)
            {
                MessageBox.Show("Неверный логин или пароль");
            }
        }
    }
}
