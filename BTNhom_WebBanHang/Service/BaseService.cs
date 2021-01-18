using System;
using System.Collections.Generic;
using System.Text;

namespace BTNhom_WebBanHang.Service
{
    class BaseService
    {
        protected string root = @"H:\BaitapNhom1\update\Module2\BTNhom_WebBanHang";
        protected string data = @"Data\ProductData.json";
        protected string dataLog = $@"DataLog\Log_{DateTime.Now.ToString("ddMMyyyy")}.json";
        protected string dataUser = @"DataUser\users.json";
        protected string databill = @"H:\BaitapNhom1\update\Module2\BTNhom_WebBanHang";


    }
}
