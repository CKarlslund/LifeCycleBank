using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace LifeCycleBank
{
    class ReadFileData
    {
        public static void ReadFileFromBankData()
        {
            var amount = new List<int>();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "bankdata\\bankdata-small.txt");
            string[] lines = System.IO.File.ReadAllLines(path);
            foreach (var line in lines)
            {
               

                
            }
          
            Console.ReadLine();
        }

     
    }
}
