using LifeCycleBank.Interfaces;
using LifeCycleBank.Models;
using LifeCycleBank.services;
using System;
using System.Globalization;
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

            try
            {
                
                RunProgram(bank);
            }
            catch (Exception e)
            {
                
                Console.WriteLine("Ett allvarligt fel uppstod. Tryck på ENTER för att fortsätta");
                Console.WriteLine(e);
                Console.ReadLine();
                Console.Clear();
                RunProgram(bank);
            }
        }

        static void RunProgram(Bank bank)
        {
            bool closeProgram = false;

            do
            {
                int userChoice = DisplayMenu();

                switch (userChoice)
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
                                    break;
                                }
                                else
                                {
                                    SearchCustomers(bank, searchWord);
                                }

                            }
                            else
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
                                    break;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Du måste ange ett nummer.");
                            }
                            break;
                        }

                    case 3:
                        {
                            //Skapa kund

                            Console.Clear();
                            Console.WriteLine("*****************************");
                            Console.WriteLine("         Skapa kund          ");
                            Console.WriteLine("*****************************");


                            Console.WriteLine("Ange organisationsnummer:");
                            var organizationNumber = Console.ReadLine();

                            Console.WriteLine("Ange företagsnamn:");
                            var companyName = Console.ReadLine();

                            Console.WriteLine("Ange adress:");
                            var address = Console.ReadLine();

                            Console.WriteLine("Ange postkod:");
                            var postalCode = Console.ReadLine();

                            Console.WriteLine("Ange stad:");
                            var city = Console.ReadLine();

                            Console.WriteLine("Ange region:");
                            var region = Console.ReadLine();

                            Console.WriteLine("Ange land:");
                            var country = Console.ReadLine();

                            Console.WriteLine("Ange telefonnummer:");
                            var phoneNumber = Console.ReadLine();

                            var result = bank.CreateCustomer(organizationNumber, companyName, address, postalCode, city, region, country, phoneNumber);
                            if (result == "true")
                            {
                                Console.Clear();
                                Console.WriteLine("*****************************");
                                Console.WriteLine("     Kunden är nu skapad     ");
                                Console.WriteLine("*****************************");
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("*****************************");
                                Console.WriteLine("     Något gick snett!!!     ");
                                Console.WriteLine("*****************************");
                            }
                            break;
                        }

                    case 4:
                        {
                            //Ta bort kund
                            Console.Clear();
                            Console.WriteLine("*****************************");
                            Console.WriteLine("        Ta bort kund         ");
                            Console.WriteLine("*****************************");

                            Console.WriteLine("Ange kundnummer på kunden du vill ta bort:");
                            var customerId = Console.ReadLine();

                            int value;
                            if (int.TryParse(customerId, out value))
                            {
                                var customerAccounts = CustomerService.GetCustomerAccounts(bank, value);
                                var customerCheckExists = CustomerService.GetCustomer(bank, value);

                                if (customerCheckExists != null)
                                {
                                    if (bank.ValidateDeleteCustomer(value, customerAccounts) == true)
                                    {

                                        var result = bank.DeleteCustomer(value);

                                        if (result == "true")
                                        {
                                            Console.Clear();
                                            Console.WriteLine("*****************************");
                                            Console.WriteLine("   Kunden är nu bortagen.    ");
                                            Console.WriteLine("*****************************");
                                        }

                                        else if (result == "false")
                                        {
                                            Console.Clear();
                                            Console.WriteLine("*****************************");
                                            Console.WriteLine("   Hoppsan något gick fel!   ");
                                            Console.WriteLine("*****************************");
                                        }
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        Console.WriteLine("*****************************");
                                        Console.WriteLine("Kontot har fortfarande pengar");                           
                                        Console.WriteLine("*****************************");
                                    }
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("*****************************");
                                    Console.WriteLine("Kunden finns inte");
                                    Console.WriteLine("*****************************");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Du måste ange ett nummer.");
                                break;
                            }
                            break;
                        }

                    case 5:
                        {
                            //Skapa konto

                            Console.Clear();
                            Console.WriteLine("*****************************");
                            Console.WriteLine("         Skapa konto         ");
                            Console.WriteLine("*****************************");

                            Console.WriteLine();
                            Console.WriteLine("Ange kundnummer på kunden du vill skapa konto hos:");
                            var customerID = Console.ReadLine();
                            int ID;
                            if (int.TryParse(customerID, out ID))
                            {
                                Console.WriteLine("Ange hur mycket du vill sätta in på kontot:");
                                var balance = Console.ReadLine();

                                decimal value;
                                if (decimal.TryParse(balance, out value))
                                {

                                    var customer = CustomerService.GetCustomer(bank, ID);

                                    if (customer != null)
                                    {
                                        var result = bank.CreateAccount(customer, value);

                                        if (result == "true")
                                        {
                                            Console.Clear();
                                            Console.WriteLine("*****************************");
                                            Console.WriteLine("     Kontot är nu Skapat     ");
                                            Console.WriteLine("*****************************");
                                        }
                                        else
                                        {
                                            Console.Clear();
                                            Console.WriteLine("*****************************");
                                            Console.WriteLine("     Något gick snett!!!     ");
                                            Console.WriteLine("*****************************");
                                        }
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        Console.WriteLine("*****************************");
                                        Console.WriteLine("   Kundnummret finns inte    ");
                                        Console.WriteLine("*****************************");
                                    }

                                }
                                else
                                {
                                    Console.WriteLine("Du måste ange ett belopp.");
                                    break;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Du måste ange ett nummer.");
                                break;
                            }

                            
                            break;
                        }

                    case 6:
                        {
                            Console.Clear();
                            Console.WriteLine("*****************************");
                            Console.WriteLine("       Ta bort konto         ");
                            Console.WriteLine("*****************************");

                            Console.Write("Ange kontonummer på det konto du vill ta bort:");
                            var accountId = Console.ReadLine();

                            int value;

                            if (int.TryParse(accountId, out value))
                            {
                                if (bank.ValidateDeleteCustomer(value, bank) == false)
                                {
                                    Console.Clear();
                                    Console.WriteLine("*****************************");
                                    Console.WriteLine("Kontot har fortfarande pengar");
                                    Console.WriteLine("*****************************");
                                }

                                else
                                {
                                    bank.DeleteAccount(value);
                                    Console.Clear();
                                    Console.WriteLine("*****************************");
                                    Console.WriteLine("    Kontot är nu bortaget    ");
                                    Console.WriteLine("*****************************");
                                }

                            }
                            else
                            {

                                Console.WriteLine("Du måste ange ett nummer.");
                                break;

                            }

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
                                debitAccount = GetDebitAccount();
                                if (debitAccount == null)
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("Det angivna kontot finns inte.");
                                    break;
                                }
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
                                creditAccount = GetCreditAccount();
                                if (creditAccount == null)
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("Det angivna kontot finns inte.");
                                    break;
                                }
                                amuontToTransfer = Amuont();
                            }
                            catch
                            {
                                Console.WriteLine("Du måste ange nummer.");
                                break;
                            }
                            Withdrawal(bank, creditAccount, amuontToTransfer);
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
                                creditAccount = GetCreditAccount();
                                debitAccount = GetDebitAccount();
                                if (debitAccount == null)
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("Det angivna kontot finns inte.");
                                    break;

                                }
                                else if (debitAccount == null)
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("Det angivna mottagar kontot finns inte.");
                                    break;
                                }
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
            do
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
                Console.Write("Skriv in nummret på ditt val: ");
                int userChoice = -1;
                try
                {
                    userChoice = Convert.ToInt32(Console.ReadLine());

                    if (userChoice >= 0 && userChoice < 10)
                    {
                        return userChoice;
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("Error: Felaktigt val");
                        Console.ReadLine();
                        Console.Clear();
                    }
                }
                catch
                {
                    Console.WriteLine();
                    Console.WriteLine("Error: Felaktigt val");
                    Console.ReadLine();
                    Console.Clear();
                }

            } while (true);

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
            try
            {
                bank.CreateDeposit(toAccount, amount);
                Console.WriteLine("Den angivna summan är nu insatt på kontot.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
            
        }

        public static void Withdrawal(Bank bank, IAccount fromAccount, decimal amount)
        {
            try
            {
                bank.CreateWithdrawal(fromAccount, amount);
                Console.WriteLine("Du har nu tagit ut " + amount + " från konto " + fromAccount.Id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static void Transaction(Bank bank, IAccount fromAccount, IAccount toAccount, decimal amuontToTransfer)
        {
            try
            {
                bank.CreateTransaction(fromAccount, toAccount, amuontToTransfer);
                Console.WriteLine(amuontToTransfer + " överfört från konto " + fromAccount.Id + " till " + toAccount.Id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static IAccount GetCreditAccount()
        {
            Console.WriteLine("Från konto:");
            var formAccount = Convert.ToInt32(Console.ReadLine());
            var creditAccount = GetAccount(formAccount);

            return creditAccount;
        }

        public static IAccount GetDebitAccount()
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
            var amuontToTransfer = Convert.ToDecimal(Console.ReadLine(), CultureInfo.InvariantCulture);

            return amuontToTransfer;
        }

    }
}