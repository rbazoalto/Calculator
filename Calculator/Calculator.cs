using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Calculator
{
    public class Calculator
    {
        /// <summary>
        /// This method adds 2 or more numbers.
        /// the input is a string that contains the numbers separated by commas or \n
        /// </summary>
        /// <param name="input"></param>
        /// <param name="message">This will contain the formatted operation</param>
        /// <returns>It returns the sum of the numbers.</returns>
        public int Add(string input, out string message)
        {            
            string delimiterString = string.Empty;
            int value = 0;
            int response = 0;
            bool success = false;
            string negativeNumbers = string.Empty;
            int length = 0;
            string[] numberInput = null;
            string operation = string.Empty;
            int upperBound = 1000;
            string[] defaultDelimiters = new string[] { ",", "\\n" };
            bool hasLongDelimiter = input.StartsWith("//[") && input.Contains("\\n");

            if (hasLongDelimiter)
            {
                string delimetersInput = input.Substring(3, input.IndexOf("\\n") - 4);
                input = input.Substring(input.IndexOf("\\n") + 2);
                string[] customDelimiters = delimetersInput.Split("][", StringSplitOptions.None);

                string[] delimiters = defaultDelimiters.Union(customDelimiters).ToArray();
                numberInput = input.Split(delimiters, StringSplitOptions.None);
            }
            else
            {
                numberInput = input.Split(defaultDelimiters, StringSplitOptions.None);
            }

            foreach (string item in numberInput)
            {
                item.Trim();
                success = int.TryParse(item, out value);
                // Only if this is a valid number smaller or equal than the upper bound, we will add it. 
                if (success && value <= upperBound)
                {
                    if (value < 0)
                    {
                        negativeNumbers = negativeNumbers + value + ",";
                        operation = operation + "0+";
                        continue;
                    }
                    operation = operation + item + "+";
                    response += value;
                }
                else
                {
                    operation = operation + "0+";
                }
            }

            length = negativeNumbers.Length;
            if (length > 0)
            {
                // We remove the last ',' from the negative numbers list.
                throw new ArgumentException(negativeNumbers.Remove(length - 1));
            }
            message = operation.Remove(operation.Length - 1);
            return response;
        }
    }
}
