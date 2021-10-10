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
    public partial class customer_work : Form
    {
        public customer_work()
        {
            InitializeComponent();


        }
        List<Panel> panelform = new List<Panel>();
       

        private void button1_Click(object sender, EventArgs e)
        {
            welcome_user1.Hide();
            view1.Hide();
           
            ads1.Show();
            ads1.BringToFront(); 

        }

        private void customer_work_Load(object sender, EventArgs e)
        {
            welcome_user1.Show();
            welcome_user1.BringToFront();
            view1.Hide();
            ads1.Hide();
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            welcome_user1.Hide();
            ads1.Hide();
           
         
            view1.Show();
            view1.BringToFront();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            welcome_user1.Hide();
            ads1.Hide();
            view1.Hide();
          
        }

        
    }
    
}

