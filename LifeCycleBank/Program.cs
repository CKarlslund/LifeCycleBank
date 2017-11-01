using System;

namespace LifeCycleBank
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("LifeCycleBank!");
            var r = new ReadFileData();
            r.ReadFileFromBankData();
           
            Console.ReadLine();
        }
    }
}
