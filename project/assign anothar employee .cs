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
    public partial class assign_anothar_employee : Form
    {
        public assign_anothar_employee()
        {
            InitializeComponent();
        }

        private void assign_anothar_employee_Load(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("flats.xml");
            XmlNodeList list = doc.GetElementsByTagName("flat");
            for(int i=0;i<list.Count;i++)
            {
                XmlNodeList ch = list[i].ChildNodes;
                if(ch[2].InnerText!=""&&ch[7].InnerText=="true")
                {
                    comboBox1.Items.Add(ch[0].InnerText);
                }
            }
             doc = new XmlDocument();
             doc.Load("log_in.xml");
             list = doc.GetElementsByTagName("officer");
            for (int i = 0; i < list.Count; i++)
            {
                XmlNodeList ch = list[i].ChildNodes;
                if (Int32.Parse(ch[2].InnerText) <5)
                {
                    comboBox2.Items.Add(ch[0].InnerText);
                }
            }
            if(comboBox1.Items.Count==0)
            {
                MessageBox.Show("there is not any flat here!!");
            }
            else if(comboBox2.Items.Count == 0)
            {
                MessageBox.Show("there is not any employee here!!");

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {  

                String id="",idf = comboBox1.SelectedItem.ToString();
                String ide = comboBox2.SelectedItem.ToString();
                XmlDocument doc = new XmlDocument();
                doc.Load("flats.xml");
                XmlNodeList list = doc.GetElementsByTagName("flat");
                for(int i=0;i<list.Count;i++)
                {
                    XmlNodeList ch = list[i].ChildNodes;
                    if(ch[0].InnerText==idf)
                    {
                        id = ch[2].InnerText;
                        ch[2].InnerText = ide;
                        MessageBox.Show("process is successful!!");
                        this.Hide();
                        work_of_admin a = new work_of_admin();
                        a.Show();
                        doc.Save("flats.xml");
                        break;
                    }
                }
                if(id!=ide)
                {
                     doc = new XmlDocument();
                    doc.Load("log_in.xml");
                    list = doc.GetElementsByTagName("officer");
                    for(int i=0;i<list.Count;i++)
                    {
                        XmlNodeList ch = list[i].ChildNodes;
                        if(ch[0].InnerText==id)
                        {
                            int d = Int32.Parse(ch[2].InnerText);
                            d--;
                            ch[2].InnerText = d.ToString();
                        }
                        else if(ch[0].InnerText == ide)
                        {
                            int d = Int32.Parse(ch[2].InnerText);
                            d++;
                            ch[2].InnerText = d.ToString();
                        }
                    }
                    doc.Save("log_in.xml");

                }
            }
            catch(Exception)
            {
                MessageBox.Show("please ,enter all information ,then click on this button!!");
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
        //    // assign_anothar_employee
        //    // 
        //    this.ClientSize = new System.Drawing.Size(282, 253);
        //    this.Name = "assign_anothar_employee";
        //    this.Load += new System.EventHandler(this.assign_anothar_employee_Load_1);
        //    this.ResumeLayout(false);

        //}

        private void assign_anothar_employee_Load_1(object sender, EventArgs e)
        {

        }
    }
}
