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
        DataQuery sql = new DataQuery();
        List<Control> listControl = new List<Control> { };
        public string getUserName;
        public Order()
        {
            InitializeComponent();
        }
        private void GetAllControls(Control container)
        {
            foreach (Control c in container.Controls)
            {
                GetAllControls(c);
                if (c is CheckBox)
                {
                    listControl.Add(c);
                }
            }
        }
        private void Order_Load(object sender, EventArgs e)
        {
            label2.Text = header;
            GetAllControls(this);
            sql.ConnectSql();
            sql.printData($"SELECT movie_order FROM Movie WHERE movie_name = '{header}'");
            foreach(var item in listControl)
            {
                if(item.GetType().Equals(typeof(CheckBox)))
                {
                    for(int i = 0; i < sql.data.Rows.Count; i++)
                    {
                        if(item.Text == sql.data.Rows[i][0].ToString())
                        {
                            item.BackColor = Color.Red;
                            item.Enabled = false;
                        }
                    }
                }
            }
            sql.disconnect();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(comboBox1.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn khung giờ của bộ phim!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboBox1.Focus();
                return;
            }
            bool order = false;
            sql.ConnectSql();
            foreach(var item in listControl)
            {
                if(item.GetType().Equals(typeof(CheckBox)))
                {
                    if(((CheckBox)item).Checked == true)
                    {
                        order = true;
                        sql.addData("Movie", $"{getUserName}", $"{header}", $"{comboBox1.Text}", $"{item.Text}");
                    }
                }
            }
            sql.disconnect();
            if(!order)
            {
                MessageBox.Show("Vui lòng chọn chỗ ngồi!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            MessageBox.Show("Bạn đã đặt chỗ thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Order_Load(sender, e);
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
