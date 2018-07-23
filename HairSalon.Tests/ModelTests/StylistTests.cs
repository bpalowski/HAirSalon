using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;
using HairSalon.Models;
//category
namespace HairSalon.Tests
{

    [TestClass]
    public class StylistTests : IDisposable
    {
        public StylistTests()
        {
            DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=brian_palowski_test;";
        }
        // public void Dispose()
        // {
        //   Stylist.DeleteAll();
        // //  Category.DeleteAll();
        // }

        [TestMethod]
       public void GetAll_CategoriesEmptyAtFirst_0()
       {
         //Arrange, Act
         int result = Stylist.GetAll().Count;

         //Assert
         Assert.AreEqual(0, result);
       }

       [TestMethod]
     public void Save_DatabaseAssignsIdToCategory_Id()
     {
       //Arrange
       Stylist testStylist = new Stylist("Household chores");
       testStylist.Save();

       //Act
       Stylist savedStylist  = Stylist.GetAll()[0];

       int result = savedStylist .GetId();
       int testId = testStylist .GetId();

       //Assert
       Assert.AreEqual(testId, result);
    }



       [TestMethod]
       public void Find_FindsCategoryInDatabase_Category()
       {
         //Arrange
         Stylist testStylist = new Stylist("Household chores");
         testStylist.Save();

         //Act
         Stylist foundStylist = Stylist.Find(testStylist.GetId());

         //Assert
         Assert.AreEqual(testStylist, foundStylist);
       }

       public void Dispose()
       {
         Stylist.DeleteAll();
         //Category.DeleteAll();
       }
     }

    }
