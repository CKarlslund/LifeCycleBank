using LifeCycleBank.Models;
using LifeCycleBank.services;
using System;
using System.IO;
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

            if (Console.ReadKey().Key == ConsoleKey.D0)
            {                
                CreateFileAndDisplayStatistics(bank);
            }

            Console.ReadLine();
        }

        private static void CreateFileAndDisplayStatistics(Bank bank)
        {
            var statistics = ReadStatisticFromBankData.GetStatistics();

            var createFileData = new CreateFileData(bank);

            var fileName = DateTime.Now.ToString("yyyyMMdd-HHmm") + ".txt";
            var path = createFileData.GetPath(fileName);

            var writer = new Writer(path, true);
            createFileData.CreateFile(writer); 

            Console.WriteLine("Sparar till " + fileName + "...");
            Console.WriteLine("Antal kunder: " + bank.Customers.Count);
            Console.WriteLine("Antal konton: " + bank.Accounts.Count);
            Console.WriteLine("Totalt saldo: " + statistics["totalBalance"]);
        }
    }
}