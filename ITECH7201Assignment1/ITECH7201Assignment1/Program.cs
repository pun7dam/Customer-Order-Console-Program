using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITECH7201Assignment1
{
    class Program
    {

        static void Main(string[] args)
        {
            Pizza pizza = null;
            Pasta pasta = null;
            string oprInput;
            do
            {
                // Display menu.
                HeaderInfo();
                Console.Write("Input Operation: ");
                oprInput = Console.ReadLine();  // Taking input operation from the console.
                switch (oprInput)
                {
                    case "0": // to exit the program
                        Environment.Exit(0);
                        break;
                    case "1": // Pizza operations.
                        Console.Clear();
                        pizza = new Pizza();
                        pizza.InitLoad();
                        // pizza.Display();
                        break;
                    case "2": // Pasta operations
                        Console.Clear();
                        pasta = new Pasta();
                        pasta.InitLoad();
                        break;
                    case "3": // Display of order summary
                        Console.Clear();
                        OrderSummary(pizza, pasta);
                        pizza = null;
                        pasta = null;
                        break;
                    default:
                        Console.Clear();
                        break;
                }
            } while (oprInput != "0");

        }
        public static void HeaderInfo()
        {
            Console.WriteLine("|-----------------------------------------------|");
            Console.WriteLine("|\t ARC Pizza and Pasta Shop \t\t|");
            Console.WriteLine("|\t Owner Sab \t\t\t\t|");
            Console.WriteLine("|-----------------------------------------------|");
            Console.WriteLine("|Press 0, 1, 2 and 3 for the program operations |");
            Console.WriteLine("|-----------------------------------------------|");
            Console.WriteLine("| 0: Exit \t\t\t\t\t|");
            Console.WriteLine("| 1: For Pizza \t\t\t\t\t|");
            Console.WriteLine("| 2: For Pasta \t\t\t\t\t|");
            Console.WriteLine("| 3: For Display Order Summary \t\t\t|");
            Console.WriteLine("|-----------------------------------------------|\n");
        }
        public static void OrderSummary(Pizza pizza, Pasta pasta)
        {
            Console.WriteLine("|\n \t\t Your order summary");
            Console.WriteLine("|---------------------------------------------------------------|");
            Console.WriteLine("| Item name \t\t\t Quantity \t Price \t Total  |");
            Console.WriteLine("|---------------------------------------------------------------|");
            if (pizza != null && pasta != null)
            {
                pizza.Display();
                pasta.Display();
                Console.WriteLine("|---------------------------------------------------------------|");
                Console.WriteLine("|\t\t\t\t\t\t Total = {0} AUD |", (pizza.totalAmount + pasta.totalAmount));
            }
            else if (pizza != null)
            {
                pizza.Display();
                Console.WriteLine("|---------------------------------------------------------------|");
                Console.WriteLine("|\t\t\t\t\t\t Total = {0} AUD |", pizza.totalAmount);
            }
            else if (pasta != null)
            {
                pasta.Display();
                Console.WriteLine("|---------------------------------------------------------------|");
                Console.WriteLine("|\t\t\t\t\t\t Total = {0} AUD |", pasta.totalAmount);
            }
            
            Console.WriteLine("|---------------------------------------------------------------|\n");
            Console.WriteLine("| \t\t Offer");
            Console.WriteLine("|---------------------------------------------------------------|");
            if (pizza != null && pizza.countOrder >= 3 && pasta != null && pasta.countOrder >= 3)
            {
                pizza.DisplayOffer();
                pasta.DisplayOffer();
                Console.WriteLine("|A small box of Baklava (a famous dessert item)");
            }
            else if (pizza != null && pizza.countOrder >= 3)
            {
                pizza.DisplayOffer();
            }
            else if (pasta != null && pasta.countOrder >= 3)
            {
                pasta.DisplayOffer();
            }
            else
                Console.WriteLine("| \t\t No offer received");
            Console.WriteLine("|---------------------------------------------------------------|\n\n");
            
        }
    }
}
