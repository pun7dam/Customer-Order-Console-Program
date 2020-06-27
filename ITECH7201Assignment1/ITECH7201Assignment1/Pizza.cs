using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITECH7201Assignment1
{
    class Pizza : Food, IAction
    {
        int countRetrySameOrder = 0;
        public Pizza()
        {   // variables initialization.
            countOrder = 0;
            totalAmount = 0;
            countOfferGarlicBread = 0;                
        }
        public void HeaderInfo()
        {   // Pizza packages information display.
            Console.WriteLine("\n Pizza packages are listed below");
            Console.WriteLine("\n 1 Large Pizza = 12 AUD");
            Console.WriteLine("\n 2 Large Pizza = 22 AUD");
            Console.WriteLine("\n N Large Pizza = N*10 AUD with every 3 Pizza, 1 extra garlic bread");
        }
        public void InitLoad()
        {
            HeaderInfo();
            CalculateOrder();
            CalculateAmount();
        }

        public void CalculateOrder()
        {   // take quantity order from the customer.
            int tempOrder = -1;
            string checkContinue = "-1";
            bool statusReorder = true, yContinue = false; ;
            do
            {
                string number = "-1";
                if (countRetrySameOrder == 0)
                {
                    Console.Write("\n Pizza Quantity: ");
                    number = Console.ReadLine();
                }
                else
                {
                    if (statusReorder & !(yContinue))
                    {
                        Console.Write("\n Do you need order again (y/n): ");
                        checkContinue = Console.ReadLine();
                        statusReorder = false;
                    }

                    if (checkContinue == "y")
                    {
                        Console.Write("\n Pizza Quantity: ");
                        number = Console.ReadLine();
                        yContinue = true;
                        statusReorder = true;
                    }
                    else if (checkContinue == "n")
                        break;
                    else
                        statusReorder = true;
                }
                try
                {
                    tempOrder = int.Parse(number);
                    countOrder += tempOrder;
                    countRetrySameOrder += 1;
                    yContinue = false;
                }
                catch (Exception)
                {
                    tempOrder = -1;
                }
            } while (tempOrder != 0);
        }

        public void CalculateAmount()
        {   // Calculate amount based on the quantity of customer order.
            if (countOrder >= 3)
            {
                totalAmount = countOrder * 10;
                Price = 10;
                ItemName = "'N Large Pizza = N*10 AUD'";
                countOfferGarlicBread = (countOrder / 3);//garlic bread offer for every 3 pizza.
                OfferName = countOfferGarlicBread + " complementary garlic bread for " + totalAmount + " AUD";

            }
            else if (countOrder == 2)
            {
                totalAmount += countOrder * 11;
                Price = 11;
                ItemName = "'2 Large Pizza = 22 AUD'";
            }
            else if (countOrder == 1)
            {
                totalAmount += 12;
                Price = 12;
                ItemName = "'1 Large Pizza = 22 AUD'";
            }
        }

        public void Display()
        {
            Console.WriteLine("|{0} \t {1} \t\t {2} \t {3} AUD|", ItemName, countOrder, Price, totalAmount);
        }
        public void DisplayOffer()
        {
            Console.WriteLine("|{0}|", OfferName);
        }
    }
}
