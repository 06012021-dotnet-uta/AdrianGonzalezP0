using System;

namespace rock_paper_scissors
{
    partial class Program
    {   
        static Random rand = new Random();
        static bool playAgain = true;
        static int playerScore = 0;
        static int computerScore = 0;
        static int tieScore = 0;
        static string playerName;

        static void Main(string[] args) {
            RpsGame rpsGame = new RpsGame();
            PlayerDerivedClass player1 = new PlayerDerivedClass();
            PlayerDerivedClass computer = new PlayerDerivedClass("Max", "HeadRoom", 38);




            Console.WriteLine("\tWelcome to Rock-Paper-Scissors!\n\nEnter Name.");
            playerName = Console.ReadLine();
            
            Console.WriteLine("\n\nPlease make a choice.");
            int rounds = 0;
            
            while (rounds <= 2 && playAgain) {
                Console.WriteLine($"Round: {rounds+1}");

                if (rounds == 2) {
                    string winner = (playerScore > computerScore) ? playerName : "Computer";
                    winner = (tieScore > playerScore && tieScore > computerScore) ? "Tie" : winner;
                    Console.WriteLine($"Game Over. {winner} is the winner!"); 
                    Console.WriteLine($"Play again. Press Y (Yes) or N (No)\n");
                    string userResp = Console.ReadLine();

                    playAgain = userResp.ToLower().Contains("y");

                    rounds = 0;
                    playerScore = 0;
                    computerScore = 0;                    
                }

                rounds++;
            }
            
        }
    }
}
