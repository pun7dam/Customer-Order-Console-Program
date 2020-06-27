using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITECH7201Assignment1
{
    class Pasta : Food, IAction  // Use of inheritance and interface.
    {
        int countRetrySameOrder = 0;
        public Pasta()  // parameterless constructor for initialization of properties
        {
            countOrder = 0;
            totalAmount = 0;            
            countSoftDrink = 0;
        }
        public void HeaderInfo()
        {
            Console.WriteLine("\n Pasta packages are listed below");
            Console.WriteLine("\n 1 Large Pasta  = 8 AUD");
            Console.WriteLine("\n 2 Large Pastas = 15 AUD");
            Console.WriteLine("\n N Large Pastas = M*7 AUD with every 3 Pastas, receive 1.25 Litre Soft drinks");
        }
        public void InitLoad()  // Load all the methods
        {
            HeaderInfo();
            CalculateOrder();
            CalculateAmount();
        }

        public void CalculateOrder()
        {
            int tempOrder = -1;
            string checkContinue = "-1";
            bool statusReorder = true, yContinue = false; ;
            do
            {
                string number = "-1";
                if (countRetrySameOrder == 0)
                {
                    Console.Write("\n Pasta Quantity: ");
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
                        Console.Write("\n Pasta Quantity: ");
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

        public void CalculateAmount()  // Calculation of order item and it's price.
        {
            if (countOrder >= 3)
            {
                totalAmount = countOrder * 7;
                Price = 7;
                ItemName = "'N Large Pastas = M*7 AUD'";
                countSoftDrink = (countOrder / 3);//garlic bread offer for every 3 pizza.
                OfferName = countSoftDrink + " complementary 1.25 litre Soft drink for " + totalAmount + " AUD";
            }
            else if (countOrder == 2)
            {
                totalAmount += countOrder * 7.5; // 15 AUD
                Price = 7.5;  // price per pasta
                ItemName = "'2 Large Pastas = 15 AUD'";
            }
            else if (countOrder == 1)
            {
                totalAmount += 8;
                Price = 8;
                ItemName = "'1 Large Pasta  = 8 AUD'";
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
