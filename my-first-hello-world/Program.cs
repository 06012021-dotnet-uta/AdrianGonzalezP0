using System;

namespace my_first_hello_world
{
    class Program
    {
  
        static void Main(string[] args)
        {
            Console.WriteLine("What's your name");
            string name = Console.ReadLine();
            Console.WriteLine("What's your age");
            int age = Convert.ToInt32(Console.ReadLine());
            
            Console.Write("\t{0} is {1} years old\n", name, age);

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