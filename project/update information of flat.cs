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
    public partial class update_information_of_flat : Form
    {
        public update_information_of_flat()
        {
            InitializeComponent();
           
        }

       
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            


        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                String l = comboBox1.SelectedItem.ToString();
                if (comboBox1.Items.Count != 0)
                {
                    XmlWriter wr = XmlWriter.Create("the id of flat you need to do update.xml");
                    wr.WriteStartElement("id");
                    wr.WriteString(l);
                    wr.WriteEndElement();
                    wr.Close();
                    update u = new update();
                    u.Show();
                }
                else
                {
                    MessageBox.Show("there isnot any flat");

                }

                this.Hide();
            }
            catch (Exception)
            {
                MessageBox.Show("Enter the id ,then click on this button!!!!");
            }
            


               
            
           
        }

        private void update_information_of_flat_Load(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("log.xml");
            XmlNodeList list = doc.GetElementsByTagName("username");
            String e_id = list[0].InnerText;
            doc = new XmlDocument();
            doc.Load("flats.xml");
            
            list = doc.GetElementsByTagName("flat");
            for (int i = 0; i < list.Count; i++)
            {
               XmlNodeList ch = list[i].ChildNodes;
                if (ch[2].InnerText == e_id&&ch[7].InnerText=="true")
                {
                    comboBox1.Items.Add(ch[0].InnerText);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            work_of_employee a = new work_of_employee();
            a.Show();
        }
    }
}
