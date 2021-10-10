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
    public partial class view_favourite_list : Form
    {
        public view_favourite_list()
        {
            InitializeComponent();
        }

        private void view_favourite_list_Load(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            XmlDocument doc = new XmlDocument();
            doc.Load("log.xml");
            XmlNodeList list = doc.GetElementsByTagName("username");
            String us = list[0].InnerText;

            doc = new XmlDocument();
            doc.Load("log_in.xml");
            list = doc.GetElementsByTagName("customer");
            XmlNodeList favourite=null;
            for (int i=0;i<list.Count;i++)
            {
                XmlNodeList ch = list[i].ChildNodes;
                if(us==ch[4].InnerText)
                {
                     favourite = ch[6].ChildNodes;
                    break;
                }
            }

            XmlDocument d = new XmlDocument();
            d.Load("flats.xml");
            XmlNodeList li = d.GetElementsByTagName("flat");
            for(int i=0;i<li.Count;i++)
            {
                XmlNodeList c = li[i].ChildNodes;
                for(int j=0;j<favourite.Count;j++)
                {
                    if(favourite[j].InnerText==c[0].InnerText && c[7].InnerText == "true")
                    {
                        comboBox1.Items.Add(c[0].InnerText);

                        if (dataGridView1.ColumnCount==0)
                        {
                            dataGridView1.Columns.Add("id", c[0].Name);
                            dataGridView1.Columns.Add("description", c[3].Name);
                            dataGridView1.Columns.Add("price", c[4].Name);
                            dataGridView1.Columns.Add("location", c[5].Name);
                            dataGridView1.Columns.Add("status", c[6].Name);

                        }
                        dataGridView1.Rows.Add(new string[] { c[0].InnerText,c[3].InnerText, c[4].InnerText ,
                        c[5].InnerText,c[6].InnerText});
                    }
                }
            }
            


            customer_work a = new customer_work();
            a.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            try
            {
                String id = comboBox1.SelectedItem.ToString();
                XmlDocument doc = new XmlDocument();
                doc.Load("log.xml");
                XmlNodeList list = doc.GetElementsByTagName("username");
                String us = list[0].InnerText;
                doc = new XmlDocument();
                doc.Load("log_in.xml");
                list = doc.GetElementsByTagName("customer");
                for (int i = 0; i < list.Count; i++)
                {
                    XmlNodeList ch = list[i].ChildNodes;
                    if (ch[4].InnerText == us)
                    {
                        XmlNodeList fa = ch[6].ChildNodes;
                        for (int j = 0; j < fa.Count; j++)
                        {
                            if (id == fa[j].InnerText)
                            {
                                ch[6].RemoveChild(fa[j]);
                                doc.Save("log_in.xml");
                                MessageBox.Show("deleted successfully!!!!!!");
                                this.Hide();
                                break;
                            }
                        }


                    }
                }

            }
                catch(Exception)
                {
                    MessageBox.Show("please, Enter id of flat you want to delete ,then click on this button!");

                }
        }
    }
}
