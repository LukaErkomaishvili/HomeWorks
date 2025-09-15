namespace Homework2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();

            Console.WriteLine("Luka Erkomaishvili");

            Console.Write("Please enter your hometown: ");
            String input = Console.ReadLine();

            Console.WriteLine();
            Console.WriteLine("Your hometown is " + input);
        }
    }
}
