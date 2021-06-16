using EcommerceBusinessLayer;
using System;
using DbCustomer = EcommerceDbContext.Customer;
using DbStore = EcommerceDbContext.Store;
using StoreAccount = StoreModels.Account;
using Xunit;
using System.Collections.Generic;

namespace Ecommerce.Test
{
    public class UnitTest1
    {
        [Theory]
        [InlineData("agonzalez108", "123456")]
        public void credentailsEvaluate(string username, string password)
        {
            // Arange
            AccountBusiness accountBusiness = new();

            // Act
            bool result = accountBusiness.credentials(username, password);

            // Assert
            Assert.True(result);
        }

        [Theory]
        [InlineData("agonzalez108")]
        public void searchCustomerEvaluate(string username)
        {
            // Arrange
            CustomerBusiness customerBusiness = new();

            // Act
            DbCustomer result = customerBusiness.searchCustomer(username);

            // Assert
            Assert.IsType<DbCustomer>(result);

        }

        [Fact]
        public void RetrieveAllCostumersEvaluate()
        {
            // Arrange
            CustomerBusiness customerBusiness = new();

            // Act
            List<DbCustomer> result = customerBusiness.RetrieveAllCostumers();

            // Assert
            Assert.IsType<List<DbCustomer>>(result);

        }

        [Theory]
        [InlineData("Adrian","Gonzalez")]
        public void searchCustomerEvalute2(string Fname, string Lname)
        {
            // Arrange
            CustomerBusiness customerBusiness = new();

            // Act
            List<DbCustomer> result = customerBusiness.searchCustomer(Fname, Lname);

            // Assert
            Assert.IsType<List<DbCustomer>>(result);

        }

        [Fact]
        public void RetrieveAllStoresEvaluate()
        {
            // Arrange
            StoreBusiness storeBusiness = new();

            // Act
            List<DbStore> result = storeBusiness.RetrieveAllStores();

            // Assert
            Assert.IsType<List<DbStore>>(result);

        }

        [Fact]
        public void addAccountEvaluate()
        {
            // Arange
            AccountBusiness accountBusiness = new();
            StoreAccount objAccount = new StoreAccount()
            {
                Username = "TEST9",
                Password = "123456"
            };

            // Act
            bool result = accountBusiness.addAccount(objAccount);

            // Assert
            Assert.True(result);

        }

        [Fact]
        public void deleteAccountEvaluate()
        {
            // Arange
            AccountBusiness accountBusiness = new();
            string username = "TEST9";

            // Act
            bool result = accountBusiness.deleteAccount(username);

            // Assert
            Assert.True(result);

        }

        [Fact]
        public void updateAccountEvaluate()
        {
            // Arange
            AccountBusiness accountBusiness = new();
            StoreAccount objAccount = new StoreAccount()
            {
                Username = "TEST9",
                Password = "54321"  // New Password
            };

            // Act
            bool result = accountBusiness.updateAccount(objAccount);

            // Assert
            Assert.True(result);

        }

        [Fact]
        public void SearchByStoreNameEvaluate()
        {
            // Arange
            StoreBusiness storeBusiness = new();
            string storeName = "Walmart";

            // Act
            List<DbStore> result = storeBusiness.SearchByStoreName(storeName);

            // Assert
            Assert.IsType<List<DbStore>>(result);

        }
    }
}
