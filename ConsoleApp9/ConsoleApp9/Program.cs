using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace ConsoleApp9
{
    class Program
    {
        static void Main(string[] args)
        {
            RegistryKey reg = Registry.CurrentUser.CreateSubKey("HelloKey");
            CreateKeys(reg);
            string str;
            str = Console.ReadLine();
            CreateSubKeys(reg, str);
            Delete();
        }

        static void CreateKeys(RegistryKey reg)
        {
            reg.SetValue("Admin", "1");
            reg.Close();
        }

        static void CreateSubKeys(RegistryKey reg, string name)
        {
            reg.OpenSubKey("HelloKey", true);
            RegistryKey subReg = reg.CreateSubKey(name);
            reg.Close();
        }

        static void Delete()
        {
            Registry.CurrentUser.DeleteSubKeyTree("HelloKey");
        }
    }
}