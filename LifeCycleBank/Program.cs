using LifeCycleBank.services;
using System;

namespace LifeCycleBank
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("LifeCycleBank!");

            AppDomain.CurrentDomain.ProcessExit += new EventHandler(OnProcessExit);
        }

        static void OnProcessExit(object sender, EventArgs e)
        {
            CreateFileData.CreateFile();
        }
    }
}
