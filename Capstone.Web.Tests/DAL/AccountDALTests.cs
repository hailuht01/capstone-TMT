using System;
using System.Transactions;
using Capstone.Web.DAL;
using Capstone.Web.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Capstone.Web.Tests.DAL
{
    [TestClass]
    public class AccountDALTests
    {
        static string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=citytour;Integrated Security = True";
        AccountDAL testAccountDAL = new AccountDAL(connectionString);
        private TransactionScope tran;
        bool wasSuccessful = false;

        [TestInitialize]
        public void Initialize()
        {
            tran = new TransactionScope();
            RegistrationForm newUserForm = new RegistrationForm()
            {
                FirstName = "Jane",
                LastName = "Doe",
                Email = "j.doe@gmail.com",
                UserName = "jdoe18",
                Password = "Password!"
            };
            wasSuccessful = testAccountDAL.CreateUser(newUserForm);
        }

        [TestMethod]
        public void CreateUserTest()
        {
            Assert.IsTrue(wasSuccessful);
        }

        //[TestMethod]
        public void GetUserTest()
        {
            User user = testAccountDAL.GetUser("j.doe@gmail.com");

            Assert.IsNotNull(user);
            Assert.AreEqual("jdoe18", user.UserName);
        }

        [TestCleanup]
        public void Cleanup()
        {
            tran.Dispose();
        }
    }
}
