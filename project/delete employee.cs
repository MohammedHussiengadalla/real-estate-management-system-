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
    public partial class delete_employee : Form
    {
        public delete_employee()
        {
            InitializeComponent();
        }

        private void delete_employee_Load(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            XmlDocument doc = new XmlDocument();
            doc.Load("log_in.xml");
            XmlNodeList list = doc.GetElementsByTagName("officer");
            for(int i=0;i<list.Count;i++)
            {
                XmlNodeList ch = list[i].ChildNodes;
                String id = ch[0].Name;
                String eid = ch[0].InnerText;
                comboBox1.Items.Add(eid);

                String name = ch[1].Name;
                String ename = ch[1].InnerText;
                String no = ch[2].Name;
                String eno = ch[2].InnerText;
                String rate = ch[3].Name;
                String erate = ch[3].InnerText;
                if(dataGridView1.ColumnCount==0)
                {
                    dataGridView1.Columns.Add("id", id);
                    dataGridView1.Columns.Add("name", name);
                    dataGridView1.Columns.Add("number of flat ", no);
                    dataGridView1.Columns.Add("rate", rate);
                }
                dataGridView1.Rows.Add(new String[] { eid, ename, eno, erate });
            }
            
        }
       

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {


                String s = comboBox1.SelectedItem.ToString();
                XmlDocument doc = new XmlDocument();
                doc.Load("log_in.xml");
                XmlNodeList list = doc.GetElementsByTagName("officer");
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
                for(int i=0;i<list.Count;i++)
                {
                    XmlNodeList ch = list[i].ChildNodes;
                    if(s==ch[2].InnerText)
                    {
                        ch[2].InnerText = "";
                        doc.Save("flats.xml");
                        break;
                    }
                }
                MessageBox.Show("information of employee deleted successfully!!!");
                this.Hide();
            }catch(Exception)
            {
                MessageBox.Show("enter id ,then click on this button");
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
                update_information_of_employee a = new update_information_of_employee();
                a.Show();
                this.Hide();
            }
            catch (Exception)
            {
                MessageBox.Show("enter id ,then click on this button!!");
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
