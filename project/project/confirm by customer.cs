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
    public partial class confirm_by_customer : Form
    {
        public confirm_by_customer()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {


                XmlDocument doc = new XmlDocument();
                doc.Load("flats.xml");
                XmlNodeList list = doc.GetElementsByTagName("flat");
                for (int i = 0; i < list.Count; i++)
                {

                    XmlNodeList ch = list[i].ChildNodes;
                    if (comboBox1.SelectedItem.ToString() == ch[0].InnerText)
                    {
                        ch[7].InnerText = "false";
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
                        doc.Save("flats.xml");
                        MessageBox.Show("confirmation successfully!!");
                        
                        break;
                    }
                }
                customer_work a = new customer_work();
                a.Show();
                this.Hide();
            }catch(Exception)
            {
                MessageBox.Show("choose id ,then click on this button!!");
            }
        }

        private void confirm_by_customer_Load(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("log.xml");
            XmlNodeList list = doc.GetElementsByTagName("username");
            String us = list[0].InnerText;

            doc = new XmlDocument();
            doc.Load("log_in.xml");
            list = doc.GetElementsByTagName("customer");
            String id = "";
            for(int i=0;i<list.Count;i++)
            {
                XmlNodeList ch = list[i].ChildNodes;
                if(us==ch[4].InnerText)
                {
                    id = ch[0].InnerText;
                    break;
                }
            }
            doc = new XmlDocument();
            doc.Load("flats.xml");
            list = doc.GetElementsByTagName("flat");
            for(int i=0;i<list.Count;i++)
            {
                XmlNodeList ch = list[i].ChildNodes;
                if(id==ch[1].InnerText&&ch[7].InnerText=="true")
                {
                    comboBox1.Items.Add(ch[0].InnerText);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            customer_work a = new customer_work();
            a.Show();
        }
    }
}
