using System;

namespace Lab4
{

    public class Product
    {

        public Guid Id { get; private set; }
        public string ProductName { get; private set; }
        public string ProductDescription { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public double Price { get; private set; }
        
        //<----initia m-am gandit ca startDate-ul sa fie astazi sau in viitor, dar am comentat asta ca sa pot testa active/inactive products---->
//        private void CheckStartDate(DateTime startDate)
//        {
//            if (startDate.CompareTo(DateTime.Today) < 0)
//                throw new ArgumentException("StartDate cannot be in past");
//        }

        private void CheckEndDate(DateTime startDate, DateTime endDate)
        {
            if (endDate.CompareTo(startDate) <= 0)
                throw new ArgumentException("EndDate must be after StartDate");
        }

        private void CheckPrice(double price)
        {
            if (price <= 0)
                throw new ArgumentException("price must be greater than 0");
        }

        private void CheckNullOrEmpty(string target)
        {
            if (string.IsNullOrEmpty(target))
                throw new ArgumentException("Product name cannot be null or empty.");
        }

        private void CheckNullOrWhiteSpace(string target)
        {
            if (string.IsNullOrWhiteSpace(target))
                throw new ArgumentException("Value cannot be null or whitespace.");
        }

        private void CheckStringMaxLength(string target, int length)
        {
            if(target.Length>length)
                throw new ArgumentException("product"+(length==50?"name":"description") +"must contain max"+length+"characters");
        }

        private void CheckString(string target,int length)
        {
            CheckNullOrEmpty(target);
            CheckNullOrWhiteSpace(target);
            CheckStringMaxLength(target,length);
        }

        private void CheckArguments(string productName, string productDescription, DateTime startDate, DateTime endDate, double price)
        {
            CheckString(productName,50);
            CheckString(productDescription,200);
            //am scris mai sus de ce am comentat asta
            //CheckStartDate(startDate);
            CheckEndDate(startDate,endDate);
            CheckPrice(price);
        }

        public Product(string productName, string productDescription, DateTime startDate, DateTime endDate, double price)
        {
            CheckArguments(productName, productDescription, startDate, endDate, price);
            Id = Guid.NewGuid();
            this.ProductName = productName;
            this.ProductDescription = productDescription;
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.Price = price;
        }

    }

}