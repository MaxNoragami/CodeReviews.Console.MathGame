using System;
using System.Diagnostics;
using MaxMathLogic;

class Program
{
    
    static void Main()
    {
        Console.Clear();

        Stopwatch stopwatch = new Stopwatch();
        Random random = new Random();
        MathLogic mathLogic = new MathLogic();
        int[] randomValues = new int[2];
        bool gameOver = false;
        int difficulty = 1;
        double ms = 0;

        while(!gameOver)
        {   
            DisplayMenu();
            Console.Write("Choice: ");
            int userChoice = GetUserInput();
                switch(userChoice)
                {
                    case 1:
                    {   
                        Console.Write("\nEnter the amount of exercises: ");
                        int amountOfQuestions = GetUserInput();

                        stopwatch.Start();
                        for(int i = 0; i < amountOfQuestions; i++)
                        {   
                            char operation = '+';
                            RandomGenerate(randomValues, difficulty, operation);
                            int result = mathLogic.MathOperation(randomValues, operation);
                            bool loss = GameRound(result);
                            if(loss)
                            {
                                break;
                            } 
                        }
                        stopwatch.Stop();
                        ms = stopwatch.ElapsedMilliseconds - ms;
                        Console.WriteLine($"Ellapsed time: {ms/1000}s");
                        break;
                    }

                    case 2:
                    {
                        Console.Write("\nEnter the amount of exercises: ");
                        int amountOfQuestions = GetUserInput();

                        stopwatch.Start();
                        for (int i = 0; i < amountOfQuestions; i++)
                        {
                            char operation = '-';
                            RandomGenerate(randomValues, difficulty, operation);
                            int result = mathLogic.MathOperation(randomValues, operation);
                            bool loss = GameRound(result);
                            if (loss)
                            {
                                break;
                            }
                        }
                        stopwatch.Stop();
                        ms = stopwatch.ElapsedMilliseconds - ms;
                        Console.WriteLine($"Ellapsed time: {ms / 1000}s");
                        break;
                    }

                    case 3:
                    {
                        Console.Write("\nEnter the amount of exercises: ");
                        int amountOfQuestions = GetUserInput();

                        stopwatch.Start();
                        for (int i = 0; i < amountOfQuestions; i++)
                        {
                            char operation = '*';
                            RandomGenerate(randomValues, difficulty, operation);
                            int result = mathLogic.MathOperation(randomValues, operation);
                            bool loss = GameRound(result);
                            if (loss)
                            {
                                break;
                            }
                        }
                        stopwatch.Stop();
                        ms = stopwatch.ElapsedMilliseconds - ms;
                        Console.WriteLine($"Ellapsed time: {ms / 1000}s");
                        break;
                    }

                    case 4:
                    {
                        Console.Write("\nEnter the amount of exercises: ");
                        int amountOfQuestions = GetUserInput();

                        stopwatch.Start();
                        for (int i = 0; i < amountOfQuestions; i++)
                        {
                            char operation = '/';
                            RandomGenerate(randomValues, difficulty, operation);
                            int result = mathLogic.MathOperation(randomValues, operation);
                            bool loss = GameRound(result);
                            if (loss)
                            {
                                break;
                            }
                        }
                        stopwatch.Stop();
                        ms = stopwatch.ElapsedMilliseconds - ms;
                        Console.WriteLine($"Ellapsed time: {ms / 1000}s");
                        break;
                    }

                    case 5:
                    {
                        Console.Write("\nEnter the amount of exercises: ");
                        int amountOfQuestions = GetUserInput();

                        stopwatch.Start();
                        for (int i = 0; i < amountOfQuestions; i++)
                        {   
                            int num = random.Next(1,4);
                            char operation = (num == 1)? '+': (num == 2)? '-' : (num == 3)? '*': '/';
                            RandomGenerate(randomValues, difficulty, operation);
                            int result = mathLogic.MathOperation(randomValues, operation);
                            bool loss = GameRound(result);
                            if (loss)
                            {
                                break;
                            }
                        }
                        stopwatch.Stop();
                        ms = stopwatch.ElapsedMilliseconds - ms;
                        Console.WriteLine($"Ellapsed time: {ms / 1000}s");
                        break;
                    }

                    case 6:
                    {
                        Console.WriteLine("\nHistory:");
                        foreach(string registration in mathLogic.History)
                        {
                            Console.WriteLine(registration);
                        }
                        break;
                    }

                    case 7:
                    {
                        Console.WriteLine("\nChoose a difficulty:");
                        Console.WriteLine("1. Easy");
                        Console.WriteLine("2. Medium");
                        Console.WriteLine("3. Hard");
                        Console.Write("Choice: ");
                        do
                        {
                            difficulty = GetUserInput();
                        }while(difficulty == -1);
                        break;
                    } 
                    

                    case -2:
                    {
                        gameOver = true;
                        break;
                    }

                    default:
                    {
                        Console.WriteLine("\nWARNING: Invalid choice!");
                        break;
                    }

                }
        }

        static int GetUserInput()
        {
            int userInput = -1;
            string? userInputRead = Console.ReadLine();
            
            if (userInputRead != null)
            {
                
                if (userInputRead.ToLower() == "exit")
                {
                    userInput = -2;
                    return userInput;
                }
            
                bool validInput = int.TryParse(userInputRead, out userInput);
                if (validInput)
                {
                    return userInput;
                }
            }

            return userInput;
        }

        static void DisplayMenu()
        {
            Console.WriteLine("\nEnter your action:");
            Console.WriteLine("1. Summation");
            Console.WriteLine("2. Substraction");
            Console.WriteLine("3. Multiplication");
            Console.WriteLine("4. Division");
            Console.WriteLine("5. Random");
            Console.WriteLine("6. History");
            Console.WriteLine("7. Difficulty");
            Console.WriteLine("\"EXIT\" to exit");
        }

        static void RandomGenerate(int[] randomValues, int difficulty, char operation)
        {
            bool validDivision = false;
            do
            {
                Random random = new Random();

                randomValues[0] =  (difficulty == 1)? random.Next(0, 101): (difficulty == 2) ? random.Next(0, 1001) : random.Next(0, 10001);
                
                if(operation == '/')
                {
                    randomValues[1] = random.Next(1, 101);
                    if (randomValues[0] % randomValues[1] == 0 && randomValues[1] != 0)
                    {
                        validDivision = true;
                    }
                }
                else
                {
                    randomValues[1] = (difficulty == 1) ? random.Next(0, 101) : (difficulty == 2) ? random.Next(0, 1001) : random.Next(0, 10001);
                    validDivision = true;
                }

            } while (!validDivision);

        }

        static bool GameRound(int result)
        {
            Console.Write("Result: ");
            if (result != GetUserInput())
            {
                Console.WriteLine($"\nYou LOST! The right answer was: {result}");
                return true;
            }
            return false;
        }

    }
}

