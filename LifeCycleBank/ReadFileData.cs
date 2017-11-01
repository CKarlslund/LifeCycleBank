using LifeCycleBank.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace LifeCycleBank
{
    class ReadFileData
    {
        private List<Account> accounts;
        private List<Customer> customers;
        public static void ReadFileFromBankData()
        {
            var number = 0;
            var path = Path.Combine(Directory.GetCurrentDirectory(), "bankdata\\bankdata-small.txt");
            string[] lines = System.IO.File.ReadAllLines(path);

            for (int i = 0; i < lines.Length; i++)
            {
                if (Regex.IsMatch(lines[i], "^[0-9]*$"))
                {
                    number = Convert.ToInt32(lines[i]);
                  
                }
                if (Array.IndexOf(lines, i) < number)
                {
                    var s = lines[i].Split(";");
                    for (int j = 0; j < s.Length; j++)
                    {
                        Console.WriteLine(s[j]);
                    }



                }
            }




            Console.ReadLine();
        }

     
    }
}
