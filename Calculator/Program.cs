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

            try
            {
                int res = myCalc.Add(input);
                Console.WriteLine("{0} = {1}.", input, res);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("{0} is not correct!", input);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
