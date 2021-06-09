using System;

namespace DelegateSimple
{
    
    class Program
    {
        static void Main(string[] args)
        {
            DelegateClass myDelegateClass =  new DelegateClass();
            MethodsClass myMethodClass = new MethodsClass();

            // Adding all of the relative methods for SimpleDelegates
            myDelegateClass.mySimpleDelegate = myMethodClass.method1;
            myDelegateClass.mySimpleDelegate += myMethodClass.method2;
            myDelegateClass.mySimpleDelegate += myMethodClass.method3;

            myDelegateClass.mySimpleDelegate();

            // Adding all of the relative methods for NotSimpleDelegates
            myDelegateClass.myNotSimpleDelegate = myMethodClass.method4;
            myDelegateClass.myNotSimpleDelegate += myMethodClass.method5;
            myDelegateClass.myNotSimpleDelegate += myMethodClass.method6;

            string myString = "This";
            int result = myDelegateClass.myNotSimpleDelegate(ref myString);
            Console.WriteLine($"The result is => {result}");
            Console.WriteLine($"The myString is => {myString}");

            myDelegateClass.myFuncDelegateInt = () => {
                return 1;
            };

            Func<int, int> square = x => x * x;

        }
    }
}
