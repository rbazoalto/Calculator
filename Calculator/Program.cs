using System;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Calculator myCalc = new Calculator();
            Console.WriteLine("Please enter the number you would like to add (i.e. '1,3')");
            string input = Console.ReadLine();
            string operation = string.Empty;

            try
            {
                int res = myCalc.Add(input, out operation);
                Console.WriteLine("{0} = {1}.", operation, res);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Negative numbers are not allowed: {0}.", ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
