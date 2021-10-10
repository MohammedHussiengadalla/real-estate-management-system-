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
    public partial class delete_customer : Form
    {
        public delete_customer()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {


                String s = comboBox1.SelectedItem.ToString();
                XmlDocument doc = new XmlDocument();
                doc.Load("log_in.xml");
                XmlNodeList list = doc.GetElementsByTagName("customer");
                for (int i = 0; i < list.Count; i++)
                {
                    XmlNodeList ch = list[i].ChildNodes;
                    if (ch[0].InnerText == s)
                    {
                        XmlNode parent = list[i].ParentNode;
                        parent.RemoveChild(list[i]);
                        work_of_admin a = new work_of_admin();
                        a.Show();
                        break;
                    }
                }
                doc.Save("log_in.xml");
                doc = new XmlDocument();
                doc.Load("flats.xml");
                list = doc.GetElementsByTagName("flat");
                String ide = "";
                
               
                for (int i=0;i<list.Count;i++)
                {
                    XmlNodeList ch = list[i].ChildNodes;
                    if(s==ch[1].InnerText)
                    {
                        
                        ide = ch[2].InnerText;
                        if (ide != "")
                        {
                            XmlDocument dc = new XmlDocument();
                            dc.Load("log_in.xml");
                            XmlNodeList li = dc.GetElementsByTagName("officer");
                            for (int j = 0; j < li.Count; j++)
                            {
                                XmlNodeList c = li[j].ChildNodes;
                                if (c[0].InnerText == ide)
                                {
                                    int d = Int32.Parse(c[2].InnerText);
                                    d--;
                                    c[2].InnerText = d.ToString();
                                    dc.Save("log_in.xml");
                                    break;
                                }
                            }
                        }
                        XmlNode parent = list[i].ParentNode;
                        parent.RemoveChild(list[i]);
                        i--;
                    }
                }
                doc.Save("flats.xml");








                MessageBox.Show("information of customer deleted successfully!!!");
                this.Hide();
                
            }catch(Exception)
            {
                MessageBox.Show("choose id ,then click on this button!!!");
            }
        }

        private void delete_customer_Load(object sender, EventArgs e)
        {
            dataGridView1.Enabled = false;
            dataGridView1.Rows.Clear();
            XmlDocument doc = new XmlDocument();
            doc.Load("log_in.xml");
            XmlNodeList list = doc.GetElementsByTagName("customer");
            for (int i = 0; i < list.Count; i++)
            {
                XmlNodeList ch = list[i].ChildNodes;
                String id = ch[0].Name;
                String cid = ch[0].InnerText;
                comboBox1.Items.Add(cid);

                String name = ch[1].Name;
                String cname = ch[1].InnerText;
                String address = ch[2].Name;
                String caddress = ch[2].InnerText;
                String phone = ch[3].Name;
                String cphone = ch[3].InnerText;
                if (dataGridView1.ColumnCount == 0)
                {
                    dataGridView1.Columns.Add("id", id);
                    dataGridView1.Columns.Add("name", name);
                    dataGridView1.Columns.Add("address", address);
                    dataGridView1.Columns.Add("phone", phone);
                }
                dataGridView1.Rows.Add(new String[] { cid, cname, caddress, cphone });
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.Items.Count == 0)
            {
                MessageBox.Show("there is not any customer here!!");
            }
            else
            {
                try
                {


                    update_information_of_customer_by_admin a = new update_information_of_customer_by_admin();
                    a.Show();
                    this.Hide();
                    String s = comboBox1.SelectedItem.ToString();
                    XmlWriter w = XmlWriter.Create("the id of flat you need to do update.xml");

                    w.WriteStartElement("id");
                    w.WriteString(s);
                    w.WriteEndElement();

                    w.Close();
                }
                catch(Exception)
                {
                    MessageBox.Show("choose id ,then click on this button!!");
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            work_of_admin a = new work_of_admin();
            a.Show();
        }
    }
}
