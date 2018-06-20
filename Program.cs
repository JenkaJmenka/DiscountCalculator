using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Customer> customers = new List<Customer>();
            #region TestDataFromTheExample
            //customers.Add(new BasicCustomer("Jon Dou", DateTime.Parse("01/21/1999"), 1000, new Calculator()));
            //customers.Add(new PremiumCustomer("Jack Black", DateTime.Parse("01/21/1999"), 500, new Calculator()));
            //customers.Add(new GoldCustomer("Jon Dou", DateTime.Parse("01/21/1999"), 1000, new Calculator()));
            //customers.Add(new GoldCustomer("Jon Dou", DateTime.Parse("01/21/1999"), 60, new Calculator()));
            #endregion
            string menuHeader = "Please put user information in specified format in the following order: \n" +
                "< Name >,\n< Birthday mm / dd / yyyy >,\n< DiscountType Low / Medium / High >,\n< ProductPrice ###.##>\n" +
                "Each parameter should be separated from teh other by ',' symbol \n" +
                "To start calculation type 'calculate'\n";
            Console.WriteLine(menuHeader);
            {
                while (true)
                {
                    string userInput = Console.ReadLine();
                    if (userInput == "calculate")
                    {
                        break;
                    }
                    else
                    {
                        List<string> userInfo = userInput.Split(',').ToList();
                        // we know that the third input value  (userInfo[2]) is the discount type.
                        //base on the discount we need to create different type of customers
                        //Low    - BasicCustomer
                        //Medium - PremiumCustomer
                        //High   - GoldCustomer
                        double productPrice = 0;
                        DateTime birthday;
                        try
                        {
                            if (Double.TryParse(userInfo[3].Trim(), out productPrice) == true &&
                                DateTime.TryParse(userInfo[1].Trim(), out birthday))
                            {
                                if (userInfo[2].Trim().ToLower().Equals("low"))
                                    customers.Add(new BasicCustomer(userInfo[0], birthday, productPrice, new Calculator()));
                                else if (userInfo[2].Trim().ToLower().Equals("medium"))
                                    customers.Add(new PremiumCustomer(userInfo[0], birthday, productPrice, new Calculator()));
                                else if (userInfo[2].Trim().ToLower().Equals("high"))
                                    customers.Add(new GoldCustomer(userInfo[0], birthday, productPrice, new Calculator()));
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Wrong Input. Please try Again!");
                        }
                    }
                }
                Console.WriteLine("Calculations");
                foreach (var customer in customers)
                    Console.WriteLine("Name: " + customer.Name + " " + "Discount: " + customer.GetDiscount(customer.ProductPrice));
            }
            
        }
    }
}
