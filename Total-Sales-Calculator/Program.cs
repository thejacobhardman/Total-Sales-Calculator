using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Total_Sales_Calculator
{
    class Program
    {
        static void DisplayResults(double[,] sales)
        {
            Console.WriteLine("\n{0,-20}{1,-20}{2,-20}{3,-20}{4,-20}",
                "Product",
                "Sales Person 1",
                "Sales Person 2",
                "Sales Person 3",
                "Total");

            Console.Write("1");
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 1; j++)
                {
                    Console.Write("{0,-20}", sales[i, j].ToString("C2"));
                }
            }

            Console.Write("\n2 ");
            for (int i = 0; i < 3; i++)
            {
                for (int j = 1; j < 2; j++)
                {
                    Console.Write(sales[i, j].ToString("C2") + " ");
                }
            }

            Console.Write("\n3 ");
            for (int i = 0; i < 3; i++)
            {
                for (int j = 2; j < 3; j++)
                {
                    Console.Write(sales[i, j].ToString("C2") + " ");
                }
            }

            Console.Write("\n4 ");
            for (int i = 0; i < 3; i++)
            {
                for (int j = 3; j < 4; j++)
                {
                    Console.Write(sales[i, j].ToString("C2") + " ");
                }
            }

            Console.Write("\n5 ");
            for (int i = 0; i < 3; i++)
            {
                for (int j = 4; j < 5; j++)
                {
                    Console.Write(sales[i, j].ToString("C2") + " ");
                }
            }
        }
        static void Main(string[] args)
        {
            double[,] sales = new double[3, 5] { { 0.00, 0.00, 0.00, 0.00, 0.00 }, { 0.00, 0.00, 0.00, 0.00, 0.00}, { 0.00 ,0.00, 0.00, 0.00, 0.00} };
            int salesmanNum = 0, productNum = 0;
            double salesNum = 0.00, salesTotal = 0.00;

            bool isRunning = true, goodInput;
            while (isRunning)
            {
                goodInput = false;
                while (!goodInput)
                {
                    Console.Write("Enter sales person number (-1 to end): ");
                    goodInput = int.TryParse(Console.ReadLine(), out salesmanNum);
                    if (!goodInput)
                    {
                        Console.WriteLine("Please enter a valid number.");
                    }
                    if (salesmanNum == -1)
                    {
                        isRunning = false;
                        break;
                    }
                    if (salesmanNum < 1 || salesmanNum > 3)
                    {
                        goodInput = false;
                        Console.WriteLine("Please select a sales person number between 1 and 3.");
                    }
                }

                if (isRunning == false) { break; }

                goodInput = false;
                while (!goodInput)
                {
                    Console.Write("Enter product number: ");
                    goodInput = int.TryParse(Console.ReadLine(), out productNum);
                    if (!goodInput)
                    {
                        Console.WriteLine("Please enter a valid number.");
                    }
                    if (productNum < 1 || productNum > 5)
                    {
                        goodInput = false;
                        Console.WriteLine("Please select a product number between 1 and 5.");
                    }
                }

                goodInput = false;
                while (!goodInput)
                {
                    Console.Write("Enter sales amount: ");
                    goodInput = double.TryParse(Console.ReadLine(), out salesNum);
                    if (!goodInput)
                    {
                        Console.WriteLine("Please enter a valid number.");
                    }
                }

                sales[salesmanNum - 1, productNum - 1] = salesNum;

            }

            DisplayResults(sales);

            //Console.WriteLine("Sales total is: " + salesTotal.ToString("C2"));

            Console.WriteLine("\n\nPress any key to close the program.");
            Console.ReadKey();
        }
    }
}
