using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using NewsAgency.Utilities;
using NewsAgency.Models;
using Moq;
using NewsAgency.Repositories;
using System.Collections.Generic;
using System.Linq;
using NewsAgency.Controllers;
using NewsAgency.Services;
namespace UnitTests
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void TestPaging()
        {
            //Arrange- define an HTML Helper - we need to do this
            //in order to apply the extension method

            HtmlHelper myHelper = null;

            //Arrange = create PagingInfo data
            PagingInfo pagingInfo = new PagingInfo
            {
                CurrentPage = 2,
                TotalItems = 28,
                ItemsPerPage = 10
            };

            //Arrange- set up the delegate using a lambda expression
            Func<int, string> pageUrlDelegate = i => "Page" + i;

            //Act
            MvcHtmlString result = myHelper.PageLinks(pagingInfo, pageUrlDelegate);

            //Assert
            Assert.AreEqual(@"<a class=""btn btn-default"" href=""Page1"">1</a>"
                + @"<a class=""btn btn-default btn-primary selected"" href=""Page2"">2</a>"
                + @"<a class=""btn btn-default"" href=""Page3"">3</a>", result.ToString());
        }

        [TestMethod]
        public void Test_Can_Send_Pagination_View_Model()
        {
            //Arrange
            Mock<INewsRepository> mock_repository = new Mock<INewsRepository>();
            mock_repository.Setup(m => m.Users).Returns(new DAL.DataBase.User[]{
                new DAL.DataBase.User{Id=1,UserName="u1",Role="r1"},
                new DAL.DataBase.User{Id=2,UserName="u2",Role="r2"},
                new DAL.DataBase.User{Id=3,UserName="u3",Role="r3"},
                 new DAL.DataBase.User{Id=4,UserName="u4",Role="r4"},
                new DAL.DataBase.User{Id=5,UserName="u5",Role="r5"},

            });

         
            //Arrange 
            UserManagementController controller = new UserManagementController(new NewsAgencyService(), mock_repository.Object);
            var result = (UserListViewModel)((ViewResult)controller.ManageUsers(2)).Model;

            PagingInfo pageInfo = result.PagingInfo;
            Assert.AreEqual(pageInfo.CurrentPage, 2);
            Assert.AreEqual(pageInfo.ItemsPerPage, 3);
            Assert.AreEqual(pageInfo.TotalItems, 5);
            Assert.AreEqual(pageInfo.TotalPages, 2);
        }
    }
}
