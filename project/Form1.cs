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

namespace Flats
{
    public partial class add : Form
    {
        public add()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
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
                    f.c_id = node.SelectSingleNode("Id").InnerText;
                }
            }
            

           f.price = Int32.Parse(textBox1.Text);
            f.flatstatus= comboBox1.SelectedItem.ToString();
            f.flatlocation = textBox2.Text;
            f.flatdesc = textBox3.Text;
            Random slor = new Random();
            int g = slor.Next(0, 1000000);
            f.f_id = g.ToString();
            if(!File.Exists("flats.xml"))
            {
                XmlWriter w = XmlWriter.Create("flats.xml");
                w.WriteStartDocument();
                w.WriteStartElement("table");
                w.WriteStartElement("flat");

                w.WriteStartElement("f_id");
                w.WriteString(f.f_id);
                w.WriteEndElement();

                w.WriteStartElement("c_id");
                w.WriteString(f.c_id);
                w.WriteEndElement();

                w.WriteStartElement("e_id");
                w.WriteString("");
                w.WriteEndElement();

                w.WriteStartElement("flat_description");
                w.WriteString(f.flatdesc);
                w.WriteEndElement();

                w.WriteStartElement("flat_price");
                w.WriteString(f.price.ToString());
                w.WriteEndElement();

                w.WriteStartElement("flat_location");
                w.WriteString(f.flatlocation);
                w.WriteEndElement();

                w.WriteStartElement("flat_status");
                w.WriteString(f.flatstatus);
                w.WriteEndElement();

                w.WriteEndElement();
                w.WriteEndElement();
                w.WriteEndDocument();
                w.Close();
            }else
            {
                XmlDocument doc = new XmlDocument();
                XmlElement flat = doc.CreateElement("flat");
                XmlElement no = doc.CreateElement("f_id");
                no.InnerText = f.f_id;
                flat.AppendChild(no);

                no = doc.CreateElement("c_id");
                no.InnerText = f.c_id;
                flat.AppendChild(no);

                no = doc.CreateElement("e_id");
                no.InnerText = "";
                flat.AppendChild(no);

                no = doc.CreateElement("flat_description");
                no.InnerText = f.flatdesc;
                flat.AppendChild(no);

                no = doc.CreateElement("flat_price");
                no.InnerText = f.price.ToString();
                flat.AppendChild(no);

                no = doc.CreateElement("flat_location");
                no.InnerText = f.flatlocation;
                flat.AppendChild(no);

                no = doc.CreateElement("flat_status");
                no.InnerText = f.flatstatus;
                flat.AppendChild(no);

                doc.Load("flats.xml");
                XmlElement root = doc.DocumentElement;
                root.AppendChild(flat);
                doc.Save("flats.xml");
            }
            MessageBox.Show("sussefully addede!!!");
        }
    }
}
