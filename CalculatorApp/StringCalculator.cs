namespace CalculatorApp
{
    public class StringCalculator
    {
        public StringCalculator()
        {
        }

        public int Add(string numbers)
        { 
            var result = 0;
            var err = ""; 
            var numbersArray = SetNumbers(numbers);

            foreach (var number in numbersArray)
            {
                var value = GetNumber(number);
                err += GetNegativeNumbers(value);
                result += value;
            }

            ThrowWhenNegativeExists(err);

            return result;
        }

        private static void ThrowWhenNegativeExists(string err)
        {
            if (err.Length > 0)
                throw new ArgumentException($"negatives not allowed {err}");
        }

        private static string GetNegativeNumbers(int sum)
        {
            string err = "";
            if (NumberLessThanZero(sum))
                err += sum.ToString();
            return err;
        }

        private static bool NumberLessThanZero(int value)
            => value < 0;

        private static char SetDelimeter(string numbers)
        {
            var defaultDelimeter = ',';
            return numbers.Contains("//") ?
                numbers.Replace("]", "").Replace("[", "").Replace("//", "")[0] :
                defaultDelimeter;
        }

        private static int GetNumber(string? number)
        {
            int.TryParse(number, out int value);
            return TryGetValue(value);
        }

        private static int TryGetValue(int value)
            => value > 1000 ? 0 : value;

        private string SetCleanNumbers(string numbers, char delimeter)
        {
           return numbers.Replace("\n", delimeter.ToString());
        }

        private string[] SetNumbers(string numbers)
        {
            var delimeter = SetDelimeter(numbers); 
            var cleanNumbers = SetCleanNumbers(numbers, delimeter);
            return cleanNumbers.Split(delimeter);
        }
    }
}