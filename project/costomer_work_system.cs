using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project
{
    public partial class costomer_work_system : Form
    {
        public costomer_work_system()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            view_favourite_list a = new view_favourite_list();
            a.Show();
            this.Hide();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Addflat A = new Addflat();
            A.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            review_list s = new review_list();
            s.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            view_falts c = new view_falts();
            c.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            rate__employee r = new rate__employee();
            r.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            confirm_by_customer a = new confirm_by_customer();
            a.Show();
            this.Hide();

        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            login_main l = new login_main();
            l.Show();
        }
    }
}
