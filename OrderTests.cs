using OederProcessSystem.Model;
using OrderProcessing.Core.Repositories;
using OrderProcessing.Core.Services;
using OrderProcessing.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;


namespace OrderProcess.IntegrationTests
{

    [TestFixture]
     public class OrderTests
     {

        private readonly string _dataPath;
        private readonly OrderService _service;

       
        public OrderTests()
        {

          //  _dataPath ="D:\\ProjectsDotnet\\Infrastructure\\Data.json";

            _dataPath = "D:\\ProjectsDotnet\\Infrastructure\\Order.json";

            var orderRepository =new FileOrderRepository(_dataPath);

            _service = new OrderService(orderRepository);
            
        }



        [Test]

        public void CreateOrder_Validate_PersistsCorrectly()
        {
            //Arrange
            //Act
            var order = _service.CreateOrder("tea", 10, 10);

            

            var retrievedOrder = _service.GetOrder(order.Id);

            Assert.That( retrievedOrder.Id,Is.EqualTo(order.Id));

            
        }
        [Test ]
        public void GetOrder_WhenOrderExists_shouldReturnOrder()
        {
            //Arrange Act
            var order = _service.CreateOrder("sugar", 3, 200);
            
            var retrivdOrder= _service.GetOrder(order.Id);

            //Assert

            Assert.That(retrivdOrder,Is.Not.Null);
            Assert.That(retrivdOrder.Id, Is.EqualTo(order.Id));
            Assert.That(retrivdOrder.Name, Is.EqualTo(order.Name));




        }

        [Test]
        
        public void GetOrder_WhenOrderDoesNot_Exists_ShouldReturnThrowKeyNotFoundExpection()
        {

            //arrange

            var dumpId = Guid.NewGuid();

            var ex= Assert.Throws<System.Collections.Generic.KeyNotFoundException>(
                ()=>_service.GetOrder(dumpId));
            Assert.That(ex.Message, Does.Contain(dumpId.ToString()));
        }

        [Test]

        public void CreateOrder_WithZeroQuantity_should()
        {
            var ex = Assert.Throws<ArgumentException>(
                ()=> _service.CreateOrder("TestCustomer" ,0, 10)


                );

        }

        [Test]

        public void CreateOrdrerwithZeroPrice()
        {

            var ex = Assert.Throws<ArgumentException>(
                
                ()=> _service.CreateOrder("Test customer" ,10 ,0)
                );

        }

        [Test]
        public void CreateOrderWithNegativeAttribute()
        {

            var ex = Assert.Throws<ArgumentException>(

                 () => _service.CreateOrder("testcustomer" ,-1,  -1)

                );
        }

        [Test]

        public void OrderId_MustBeUnique()
        {

            var order1 = _service.CreateOrder("Customer1", 20, 2);
            var order2 = _service.CreateOrder("Customer2", 30, 3);

            Assert.That(order1.Id, Is.Not.EqualTo(order2.Id));


        }

        [Test]
        [TestCase("Ali" ,100 ,1)]
        [TestCase("Omar" ,200 ,2)]
        [TestCase("sara" ,300  ,3)]

        public void CreateOrder_WithDifferentData(string cusname , double price ,int quantity)
        {
            var order = _service.CreateOrder(cusname, price,quantity);

            Assert.That(order.Name, Is.EqualTo(cusname));
            Assert.That(order.Quantity, Is.EqualTo(quantity));
            Assert.That(order.Price, Is.EqualTo(price));
           

        }

       









        //   [Test]
        // public void GetOrder_WithValidID_ThrowsException()
        // {
        //       IOrderRepository orderRepository = new FileOrderRepository(_dataPath);
        //       OrderService orderService = new OrderService(orderRepository);

        //       Guid ExistingId = new Guid("e65db3c3-cf11-4045-93db-bf52eec9b930");
        //       var order = orderService.GetOrder(ExistingId);
        //       Assert.Equals(order.Id, ExistingId.ToString());

        //}





        //[Test]
        //public void GetOrder_NonExisting_ThrowsException1()
        //{
        //    IOrderRepository orderRepository = new FileOrderRepository(_dataPath);
        //    OrderService orderService = new OrderService(orderRepository);

        //    var nonExistingId = Guid.NewGuid();
        //    Assert.Throws<KeyNotFoundException>(
        //        () => orderService.GetOrder(nonExistingId));
        //}








        //[Test]
        //public void CreateOrder_InvalidQuantity_ThrowsException()
        //{
        //    IOrderRepository orderRepository = new FileOrderRepository(_dataPath);
        //    OrderService orderService = new OrderService(orderRepository);
        //    Assert.Throws<ArgumentException>(
        //        () =>orderService.CreateOrder("Test", 0, 10));
        //}


        //[Test]
        //public void CreateOrder_InvalidPrice_ThrowsException()
        //{
        //    IOrderRepository orderRepository = new FileOrderRepository(_dataPath);
        //    OrderService orderService = new OrderService(orderRepository);
        //    Assert.Throws<ArgumentException>(
        //        () => orderService.CreateOrder("Test", 1, 0));
        //}










        //public void Dispose()
        //{
        //    if (File.Exists(_dataPath))
        //        File.Delete(_dataPath);
        //}
    }










}
