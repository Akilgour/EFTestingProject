using EFModels.Model;
using EFRepository.Context;
using EFRepository.Repositorys;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace EFRepository.Test.Repositorys
{
    [TestFixture]
    public class SalesOrderRepositoryTest
    {
        private const string saleOrderIdOne = "41f1cf63-c26f-496b-8b98-37b2d818aca6";
        private const string saleOrderIdTwo = "bd149afd-fa75-4403-b00e-ebcf634fe0d5";
        private const string saleOrderIdThree = "82d48fee-f386-415b-b69b-2bec16ec0768";
        private const string saleOrderIdFour = "8933a51e-f49c-44cc-a66b-1b7aeb550721";

        [TestCase(saleOrderIdOne, "John")]
        [TestCase(saleOrderIdTwo, "Paul")]
        [TestCase(saleOrderIdThree, "George")]
        [TestCase(saleOrderIdFour, "Ringo")]
        public void GetById(string Id, string expected)
        {
            //arrange
            var salesOrderRepository = new SalesOrderRepository(SetUpContext());
            //act
            var value = salesOrderRepository.GetById(new Guid(Id));
            //assert
            Assert.AreEqual(expected, value.CustomerFirstName);
        }

        [TestCase(saleOrderIdOne, 1)]
        [TestCase(saleOrderIdTwo, 2)]
        [TestCase(saleOrderIdThree, 6)]
        [TestCase(saleOrderIdFour, 3)]
        public void GetById_SaleOrderItemsCount(string Id, int expected)
        {
            //arrange
            var salesOrderRepository = new SalesOrderRepository(SetUpContext());
            //act
            var value = salesOrderRepository.GetById(new Guid(Id));
            //assert
            Assert.AreEqual(expected, value.SaleOrderItems.Count());
        }

        private static MyContext SetUpContext()
        {
            var salesOrderOne = new SaleOrder() { Id = new Guid(saleOrderIdOne), CustomerFirstName = "John" };
            salesOrderOne.SaleOrderItems = new List<SaleOrderItem>() { new SaleOrderItem() };

            var salesOrderTwo = new SaleOrder() { Id = new Guid(saleOrderIdTwo), CustomerFirstName = "Paul" };
            salesOrderTwo.SaleOrderItems = new List<SaleOrderItem>() { new SaleOrderItem(), new SaleOrderItem() };

            var salesOrderThree = new SaleOrder() { Id = new Guid(saleOrderIdThree), CustomerFirstName = "George" };
            salesOrderThree.SaleOrderItems = new List<SaleOrderItem>() { new SaleOrderItem(), new SaleOrderItem(), new SaleOrderItem(), new SaleOrderItem(), new SaleOrderItem(), new SaleOrderItem() };

            var salesOrderFour = new SaleOrder() { Id = new Guid(saleOrderIdFour), CustomerFirstName = "Ringo" };
            salesOrderFour.SaleOrderItems = new List<SaleOrderItem>() { new SaleOrderItem(), new SaleOrderItem(), new SaleOrderItem() };

            var SaleOrders = new List<SaleOrder>
            {
               salesOrderOne,
               salesOrderTwo,
               salesOrderThree,
               salesOrderFour
            }.AsQueryable();

            var context = Substitute.For<MyContext>();
            context.SaleOrders = Substitute.For<IDbSet<SaleOrder>>().Initialize(SaleOrders);
            return context;
        }
    }
}