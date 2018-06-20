using System;

namespace DiscountCalculator
{
    class Customer :IDiscount
    {
        protected ICalculationLogic calcLogic;

        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private DateTime birthday;
        public DateTime Birthday
        {
            get { return birthday; }
            set { birthday = value; }
        }
        private double productPrice;
        public double ProductPrice
        {
            get { return productPrice; }
            set { productPrice = value; }
        }

        public Customer(string name, DateTime birthday, double productPrice, ICalculationLogic calcLogic)
        {
            this.name = name;
            this.birthday = birthday;
            this.productPrice = productPrice;
            this.calcLogic = calcLogic;
        }

        public virtual double GetDiscount(double productPrice)
        {
            return productPrice;
        }
    }
}
