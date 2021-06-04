using System;

namespace rock_paper_scissors {
    public class PersonBaseClass {
        private string _fname;
        private string _lname;

        public int Score { get; set; }

        public string Fname {
            get {
                return _fname;
            }
            set {
                if (value.Length > 20 || value.Length < 1) {
                    throw new InvalidOperationException("fname is invalid");
                }
                _fname = value;
            }
        }

        public string Lname {
            get {
                return _lname;
            }
            set {
                if (value.Length > 20 || value.Length < 1) {
                    throw new InvalidOperationException("lname is invalid");
                }
                _lname = value;
            }
        }

        public PersonBaseClass() {
            this.Fname = "defaultFname";
            this.Lname = "defaultLname";
            this.Score = 0;
        }
        
        public PersonBaseClass(string fname, string lname) {
            this.Fname = fname;
            this.Lname = lname;
            this.Score = 0;
        }

        public virtual string GetFullAddress() {
            string fullname = $"{Fname} {Lname}";
            return fullname;
        }

    }

}