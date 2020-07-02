using Microsoft.CodeAnalysis.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mohammadi.Models.ViewModel
{
    public interface IUser
    {
         int MyProperty { get; set; }
         string getUser(int age);
    }
    public class User : IUser
    {
        public int MyProperty { get; set; }
        public string Name { get; set; }

        public string getUser(int age)
        {
            return "10";
        }
    }
    public class grandUser : IUser
    {
        User hassa = new User();
        public int MyProperty { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public string getUser(int age)
        {
            return age.ToString();
        }
    }
}
