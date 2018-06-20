using System;

namespace DiscountCalculator
{
    public interface ICalculationLogic
    {
        double CalculateDiscount(double price, double discount, DateTime birthdayDate);
        double CheckDiscount(double price, double discount);
    }
}
