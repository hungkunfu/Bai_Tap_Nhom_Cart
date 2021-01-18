using System;
using System.Collections.Generic;
using System.Text;

namespace BTNhom_WebBanHang.Model
{
    class Order
    {
        public string userId { get; set; }
        public bool isPaid { get; set; }
        public List<OrderDetail> ordersDetailList { get; set; }
        public decimal total => GetTotal();

        private decimal GetTotal()
        {
            decimal sum = 0;
            foreach(OrderDetail item in ordersDetailList)
            {
                sum += item.Amount;
            }
            return sum;
        }
    }
}
