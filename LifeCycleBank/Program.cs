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
            Console.Clear();
            Console.WriteLine("*****************************");
            Console.WriteLine("Välkommen till LifeCycleBank");
            Console.WriteLine("*****************************");

            ReadFileData.ReadFileFromBankData();
            var bank = new Bank();
            bool closeProgram = false;

            do
            {
                int choice = DisplayMenu();

                switch (choice)
                {
                    case 0:
                        {
                            CreateFileAndDisplayStatistics(bank);
                            closeProgram = true;
                            break;
                        }

                    case 1:
                        {
                            break;
                        }

                    case 2:
                        {
                            break;
                        }

                    case 3:
                        {
                            break;
                        }

                    case 4:
                        {
                            break;
                        }

                    case 5:
                        {
                            break;
                        }

                    case 6:
                        {
                            break;
                        }

                    case 7:
                        {
                            break;
                        }

                    case 8:
                        {
                            break;
                        }

                    case 9:
                        {
                            break;
                        }
                }

                Console.WriteLine("Tryck på valfri kanpp för att fortsätta.");
                Console.ReadLine();

            } while (closeProgram == false);

        }

        private static int DisplayMenu()
        {
            Console.WriteLine("0) Avsluta och Spara");
            Console.WriteLine("1) Sök Kund");
            Console.WriteLine("2) Visa Kundbild");
            Console.WriteLine("3) Skapa kund");
            Console.WriteLine("4) Ta bort kund");
            Console.WriteLine("5) Skapa konto");
            Console.WriteLine("6) Ta bort konto");
            Console.WriteLine("7) Insättning");
            Console.WriteLine("8) Uttag");
            Console.WriteLine("9) Överföring");
            Console.Write("Skriv in nummret på dit val: ");
            var userChoice = Convert.ToInt32(Console.ReadLine());

            return userChoice;
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