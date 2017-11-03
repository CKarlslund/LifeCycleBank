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
