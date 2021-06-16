using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceBusinessLayer
{
    public static class DisplayErrors
    {
        /// <summary>
        /// Displays the error with user's input
        /// </summary>
        /// <param name="userInput"></param>
        public static void IncorrectInput(string userInput)
        {
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine($"\n {userInput} is NOT a valid choice.\n Select again.\n");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
        }
    }
}
