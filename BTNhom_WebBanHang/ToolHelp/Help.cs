using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BTNhom_WebBanHang.Helper
{
   public class Help
    {
        public static T ReadFile<T>(string fullPath)
        {
            using(StreamReader sr = new StreamReader(fullPath,Encoding.UTF8))
            {
                string productData = sr.ReadToEnd();
                return JsonConvert.DeserializeObject<T>(productData);
            }
        }

        public static void WriteFile<T>(string fullPath, T data)
        {
            using(StreamWriter sw = new StreamWriter(fullPath, append:false, Encoding.UTF8))
            {
                sw.Write(JsonConvert.SerializeObject(data,Formatting.Indented));
            }
        }
    }
}
