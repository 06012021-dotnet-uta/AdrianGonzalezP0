using System;

namespace EventHandler
{
    class Program
    {
        static void Main(string[] args)
        {
            EventHandlerClass eventHandlerClass = new EventHandlerClass();
            MethodsClass methodsClass = new MethodsClass();

            // We are subscribing 
            eventHandlerClass.myMessageHandler += methodsClass.OnMessageSend1; // You can only subscribe methods to the event with '+' or '-'
            eventHandlerClass.myMessageHandler += methodsClass.OnMessageSend2;

            Console.WriteLine("Eneter a Word");
            string message = Console.ReadLine(); // Get message from the user
            eventHandlerClass.MessageSend(message); // envoke the prep/protector method to the event

        }
    }
}
