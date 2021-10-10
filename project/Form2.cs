using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace project
{
    public partial class work_of_employee : Form
    {
        public work_of_employee()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            view_all_assigned_flats v = new view_all_assigned_flats();
            v.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            update_information_of_flat u = new update_information_of_flat();
            u.Show();
            this.Hide();

        }

        private void work_of_employee_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            login_main l = new login_main();
            l.Show();
        }
    }
}
