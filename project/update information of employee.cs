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
    public partial class update_information_of_employee : Form
    {
        public update_information_of_employee()
        {
            InitializeComponent();
        }

        private void update_information_of_employee_Load(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("the id of flat you need to do update.xml");
            XmlNodeList list = doc.GetElementsByTagName("id");
            String id = list[0].InnerText;

            textBox1.Enabled = false;
            textBox1.Text = id;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                MessageBox.Show("enter the name of this employee ,please");
            }
            else
            {


                String id = textBox1.Text;
                XmlDocument doc = new XmlDocument();
                doc.Load("log_in.xml");
                XmlNodeList list = doc.GetElementsByTagName("officer");
                for (int i = 0; i < list.Count; i++)
                {
                    XmlNodeList ch = list[i].ChildNodes;
                    if (ch[0].InnerText == id)
                    {
                        ch[1].InnerText = textBox2.Text;
                        doc.Save("log_in.xml");
                        MessageBox.Show("the update is success!!");
                        this.Hide();
                        delete_employee a = new delete_employee();
                        a.Show();
                        break;
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            delete_employee a = new delete_employee();
            a.Show();
        }
    }
}
