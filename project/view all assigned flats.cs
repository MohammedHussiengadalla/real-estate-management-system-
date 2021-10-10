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
    public partial class view_all_assigned_flats : Form
    {
        public view_all_assigned_flats()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            XmlDocument xmlD = new XmlDocument();
            xmlD.Load("log.xml");
            XmlNodeList nodeL = xmlD.GetElementsByTagName("username");

            String id = nodeL[0].InnerText;

            xmlD = new XmlDocument();
            xmlD.Load("flats.xml");
            nodeL = xmlD.GetElementsByTagName("flat");
            for (int i = 0; i < nodeL.Count; i++)
            {
                XmlNodeList child = nodeL[i].ChildNodes;
               
                if (id==child[2].InnerText&&child[7].InnerText=="true")
                {
                    String f_id = child[0].Name;
                    String fi = child[0].InnerText;
                    String c_id = child[1].Name;
                    String ci = child[1].InnerText;
                    String flat_desc = child[3].Name;
                    String fd = child[3].InnerText;
                    String flat_price = child[4].Name;
                    String fp = child[4].InnerText;
                    String flat_location = child[5].Name;
                    String fl = child[5].InnerText;
                    String flat_status = child[6].Name;
                    String fs = child[6].InnerText;
                    if (dataGridView1.ColumnCount == 0)
                    {
                        dataGridView1.Columns.Add("f_id", f_id);
                        dataGridView1.Columns.Add("c_id", c_id);
                        dataGridView1.Columns.Add("flat_description", flat_desc);
                        dataGridView1.Columns.Add("flat_price", flat_price);
                        dataGridView1.Columns.Add("flat_location", flat_location);
                        dataGridView1.Columns.Add("flat_status", flat_status);
                    }
                    dataGridView1.Rows.Add(new String[] { fi, ci, fd, fp, fl, fs });
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            work_of_employee a = new work_of_employee();
            a.Show();
        }

        private void view_all_assigned_flats_Load(object sender, EventArgs e)
        {
           
        }
    }
}
