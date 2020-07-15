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
    public partial class Movie : Form
    {
        public string userName;
        List<Control> ControlList = new List<Control>();
        public Movie()
        {
            InitializeComponent();
        }

        private void Movie_Load(object sender, EventArgs e)
        {
            string[] splitUserName = userName.Trim().Split(' ');
            string lastName = splitUserName[splitUserName.Length - 1];
            nameToolStripMenuItem.Text += lastName;
        }

        private void đăngXuấtToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Movie.ActiveForm.Close();
        }

        private void chiTiếtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using(User userDashboard = new User())
            {
                userDashboard.userNameForm = userName;
                userDashboard.ShowDialog();
            }
        }
        //Get all controls in Movie form
        private void GetAllControls(Control container)
        {
            foreach (Control c in container.Controls)
            {
                GetAllControls(c);
                if (c is Label)
                {
                    ControlList.Add(c);
                }
            }
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string nameLabel = button.Name;
            nameLabel = $"label{Convert.ToInt32(nameLabel.Substring(6)) + 1}";
            using (Order order = new Order())
            {
                order.getUserName = userName;
                GetAllControls(this);
                foreach(var item in ControlList)
                {
                    if(item.GetType().Equals(typeof(Label)) && item.Name == nameLabel)
                    {
                        if(item.Name == nameLabel)
                        {
                            order.header = item.Text;
                            break;
                        }
                    }
                }
                order.ShowDialog();
            }
        }
    }
}
