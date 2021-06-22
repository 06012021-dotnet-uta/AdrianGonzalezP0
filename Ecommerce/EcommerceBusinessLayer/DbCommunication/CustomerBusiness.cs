using System;
using System.Linq;
using EcommerceDbContext;
using Mapper;
using DbContext;
using StoreCustomer = StoreModels.Customer;
using DbCustomer = EcommerceDbContext.Customer;
using StoreAccount = StoreModels.Account;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EcommerceBusinessLayer
{
    public class CustomerBusiness : ICustomer
    {
        private readonly Project0Context _context;
        private DbCustomer dbCustomer;
        private StoreCustomer storeCustomer;

        public CustomerBusiness() 
        {
            _context = DbConextProject.DbContext;
        
        }
        
        /// <summary>
        /// Creates a new Customer in data entry for Customers table
        /// </summary>
        /// <param name="obj"> An instance of a Customer object</param>
        /// <returns>True if successfuly added to database. False otherwise.</returns>
        public bool Create(StoreCustomer obj)
        {
            dbCustomer = MapperClassAppToDb.AppCustomerToDbCustomer(obj);

            try
            {
                _context.Customers.Add(dbCustomer);
                _context.SaveChanges();
                return true;
            }
            catch (DbUpdateException e)

            {
                Console.WriteLine($"Could not create Customer with {obj.customerInfo()}\nError: {e.Message}");
                return false;
            }
        }

        /// <summary>
        /// Deletes and existing cutomer from the databse.
        /// </summary>
        /// <param name="obj">An instance of a Customer object</param>
        /// <returns>True if successfuly added to database. False otherwise.</returns>
        public bool Delete(StoreCustomer obj)
        {
            dbCustomer = MapperClassAppToDb.AppCustomerToDbCustomer(obj);

            try
            {
                _context.Customers.Remove(dbCustomer);
                _context.SaveChanges();
                return true;
            }
            catch (DbUpdateException e)

            {
                Console.WriteLine($"Could not delete Customer with {obj.customerInfo()}\nError: {e.Message}");
                return false;
            }
        }

        /// <summary>
        /// Returns the number of elements from Customer
        /// </summary>
        /// <returns>The number of elements as a long</returns>
        public long LengthOfCustomers()
        {
            try
            {
                long lengthCustomer = _context.Customers.Count();
                return lengthCustomer;
            }
            catch (OverflowException e)
            {
                Console.WriteLine($"Could not retrieve length of table\nError Message {e.Message}");
                return 0;
            }
        }

        /// <summary>
        /// Retrieves a single data entry from Customers table with a given name
        /// </summary>
        /// <param name="keyValue">Customers name</param>
        /// <returns>A single data entry from Customers table</returns>
        public StoreCustomer Read(string keyValue)
        {
            try
            {
                dbCustomer = _context.Customers.SingleOrDefault(customer => customer.Fname == keyValue);
                storeCustomer = MapperClassDBToApp.DbCustomerToClassCustomer(dbCustomer);
                return storeCustomer;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public List<StoreCustomer> SearchCustomer(string Fname, string Lname)
        {
            try
            {
                List<DbCustomer> dbCustomer = _context.Customers
                    .Where(customer => customer.Fname.ToLower().Trim() == Fname.ToLower().Trim() && customer.Lname.ToLower().Trim() == Lname.ToLower().Trim()).ToList();

                List<StoreCustomer> storeCustomers = dbCustomer.ConvertAll(customer => MapperClassDBToApp.DbCustomerToClassCustomer(customer));

                return storeCustomers;
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Error - Could not retrieve customer(s)");
                return null;
            }
        }

        public StoreCustomer SearchCustomer(string username)
        {
            throw new NotImplementedException();
        }

        public bool Update(StoreCustomer obj)
        {
            throw new NotImplementedException();
        }
    } //EOC
} // EON
