using System;
using System.Collections.Generic;
using System.Text;

namespace BTNhom_WebBanHang.Model
{
    class Product
    {
        public string type { get; set; }
        public string name { get; set; }
        public bool status { get; set; }
        public decimal price { get; set; }

        public override string ToString()
        {
            return $"Name: {name}\n" +
                $"Type: {type}\tStatus: {status}\tprice: {price}";
        }
    }
}
