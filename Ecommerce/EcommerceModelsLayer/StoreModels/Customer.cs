
namespace StoreModels
{
    /// <summary>
    /// The main <c>Customer</c> class. 
    /// Contains detail information about a customer.    
    /// </summary>
    public class Customer : Address
    {
        public int CustomerId { get; set; }             // A customer Id which is provided by the database
        public string Username { get; set; }                        // Customer's Account
        public string Fname { get; set; }              // First name of the customer
        public string Lname { get; set; }              // Last name of the customer 
        public string ContactNumber { get; set; }      // The customers contact info
        public string Email { get; set; }              // The email of customer

        public Customer(): base() { }

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
        public Customer(string Username, string Fname, string Lname, string Street, string City, string State, string Zipcode, string ContactNumber = null, string Email = null) : base(Street, City, State, Zipcode)
        {
            this.Fname = Fname;
            this.Lname = Lname;
            this.ContactNumber = ContactNumber;
            this.Email = Email;
            this.Username = Username;
        }

        /// <summary>
        /// Concatinates all of the fields together of the and returns it as a string 
        /// </summary>
        /// <returns>All info about the Client inlcuding Account info</returns>
        public string customerInfo()
        {
            string customer_info = $"\t\tCustomer Information\n\tUsername: {this.Username}\n\tFirst Name: {this.Fname}\n\tLast Name: {this.Lname}\n\tAddress: {this.Street}\n\tCity: {this.City}\n\tState: {this.State}\n\tZipcode: {this.ZipCode}\n\tContact Number: {this.ContactNumber}\n\tEmail: {this.Email}\n";
            return customer_info;
        }

    }
}