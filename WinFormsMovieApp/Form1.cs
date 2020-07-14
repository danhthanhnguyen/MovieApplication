using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsMovieApp
{
    public partial class Form1 : Form
    {
        DataQuery sql = new DataQuery();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sql.printData("SELECT user_name, user_password FROM Users");
            sql.disconnect();
            bool userExist = true;
            for(int i = 0; i < sql.data.Rows.Count; i++)
            {
                if(textBox1.Text == sql.data.Rows[i][0].ToString())
                {
                    userExist = true;
                    if (textBox2.Text == sql.data.Rows[i][1].ToString())
                    {
                        using (Movie movieForm = new Movie())
                        {
                            movieForm.userName = textBox1.Text;
                            movieForm.ShowDialog();
                        }
                        break;
                    } else
                    {
                        MessageBox.Show("Bạn nhập sai mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBox2.Clear();
                        textBox2.Focus();
                        break;
                    }
                } else
                {
                    userExist = false;
                }
            }
            if(!userExist)
            {
                MessageBox.Show("Bạn phải đăng ký để tiếp tục!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void Form1_Load(object sender, EventArgs e)
        {
            sql.ConnectSql();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool checkDuplicate = true;
            for(int i = 0; i < sql.data.Rows.Count; i++)
            {
                if(textBox1.Text == sql.data.Rows[i][0].ToString())
                {
                    MessageBox.Show("Tên người dùng đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    checkDuplicate = false;
                    break;
                }

            }
            if(checkDuplicate)
            {
                if (textBox1.Text != "" && textBox2.Text != "")
                {
                    sql.ConnectSql();
                    sql.addData("Users", $"{textBox1.Text}", $"{textBox2.Text}");
                    sql.disconnect();
                    MessageBox.Show("Đăng ký thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin của bạn!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }
}
