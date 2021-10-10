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
    public partial class view_company_s_commission : Form
    {
        public view_company_s_commission()
        {
            InitializeComponent();
        }

        private void view_company_s_commission_Load(object sender, EventArgs e)
        {
            dataGridView1.Enabled = false;
            dataGridView1.Rows.Clear();
            XmlDocument doc = new XmlDocument();
            doc.Load("flats.xml");
            XmlNodeList list = doc.GetElementsByTagName("flat");
            for(int i=0;i<list.Count;i++)
            {
                XmlNodeList ch = list[i].ChildNodes;
                float t = Int32.Parse(ch[4].InnerText);
                t *= 10;
                t /= 100;
                String id = ch[0].Name;
                String price = ch[4].Name;
                if (dataGridView1.ColumnCount==0)
                {
                    dataGridView1.Columns.Add("f_id", id);
                    dataGridView1.Columns.Add("price of flat", price);
                    dataGridView1.Columns.Add(" company’s commission", " company’s commission");
                }
                dataGridView1.Rows.Add(new string[] { ch[0].InnerText, ch[4].InnerText+" $", t.ToString()+" $" });
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            work_of_admin a = new work_of_admin();
            a.Show();
        }
    }
}
