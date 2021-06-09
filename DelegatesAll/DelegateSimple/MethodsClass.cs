using System;

namespace DelegateSimple
{
    class MethodsClass {

        #region This region holds SimpleMethods will be
        public void method1() {
            
            Console.WriteLine("This is method 1");
        }

        public void method2() {
            
            Console.WriteLine("This is method 2");
        }
        public void method3() {
            
            Console.WriteLine("This is method 3");
        }

        #endregion

        #region This region holds NotsimpleMethods will be
        public int method4(ref string message) {
            
            Console.WriteLine($"Method 4. Add somethind to the message");
            string m = Console.ReadLine();
            message += m;
            return 1;
        }

        public int method5(ref string message) {

            Console.WriteLine($"Method 5. Add somethind to the message");
            string m = Console.ReadLine();
            message += m;
            return 2;
        }

        public int method6(ref string message) {

            Console.WriteLine($"Method 6. Add somethind to the message");
            string m = Console.ReadLine();
            message += m;
            return 3;
        }

        #endregion
    
        #region This region holds methods for a Function type deleagate

        #endregion
    }
}