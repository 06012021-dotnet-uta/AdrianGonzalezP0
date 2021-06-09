using System;

namespace rock_paper_scissors {
    public class PlayerDerivedClass : PersonBaseClass {
        public string Street {get; set;}
        public string State {get; set;}
        public string City {get; set;}

        private int _age;
        public int Age {
            get {
                return _age; 
            }
            set {
                if (value > 125 || value < 1) {
                    throw new InvalidOperationException("Age value is too high!");
                }
                _age = value;
            }
        }

        public PlayerDerivedClass() : base() {}
        
        public PlayerDerivedClass(string fname, string lname, int age = 0) : base(fname,lname) {
            this.Age = age;
        }

        public override string GetFullAddress() {
            string fullAdd = $"{Fname} {Lname}\n{Street}\n{City}, {State}.";

            return fullAdd;
        }
    }
}