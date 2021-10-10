using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project
{
    public partial class login_main : Form
    {

        public login_main()
        {
            InitializeComponent();
            
        }


        Login lo = new Login();
        customer_login cl = new customer_login();

        private void button2_Click(object sender, EventArgs e)
        {
            cl.Show();
           cl.TopMost = true;
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lo.Show();
            lo.TopMost = true;
            this.Hide();
        }
    }
}
