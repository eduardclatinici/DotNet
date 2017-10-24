using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace Lab4
{

    public class QueryProductRepository:IProductRepository
    {
        public IEnumerable<Product> ProductList { get; private set; }

        public QueryProductRepository(IEnumerable<Product> productList)
        {
            this.ProductList = productList;
        }

        public IQueryable<Product> RetrieveActiveProducts()
        {
            return (from product in ProductList
                where product.EndDate.CompareTo(DateTime.Today) >= 0 &&
                      product.StartDate.CompareTo(DateTime.Today) <= 0
                select product).AsQueryable();

        }

        public IQueryable<Product> RetrieveInactiveProducts()
        {
            return (from product in ProductList
                where product.EndDate.CompareTo(DateTime.Today) < 0 ||
                      product.StartDate.CompareTo(DateTime.Today) > 0
                select product).AsQueryable();
        }

        public IQueryable<Product> RetrieveAllOrderByPriceDescending()
        {
            return (from product in ProductList
                orderby product.Price descending
                select product).AsQueryable();
        }

        public IQueryable<Product> RetrieveAllOrderByPriceAscending()
        {
            return (from product in ProductList
                orderby product.Price ascending 
                select product).AsQueryable();
        }

        public IQueryable<Product> RetrieveAll(string name)
        {
            return (from product in ProductList
                where product.ProductName.Contains(name)
                select product).AsQueryable();
        }

        public IQueryable<Product> RetrieveAll(DateTime startDate, DateTime endDate)
        {
            return (from product in ProductList
                where product.StartDate.CompareTo(startDate) >= 0 &&
                product.EndDate.CompareTo(endDate) <= 0
                select product).AsQueryable();
        }

    }

}