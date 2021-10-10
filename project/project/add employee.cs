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
    public partial class add_employee : Form
    {
        public add_employee()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("please enter name of this employee ,then click on this button!!");
            }
            else
            {


                int i;
                Random slumpGenerator = new Random();
                i = slumpGenerator.Next(0, 1000000);
                string id = i.ToString();
                string name = textBox1.Text;


                if (!File.Exists("log_in.xml"))
                {
                    XmlWriter wr = XmlWriter.Create("log_in.xml");

                    wr.WriteStartDocument();
                    wr.WriteStartElement("table");
                    wr.WriteStartElement("officer");

                    wr.WriteStartElement("id");
                    wr.WriteString(id);
                    wr.WriteEndElement();

                    wr.WriteStartElement("name");
                    wr.WriteString(name);
                    wr.WriteEndElement();

                    wr.WriteStartElement("no");
                    wr.WriteString((0).ToString());
                    wr.WriteEndElement();

                    wr.WriteStartElement("rate");
                    wr.WriteString((0.0).ToString());
                    wr.WriteEndElement();

                    wr.WriteEndElement();
                    wr.WriteEndElement();
                    wr.WriteEndDocument();


                    wr.Close();
                }

                //  when Append employee
                else
                {
                    XmlDocument doc = new XmlDocument();
                    XmlElement append = doc.CreateElement("officer");



                    XmlElement d = doc.CreateElement("id");
                    d.InnerText = id;
                    append.AppendChild(d);

                    d = doc.CreateElement("name");
                    d.InnerText = name;
                    append.AppendChild(d);

                    d = doc.CreateElement("no");
                    d.InnerText = (0).ToString();
                    append.AppendChild(d);

                    d = doc.CreateElement("rate");
                    d.InnerText = (0.0).ToString();
                    append.AppendChild(d);



                    //load information
                    doc.Load("log_in.xml");
                    XmlElement root = doc.DocumentElement;
                    root.AppendChild(append);

                    doc.Save("log_in.xml");

                }
                MessageBox.Show("new employee added successfully!!! & his id is " + i);
                work_of_admin admin = new work_of_admin();
                admin.Show();
                this.Hide();
            }
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
        //    // add_employee
        //    // 
        //    this.ClientSize = new System.Drawing.Size(282, 253);
        //    this.Name = "add_employee";
        //    this.Load += new System.EventHandler(this.add_employee_Load);
        //    this.ResumeLayout(false);

        //}

        private void add_employee_Load(object sender, EventArgs e)
        {

        }
    }
    }

