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
    public partial class rate : UserControl
    {
        public rate()
        {
            InitializeComponent();
        }

        private void C_SelectedIndexChanged(object sender, EventArgs e)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("log_in.xml");
            XmlNodeList nodeL = xmlDoc.GetElementsByTagName("Employee");

            for (int i = 0; i < nodeL.Count; i++)
            {
                XmlNodeList child = nodeL[i].ChildNodes;

                string name = child[1].InnerText;
                C.Items.Add(name);
            }
        }

        private void rate_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
