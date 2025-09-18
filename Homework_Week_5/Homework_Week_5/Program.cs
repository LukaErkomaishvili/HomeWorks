using System.Numerics;

namespace Homework_Week_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
           
            #region Task 1

            Console.WriteLine("Enter a number: ");
            var number = Convert.ToDecimal(Console.ReadLine());

            if (number % 5 == 0)
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
            }

            #endregion



            #region Task 2

            Console.WriteLine("Enter fist number: ");
            var firstNumber = Convert.ToDecimal(Console.ReadLine());

            Console.WriteLine("Enter second number: ");
            var secondNumber = Convert.ToDecimal(Console.ReadLine());

            var sum = firstNumber + secondNumber;
            Console.WriteLine($"Sum is equal to {sum}");
            var multiplication = firstNumber * secondNumber;
            Console.WriteLine($"Multiptication is equal to {multiplication}");

            if (firstNumber >= secondNumber)
            {                
                var subtraction = firstNumber - secondNumber;
                Console.WriteLine($"Subtraction is equal to {subtraction}");

                if (secondNumber != 0)
                {
                    decimal division = firstNumber / secondNumber;
                    Console.WriteLine($"Division is equal to {division}");
                }
                else
                    Console.WriteLine("Not Allowed To Divide By Zero");
            }
            else
            {
                var subtraction = secondNumber - firstNumber;
                Console.WriteLine($"Subtraction is equal to {subtraction}");
                
                if (firstNumber != 0)
                {
                    decimal division = secondNumber / firstNumber;
                    Console.WriteLine($"Division is equal to {division}");
                }
                else
                    Console.WriteLine("Not Allowed To Divide By Zero");
            }


            #endregion



            #region Task 3

            int x = 5;
            int y = 12;

            x = x + y;  // 17
            y = x - y;  // 5
            x = x - y;  // 12

            Console.WriteLine($"x = {x}, y = {y}");


            #endregion



            #region Task 4

            Console.WriteLine("Enter a number: ");
            var input = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < 10; i++)
            { 
                Console.WriteLine($"{input} * {i} = {input * i}");
            }


            #endregion



            #region Task 5

            Console.WriteLine("Enter a number: ");
            var task5Input = Convert.ToInt32(Console.ReadLine());

            for (int n = 1; n <= task5Input; n++)
            {
                if (n % 2 == 0)
                {
                    Console.WriteLine(n*n);
                }
            }



            #endregion























        }
    }
}
