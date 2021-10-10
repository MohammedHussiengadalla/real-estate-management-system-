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
        string Nemployyid;
        string loction;
        string employee_name;
        string empl_name;
        string Nflat_lo;
        string x_flats;
       

      

        private void view_2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {

            listofloction.Items.Clear();



            int count = 0;
            XmlDocument doc = new XmlDocument();
            doc.Load("flats.xml");
            XmlNodeList list = doc.GetElementsByTagName("flat");
            for (int i = 0; i < list.Count; i++)
            {
                XmlNodeList flat_child = list[i].ChildNodes;
                String x_flats = flat_child[5].InnerText;
                count++;

                if (flat_child[7].InnerText == "true")
                    listofloction.Items.Add(x_flats);

            }



            String location = "";
            doc = new XmlDocument();
            doc.Load("log.xml");
            list = doc.GetElementsByTagName("username");
            XmlNodeList ch = list[0].ChildNodes;
            String us = ch[0].InnerText;

            doc = new XmlDocument();
            doc.Load("log_in.xml");
            list = doc.GetElementsByTagName("customer");
            for (int i = 0; i < list.Count; i++)
            {
                ch = list[i].ChildNodes;
                if (us == ch[4].InnerText)
                {
                    location = ch[2].InnerText;
                }
            }
            dataGridView1.Rows.Clear();
            String desc, fdesc, price, fprice, loca, floca, status, fstatus;
            doc = new XmlDocument();
            doc.Load("flats.xml");
            list = doc.GetElementsByTagName("flat");
            for (int i = 0; i < list.Count; i++)
            {
                ch = list[i].ChildNodes;
                if (location == ch[5].InnerText && ch[7].InnerText == "true")
                {
                    desc = ch[3].Name;
                    fdesc = ch[3].InnerText;
                    price = ch[4].Name;
                    fprice = ch[4].InnerText;
                    loca = ch[5].Name;
                    floca = ch[5].InnerText;
                    status = ch[6].Name;
                    fstatus = ch[6].InnerText;
                    if (dataGridView1.ColumnCount == 0)
                    {
                        dataGridView1.Columns.Add("description", desc);
                        dataGridView1.Columns.Add("price", price);
                        dataGridView1.Columns.Add("location", loca);
                        dataGridView1.Columns.Add("status", status);
                    }
                    dataGridView1.Rows.Add(new String[] { fdesc, fprice, floca, fstatus });
                }



            }
            for (int i = 0; i < list.Count; i++)
            {
                ch = list[i].ChildNodes;
                if (location != ch[5].InnerText && ch[7].InnerText == "true")
                {
                    desc = ch[3].Name;
                    fdesc = ch[3].InnerText;
                    price = ch[4].Name;
                    fprice = ch[4].InnerText;
                    loca = ch[5].Name;
                    floca = ch[5].InnerText;
                    status = ch[6].Name;
                    fstatus = ch[6].InnerText;
                    if (dataGridView1.ColumnCount == 0)
                    {
                        dataGridView1.Columns.Add("description", desc);
                        dataGridView1.Columns.Add("price", price);
                        dataGridView1.Columns.Add("location", loca);
                        dataGridView1.Columns.Add("status", status);
                    }
                    dataGridView1.Rows.Add(new String[] { fdesc, fprice, floca, fstatus });
                }



            }

        }
    }
}
