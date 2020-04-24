using Microsoft.Extensions.DependencyInjection;
using PlyTracker.Core.Attributes;
using System;

namespace PlyTracker.ConsoleApplication
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var test = ActivatorUtilities.CreateInstance<Test>(InversionOfControl.Provider);
            test.TestMethod();
        }
    }
}
