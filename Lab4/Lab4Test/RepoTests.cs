using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Lab4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lab4Test
{
    [TestClass]
    public class RepoTests
    {
        public static IEnumerable<Product> Products;
        public static IProductRepository ProductRepository;

        [ClassInitialize]
        public static void InitializeRepositories(TestContext context)
        {
            Products = new List<Product>
            {
                new Product("A", "B", new DateTime(2017, 10, 10), new DateTime(2017, 10, 12), 100.0),
                new Product("C", "C", new DateTime(2017, 10,15), new DateTime(2017, 10, 20), 120.0),
                new Product("D", "D", new DateTime(2017, 10, 17), new DateTime(2017, 10, 30), 130.0),
                new Product("E", "E", new DateTime(2017, 10, 12), new DateTime(2017, 10, 21), 130.0),
                new Product("F", "BF", new DateTime(2017, 10, 18), new DateTime(2017, 10, 22), 10.0),
                new Product("G", "BG", new DateTime(2017, 10, 24), new DateTime(2017, 10, 30), 1010.0),
                new Product("H", "BH", new DateTime(2017, 10, 26), new DateTime(2017, 10, 29), 5.0),
                new Product("IA", "BJ", new DateTime(2017, 10, 27), new DateTime(2017, 11, 10), 180.0),
                new Product("J", "BK", new DateTime(2017, 10, 28), new DateTime(2017, 10, 29), 20.0),
                new Product("K", "BL", new DateTime(2017, 10, 29), new DateTime(2017, 11, 3), 1200.0)
            };

 //<------------Set The Wanted Repository Here: Method Or Query (if misspelled or not specified->default is Method Repository)--------------------->
            string strategy = "Query";
            selectStrategy(strategy);
        }

        private static void selectStrategy(string strategy)
        {
            if (strategy.Equals("Query"))
                ProductRepository = new QueryProductRepository(Products);
            else
                ProductRepository = new MethodProductRepository(Products);
        }

        //am inteles prin active acele produse care au start date-ul in trecut sau in prezent si end date-ul in viitor
        [TestMethod]
        public void shouldRetrieveAllActiveProducts()
        {
            ProductRepository.RetrieveActiveProducts().Count().Should().Be(2);
        }

        [TestMethod]
        public void shouldRetrieveAllInactiveeProducts()
        {
            ProductRepository.RetrieveInactiveProducts().Count().Should().Be(8);
        }

        [TestMethod]
        public void shouldRetrieveAllOrderByPriceDescending()
        {
            ProductRepository.RetrieveAllOrderByPriceDescending().First().Price.Should().Be(1200.0);
            ProductRepository.RetrieveAllOrderByPriceDescending().Last().Price.Should().Be(5.0);
        }

        [TestMethod]
        public void shouldRetrieveAllOrderByPriceAscending()
        {
            ProductRepository.RetrieveAllOrderByPriceAscending().First().Price.Should().Be(5.0);
            ProductRepository.RetrieveAllOrderByPriceAscending().Last().Price.Should().Be(1200.0);
        }


        [TestMethod]
        public void shouldRetrieveProductsThatContainNameInProductName()
        {
            ProductRepository.RetrieveAll("A").Count().Should().Be(2);
            ProductRepository.RetrieveAll("B").Count().Should().Be(0);
        }

        [TestMethod]
        public void shouldRetrieveProductsInBetweenDates()
        {
            ProductRepository.RetrieveAll(new DateTime(2017, 10, 18), new DateTime(2017, 10, 29)).Count().Should()
                .Be(3);
        }
    }
}
