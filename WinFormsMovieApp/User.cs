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
    public partial class User : Form
    {
        DataQuery sql = new DataQuery();
        public string userNameForm;
        public User()
        {
            InitializeComponent();
        }

        private void User_Load(object sender, EventArgs e)
        {
            label1.Text = userNameForm;
            sql.ConnectSql();
            sql.printData($"SELECT movie_name, order_time, order_seat FROM Users INNER JOIN Orders ON Users.user_name = '{userNameForm}' AND Users.user_name = Orders.user_name");
            for(int i = 0; i < sql.data.Rows.Count; i++)
            {
                dataGridView1.Rows.Add(sql.data.Rows[i][0].ToString(), sql.data.Rows[i][1].ToString(), sql.data.Rows[i][2].ToString());
            }
            sql.disconnect();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count > 0)
            {
                DialogResult cancel = MessageBox.Show("Bạn có muốn hủy vé không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (cancel == DialogResult.Yes)
                {
                    sql.ConnectSql();
                    foreach(DataGridViewRow item in this.dataGridView1.SelectedRows)
                    {
                        sql.deleteData($"DELETE FROM Orders WHERE movie_name = '{item.Cells[0].Value}' AND order_time = '{item.Cells[1].Value}' AND order_seat = '{item.Cells[2].Value}'");
                    }
                    sql.disconnect();
                    MessageBox.Show("Đã hủy vé thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    Order.ActiveForm.Close();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn chỗ ngồi bạn muốn hủy!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
