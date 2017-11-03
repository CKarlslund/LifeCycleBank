using LifeCycleBank.Models;
using LifeCycleBank.services;
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
           
            if (Console.ReadKey().Key == ConsoleKey.D0)
            {
                CreateFileAndDisplayStatistics(bank);

            }

            Console.ReadLine();
        }

        private static void CreateFileAndDisplayStatistics(Bank bank)
        {
            var fileName = CreateFileData.CreateFile(bank);
            var statistics = ReadStatisticFromBankData.GetStatistics();

            Console.WriteLine("Sparar till " + "fileName" + "...");
            Console.WriteLine("Antal kunder: " + statistics["numberOfCustomers"]);
            Console.WriteLine("Antal konton: " + statistics["numberOfAccounts"]);
            Console.WriteLine("Totalt saldo: " + statistics["totalBalance"]);
            Console.ReadLine();
        }
    }
}