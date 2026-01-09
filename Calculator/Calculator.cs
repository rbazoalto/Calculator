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
            char delimiter = '\0';
            int delimiterLength = GetCustomDelimiter(input, out delimiter);

            if (delimiterLength > 0)
            {
                input = input.Substring(delimiterLength + 4);
            }
            char[] delimiters = new char[] { ',', '\n', delimiter};
            // this is to replace the character \n in the input for the real end of line character. 
            input = input.Replace("\\n", "\n");
            string[] numberInput = input.Split(delimiters);

            int value = 0;
            int response = 0;
            bool success = false;
            string negativeNumbers = string.Empty;
            int length = 0;

            foreach (string item in numberInput)
            {
                item.Trim();
                success = int.TryParse(item, out value);

                // Only if this is a valid number smaller than 1001, we will add it. 
                if (success && value < 1001)
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
    }
}
