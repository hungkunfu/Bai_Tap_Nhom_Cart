using System;
using System.Collections.Generic;
using System.Text;

namespace BTNhom_WebBanHang.Model
{
    class OrderDetail
    {
        public string productName { get; set; }
        public int quantity { get; set; }
        public decimal price { get; set; }
        public decimal Amount => price * quantity;
    }
}
