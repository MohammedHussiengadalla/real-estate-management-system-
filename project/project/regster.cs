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
    public partial class regster : Form
    {
        public regster()
        {
            InitializeComponent();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void namet_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool z = false;
            if (namet.Text == ""|| phonet.Text == ""|| usernamet.Text == ""|| addresst.Text == ""|| passwordt.Text == "")
            {
                MessageBox.Show("fill your information ,please");
                z = true;
            }

            if (z == false)
            {


                try
                {
                    // radom id for customer 
                    int i;
                    Random slumpGenerator = new Random();
                    i = slumpGenerator.Next(0, 1000000);
                    // information about customer


                    string id = i.ToString();


                    string name = namet.Text;
                    string phone = phonet.Text;

                    string use = usernamet.Text;

                    string address = addresst.Text;

                    string password = passwordt.Text;

                    //save in inforamation in file "log_in.xml"
                    if (!File.Exists("log_in.xml"))
                    {
                        XmlWriter wr = XmlWriter.Create("log_in.xml");

                        wr.WriteStartDocument();
                        wr.WriteStartElement("table");
                        wr.WriteStartElement("customer");

                        wr.WriteStartElement("Id");
                        wr.WriteString(id);
                        wr.WriteEndElement();

                        wr.WriteStartElement("Name");
                        wr.WriteString(name);
                        wr.WriteEndElement();

                        wr.WriteStartElement("Address");
                        wr.WriteString(address);
                        wr.WriteEndElement();

                        wr.WriteStartElement("phone");
                        wr.WriteString(phone);
                        wr.WriteEndElement();

                        wr.WriteStartElement("username");
                        wr.WriteString(use);
                        wr.WriteEndElement();

                        wr.WriteStartElement("password");
                        wr.WriteString(password);
                        wr.WriteEndElement();

                        wr.WriteStartElement("favouritelist");
                        wr.WriteEndElement();

                        wr.WriteEndElement();
                        wr.WriteEndElement();
                        wr.WriteEndDocument();


                        wr.Close();
                    }

                    //  when Append customer
                    else
                    {
                        XmlDocument doc = new XmlDocument();
                        doc.Load("log_in.xml");
                        XmlNodeList list = doc.GetElementsByTagName("customer");

                        for (int j = 0; j < list.Count; j++)
                        {
                            XmlNodeList ch = list[j].ChildNodes;
                            if (ch[4].InnerText == use)
                            {
                                z = true;
                                break;
                            }
                        }
                        if (z == false)
                        {
                            doc = new XmlDocument();
                            XmlElement append = doc.CreateElement("customer");

                            XmlElement d = doc.CreateElement("Id");
                            d.InnerText = id;
                            append.AppendChild(d);

                            d = doc.CreateElement("Name");
                            d.InnerText = name;
                            append.AppendChild(d);

                            d = doc.CreateElement("Address");
                            d.InnerText = address;
                            append.AppendChild(d);

                            d = doc.CreateElement("phone");
                            d.InnerText = phone;
                            append.AppendChild(d);

                            d = doc.CreateElement("username");
                            d.InnerText = use;
                            append.AppendChild(d);

                            d = doc.CreateElement("password");
                            d.InnerText = password;
                            append.AppendChild(d);

                            d = doc.CreateElement("favouritelist");
                            d.InnerText = "";
                            append.AppendChild(d);

                            //load information in file 
                            doc.Load("log_in.xml");
                            XmlElement root = doc.DocumentElement;
                            root.AppendChild(append);

                            doc.Save("log_in.xml");

                        }
                        else
                            MessageBox.Show("username is repeated,please enter another one!!!!");

                    }
                    if (z == false)
                    {
                        MessageBox.Show("new customer added successfully!!!!");
                        regster n = new regster();
                        n.Hide();
                    }
                    

                }
                catch (Exception)
                {
                    MessageBox.Show("fill your information ,please");
                    regster n = new regster();
                    n.Hide();
                }
            }
        }
    }
}
