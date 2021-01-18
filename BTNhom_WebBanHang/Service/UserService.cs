using BTNhom_WebBanHang.Helper;
using BTNhom_WebBanHang.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BTNhom_WebBanHang.Service
{
    class UserService : BaseService
    {
        private List<User> userData;
        private User account;
        private string userPath;

        public UserService()
        {
            userPath = Path.Combine(root, dataUser);
            if (File.Exists(userPath))
            {
                userData = Help.ReadFile<List<User>>(userPath);
            }
            else
            {
                userData = new List<User>();
            }
        }

        public User SignUp(string userID, string passWord, string name, string address)
        {
            account = new User();
            for (int i = 0; i < userData.Count; i++)
            {
                if(userID == userData[i].userID)
                {
                    Console.WriteLine("Invalid ID or PassWord");
                    return null;
                }               
            }
            account.userID = userID;
            account.passWord = passWord;
            account.name = name;
            account.address = address;
            userData.Add(account);
            Help.WriteFile<List<User>>(userPath, userData);
            Console.WriteLine($"Welcome {name}");
            return account;
        }

        public User LogIn(string Id, string pass)
        {
            foreach(User user in userData)
            {
                if(user.userID == Id && user.passWord == pass)
                {
                    Console.WriteLine($"Welcome {user.name}");
                    return user;
                }
            }
            Console.WriteLine("Invalid ID or PassWord");
            return null;
        }

    }
}
