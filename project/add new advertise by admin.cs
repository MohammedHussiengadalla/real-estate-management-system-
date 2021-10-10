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

namespace project
{
    public partial class add_new_advertise_by_admin : Form
    {
        public add_new_advertise_by_admin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("enter all your information,please!!");


            }
            else
            {


                try
                {


                    int price;
                    String flatstatus, c_id = "", flatlocation, flatdesc, f_id;
                    XmlDocument xmlDoc = new XmlDocument();
                    XmlDocument xmlD = new XmlDocument();
                    xmlD.Load("log.xml");
                    XmlNodeList nodeL = xmlD.DocumentElement.SelectNodes("/user");
                    XmlNodeList child = nodeL[0].ChildNodes;
                    String us = child[0].InnerText;


                    price = Int32.Parse(textBox1.Text);
                    flatstatus = comboBox1.SelectedItem.ToString();
                    flatlocation = textBox2.Text;
                    flatdesc = textBox3.Text;
                    Random slor = new Random();
                    int g = slor.Next(0, 1000000);
                    f_id = g.ToString();
                    if (!File.Exists("flats.xml"))
                    {
                        XmlWriter w = XmlWriter.Create("flats.xml");
                        w.WriteStartDocument();
                        w.WriteStartElement("table");
                        w.WriteStartElement("flat");

                        w.WriteStartElement("f_id");
                        w.WriteString(f_id);
                        w.WriteEndElement();

                        w.WriteStartElement("c_id");
                        w.WriteString(us);
                        w.WriteEndElement();

                        w.WriteStartElement("e_id");
                        w.WriteString("");
                        w.WriteEndElement();

                        w.WriteStartElement("flat_description");
                        w.WriteString(flatdesc);
                        w.WriteEndElement();

                        w.WriteStartElement("flat_price");
                        w.WriteString(price.ToString());
                        w.WriteEndElement();

                        w.WriteStartElement("flat_location");
                        w.WriteString(flatlocation);
                        w.WriteEndElement();

                        w.WriteStartElement("flat_status");
                        w.WriteString(flatstatus);
                        w.WriteEndElement();

                        w.WriteStartElement("confirmation");
                        w.WriteString("true");
                        w.WriteEndElement();

                        w.WriteStartElement("reviewlist");
                        w.WriteString("");
                        w.WriteEndElement();

                        w.WriteEndElement();
                        w.WriteEndElement();
                        w.WriteEndDocument();
                        w.Close();
                    }
                    else
                    {
                        XmlDocument doc = new XmlDocument();
                        XmlElement flat = doc.CreateElement("flat");
                        XmlElement no = doc.CreateElement("f_id");
                        no.InnerText = f_id;
                        flat.AppendChild(no);

                        no = doc.CreateElement("c_id");
                        no.InnerText = us;
                        flat.AppendChild(no);

                        no = doc.CreateElement("e_id");
                        no.InnerText = "";
                        flat.AppendChild(no);

                        no = doc.CreateElement("flat_description");
                        no.InnerText = flatdesc;
                        flat.AppendChild(no);

                        no = doc.CreateElement("flat_price");
                        no.InnerText = price.ToString();
                        flat.AppendChild(no);

                        no = doc.CreateElement("flat_location");
                        no.InnerText = flatlocation;
                        flat.AppendChild(no);

                        no = doc.CreateElement("flat_status");
                        no.InnerText = flatstatus;
                        flat.AppendChild(no);

                        no = doc.CreateElement("confirmation");
                        no.InnerText = "true";
                        flat.AppendChild(no);

                        no = doc.CreateElement("reviewlist");
                        no.InnerText = "";
                        flat.AppendChild(no);

                        doc.Load("flats.xml");
                        XmlElement root = doc.DocumentElement;
                        root.AppendChild(flat);
                        doc.Save("flats.xml");
                    }
                    MessageBox.Show("sussefully addeded!!! & id of this flat is " + f_id);
                    this.Hide();
                    work_of_admin a = new work_of_admin();
                    a.Show();
                }
                catch (Exception)
                {
                    MessageBox.Show("enter all your information right,please!!");
                }
            }
        }

        private void add_new_advertise_by_admin_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("rental");
            comboBox1.Items.Add("sell");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            work_of_admin a = new work_of_admin();
            a.Show();
        }

        //private void InitializeComponent()
        //{
        //    this.SuspendLayout();
        //    // 
        //    // add_new_advertise_by_admin
        //    // 
        //    this.ClientSize = new System.Drawing.Size(335, 290);
        //    this.Name = "add_new_advertise_by_admin";
        //    this.Load += new System.EventHandler(this.add_new_advertise_by_admin_Load_1);
        //    this.ResumeLayout(false);

        //}

        private void add_new_advertise_by_admin_Load_1(object sender, EventArgs e)
        {

        }
    }
}
