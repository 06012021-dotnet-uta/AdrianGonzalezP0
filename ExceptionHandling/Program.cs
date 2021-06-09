using System;

namespace ExceptionHandling
{
    class Program
    {
        static void Main(string[] args)
        {
            int number  = 5;

            try
            {
                int a =  number / 0;
            }
            catch (ArithmeticException ex)
            {
                
                throw new ArithmeticException("That was a bad choice", ex);
            }
        }
    }
}
