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
    public partial class delete_or_update_flat : Form
    {
        public delete_or_update_flat()
        {
            InitializeComponent();
        }

        private void delete_or_update_flat_Load(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("flats.xml");
            XmlNodeList list = doc.GetElementsByTagName("flat");
            for (int i = 0; i < list.Count; i++)
            {
                
                XmlNodeList ch = list[i].ChildNodes;
                if(ch[7].InnerText=="true")
                {

                    String id = ch[0].Name;
                    String fid = ch[0].InnerText;
                    comboBox1.Items.Add(fid);
                    String cid = ch[1].Name;
                    String ciid = ch[1].InnerText;
                    String eid = ch[2].Name;
                    String eiid = ch[2].InnerText;
                    String d = ch[3].Name;
                    String fd = ch[3].InnerText;
                    String p = ch[4].Name;
                    String fp = ch[4].InnerText;
                    String l = ch[5].Name;
                    String fl = ch[5].InnerText;
                    String s = ch[6].Name;
                    String fs = ch[6].InnerText;
                    if (dataGridView1.ColumnCount == 0)
                    {
                        dataGridView1.Columns.Add("flat id", id);
                        dataGridView1.Columns.Add("customer id", cid);
                        dataGridView1.Columns.Add("employee id", eid);
                        dataGridView1.Columns.Add("flat description", d);
                        dataGridView1.Columns.Add("flat price", p);
                        dataGridView1.Columns.Add("flat location", l);
                        dataGridView1.Columns.Add("flat status", s);

                    }
                    dataGridView1.Rows.Add(new String[] { fid,ciid,eiid, fd, fp, fl, fs });
                }
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                String s = comboBox1.SelectedItem.ToString();
                XmlDocument doc = new XmlDocument();
                doc.Load("flats.xml");
                XmlNodeList list = doc.GetElementsByTagName("flat");
                for (int i = 0; i < list.Count; i++)
                {
                    XmlNodeList ch = list[i].ChildNodes;
                    if (ch[0].InnerText == s)
                    {
                        XmlNode parent = list[i].ParentNode;
                        parent.RemoveChild(list[i]);
                        String id = ch[2].InnerText;
                        XmlDocument dc = new XmlDocument();
                        dc.Load("log_in.xml");
                        XmlNodeList li = dc.GetElementsByTagName("officer");
                        for (int j = 0; j < li.Count; j++)
                        {
                            XmlNodeList h = li[j].ChildNodes;
                            if (h[0].InnerText == id)
                            {
                                int no = Int32.Parse(h[2].InnerText);
                                no--;
                                h[2].InnerText = no.ToString();
                                dc.Save("log_in.xml");
                                break;
                            }
                        }
                        break;
                    }
                }
                doc.Save("flats.xml");
                MessageBox.Show("information of flat deleted successfully!!!");
                work_of_admin a = new work_of_admin();
                a.Show();
                this.Hide();
            }catch(Exception)
            {
                MessageBox.Show("enter id ,then click on this button!!!!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            try
            {


                String s = comboBox1.SelectedItem.ToString();
                XmlWriter w = XmlWriter.Create("the id of flat you need to do update.xml");
                

                w.WriteStartElement("id");
                w.WriteString(s);
                w.WriteEndElement();
                w.Close();
                update_information_of_flat_by_admin a = new update_information_of_flat_by_admin();
                a.Show();
                this.Hide();
            }
            catch(Exception)
            {
                MessageBox.Show("enter id ,then click on this button!!!!");

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
