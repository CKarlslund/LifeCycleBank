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
        public static void ReadFileFromBankData()
        {
            var number = 0;
            var path = Path.Combine(Directory.GetCurrentDirectory(), "bankdata\\bankdata-small.txt");
            string[] lines = System.IO.File.ReadAllLines(path);
            foreach (var line in lines)
            {
               if(Regex.IsMatch(line, "^[0-9]*$"))
                    {
                    number = Convert.ToInt32(line);
                  
                }
                for (int i = 0; i < number; i++)
                {
                    var s = line.Split(";");
                    for (int x = 0; x < s.Length; x++)
                    {
                        Console.WriteLine(s[x]);
                    }


                }

            }
          
            Console.ReadLine();
        }

     
    }
}
