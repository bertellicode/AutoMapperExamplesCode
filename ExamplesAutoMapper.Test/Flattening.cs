
using System;
using System.Diagnostics;
using ExamplesAutoMapper.Mapper.Adapter;
using ExamplesAutoMapper.Mapper.Config.AutoMapper;
using ExamplesAutoMapper.Model;
using ExamplesAutoMapper.Model.Dto;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExamplesAutoMapper.Test
{
    /// <summary>
    /// Summary description for Flattening
    /// </summary>
    [TestClass]
    public class Flattening
    {

        private ITypeAdapter _typeAdapter;

        private Customer customer;
        private Order order;
        private Product bosco;

        public Flattening()
        {
            customer = new Customer { Name = "George Costanza" };
            order = new Order { Customer = customer };
            bosco = new Product { Name = "Bosco", Price = 4.99m };
            order.AddOrderLineItem(bosco, 15);
        }

        [TestMethod]
        public void AutoMapperFlatteningMethod()
        {

            _typeAdapter = new AutoMapperAdapter();

            AutoMapperConfiguration.RegisterMappings();

            OrderDto orderDto = AddWatch(() => _typeAdapter.Adapt<Order, OrderDto>(order));

            Assert.AreEqual("George Costanza", orderDto.CustomerName);

            Assert.AreEqual(74.85m, orderDto.Total); 

        }

        [TestMethod]
        public void FastMapperFlatteningMethod()
        {

            _typeAdapter = new FastMapperAdapter();

            OrderDto orderDto = AddWatch(() => _typeAdapter.Adapt<Order, OrderDto>(order));

            Assert.AreEqual("George Costanza", orderDto.CustomerName);

            Assert.AreEqual(74.85m, orderDto.Total);

        }

        [TestMethod]
        public void EmitMapperFlatteningMethod()
        {

            _typeAdapter = new EmitMapperAdapter();

            OrderDto orderDto = AddWatch(() => _typeAdapter.Adapt<Order, OrderDto>(order));

            Assert.AreEqual("George Costanza", orderDto.CustomerName);

            Assert.AreEqual(74.85m, orderDto.Total);

        }

        [TestMethod]
        public void ValueInjecterFlatteningMethod()
        {

            _typeAdapter = new ValueInjecterAdapter();

            OrderDto orderDto = AddWatch(() => _typeAdapter.Adapt<Order, OrderDto>(order));

            Assert.AreEqual("George Costanza", orderDto.CustomerName);

            Assert.AreEqual(74.85m, orderDto.Total);

        }

        public OrderDto AddWatch(Func<OrderDto> action)
        {
            var stopWatch = new Stopwatch();

            stopWatch.Start();

            var result = action();

            Debug.WriteLine("{0}: Tempo de Execução {1}", _typeAdapter.Name, stopWatch.Elapsed);

            return result;
        }
    }
}
