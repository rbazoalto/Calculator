using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator
{
    public class Calculator
    {
        /// <summary>
        /// This method adds 2 or more numbers.
        /// the niput is a string that contains the numbers separated by commas or \n
        /// </summary>
        /// <param name="input"></param>
        /// <returns>It returns the sum of the numbers.</returns>
        public int Add(string input)
        {
            // this is to replace the character \n in the input for the real end of line character. 
            input = input.Replace("\\n", "\n");
            string[] numberInput = input.Split(new[] { ',', '\n' });

            int value = 0;
            int response = 0;
            bool success = false;

            foreach (string item in numberInput)
            {
                item.Trim();
                success = int.TryParse(item, out value);

                // Only if this is a valid number, we will add it. 
                if (success)
                {
                    response += value;
                }
            }

            return response;
        }
    }
}
