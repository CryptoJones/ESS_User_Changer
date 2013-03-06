using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ESS_User_Changer
{
    class UserChanger
    {
        static void Main(string[] args)
        {
            string path = @"C:\UserChanger.sql";


            if (File.Exists(path))
            {
                File.Delete(path);
            }

            using (FileStream fs = File.Create(path)) ;
            Console.WriteLine("Enter the old Employee Number: ");
            string old_emp_no = Console.ReadLine();
            Console.WriteLine("Enter the old Employee First Name: ");
            string old_fname = Console.ReadLine();
            Console.WriteLine("Enter the old Employee Last Name: ");
            string old_lname = Console.ReadLine();
        }
    }

}
