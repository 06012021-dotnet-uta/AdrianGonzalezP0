using System.Collections.Generic;

namespace rock_paper_scissors {
    public class Game {
        public PlayerDerivedClass Player1 {get;set;}
        public PlayerDerivedClass Player2 {get;set;}
        public List<int> Player1Choice {get;set;}
        public List<int> Player2Choice {get;set;}

        public Game() {
            Player1Choice = new List<int>();
            Player2Choice = new List<int>();
        }


    }
}