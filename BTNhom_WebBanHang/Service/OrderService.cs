using BTNhom_WebBanHang.Helper;
using BTNhom_WebBanHang.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BTNhom_WebBanHang.Service
{
    class OrderService : BaseService
    {
        private List<Order>? ordersList;
        //private List<Product> dataProduct;
        private string fullPath;

        public OrderService()
        {
            //dataProduct = Help.ReadFile<List<Product>>($@"{root}\{data}")
            fullPath = Path.Combine(root, dataLog);
            if (File.Exists(fullPath))
            {
                ordersList = Help.ReadFile<List<Order>>(fullPath);
                if (ordersList == null) ordersList = new List<Order>();
            }
            else
            {
                ordersList = new List<Order>();
            }
        }

        public void AddToCart(List<OrderDetail> orderDetailsList, string userId)
        {
            if (ordersList.Count !=0)
            {
                UpdateCart(orderDetailsList, userId);
            }
            else
            {
                Order newOrder = new Order()
                {
                    userId = userId,
                    isPaid = false,
                    ordersDetailList = orderDetailsList
                };
                ordersList.Add(newOrder);
                Help.WriteFile(fullPath, ordersList);
            }
        }

        public void UpdateCart(List<OrderDetail> orderDetailsList, string userId)
        {
            bool isExist;
            Order orderUpdate = GetOrderByUserID(userId);
            try
            {
                foreach (OrderDetail newOd in orderDetailsList)
                {
                    isExist = false;
                    foreach (OrderDetail OldOd in orderUpdate.ordersDetailList)
                    {
                        if (newOd.productName == OldOd.productName)
                        {
                            isExist = true;
                            OldOd.quantity += newOd.quantity;
                        }
                    }
                    if (!isExist)
                    {
                        orderUpdate.ordersDetailList.Add(newOd);
                    }
                }
                Help.WriteFile<List<Order>>(fullPath, ordersList);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        //public bool CheckStock(List<OrderDetail> orderDetailsList)
        //{
        //    foreach(OrderDetail items in orderDetailsList)
        //    {
        //         foreach(Data datas in dataProduct)
        //          {
        //             if(items.productName == dataProduct.name && !dataProduct.status)
        //              {
        //                  return false;
        //              }
        //          }
        //    }
        //    return true;
        //}

        public Order GetOrderByUserID(string userID)
        {
            foreach (Order items in ordersList)
            {
                if (items.userId == userID && items.isPaid == false)
                {
                    return items;
                }
            }
            return new Order();
        }

        public void ShowAllCart(string userID)
        {
            Order order = GetOrderByUserID(userID);
            foreach (OrderDetail items in order.ordersDetailList)
            {
                Console.WriteLine($"Product: {items.productName}\nPrice: {items.price}\nQuantity: {items.quantity}\nAmount: {items.Amount}");
                for (int i = 0; i < 20; i++)
                {
                    Console.Write("=");
                }
                Console.WriteLine();
            }
        }
        public void UpdateOrderShop(string userid)
        {
            Order orderNeedUpdate = GetOrderByUserID(userid);
            orderNeedUpdate.isPaid = true;

            Help.WriteFile<List<Order>>(fullPath, ordersList);
        }

    }
}
