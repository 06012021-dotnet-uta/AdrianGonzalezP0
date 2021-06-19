using System;
using System.Collections.Generic;
namespace StoreModels

{
    /// <summary>
    /// The main <c>Store</c> class. 
    /// Concatinates all of the fields together of the and returns it as a string 
    /// </summary>
    public class Store : Address, IComparable
    {
        public int StoreId { get; set; }
        public string StoreName { get; set; }
        public string ContactNumber { get; set; }
        public string Description { get; set; }

        public Store() { }

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
        public Store(string StoreName, string Street, string City, string State, string ZipCode, string ContactNumber, string Description) : base(Street, City, State, ZipCode)
        {
            this.StoreName = StoreName;
            this.Street = Street;
            this.ContactNumber = ContactNumber;
            this.Description = Description;
        }

        /// <summary>
        /// Concatinates all of the fields together of the and returns it as a string 
        /// </summary>
        /// <returns>A string with all if the fields</returns>
        public string storeInfo()
        {
            string store_info = $"\t\tStore Information\nName: {this.StoreName}\nAddress:{this.Street}\nCity: {this.City}\nState: {this.State}\n{this.ZipCode}\nContact Number: {this.ContactNumber}\nDesciption: {this.Description}";
            return store_info;
        }

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;

            Store otherStore = obj as Store;
            if (otherStore != null)
                return StoreName.CompareTo(otherStore.StoreName);
            else
                throw new ArgumentException("Object is not a Store");
        }
    }
}