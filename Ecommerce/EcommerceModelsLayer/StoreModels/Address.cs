namespace StoreModels
{
    /// <summary>
    /// This interface is makes sure the classes implement all the info of a location
    /// </summary>
    public class Address
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zipcode { get; set; }

        public Address() { }
        public Address(string Street, string City, string State, string Zipcode)
        {
            this.Street = Street;
            this.City = City;
            this.State = State;
            this.Zipcode = Zipcode;
        }
    }
}