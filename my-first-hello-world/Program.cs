using System;
using System.Collections.Generic;

namespace my_first_hello_world
{
    class Program
    {

        Action a = () => Console.WriteLine("it equlas");
  
        static void Main(string[] args)
        {

            Dictionary<string,int> dic = new Dictionary<string, int>();

            dic.Add("name", 4);
            dic.Add("david", 4);

            int i = 9;
            double j=  .2;

            Console.WriteLine(++i/j-i++);

            // Console.WriteLine($"is Girrffe object => {b as Animal}");
            //this is a comment

            /* this is a multiline comment
            going on 
            and and on*/

            /*
            1. Clone your P0 repo.
            2. create a new feature branch
            3. create the template hello world program in a file.
            4. In that hello world program, add code to....
            5. 1. prompt the user for their age
            6. prompt the user for their name
            7. print the users name and age to the console using string interpolation.
            */
        }
    }
}