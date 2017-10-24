using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab4
{

    public class MethodProductRepository:IProductRepository
    {
        public IEnumerable<Product> ProductList { get; private set; }

        public MethodProductRepository(IEnumerable<Product> productList)
        {
            this.ProductList = productList;
        }

        public IQueryable<Product> RetrieveActiveProducts()
        {
            return this.ProductList.Where(p => p.EndDate.CompareTo(DateTime.Today) >= 0 &&
                                               p.StartDate.CompareTo(DateTime.Today)<=0)
                                               .AsQueryable();
        }

        public IQueryable<Product> RetrieveInactiveProducts()
        {
            return ProductList.Where(p => p.EndDate.CompareTo(DateTime.Today) < 0 ||
                                          p.StartDate.CompareTo(DateTime.Today)>0)
                                          .AsQueryable();
        }

        public IQueryable<Product> RetrieveAllOrderByPriceDescending()
        {
            return ProductList.OrderByDescending(p => p.Price).AsQueryable();
        }

        public IQueryable<Product> RetrieveAllOrderByPriceAscending()
        {
            return ProductList.OrderBy(p => p.Price).AsQueryable();
        }

        public IQueryable<Product> RetrieveAll(string name)
        {
            return ProductList.Where(p => p.ProductName.Contains(name)).AsQueryable();
        }

        public IQueryable<Product> RetrieveAll(DateTime startDate, DateTime endDate)
        {
            return ProductList.Where(p => p.StartDate.CompareTo(startDate) >= 0 && p.EndDate.CompareTo(endDate) <= 0).AsQueryable();
        }

    }

}