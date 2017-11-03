using System;

namespace LifeCycleBank
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("LifeCycleBank!");
            ReadFileData.ReadFileFromBankData();
            var customers = ReadFileData.GetAllCustomers();

            foreach (var item in customers)
            {
                Console.WriteLine(item.CompanyName);
            }
           
            Console.ReadLine();
        }
    }
}
