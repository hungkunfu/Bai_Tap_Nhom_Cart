using BTNhom_WebBanHang.Model;
using BTNhom_WebBanHang.Service;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace BTNhom_WebBanHang
{
    class Program
    {
        
        static void Main(string[] args)
        {
          
            MainService main = new MainService();
            main.EnterService();
            main.MenuService();
        }
    }
}
