using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
namespace project
{
    public partial class view : UserControl
    {
        public view()
        {
            InitializeComponent();
        }
        private void button8_Click(object sender, EventArgs e)
        {
           
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void view_2_Paint(object sender, PaintEventArgs e)
        {
        }

        private void listofloction_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void view_Load(object sender, EventArgs e)
        {
            checkedListBox1.Items.Clear();
            dataGridView1.Rows.Clear();
            listofloction.Items.Clear();
            XmlDocument doc = new XmlDocument();
            doc.Load("log.xml");
            XmlNodeList list = doc.GetElementsByTagName("username");
            String us = list[0].InnerText;
            XmlDocument d = new XmlDocument();
            d.Load("log_in.xml");
            XmlNodeList li = d.GetElementsByTagName("customer");
            String city = "";
            for (int i = 0; i < li.Count; i++)
            {
                XmlNodeList c = li[i].ChildNodes;
                if (c[4].InnerText == us)
                {
                    city = c[2].InnerText;
                }
            }
            doc = new XmlDocument();
            doc.Load("flats.xml");
            list = doc.GetElementsByTagName("flat");
            bool z = false;
            for (int i = 0; i < list.Count; i++)
            {
                XmlNodeList ch = list[i].ChildNodes;
                if (ch[7].InnerText == "true" && city == ch[5].InnerText)
                {
                    checkedListBox1.Items.Add(ch[0].InnerText);
                    z = true;
                    if (dataGridView1.ColumnCount == 0)
                    {
                        dataGridView1.Columns.Add("id", ch[0].Name);
                        dataGridView1.Columns.Add("descrpition", ch[3].Name);
                        dataGridView1.Columns.Add("price", ch[4].Name);
                        dataGridView1.Columns.Add("location", ch[5].Name);
                        dataGridView1.Columns.Add("status", ch[6].Name);
                    }
                    dataGridView1.Rows.Add(new string[]
                    { ch[0].InnerText, ch[3].InnerText, ch[4].InnerText, ch[5].InnerText, ch[6].InnerText });
                }
            }
            if (z == true)
                listofloction.Items.Add(city);
            for (int i = 0; i < list.Count; i++)
            {
                XmlNodeList ch = list[i].ChildNodes;
                if (ch[7].InnerText == "true" && city != ch[5].InnerText)
                {
                    checkedListBox1.Items.Add(ch[0].InnerText);
                    bool a = false;
                    for (int j = 0; j < listofloction.Items.Count; j++)
                    {
                        if (ch[5].InnerText == listofloction.Items[j].ToString())
                        {
                            a = true;
                            break;
                        }
                    }
                    if (a == false)
                    {
                        listofloction.Items.Add(ch[5].InnerText);
                    }
                    else
                    {
                        a = false;
                    }
                    if (dataGridView1.ColumnCount == 0)
                    {
                        dataGridView1.Columns.Add("id", ch[0].Name);
                        dataGridView1.Columns.Add("descrpition", ch[3].Name);
                        dataGridView1.Columns.Add("price", ch[4].Name);
                        dataGridView1.Columns.Add("location", ch[5].Name);
                        dataGridView1.Columns.Add("status", ch[6].Name);
                    }
                    dataGridView1.Rows.Add(new string[]
                    { ch[0].InnerText, ch[3].InnerText, ch[4].InnerText, ch[5].InnerText, ch[6].InnerText });
                }
            }
            d = new XmlDocument();
            d.Load("log_in.xml");
            list = d.GetElementsByTagName("customer");
            
                for(int j=0;j<list.Count;j++)
                {
                    XmlNodeList ch = list[j].ChildNodes;
                    if (ch[4].InnerText ==us)
                    {
                        for (int i = 0; i < checkedListBox1.Items.Count; i++)
                        {
                            XmlNodeList c = ch[6].ChildNodes;
                            for(int k=0;k<c.Count;k++)
                            {
                                if(c[k].InnerText==checkedListBox1.Items[i].ToString())
                                {
                                checkedListBox1.Items.RemoveAt(i);
                                }
                            }
                        }

                    }
                }
               
            
      
        }
        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            String s = "";
            try
            {
                s = listofloction.SelectedItem.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("enter city ,please!!!");
            }
            XmlDocument doc = new XmlDocument();
            doc.Load("flats.xml");
            XmlNodeList list = doc.GetElementsByTagName("flat");
            for (int i = 0; i < list.Count; i++)
            {
                XmlNodeList ch = list[i].ChildNodes;
                if (ch[5].InnerText == s && ch[7].InnerText == "true")
                {
                    if (dataGridView1.ColumnCount == 0)
                    {
                        dataGridView1.Columns.Add("id", ch[0].Name);
                        dataGridView1.Columns.Add("descrpition", ch[3].Name);
                        dataGridView1.Columns.Add("price", ch[4].Name);
                        dataGridView1.Columns.Add("location", ch[5].Name);
                        dataGridView1.Columns.Add("status", ch[6].Name);
                    }
                    dataGridView1.Rows.Add(new string[]
                    { ch[0].InnerText, ch[3].InnerText, ch[4].InnerText, ch[5].InnerText, ch[6].InnerText });
                }
            }
            
        }
        private void button2_Click(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("log.xml");
            XmlNodeList list = doc.GetElementsByTagName("username");
            String us = list[0].InnerText;
            doc = new XmlDocument();
            doc.Load("log_in.xml");
            list = doc.GetElementsByTagName("customer");
            bool z = false;
            for (int i = 0; i < list.Count; i++)
            {
                XmlNodeList ch = list[i].ChildNodes;
                if (ch[4].InnerText == us)
                {
                    for (int j = 0; j < checkedListBox1.Items.Count; j++)
                    {
                        if(checkedListBox1.GetItemChecked(j))
                        {

                            XmlElement node = doc.CreateElement("flatid");
                            node.InnerText = checkedListBox1.Items[j].ToString();
                            ch[6].AppendChild(node);
                            z = true;
                            doc.Save("log_in.xml");
                            this.Hide();
                            MessageBox.Show("add to favourite list successfully !!!!!!!!!");
                        }
                        
                    }
                    break;
                }
            }
            if (z == false)
                MessageBox.Show("please ,click on your favourite flat ,then chick on this button!!");
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
    }
}
