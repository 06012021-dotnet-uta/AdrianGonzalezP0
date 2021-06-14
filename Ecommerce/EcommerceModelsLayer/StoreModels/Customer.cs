
namespace StoreModels
{
    /// <summary>
    /// The main <c>Customer</c> class. 
    /// Contains detail information about a customer.    
    /// </summary>
    public class Customer : Address
    {
        public int CustomerId { get; set; }             // A customer Id which is provided by the database
        public Account Account;                        // Customer's Account
        public string Fname { get; set; }              // First name of the customer
        public string Lname { get; set; }              // Last name of the customer 
        public string ContactNumber { get; set; }      // The customers contact info
        public string Email { get; set; }              // The email of customer

        /// <summary>
        /// This Constructor is responsible for initializing the state of the customer
        /// </summary>
        /// <param name="Account">An Account Object</param>
        /// <param name="Fname">String First Name</param>
        /// <param name="Lname">String Last Name</param>
        /// <param name="Street">String Street</param>
        /// <param name="City">String City Name</param>
        /// <param name="State">String State Name</param>
        /// <param name="Zipcode">String ZipCode</param>
        /// <param name="ContactNumber">String Contact Number or Phone Number</param>
        /// <param name="Email">String email of Customer</param>
        public Customer(Account Account, string Fname, string Lname, string Street, string City, string State, string Zipcode, string ContactNumber = null, string Email = null) : base(Street, City, State, Zipcode)
        {
            this.Fname = Fname;
            this.Lname = Lname;
            this.ContactNumber = ContactNumber;
            this.Email = Email;
            this.Account = Account;
        }

        /// <summary>
        /// Concatinates all of the fields together of the and returns it as a string 
        /// </summary>
        /// <returns>All info about the Client inlcuding Account info</returns>
        public string customerInfo()
        {
            string customer_info = $"\t\tCustomer Information\nFirst Name: {this.Fname}\nLast Name: {this.Lname}\nAddress: {this.Street}\nCity: {this.City}\nState: {this.State}\nZipcode: {this.Zipcode}\nContact Number: {this.ContactNumber}\nEmail: {this.Email}\n\n\t\t Account Info\n{this.Account.accountInfo()}";
            return customer_info;
        }

    }
}