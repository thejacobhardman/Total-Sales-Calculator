using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Total_Sales_Calculator
{
    //I wanted a more elegant way to print my data from a table. So I got this solution from stackoverflow.com.
    // https://stackoverflow.com/a/54943087/10190341
    public class TablePrinter
    {
        private readonly string[] titles;
        private readonly List<int> lengths;
        private readonly List<string[]> rows = new List<string[]>();

        public TablePrinter(params string[] titles)
        {
            this.titles = titles;
            lengths = titles.Select(t => t.Length).ToList();
        }

        public void AddRow(params object[] row)
        {
            if (row.Length != titles.Length)
            {
                throw new System.Exception($"Added row length [{row.Length}] is not equal to title row length [{titles.Length}]");
            }
            rows.Add(row.Select(o => o.ToString()).ToArray());
            for (int i = 0; i < titles.Length; i++)
            {
                if (rows.Last()[i].Length > lengths[i])
                {
                    lengths[i] = rows.Last()[i].Length;
                }
            }
        }

        public void Print()
        {
            lengths.ForEach(l => System.Console.Write("+-" + new string('-', l) + '-'));
            System.Console.WriteLine("+");

            string line = "";
            for (int i = 0; i < titles.Length; i++)
            {
                line += "| " + titles[i].PadRight(lengths[i]) + ' ';
            }
            System.Console.WriteLine(line + "|");

            lengths.ForEach(l => System.Console.Write("+-" + new string('-', l) + '-'));
            System.Console.WriteLine("+");

            foreach (var row in rows)
            {
                line = "";
                for (int i = 0; i < row.Length; i++)
                {
                    if (int.TryParse(row[i], out int n))
                    {
                        line += "| " + row[i].PadLeft(lengths[i]) + ' ';  // numbers are padded to the left
                    }
                    else
                    {
                        line += "| " + row[i].PadRight(lengths[i]) + ' ';
                    }
                }
                System.Console.WriteLine(line + "|");
            }

            lengths.ForEach(l => System.Console.Write("+-" + new string('-', l) + '-'));
            System.Console.WriteLine("+");
        }
    }

    class Program
    {
        static void DisplayResults(double[,] sales)
        {

            var table = new TablePrinter("Product", "Sales Person 1", "Sales Person 2", "Sales Person 3", "Total");
            table.AddRow(1, sales[0, 0].ToString("C2"), sales[1, 0].ToString("C2"), sales[2, 0].ToString("C2"), (sales[0, 0] + sales[1, 0] + sales[2, 0]).ToString("C2"));
            table.AddRow(2, sales[0, 1].ToString("C2"), sales[1, 1].ToString("C2"), sales[2, 1].ToString("C2"), (sales[0, 1] + sales[1, 1] + sales[2, 1]).ToString("C2"));
            table.AddRow(3, sales[0, 2].ToString("C2"), sales[1, 2].ToString("C2"), sales[2, 2].ToString("C2"), (sales[0, 2] + sales[1, 2] + sales[2, 2]).ToString("C2"));
            table.AddRow(4, sales[0, 3].ToString("C2"), sales[1, 3].ToString("C2"), sales[2, 3].ToString("C2"), (sales[0, 3] + sales[1, 3] + sales[2, 3]).ToString("C2"));
            table.AddRow(5, sales[0, 4].ToString("C2"), sales[1, 4].ToString("C2"), sales[2, 4].ToString("C2"), (sales[0, 4] + sales[1, 4] + sales[2, 4]).ToString("C2"));
            table.AddRow("Total", (sales[0, 0] + sales[0, 1] + sales[0, 2] + sales[0, 3] + sales[0, 4]).ToString("C2"),
                                  (sales[1, 0] + sales[1, 1] + sales[1, 2] + sales[1, 3] + sales[1, 4]).ToString("C2"),
                                  (sales[2, 0] + sales[2, 1] + sales[2, 2] + sales[2, 3] + sales[2, 4]).ToString("C2"), "");
            table.Print();
        }

        static void Main(string[] args)
        {
            double[,] sales = new double[3, 5] { { 0.00, 0.00, 0.00, 0.00, 0.00 }, { 0.00, 0.00, 0.00, 0.00, 0.00}, { 0.00 ,0.00, 0.00, 0.00, 0.00} };
            int salesmanNum = 0, productNum = 0;
            double salesNum = 0.00;

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

            Console.WriteLine("\nPress any key to close the program.");
            Console.ReadKey();
        }
    }
}
