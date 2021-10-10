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
    public partial class review_list : Form
    {
        public review_list()
        {
            InitializeComponent();
        }

        private void review_list_Load(object sender, EventArgs e)
        {
            button3.Visible = false;
            dataGridView1.Visible = false;
            XmlDocument doc = new XmlDocument();
            doc.Load("flats.xml");
            XmlNodeList list = doc.GetElementsByTagName("flat");
            for(int i=0;i<list.Count;i++)
            {
                XmlNodeList ch = list[i].ChildNodes;
                if(ch[7].InnerText=="true")
                {
                    comboBox1.Items.Add(ch[0].InnerText);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            

            try
            {

                String s = comboBox1.SelectedItem.ToString();

                if (textBox1.Text == "")
                {
                    MessageBox.Show("please,enter your review about this flat,then click!!");
                }
                else
                {

                
                XmlDocument doc = new XmlDocument();
                doc.Load("flats.xml");
                XmlNodeList list = doc.GetElementsByTagName("flat");
                    for (int i = 0; i < list.Count; i++)
                    {
                        XmlNodeList ch = list[i].ChildNodes;
                        if (s == ch[0].InnerText)
                        {
                                XmlElement r = doc.CreateElement("review");
                                r.InnerText = textBox1.Text;
                                ch[8].AppendChild(r);
                            doc.Save("flats.xml");
                            MessageBox.Show("review added successfully!!!!");
                            this.Hide();
                            break;
                        }
                    }
                }
            }
            catch(Exception)
            {
                MessageBox.Show("please ,select id of flat ,then click on this button!!!!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool z = false;
            try
            {
                String s = comboBox1.SelectedItem.ToString();
                dataGridView1.Rows.Clear();
                XmlDocument doc = new XmlDocument();
                doc.Load("flats.xml");
                XmlNodeList list = doc.GetElementsByTagName("flat");
                for(int i=0;i<list.Count;i++)
                {
                    XmlNodeList ch = list[i].ChildNodes;
                    if(ch[0].InnerText==s)
                    {
                        XmlNodeList review = ch[8].ChildNodes;
                        for(int j=0;j<review.Count;j++)
                        {
                            if(dataGridView1.ColumnCount==0)
                            {
                                dataGridView1.Columns.Add("reviews", review[0].Name);
                            }
                            z = true;
                            dataGridView1.Rows.Add(new string[] { review[j].InnerText });
                        }
                        break;
                    }
                }
                if(z==true)
                {
                    button3.Visible = true;
                    textBox1.Visible = false;
                    dataGridView1.Visible = true;
                    dataGridView1.Enabled = false;
                    button1.Visible = false;
                    comboBox1.Visible = false;
                    button2.Visible = false;
                }
                else
                {
                    MessageBox.Show("there is not any review about this flat!!!");
                }
               
            }
            catch(Exception)
            {
                MessageBox.Show("please ,select id of flat ,then click on this button!!!!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            costomer_work_system c = new costomer_work_system();
            c.Show();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            costomer_work_system c = new costomer_work_system();
            c.Show();
        }
    }
}
