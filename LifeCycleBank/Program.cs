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
            Console.Clear();
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
                            Console.WriteLine();
                            Console.WriteLine("Ange stad eller företagsnamn:");
                            var searchWord = Console.ReadLine();
                            SearchCustomers(bank, searchWord);
                            break;
                        }

                    case 2:
                        {
                            Console.WriteLine();
                            Console.WriteLine("Ange kundnummer på kunden du vill se:");
                            var customerID = Convert.ToInt32(Console.ReadLine());
                            GetCustomerInfo(bank, customerID);
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

                Console.WriteLine();
                Console.WriteLine("Tryck på ENTER för att fortsätta.");
                Console.ReadLine();
                Console.Clear();

            } while (closeProgram == false);


        }

        private static int DisplayMenu()
        {
            Console.WriteLine("*****************************");
            Console.WriteLine("Välkommen till LifeCycleBank");
            Console.WriteLine("*****************************");
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
            var fileName = DateTime.Now.ToString("yyyyMMdd-HHmm") + ".txt";
            var path = CreateFileData.GetPath(fileName);

            var writer = new Writer(path, true);
            CreateFileData.CreateFile(bank, writer); 

            Console.WriteLine("Sparar till " + fileName + "...");
            Console.WriteLine("Antal kunder: " + bank.Customers.Count);
            Console.WriteLine("Antal konton: " + bank.Accounts.Count);
            Console.WriteLine("Totalt saldo: " + bank.TotalBalance);
        }

        private static void SearchCustomers(Bank bank, string searchWord)
        {
            var customers = CustomerService.SearchCustomer(bank, searchWord);

            if (customers.Count() != 0)
            {
                foreach (var customer in customers)
                {
                    Console.WriteLine("\n------------------------\n");
                    Console.WriteLine("Företag: " + customer.CompanyName);
                    Console.WriteLine("Kundnummer: " + customer.Id);
                }
                Console.WriteLine("\n------------------------\n");

            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Ingen kund matchade sökningen");
            }
        }

        private static void GetCustomerInfo(Bank bank, int customerNumber)
        {

            var customer = CustomerService.GetCustomer(bank, customerNumber);

            if (customer != null)
            {
                var customerAccounts = CustomerService.GetCustomerAccounts(bank, customer.Id);
                decimal totalBalance = 0;

                Console.WriteLine("\n-----------------------------");
                Console.WriteLine("Kundnummer: " + customer.Id);
                Console.WriteLine("Organisationsnummer: " + customer.OrganizationNumber);
                Console.WriteLine("Företagsnamn: " + customer.CompanyName);
                Console.WriteLine("Adress: " + customer.Address);
                Console.WriteLine("Stad: " + customer.City);
                Console.WriteLine("Region: " + customer.Region);
                Console.WriteLine("Postnummer: " + customer.PostalCode);
                Console.WriteLine("Land: " + customer.Country);
                Console.WriteLine();
                Console.WriteLine("Konton:");

                foreach (var account in customerAccounts)
                {
                    Console.WriteLine("Kontonummer: " + account.Id);
                    Console.WriteLine("Saldo: " + account.Balance + "kr");
                    totalBalance = totalBalance + account.Balance;
                    Console.WriteLine();
                }

                Console.WriteLine("Kundens totala saldo: " + totalBalance + "kr");
                Console.WriteLine("-----------------------------\n");

            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Ingen kund matchade sökningen");
            }


        }

    }
}