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
            string upperBoundString = string.Empty;
            int upperBound = 1000;
            string denyNegativeNumbersString = string.Empty;
            bool denyNegativeNumbers = true;

            // We will iterate until Ctrl-C is pressed.
            while (true)
            {
                // set default values at every cycle.
                upperBound = 1000;
                denyNegativeNumbers = true;

                // get the configuration for the cycle.
                Console.WriteLine("\nPlease enter the number you would like to add (i.e. '1,3')");
                Console.WriteLine("You can add your own separators (i.e. '//[*][ff]\\n1*3')");
                Console.Write("Introduce the upper bound number [default: 1000] : ");
                upperBoundString = Console.ReadLine();
                
                if (upperBoundString.Length > 0)
                {
                    // if the input is not valid continue with the default.
                    if (!int.TryParse(upperBoundString, out upperBound))
                    {
                        upperBound = 1000;
                    }
                    // if the upper bound is 0 or negative continue with the default.
                    else if (upperBound < 1)
                    {
                        upperBound = 1000;
                    }
                }

                Console.Write("Do you want to deny negative numbers?(y/n) [default: y] : ");
                denyNegativeNumbersString = Console.ReadLine();

                // if the input is 'n' or 'no', set the flag to false, otherwise continue with default.
                if (denyNegativeNumbersString == "n" || denyNegativeNumbersString == "no")
                {
                    denyNegativeNumbers = false;
                }
                Console.Write("Please introduce your operation input: ");
                input = Console.ReadLine();

                try
                {
                    int res = myCalc.Add(input, upperBound, denyNegativeNumbers, out operation);
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
