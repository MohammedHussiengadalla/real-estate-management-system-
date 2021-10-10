using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml;

namespace project
{
    public partial class rate__employee : Form
    {

        public rate__employee()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            bool r = false;
            int sum = 0;
            int cont;

            if (textBox1.Text == "")
            {
                MessageBox.Show("please enter rate!!!");
            }
            else
            {

                string rate = textBox1.Text;
                if (Int32.Parse(rate) > 10 || Int32.Parse(rate) < 0)
                {
                    MessageBox.Show("please enter rate between 0 , 10!!!");
                }
                else
                {
                    string employee_name2 = combox_emp.SelectedItem.ToString();
                    if (!File.Exists("rates.xml"))
                    {

                        XmlWriter w = XmlWriter.Create("rates.xml");
                        w.WriteStartDocument();
                        w.WriteStartElement("table");
                        w.WriteStartElement("information");

                        w.WriteStartElement("officer");
                        w.WriteString(employee_name2);
                        w.WriteEndElement();

                        w.WriteStartElement("customer_rate");
                        w.WriteString(rate);
                        w.WriteEndElement();

                        w.WriteEndElement();
                        w.WriteEndElement();
                        w.WriteEndDocument();
                        w.Close();

                    }
                    else
                    {
                        try
                        {


                            XmlDocument doc = new XmlDocument();
                            doc.Load("rates.xml");
                            XmlNodeList list = doc.GetElementsByTagName("information");
                            for (int i = 0; i < list.Count; i++)
                            {
                                XmlNodeList child = list[i].ChildNodes;
                                bool x = true;
                                if (employee_name2 == child[0].InnerText)
                                {

                                    XmlElement no = doc.CreateElement("customer_rate");
                                    no.InnerText = rate;
                                    list[i].AppendChild(no);
                                    doc.Save("rates.xml");




                                    x = false;
                                    MessageBox.Show("rate of this employee added successfully!!!!!!");


                                }
                                else
                                {
                                    XmlElement newelement = doc.CreateElement("information");
                                    XmlElement noo = doc.CreateElement("employee");
                                    noo.InnerText = employee_name2;
                                    newelement.AppendChild(noo);

                                    noo = doc.CreateElement("customer_rate");
                                    noo.InnerText = rate;
                                    newelement.AppendChild(noo);

                                    doc.Load("rates.xml");
                                    XmlElement root = doc.DocumentElement;
                                    root.AppendChild(newelement);
                                    doc.Save("rates.xml");

                                }
                                break;
                            }
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("choose id,then click on this button!!!!!");
                        }








                    }

                }
            }



        }

        private void rate__employee_Load(object sender, EventArgs e)
        {
            string customer_username="";
            string customer_id="";

            combox_emp.Items.Clear();
            //to get username
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("log.xml");
            XmlNodeList nodeL = xmlDoc.GetElementsByTagName("user");
            for (int i = 0; i < nodeL.Count; i++)
            {
                XmlNodeList child = nodeL[i].ChildNodes;
                customer_username = child[0].InnerText;
            }


            //to get id customer from login
            XmlDocument xmlDoc1 = new XmlDocument();
            xmlDoc1.Load("log_in.xml");
            XmlNodeList nodeL1 = xmlDoc1.GetElementsByTagName("customer");
            for (int i = 0; i <= nodeL.Count; i++)
            {
                XmlNodeList child = nodeL1[i].ChildNodes;
                if (customer_username == child[4].InnerText)
                {
                    customer_id = child[0].InnerText;
                    break;
                }
            }

            //to load combobox by customer id 
            xmlDoc = new XmlDocument();
            xmlDoc.Load("flats.xml");
            nodeL = xmlDoc.GetElementsByTagName("flat");
            for (int i = 0; i < nodeL.Count; i++)
            {

                XmlNodeList child = nodeL[i].ChildNodes;
                if (customer_id == child[1].InnerText && child[7].InnerText == "false")
                {
                    string ss = child[2].InnerText;
                    combox_emp.Items.Add(ss);
                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            costomer_work_system c = new costomer_work_system();
            c.Show();
        }
    }
}
