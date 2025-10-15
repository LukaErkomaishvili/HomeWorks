namespace Homework_8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");



        }

        static void Task1 (int a, int b, int c)
        {
            try
            {
                Console.WriteLine("Enter the first number:");
                a = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter the second number:");
                b = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter the power:");
                c = Convert.ToInt32(Console.ReadLine());

            }
            catch ()
            {
                               Console.WriteLine("Invalid input. Please enter integers only.");
                return;
            }


        }
    }
}
