using LifeCycleBank.services;
using System;

namespace LifeCycleBank
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("LifeCycleBank!");

            if (Console.ReadKey().Key == ConsoleKey.D0)
            {
                CreateFileData.CreateFile();
            }
        }
    }
}
