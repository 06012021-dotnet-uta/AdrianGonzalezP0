namespace StoreModels
{
    /// <summary>
    /// The main <c>Store</c> class. 
    /// Concatinates all of the fields together of the and returns it as a string 
    /// </summary>
    public class Store : ILocation
    {
        public int StoreId { get; set; }
        public string StoreName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zipcode { get; set; }
        public string ContactNumber { get; set; }
        public string Description { get; set; }

        /// <summary>
        /// This Constructor is responsible for initizaling the store state
        /// </summary>
        /// <param name="StoreName">String name of the store</param>
        /// <param name="Address">String Addresss</param>
        /// <param name="City">String City</param>
        /// <param name="State">String State</param>
        /// <param name="ZipCode">String ZipCode</param>
        /// <param name="ContactNumber">String Contact Number</param>
        /// <param name="Description">String Description</param>
        public Store(string StoreName, string Address, string City, string State, string ZipCode, string ContactNumber, string Description)
        {
            this.StoreName = StoreName;
            this.Address = Address;
            this.City = City;
            this.State = State;
            this.Zipcode = ZipCode;
            this.ContactNumber = ContactNumber;
            this.Description = Description;
        }

        /// <summary>
        /// Concatinates all of the fields together of the and returns it as a string 
        /// </summary>
        /// <returns>A string with all if the fields</returns>
        public string storeInfo()
        {
            string store_info = $"\t\tStore Information\nName: {this.StoreName}\nAddress:{this.Address}\nCity: {this.City}\nState: {this.State}\n{this.Zipcode}\nContact Number: {this.ContactNumber}\nDesciption: {this.Description}";
            return store_info;
        }
    }
}