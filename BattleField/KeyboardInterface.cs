namespace BattleField
{
    using System;
    using System.Collections.Generic;
    using BattleField.Interfaces;

    public class KeyboardInterface : IUserInterface
    {        
        public int ReadInteger()
        {
            var input = Console.ReadLine();
            int result = this.ConvertToInteger(input);
            return result;
        }

        public IEnumerable<int> ReadMultipleIntegers(int count)
        {
            var input = Console.ReadLine();
            string[] splittedResult = input.Split(' ');
            var splittedItemsLenght = splittedResult.Length;

            if (splittedItemsLenght != count)
            {
                throw new ArgumentException("The length of the splitted items doesn't match the expected count.");
            }

            int[] resultNumbers = new int[splittedItemsLenght];

            for (int i = 0; i < resultNumbers.Length; i++)
            {
                resultNumbers[i] = this.ConvertToInteger(splittedResult[i]);
            }

            return resultNumbers;
        }

        private int ConvertToInteger(string value)
        {
            int result;

            if (!int.TryParse(value, out result))
            {
                throw new FormatException("Could not convert to integer successfully.");
            }

            return result;
        }
    }
}
