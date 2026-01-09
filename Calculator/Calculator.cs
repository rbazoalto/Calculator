using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator
{
    public class Calculator
    {
        public int Add(string input)
        {
            string[] numberInput = input.Split(',');

            int value = 0;
            int response = 0;
            bool success = false;

            foreach (string item in numberInput)
            {
                item.Trim();
                success = int.TryParse(item, out value);

                if (success)
                {
                    response += value;
                }
            }

            return response;
        }
    }
}
