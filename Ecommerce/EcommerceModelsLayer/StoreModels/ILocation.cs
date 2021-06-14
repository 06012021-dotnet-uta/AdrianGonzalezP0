namespace StoreModels
{
    /// <summary>
    /// This interface is makes sure the classes implement all the info of a location
    /// </summary>
    public interface ILocation
    {
        string Address { get; set; }
        string City { get; set; }
        string State { get; set; }
        string Zipcode { get; set; }
    }
}