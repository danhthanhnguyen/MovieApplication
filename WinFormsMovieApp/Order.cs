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
    public partial class Order : Form
    {
        public string header;
        public Order()
        {
            InitializeComponent();
        }

        private void Order_Load(object sender, EventArgs e)
        {
            label2.Text = header;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bạn đã đặt chỗ thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult closing = MessageBox.Show("Bạn có muốn đặt chỗ tiếp không?", "Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(closing == DialogResult.No)
            {
                Order.ActiveForm.Close();
            }
        }
    }
}
