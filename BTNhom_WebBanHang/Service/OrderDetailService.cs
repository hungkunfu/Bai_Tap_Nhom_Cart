using BTNhom_WebBanHang.Helper;
using BTNhom_WebBanHang.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BTNhom_WebBanHang.Service
{
    class OrderDetailService : BaseService
    {       
        private List<Product> allProduct;

        public OrderDetailService()
        {
            allProduct = Help.ReadFile<List<Product>>($@"{root}\{data}");
        }

        public OrderDetail ChooseProduct()
        {
            OrderDetail orderDetail = new OrderDetail();
            int choice;
            bool check;
            int quantity;
            do
            {
                Console.WriteLine("Enter product");
                check = int.TryParse(Console.ReadLine(), out choice);
            } while (!check || choice > allProduct.Count);
            if(allProduct[choice-1].status)
            {
                orderDetail.productName = allProduct[choice - 1].name;
                orderDetail.price = allProduct[choice - 1].price;
                do
                {
                    Console.WriteLine("Enter quantity");
                    check = int.TryParse(Console.ReadLine(), out quantity);
                } while (!check);
                orderDetail.quantity = quantity;
                return orderDetail;
            }
            return null;
        }
    }
}
