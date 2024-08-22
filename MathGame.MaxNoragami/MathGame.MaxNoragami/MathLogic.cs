namespace MaxMathLogic
{
    class MathLogic
    {
        public List<string> History {get;set;} = new List<string>();

        public int MathOperation(int[] randomValues, char operation)
        {
            int result = -1;
            switch(operation)
            {
                case '+':
                {
                    Console.WriteLine($"{randomValues[0]} + {randomValues[1]} = ?");
                    History.Add($"{randomValues[0]} + {randomValues[1]} = {randomValues[0] + randomValues[1]}");
                    return randomValues[0] + randomValues[1];
                }
                case '-':
                {
                    Console.WriteLine($"{randomValues[0]} - {randomValues[1]} = ?");
                    History.Add($"{randomValues[0]} - {randomValues[1]} = {randomValues[0] - randomValues[1]}");
                    return randomValues[0] - randomValues[1];
                }
                case '*':
                {
                    Console.WriteLine($"{randomValues[0]} * {randomValues[1]} = ?");
                    History.Add($"{randomValues[0]} * {randomValues[1]} = {randomValues[0] * randomValues[1]}");
                    return randomValues[0] * randomValues[1];
                }
                case '/':
                {
                    Console.WriteLine($"{randomValues[0]} / {randomValues[1]} = ?");
                    History.Add($"{randomValues[0]} / {randomValues[1]} = {randomValues[0] / randomValues[1]}");
                    return randomValues[0] / randomValues[1];
                }
            }
            return result;
        }
    }
}