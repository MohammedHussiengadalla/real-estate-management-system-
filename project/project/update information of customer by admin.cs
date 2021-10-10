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
    public partial class update_information_of_customer_by_admin : Form
    {
        public update_information_of_customer_by_admin()
        {
            InitializeComponent();
        }

        private void update_information_of_customer_by_admin_Load(object sender, EventArgs e)
        {
            textBox1.Enabled = false;

            XmlDocument doc = new XmlDocument();
            doc.Load("the id of flat you need to do update.xml");
            XmlNodeList list = doc.GetElementsByTagName("id");
            String cid = list[0].InnerText;

            doc = new XmlDocument();
            doc.Load("log_in.xml");
            list = doc.GetElementsByTagName("customer");
            for(int i=0;i<list.Count;i++)
            {
                XmlNodeList ch = list[i].ChildNodes;
                if(cid==ch[0].InnerText)
                {
                    textBox1.Text = cid;
                    textBox2.Text = ch[1].InnerText;
                    textBox3 .Text= ch[2].InnerText;
                    textBox4 .Text= ch[3].InnerText;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "")
            {
                MessageBox.Show("please enter all your information!!");
            }
            else
            {


                XmlDocument doc = new XmlDocument();
                doc.Load("log_in.xml");
                XmlNodeList list = doc.GetElementsByTagName("customer");
                int p;
                bool z = false;
                for (int i = 0; i < list.Count; i++)
                {
                    XmlNodeList ch = list[i].ChildNodes;
                    if (textBox1.Text == ch[0].InnerText)
                    {
                        try
                        {
                            p = Int32.Parse(textBox4.Text);
                            ch[1].InnerText = textBox2.Text;
                            ch[2].InnerText = textBox3.Text;
                            ch[3].InnerText = textBox4.Text;
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("please, Enter phone integer!!");
                            z = true;
                            
                        }
                        
                    }
                }
                if (z == false)
                {


                    doc.Save("log_in.xml");
                    MessageBox.Show("the information of this customer is updated successfully!!!");
                    this.Hide();
                    delete_customer a = new delete_customer();
                    a.Show();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            delete_customer a = new delete_customer();
            a.Show();
        }
    }
}
