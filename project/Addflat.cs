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
    public partial class Addflat : Form
    {
        public Addflat()
        {
            InitializeComponent();
        }

        private void Addflat_Load(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            XmlDocument xmlDoc = new XmlDocument();
            XmlDocument xmlD = new XmlDocument();
            xmlD.Load("log.xml");
            XmlNodeList nodeL = xmlD.DocumentElement.SelectNodes("/user");
            XmlNodeList child = nodeL[0].ChildNodes;
            String us = child[0].InnerText;
            String pass = child[1].InnerText;
            xmlDoc.Load("log_in.xml");

            XmlNodeList nodeList = xmlDoc.DocumentElement.SelectNodes("/table/customer");

            Flats f = new Flats();
            foreach (XmlNode node in nodeList)
            {
                if (node.SelectSingleNode("username").InnerText == us &&
                        node.SelectSingleNode("password").InnerText == pass)
                {
                    f.customerid = node.SelectSingleNode("Id").InnerText;
                }
            }
            try
            {
                if (textBox1.Text == "" || textBox3.Text == "" || textBox4.Text == "")
                    MessageBox.Show("check on your information ,please");
                else
                {


                    string j = textBox1.Text;
                    f.Price = Int32.Parse(j);
                    f.flatstat = comboBox1.SelectedItem.ToString();
                    f.FlatLocation = textBox3.Text;
                    f.FlatDesc = textBox4.Text;
                    Random slor = new Random();
                    int g = slor.Next(0, 1000000);
                    f.FlatID = g.ToString();
                    if (!File.Exists("flats.xml"))
                    {
                        XmlWriter w = XmlWriter.Create("flats.xml");
                        w.WriteStartDocument();
                        w.WriteStartElement("table");
                        w.WriteStartElement("flat");

                        w.WriteStartElement("f_id");
                        w.WriteString(f.FlatID);
                        w.WriteEndElement();

                        w.WriteStartElement("c_id");
                        w.WriteString(f.customerid);
                        w.WriteEndElement();

                        w.WriteStartElement("e_id");
                        w.WriteString("");
                        w.WriteEndElement();

                        w.WriteStartElement("flat_description");
                        w.WriteString(f.FlatDesc);
                        w.WriteEndElement();

                        w.WriteStartElement("flat_price");
                        w.WriteString(f.Price.ToString());
                        w.WriteEndElement();

                        w.WriteStartElement("flat_location");
                        w.WriteString(f.FlatLocation);
                        w.WriteEndElement();

                        w.WriteStartElement("flat_status");
                        w.WriteString(f.flatstat);
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
                        no.InnerText = f.FlatID;
                        flat.AppendChild(no);

                        no = doc.CreateElement("c_id");
                        no.InnerText = f.customerid;
                        flat.AppendChild(no);

                        no = doc.CreateElement("e_id");
                        no.InnerText = "";
                        flat.AppendChild(no);

                        no = doc.CreateElement("flat_description");
                        no.InnerText = f.FlatDesc;
                        flat.AppendChild(no);

                        no = doc.CreateElement("flat_price");
                        no.InnerText = f.Price.ToString();
                        flat.AppendChild(no);

                        no = doc.CreateElement("flat_location");
                        no.InnerText = f.FlatLocation;
                        flat.AppendChild(no);

                        no = doc.CreateElement("flat_status");
                        no.InnerText = f.flatstat;
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
                    MessageBox.Show("sussefully addede!!!");
                    costomer_work_system c = new costomer_work_system();
                    c.Show();
                    this.Hide();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("check your information ,please!!");
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            costomer_work_system c = new costomer_work_system();
            c.Show();
        }
    }
}
