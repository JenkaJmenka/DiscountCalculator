using System;

namespace DiscountCalculator
{
    class BasicCustomer : Customer, IDiscount
    {
        private const double baseDiscount = 50;

        public BasicCustomer(string name, DateTime birthday, double productPrice, ICalculationLogic calcLogic) 
            : base(name, birthday, productPrice, calcLogic)
        {
        }

        public override double GetDiscount(double productPrice)
        {
            double price = base.GetDiscount(productPrice);
            double discount = calcLogic.CalculateDiscount(price, baseDiscount, Birthday.Date);
            return calcLogic.CheckDiscount(price, discount);
        }
    }
}
