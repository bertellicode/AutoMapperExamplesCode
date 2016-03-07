
using ExamplesAutoMapper.Mapper.Adapter;
using ExamplesAutoMapper.Mapper.Config.AutoMapper;
using ExamplesAutoMapper.Model.Flattening;
using ExamplesAutoMapper.Test.Config;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExamplesAutoMapper.Test
{
    /// <summary>
    /// Summary description for Flattening
    /// </summary>
    [TestClass]
    public class FlatteningTest
    {

        private ITypeAdapter _typeAdapter;
        private IWatch<OrderDto> _watch;

        private Customer customer;
        private Order order;
        private Product bosco;

        public FlatteningTest()
        {
            customer = new Customer { Name = "George Costanza" };
            order = new Order { Customer = customer };
            bosco = new Product { Name = "Bosco", Price = 4.99m };
            order.AddOrderLineItem(bosco, 15);
            _watch = new Watch<OrderDto>();
        }

        [TestMethod]
        public void AutoMapperFlatteningMethod()
        {

            _typeAdapter = new AutoMapperAdapter();

            AutoMapperConfiguration.RegisterMappings();

            OrderDto orderDto = _watch.AddWatch(() => _typeAdapter.Adapt<Order, OrderDto>(order), _typeAdapter);

            Asserts(orderDto);

        }

        [TestMethod]
        public void FastMapperFlatteningMethod()
        {

            _typeAdapter = new FastMapperAdapter();

            OrderDto orderDto = _watch.AddWatch(() => _typeAdapter.Adapt<Order, OrderDto>(order), _typeAdapter);

            Asserts(orderDto);

        }

        public void Asserts(OrderDto orderDto)
        {

            Assert.AreEqual("George Costanza", orderDto.CustomerName);
            Assert.AreEqual(74.85m, orderDto.Total);

        }

    }
}
