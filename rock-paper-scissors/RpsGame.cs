using System;

namespace rock_paper_scissors {
    public class RpsGame {
        private bool successfulConversion;
        private int playerChoiceInt;

        public RpsGame() {
            this.successfulConversion = false;
            this.playerChoiceInt = 1;
        }
        public string WelcomeMessage() {
            string welcome = "\tWelcome to Rock-Paper-Scissors!\n\nPlease make a choice.";
            return welcome;
        }

        public string getPlayerName(string playerInput) {
            
            playerInput = playerInput.Trim();

            if (playerInput.Length > 20 || playerInput.Length < 1) {
                
                return null;
            }

            return "";
        }

        public int? chooseRPS(string move) {

            do {
    
                // Create a int variable to catch the converted choice
                successfulConversion = Int32.TryParse(move, out playerChoiceInt);

                if (playerChoiceInt > 3 || playerChoiceInt < 1) {
                    Console.WriteLine($"You Inputted {playerChoiceInt}. That is not a valid choice.");
                    return null;
                } else if (!successfulConversion) {
                    Console.WriteLine($"You Inputted {move}. That is not a valid choice.");
                    return null;
                }

            } while (!successfulConversion || !(playerChoiceInt >= 1 && playerChoiceInt <= 3));

            return playerChoiceInt;
        }

        public void getPlayerMove(int move) {

        }

        public string checkWinner(int player1, int player2){
            string winner;

            if ((player1 == 1 && player2 == 2) || 
                (player1 == 2 && player2 == 3) ||
                (player1 == 3 && player2 == 1)) {
                
                winner = "Player 1 Wins";

            } else if (player1 == player2) {

                winner = "Tie Round!!";

            } else {
                winner = "Computer Wins";
                
            }
            return winner;

        }
        
        // public void displayChoice(int player1, int player2) {
        //     Console.WriteLine($"The players choice is {(RpsChoice)player1}");
        //     Console.WriteLine($"The computer's choice is {(RpsChoice)player2}");
        // }
}