using LifeCycleBank.Models;
using System;
using System.Linq;

namespace LifeCycleBank
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("LifeCycleBank!");
            ReadFileData.ReadFileFromBankData();
            var bank = new Bank();
           
            Console.ReadLine();
        }
    }
}

            if (Console.ReadKey().Key == ConsoleKey.D0)
            {
                CreateFileAndDisplayStatistics();
                
            }
        }

        private static void CreateFileAndDisplayStatistics()
        {
            var fileName = CreateFileData.CreateFile();
            var statistics = ReadStatisticFromBankData.GetStatistics();

            Console.WriteLine("Sparar till " + "fileName" + "...");
            Console.WriteLine("Antal kunder: " + statistics["numberOfCustomers"]);
            Console.WriteLine("Antal konton: " + statistics["numberOfAccounts"]);
            Console.WriteLine("Totalt saldo: " + statistics["totalBalance"]);
            Console.WriteLine("Totalt saldo: " + statistics["totalBalance"]);
            Console.ReadLine();
        }
    }
}