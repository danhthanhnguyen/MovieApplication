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
            sql.printData($"SELECT movie_name, movie_time, movie_order FROM Users INNER JOIN Movie ON Users.user_name = '{userNameForm}' AND Users.user_name = Movie.user_name");
            for(int i = 0; i < sql.data.Rows.Count; i++)
            {
                dataGridView1.Rows.Add(sql.data.Rows[i][0].ToString(), sql.data.Rows[i][1].ToString(), sql.data.Rows[i][2].ToString());
            }
            sql.disconnect();
        }
    }
}
