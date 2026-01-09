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
            string delimiterString = string.Empty;
            bool hasLongDelimiter = input.StartsWith("//[") && input.Contains("]");
            int delimiterLength = GetCustomDelimiter(input, hasLongDelimiter, out delimiterString);

            if (delimiterLength > 0)
            {
                // We remove the delimiter definition including //\n chars
                input = input.Substring(delimiterLength + 4);
            }
            string[] delimiters = new string[] { ",", "\\n", delimiterString};

            string[] numberInput = input.Split(delimiters, StringSplitOptions.None);

            int value = 0;
            int response = 0;
            bool success = false;
            string negativeNumbers = string.Empty;
            int length = 0;
            int upperBound = 1000;

            foreach (string item in numberInput)
            {
                item.Trim();
                success = int.TryParse(item, out value);

                // Only if this is a valid number smaller and equal than the upper bound, we will add it. 
                if (success && value <= upperBound)
                {
                    if (value < 0)
                    {
                        negativeNumbers = negativeNumbers + value + ",";
                        continue;
                    }
                    response += value;
                }
            }

            length = negativeNumbers.Length;
            if (length > 0)
            {
                // We remove the last ',' from the negative numbers list.
                throw new ArgumentException(negativeNumbers.Remove(length - 1));
            }

            return response;
        }

        /// <summary>
        /// We parse the input to find the delimiter
        /// </summary>
        /// <param name="input"></param>
        /// <param name="hasLongDelimiter">A flag to handle long delimiters</param>
        /// <param name="delimiterString"></param>
        /// <returns>The size of the delimiter</returns>
        private int GetCustomDelimiter(string input, bool hasLongDelimiter, out string delimiterString)
        {
            delimiterString = string.Empty;
            char delimiter = '\0';
            int delimiterLength = -1;
            if (!hasLongDelimiter)
            {
                delimiterLength = GetCustomDelimiter(input, out delimiter);
                delimiterString = delimiter.ToString();
                return delimiterLength;
            }

            delimiterLength = GetCustomDelimiter(input, out delimiterString);
            // We need to fix the length by adding 2 because of the brackets []
            return delimiterLength + 2;
        }

        /// <summary>
        /// We parse the input to find the delimiter char
        /// </summary>
        /// <param name="input"></param>
        /// <param name="delimiter"></param>
        /// <returns>The size of the delimiter. -1 if no custom delimiter was found.</returns>
        private int GetCustomDelimiter(string input, out char delimiter)
        {
            delimiter = '\0';
            int endOfDelimiterIndex = input.IndexOf("\\n");
            if (input.StartsWith("//") && input.Length > endOfDelimiterIndex + 2)
            {
                delimiter = input[2];
                return 1;
            }

            return -1;
        }

        /// <summary>
        /// We parse the input to find the delimiter string
        /// </summary>
        /// <param name="input"></param>
        /// <param name="delimiter"></param>
        /// <returns>The size of the delimiter. -1 if no custom delimiter was found.</returns>
        private int GetCustomDelimiter(string input, out string delimiter)
        {
            delimiter = string.Empty;
            int endOfDelimiterIndex = input.IndexOf("]\\n");
            if (input.StartsWith("//[") && input.Length > endOfDelimiterIndex + 2)
            {
                delimiter = input.Substring(3, endOfDelimiterIndex - 3);
                return delimiter.Length;
            }

            return -1;
        }
    }
}
