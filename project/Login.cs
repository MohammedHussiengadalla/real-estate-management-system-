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
using System.IO;

namespace project
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
          
          
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string user = enteruse.Text;
            string pass = enterpass.Text;
            string P, U;
            bool z = false;
            XmlDocument doc = new XmlDocument();
            doc.Load("log_in.xml");
            XmlNodeList list = doc.GetElementsByTagName("admin");
            int b = 0;


            XmlNodeList child = list[0].ChildNodes;
            U = child[0].InnerText;
            P = child[1].InnerText;
            if (user == U && pass == P)
            {
                z = true;
                b = 1;
                XmlWriter wr = XmlWriter.Create("log.xml");

                wr.WriteStartElement("user");




                wr.WriteStartElement("username");
                wr.WriteString(user);
                wr.WriteEndElement();

                wr.WriteStartElement("password");
                wr.WriteString(pass);
                wr.WriteEndElement();
                wr.WriteEndElement();

                wr.WriteEndDocument();


                wr.Close();
                work_of_admin a = new work_of_admin();
                a.Show();
                this.Hide();
            }



            else if (z == false)
            {
                list = doc.GetElementsByTagName("officer");

                for (int i = 0; i < list.Count; i++)
                {

                    child = list[i].ChildNodes;
                    U = child[0].InnerText;
                    P = child[1].InnerText;
                    if (user == U && pass == P)
                    {
                        z = true;
                        b = 1;
                        XmlWriter wr = XmlWriter.Create("log.xml");

                        wr.WriteStartElement("user");




                        wr.WriteStartElement("username");
                        wr.WriteString(user);
                        wr.WriteEndElement();

                        wr.WriteStartElement("password");
                        wr.WriteString(pass);
                        wr.WriteEndElement();
                        wr.WriteEndElement();

                        wr.WriteEndDocument();


                        wr.Close();
                        work_of_admin f2 = new work_of_admin();
                        f2.Show();
                        this.Hide();
                        break;

                    }


                }
            }
            if (b == 0)
            {
                MessageBox.Show("id or name is incorrect!!!");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void enterpass_TextChanged(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {
          
        }
    }
}
