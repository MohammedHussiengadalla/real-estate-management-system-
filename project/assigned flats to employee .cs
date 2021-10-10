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
    public partial class assigned_flats_to_employee : Form
    {
        public assigned_flats_to_employee()
        {
            InitializeComponent();
        }

        private void assigned_flats_to_employee_Load(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("flats.xml");
            XmlNodeList list = doc.GetElementsByTagName("flat");
            for(int i=0;i<list.Count;i++)
            {
                XmlNodeList ch = list[i].ChildNodes;
                if(ch[2].InnerText==""&&ch[7].InnerText=="true")
                comboBox1.Items.Add(ch[0].InnerText);
            }

            doc = new XmlDocument();
            doc.Load("log_in.xml");
             list = doc.GetElementsByTagName("officer");
            for (int i = 0; i < list.Count; i++)
            {
                XmlNodeList ch = list[i].ChildNodes;
                if(Convert.ToInt32(ch[2].InnerText)<5)
                comboBox2.Items.Add(ch[0].InnerText);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {


                XmlDocument doc = new XmlDocument();
                doc.Load("flats.xml");
                XmlNodeList list = doc.GetElementsByTagName("flat");
                String idf = comboBox1.SelectedItem.ToString();
                String ide = comboBox2.SelectedItem.ToString();
                for (int i = 0; i < list.Count; i++)
                {
                    XmlNodeList ch = list[i].ChildNodes;
                    if (idf == ch[0].InnerText)
                    {
                        ch[2].InnerText = ide;
                        break;
                    }

                }
                doc.Save("flats.xml");
                doc = new XmlDocument();
                doc.Load("log_in.xml");
                list = doc.GetElementsByTagName("officer");
                for (int i = 0; i < list.Count; i++)
                {
                    XmlNodeList ch = list[i].ChildNodes;
                    if (ide == ch[0].InnerText)
                    {
                        int d = Convert.ToInt32(ch[2].InnerText);
                        d++;
                        ch[2].InnerText = d.ToString();
                        break;
                    }
                }
                doc.Save("log_in.xml");
                MessageBox.Show("assign this flat to this employee is success!!");
                work_of_admin a = new work_of_admin();
                a.Show();
                this.Hide();
            }catch(Exception)
            {
                MessageBox.Show("please choose id of flat & id of employee ,then click on this button!!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            work_of_admin a = new work_of_admin();
            a.Show();
        }
    }
}
