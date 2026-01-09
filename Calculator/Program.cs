using System;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Calculator myCalc = new Calculator();
            string input = string.Empty;
            string operation = string.Empty;

            // We will iterate until Ctrl-C is pressed.
            while (true)
            {
                Console.WriteLine("\nPlease enter the number you would like to add (i.e. '1,3')");
                Console.WriteLine("You can add your own separators (i.e. '//[*][ff]\\n1*3')");
                Console.Write("Your input: ");
                input = Console.ReadLine();

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
}
