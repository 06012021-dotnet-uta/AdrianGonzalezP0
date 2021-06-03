using System;

namespace rock_paper_scissors
{
    class Program
    {   
        static Random rand = new Random();
        static bool playAgain = true;
        static int playerScore = 0;
        static int computerScore = 0;
        static int tieScore = 0;
        static string playerName;

        public enum RpsChoise {
            Rock=1,
            Paper=2,
            Scissors=3
        }
        static void Main(string[] args) {
            Console.WriteLine("\tWelcome to Rock-Paper-Scissors!\n\nEnter Name.");
            playerName = Console.ReadLine();
            
            Console.WriteLine("\n\nPlease make a choice.");
            int rounds = 0;
            
            while (rounds <= 2 && playAgain) {
                Console.WriteLine($"Round: {rounds+1}");
                playGame();

                if (rounds == 2) {
                    string winner = (playerScore > computerScore) ? playerName : "Computer";
                    winner = (tieScore > playerScore && tieScore > computerScore) ? "Tie" : winner;
                    Console.WriteLine($"Game Over. {winner} is the winner!"); 
                    Console.WriteLine($"Play again. Press y (yes) or n (no)\n");
                    string userResp = Console.ReadLine();

                    playAgain = userResp.ToLower().Contains("y");

                    rounds = 0;
                    playerScore = 0;
                    computerScore = 0;                    
                }

                rounds++;
            }
            
        }

        static void playGame() {
            bool successfulConversion = false;
            int playerChoiceInt;

            do {
                Console.Write("1. Rock\n2. Paper\n3. Scissors\n-> ");
                string playerChoice = Console.ReadLine();

                Console.WriteLine();
            
                // Create a int variable to catch the converted choice
                successfulConversion = Int32.TryParse(playerChoice, out playerChoiceInt);

                if (playerChoiceInt > 3 || playerChoiceInt < 1) {
                    Console.WriteLine($"You Inputted {playerChoiceInt}. That is not a valid choice.");
                } else if (!successfulConversion) {
                    Console.WriteLine($"You Inputted {playerChoice}. That is not a valid choice.");
                }

            } while (!successfulConversion || !(playerChoiceInt >= 1 && playerChoiceInt <= 3));
            
            // Displays who won the round
            int computerChoice = rand.Next(1, 3);
            Console.WriteLine($"The players choice is {(RpsChoise)playerChoiceInt}");
            Console.WriteLine($"The computer's choice is {(RpsChoise)computerChoice}");

            // Check who won
            if ((playerChoiceInt == 1 && computerChoice == 2) || 
                (playerChoiceInt == 2 && computerChoice == 3) ||
                (playerChoiceInt == 3 && computerChoice == 1)) {
                
                Console.WriteLine("Computer Wins this round!!");
                computerScore++;

            } else if (playerChoiceInt == computerChoice) {

                Console.WriteLine("Tie Round!!");
                tieScore++;
            } else {

                Console.WriteLine("Computer Wins this round!!");
                playerScore++;
            }

            Console.WriteLine();

    }
}
}
