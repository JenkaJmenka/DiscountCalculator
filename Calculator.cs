using System;

namespace DiscountCalculator
{
    class Calculator : ICalculationLogic
    {
        public double CalculateDiscount(double price, double discount, DateTime birthdayDate)
        {
            int todayDate = DateTime.Today.Day;
            int todayMonth = DateTime.Today.Month;

            if (todayDate == birthdayDate.Day &&
               birthdayDate.Month == todayMonth)
            {
                return discount *= 2;
            }
            else
                return discount;
        }

        public double CheckDiscount(double productPrice, double discount)
        {
            if (discount / productPrice < 0.9)
                return productPrice - discount;
            else
                return productPrice - (productPrice * 0.9);
        }
    }
}
