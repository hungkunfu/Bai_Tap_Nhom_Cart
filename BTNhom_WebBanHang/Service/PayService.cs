using BTNhom_WebBanHang.Helper;
using BTNhom_WebBanHang.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BTNhom_WebBanHang.Service
{
    class PayService:BaseService
    {
        private readonly OrderService orderService;
        private readonly OrderDetail orderDetail;
        private string databill = "Bill_{0}_{1}.json";
        private string fullPath;
       
        public PayService()
        {

            orderDetail = new OrderDetail();
            orderService = new OrderService();
        }

        public void Pay(string userid)
        {
            //generate bill file
            string billFile = string.Format(databill, userid, DateTime.Now.ToString("dd.MM.yyyy.hh.mm.ss"));
            fullPath = Path.Combine(root, billFile);

            //get order needed to pay by tableid
            Order oder = orderService.GetOrderByUserID(userid);

            //update order paid
            orderService.UpdateOrderShop(userid);
            //print bill
            Help.WriteFile<Order>(fullPath, oder);


        }
    }
}
