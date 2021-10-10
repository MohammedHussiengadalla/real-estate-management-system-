using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace project
{
    public partial class work_of_admin : Form
    {
        public work_of_admin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            assigned_flats_to_employee a = new assigned_flats_to_employee();
            a.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            delete_or_update_flat d = new delete_or_update_flat();
            d.Show();
            this.Hide();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            add_new_advertise_by_admin a = new add_new_advertise_by_admin();
            a.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            add_employee a = new add_employee();
            a.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            delete_employee d = new delete_employee();
            d.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            delete_customer d = new delete_customer();
            d.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            view_company_s_commission a = new view_company_s_commission();
            a.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            assign_anothar_employee a = new assign_anothar_employee();
            a.Show();
        }
    }
}
