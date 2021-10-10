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
    public partial class customer_login : Form
    {
        public customer_login()
        {
            InitializeComponent();
           
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            regster re = new regster();
            re.Show();
            re.TopMost = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string us = enter_use.Text;
            string pass = enter_pass.Text;
            string U, P;
            bool Z = false;
            XmlDocument doc = new XmlDocument();
            doc.Load("log_in.xml");
            XmlNodeList list = doc.GetElementsByTagName("customer");
            for (int i = 0; i < list.Count; i++)
            {

                XmlNodeList child = list[i].ChildNodes;
                U = child[4].InnerText;
                P = child[5].InnerText;
                if (us == U&&pass==P)
                {
                    Z = true;

                    customer_work w = new customer_work();
                    w.Show();
                    w.TopMost = true;
                    customer_login c = new customer_login();
                    XmlWriter wr = XmlWriter.Create("log.xml");
                    wr.WriteStartElement("user");
                    wr.WriteStartElement("username");
                    wr.WriteString(us);
                    wr.WriteEndElement();
                    wr.WriteStartElement("password");
                    wr.WriteString(pass);
                    wr.WriteEndElement();

                    wr.WriteEndElement();
                    wr.Close();
                    break;
                }

            }
            if(Z==false)
            {
                MessageBox.Show("username or password is incorrect!!");
            }
            this.Hide();
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void customer_login_Load(object sender, EventArgs e)
        {

        }

        private void enter_use_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
