using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using InputFormatter;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            label1.Text = "Hello";
            label2.Text = "Hello";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            String inputedString = textBox1.Text.ToString();
            label1.Text += " " + inputedString;
            label2.Text += label2.Text.ToString().FormatString() + " " + inputedString;

        }
    }
}
