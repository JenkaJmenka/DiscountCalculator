﻿using System;

namespace DiscountCalculator
{
    class GoldCustomer : Customer, IDiscount
    {
        private const double baseDiscount = 50;
        private const double percentage = 0.5;
        private ICalculationLogic calculator = new Calculator();

        public GoldCustomer(string name, DateTime birthday, double productPrice, ICalculationLogic calcLogic)
            : base(name, birthday, productPrice, calcLogic)
        { 
        }

        public override double GetDiscount(double productPrice)
        {
            double price = base.GetDiscount(productPrice);
            double discount = baseDiscount + (productPrice * percentage);
            double newDiscount = calcLogic.CalculateDiscount(price, discount, Birthday.Date);
            return calcLogic.CheckDiscount(price, newDiscount);
        }
    }
}
