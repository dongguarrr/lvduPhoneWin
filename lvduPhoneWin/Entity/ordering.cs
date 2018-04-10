using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace lvduPhoneWin.Entity
{
    public class ordering
    {
        public Guid id { get; set; }
        public String roomID { get; set; }
        public String order { get; set; }
        public String orderID { get; set; }
        public Boolean orderState { get; set; }
        public String note { get; set; }
        public DateTime createtime { get; set; }
        public String total { get; set; }
    }
    public class good
    {
        public Guid id { get; set; }
        public int upitem { get; set; }
        public String img { get; set; }
        public String name { get; set; }
        public String info { get; set; }
        public double price { get; set; }
        public String alert { get; set; }
    }
}