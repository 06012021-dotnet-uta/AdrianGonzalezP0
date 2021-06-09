using System;
namespace DelegateSimple
{
    public class DelegateClass {
        /*
        Declare a delegate Type.
        This gives the method signature for any method
        that can be assigned to a delegate of this type.
        Used more for EVENT Handler
        */
        public delegate void SimpleDelegate();

        /* 
        Now create the instance of the delegate thype that you can assign methods to
        */
        public SimpleDelegate mySimpleDelegate;



        public delegate int NotSimpleDelegate(ref string message);
        public NotSimpleDelegate myNotSimpleDelegate;

        // Make other mehtods to do things....

        /* 
        Action Delegates do NOT return a value 
        'Action delegateName' is used when it has no parameters.
        'Action<paramType>' is used for delegates with  > 0 parameters
        */
        Action myAction {get; set;}
        Action<int> myActionWithParameter {get; set;}


        /*
        Func Delegate returns a value 'Func<returnType>'
        */
        public Func<int> myFuncDelegateInt;
        public Func<string> myFuncDelegateStr;

    }
}