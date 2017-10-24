using System;
using System.Linq;

namespace Lab4
{
    public interface IProductRepository
    {
        IQueryable<Product> RetrieveActiveProducts();
        IQueryable<Product> RetrieveInactiveProducts();
        IQueryable<Product> RetrieveAllOrderByPriceDescending();
        IQueryable<Product> RetrieveAllOrderByPriceAscending();
        IQueryable<Product> RetrieveAll(string name);
        IQueryable<Product> RetrieveAll(DateTime startDate, DateTime endDate);
    }
}