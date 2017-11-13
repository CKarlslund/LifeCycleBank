using LifeCycleBank.Interfaces;
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
            int choice = 11;

            do
            {
                
                try
                {
                    int userChoice = DisplayMenu();
                    if (userChoice > 9)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Du måste ange ett tal mellan 0-9.");

                    } else
                    {
                        choice = userChoice;
                    }
                }
                catch 
                {

                    Console.WriteLine();
                    Console.WriteLine("Du måste ange ett tal.");
                }

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
                            Console.WriteLine("Sök kund");
                            Console.WriteLine("Ange stad eller företagsnamn:");
                            var searchWord = Console.ReadLine();
                            if (searchWord != "")
                            {
                                int intValue;
                                if (int.TryParse(searchWord, out intValue))
                                {
                                    Console.WriteLine("Du måste ange ett ord.");
                                }
                                else
                                {
                                    SearchCustomers(bank, searchWord);
                                }

                            } else
                            {
                                Console.WriteLine("Du måste ange ett sökord.");
                            }
                            break;
                        }

                    case 2:
                        {
                            Console.WriteLine();
                            Console.WriteLine("Visa kundbild");
                            Console.WriteLine("Ange kundnummer på kunden du vill se:");
                            var customerID = Console.ReadLine();
                            if (customerID != "")
                            {
                                int ID;
                                if (int.TryParse(customerID, out ID))
                                {
                                    GetCustomerInfo(bank, ID);
                                }
                                else
                                {
                                    Console.WriteLine("Du måste ange ett nummer.");
                                }
                            } else
                            {
                                Console.WriteLine("Du måste ange ett nummer.");
                            }
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
                            Console.WriteLine();
                            Console.WriteLine("Insättning");
                            IAccount debitAccount;
                            decimal amuontToTransfer;
                            try
                            {
                                debitAccount = DebitAccount();
                                amuontToTransfer = Amuont();
                            }
                            catch
                            {
                                Console.WriteLine("Du måste ange nummer.");
                                break;
                            }
                            Deposit(bank, debitAccount, amuontToTransfer);
                            break;
                        }

                    case 8:
                        {
                            Console.WriteLine();
                            Console.WriteLine("Uttag");
                            IAccount creditAccount;
                            decimal amuontToTransfer;
                            try
                            {
                                creditAccount = CreditAccount();
                                amuontToTransfer = Amuont();
                            }
                            catch
                            {
                                Console.WriteLine("Du måste ange nummer.");
                                break;
                            }
                            Withdrawal(bank,creditAccount,amuontToTransfer);
                            break;
                        }

                    case 9:
                        {
                            Console.WriteLine();
                            Console.WriteLine("Överföring");
                            IAccount creditAccount;
                            IAccount debitAccount;
                            decimal amuontToTransfer;
                            try
                            {
                                creditAccount = CreditAccount();
                                debitAccount = DebitAccount();
                                amuontToTransfer = Amuont();
                            }
                            catch
                            {
                                Console.WriteLine("Du måste ange nummer.");
                                break;
                            }
                            Transaction(bank, creditAccount, debitAccount, amuontToTransfer);
                            break;
                        }
                }

                Console.WriteLine();
                Console.WriteLine("Tryck på ENTER för att fortsätta.");
                Console.ReadLine();
                Console.Clear();

            } while (closeProgram == false);
            
        }

        private static void DisplayBankData()
        {
            var statistics = ReadStatisticFromBankData.GetStatistics();

            Console.WriteLine("Sparar till " + "Läser in bankdata.txt..." + "...");
            Console.WriteLine("Antal kunder: " + statistics["numberOfCustomers"]);
            Console.WriteLine("Antal konton: " + statistics["numberOfAccounts"]);
            Console.WriteLine("Totalt saldo: " + statistics["totalBalance"] + "kr");
        
        }

        private static int DisplayMenu()
        {
            Console.WriteLine("*****************************");
            Console.WriteLine("Välkommen till LifeCycleBank");
            Console.WriteLine("*****************************");
            DisplayBankData();
            Console.WriteLine();
            Console.WriteLine("HUVUDMENY");
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
            var statistics = ReadStatisticFromBankData.GetStatistics();

            var fileName = DateTime.Now.ToString("yyyyMMdd-HHmm") + ".txt";
            var path = CreateFileData.GetPath(fileName);

            var writer = new Writer(path, true);
            CreateFileData.CreateFile(bank, writer); 

            Console.WriteLine("Sparar till " + fileName + "...");
            Console.WriteLine("Antal kunder: " + bank.Customers.Count);
            Console.WriteLine("Antal konton: " + bank.Accounts.Count);
            Console.WriteLine("Totalt saldo: " + statistics["totalBalance"]);
        }

        private static void SearchCustomers(Bank bank, string searchWord)
        {
            var customers = CustomerService.SearchCustomer(bank, searchWord.ToLower());

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

        public static void Deposit(Bank bank,IAccount toAccount, decimal amount)
        {
            bank.CreateDeposit(toAccount, amount);
            Console.WriteLine("Den angivna summan är nu insatt på kontot.");
        }

        public static void Withdrawal(Bank bank, IAccount fromAccount, decimal amount)
        {
            bool fail = false;

            try
            {
                bank.CreateWithdrawal(fromAccount, amount);
            }
            catch 
            {
                fail = true;
                Console.WriteLine("Medges ej.");
            }

            if (fail == false)
            {
                Console.WriteLine("Du har nu tagit ut " + amount + " från konto " + fromAccount.Id);
            }
        }

        public static void Transaction(Bank bank, IAccount fromAccount, IAccount toAccount, decimal amuontToTransfer)
        {
            bool fail = false;

            try
            {
                bank.CreateTransaction(fromAccount, toAccount, amuontToTransfer);
            }
            catch 
            {
                fail = true;
                Console.WriteLine("Den angivna summan är större än vad som finns tillgängligt på kontot. Kunde inte fortsätta.");
            }

            if (fail == false)
            {
                Console.WriteLine(amuontToTransfer + " överfört från konto " + fromAccount.Id + " till " + toAccount.Id);
            }


        }

        public static IAccount CreditAccount()
        {
            Console.WriteLine("Från konto:");
            var formAccount = Convert.ToInt32(Console.ReadLine());
            var creditAccount = GetAccount(formAccount);

            return creditAccount;
        }

        public static IAccount DebitAccount()
        {
            Console.WriteLine("Till konto:");
            var toAccount = Convert.ToInt32(Console.ReadLine());
            var debitAccount = GetAccount(toAccount);

            return debitAccount;
        }

        public static IAccount GetAccount(int account)
        {
            var accounts = ReadFileData.GetAllAccounts();

            var creditAccount = accounts.FirstOrDefault(a => a.Id == account);

            return creditAccount;

        }

        public static decimal Amuont()
        {
            Console.WriteLine("Belopp:");
            var amuontToTransfer = Convert.ToDecimal(Console.ReadLine());

            return amuontToTransfer;
        }

    }
}