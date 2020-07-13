using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsMovieApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using(Movie movieForm = new Movie()) {
                movieForm.userName = textBox1.Text;
                movieForm.ShowDialog();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult closing = MessageBox.Show("Bạn có muốn thoát khỏi chương trình không?", "Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            e.Cancel = (closing == DialogResult.Yes) ? false : true;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.MaxLength = 15;
            textBox2.PasswordChar = '●';
            checkBox1.Checked = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.MaxLength = 20;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.PasswordChar = (checkBox1.Checked) ? '\0' : '●';
        }
    }
}
