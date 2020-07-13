using Assignment_4.Displays;
using Assignment_4.Services;
using System;
using System.Diagnostics.CodeAnalysis;

namespace Assignment_4
{

    [ExcludeFromCodeCoverage]
    class Program
    {
        /// <summary>
        /// This is my Main method.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            var calculator = new Calculator();

            var menuRecall = true;

            while (menuRecall)
            {
               DisplayUtility.Menu(out menuRecall, calculator);
            }
        }
    }
}
