using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace project
{
    [Serializable()]
    class Flats

    {
        [XmlElement]

        public string  FlatID { get; set; }
        [XmlElement]
        public string  customerid { get; set; }
        [XmlElement]
        public string   EmpID { get; set; }
        [XmlElement]
        public string FlatDesc { get; set; }
        [XmlElement]
        public int  Price { get; set; }
        [XmlElement]
        public string FlatLocation { get; set; }
        [XmlElement]
        public string Customer_Review { get; set; }
        [XmlElement]
        public string flatstat { get; set; }

    }
    
    class Admin {
         string id;
         string name;
       Admin(string i,string n) {
            this.id = i;
            this.name = n;

        }

    }
    class Customers
    {
        public string customer_id,customer_name,Address ,phone_num;
        Customers(string customer_id, string customer_name, string Address ,string phone_num)
        {
            this.customer_id = customer_id;
            this.customer_name = customer_name;
            this.Address = Address;
            this.phone_num = phone_num;

        }

    }
    class Employee
     {
        string Emp_id;
        int No_ass_flat;
        int Rate;
        Employee(string Emp_id,int No_ass_flat,int Rate)
        {
            this.Emp_id = Emp_id;
            this.No_ass_flat = No_ass_flat;
            this.Rate = Rate;
        }

    }
}
