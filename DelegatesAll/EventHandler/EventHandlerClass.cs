using System;

namespace EventHandler
{
    public class EventHandlerClass
    {
        /*
            1. Create the Delagate Type
            2. Instantiate the delegate
        */

        // 'EventsArgs' is an
        public delegate void Messagehandler(object source, MessageEventArgsClass args);

        // 'event' is a ...
        public event Messagehandler myMessageHandler;

        // Raise the event through this preparatory/protector method
        public void MessageSend(string message) {
            
            message += message;
            OnMessageSend(message);
        }

        private void OnMessageSend(string message) {

            //Check if there are any sunscribers to the delagate
            if (myMessageHandler != null) {

                MessageEventArgsClass meac = new MessageEventArgsClass() {MyString = message};
                myMessageHandler(this, meac);
                Console.WriteLine(meac.MyString);

            } else {

                Console.WriteLine("There were no subscribers to the event");
            }
        }

    } // EOC
} // EON