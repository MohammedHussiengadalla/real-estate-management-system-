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
    public partial class update : Form
    {
        public update()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "" || textBox4.Text == "")
            {
                MessageBox.Show("please fill all information!!!!");
            }else
            {
                XmlDocument doc = new XmlDocument();
                doc.Load("flats.xml");
                XmlNodeList list = doc.GetElementsByTagName("flat");
                for (int i = 0; i < list.Count; i++)
                {
                    XmlNodeList ch = list[i].ChildNodes;
                    if (ch[0].InnerText == textBox1.Text)
                    {
                        ch[4].InnerText = textBox3.Text;
                        ch[3].InnerText = textBox2.Text;
                        ch[5].InnerText = textBox4.Text;
                        if (radioButton2.Checked == true)
                        {
                            ch[6].InnerText = "sell";
                        }
                        else if (radioButton1.Checked == true)
                        {
                            ch[6].InnerText = "rental";
                        }
                        if (radioButton3.Checked == true)
                            ch[7].InnerText = "true";
                        else
                            ch[7].InnerText = "false";
                        
                        if(ch[7].InnerText=="false")
                        {
                            String id = ch[2].InnerText;
                            XmlDocument dc = new XmlDocument();
                            dc.Load("log_in.xml");
                            XmlNodeList li = dc.GetElementsByTagName("officer");
                            for(int j=0;j<li.Count;j++)
                            {
                                XmlNodeList h = li[j].ChildNodes;
                                if(h[0].InnerText==id)
                                {
                                    int no = Int32.Parse(h[2].InnerText);
                                    no--;
                                    h[2].InnerText = no.ToString() ;
                                    dc.Save("log_in.xml");
                                    break;
                                }
                            }
                            
                        }
                        MessageBox.Show("the information is changed successfully!!!!");
                        this.Hide();
                        work_of_employee a = new work_of_employee();
                        a.Show();
                        break;
                    }
                }
                doc.Save("flats.xml");

            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
           

            
        }

        private void update_Load(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            XmlDocument doc = new XmlDocument();
            doc.Load("the id of flat you need to do update.xml");
            XmlNodeList list = doc.GetElementsByTagName("id");
            String f_id = list[0].InnerText;
            textBox1.Text = f_id;
            
            
            textBox3.Enabled = false;
             doc = new XmlDocument();
            doc.Load("flats.xml");
            list = doc.GetElementsByTagName("flat");
            for (int i = 0; i < list.Count; i++)
            {
                XmlNodeList ch = list[i].ChildNodes;
                if (ch[0].InnerText == textBox1.Text)
                {
                    textBox3.Text = ch[4].InnerText;
                    textBox2.Text = ch[3].InnerText;
                    textBox4.Text = ch[5].InnerText;
                    if(ch[6].InnerText=="sell")
                    {
                        radioButton2.Checked = true;
                    }
                    else
                    {
                        radioButton1.Checked = true;
                    }
                        radioButton3.Checked = true;
                   
                    break;
                }
            }

            

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            update_information_of_flat a = new update_information_of_flat();
            a.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
