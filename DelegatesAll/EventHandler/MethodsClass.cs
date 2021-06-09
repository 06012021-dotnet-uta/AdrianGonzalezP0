using System;

namespace EventHandler
{
    public class MethodsClass
    {
        public void OnMessageSend1(object source, MessageEventArgsClass args) {
            
            Console.WriteLine("Add a word to the message");
            string usersMessage = Console.ReadLine(); // Get a word from user
            args.MyString += usersMessage; // that new word to the existing method
        }

        public void OnMessageSend2(object source, MessageEventArgsClass args) {
            
            Console.WriteLine("Add a word to the message");
            string usersMessage = Console.ReadLine(); // Get a word from user
            args.MyString += usersMessage; // that new word to the existing method
        }
    }
}