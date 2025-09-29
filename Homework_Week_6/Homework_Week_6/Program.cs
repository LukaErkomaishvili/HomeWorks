namespace Homework_Week_6
{
    internal class Program
    {
        static void Main(string[] args)
        {
           
            #region Task 1

            Console.WriteLine("Enter an array length: ");
            var length = int.Parse(Console.ReadLine());
            int[] array = new int[length];

            List<int> listForEvens = new List<int>();
            List<int> listForOdds = new List<int>();

            for (int i = 0; i < length; i++)
            {
                Console.WriteLine($"Enter element #{i + 1}");
                array[i] = int.Parse(Console.ReadLine());
            }

            Console.WriteLine($"Numbers in the array: {string.Join(", ", array)}");

            for (int i = 0; i < length; i++)
            {
                if (array[i] % 2 == 0)
                {
                    listForEvens.Add(array[i]);
                }
                else
                {
                    listForOdds.Add(array[i]);
                }
            }

            Console.WriteLine($"Even numbers in the array: {string.Join(", ", listForEvens)}");
            Console.WriteLine($"Odd numbers in the array: {string.Join(", ", listForOdds)}");


            #endregion



            #region Task 2

            Dictionary<string, string> contacts = new Dictionary<string, string>();

            while (true)
            {
                Console.WriteLine("Enter a number of desired operation: 1. Add; 2. Remove; 3. AllContacts 4. Exit");
                var response = int.Parse(Console.ReadLine());
                if (response == 1)
                {
                    Console.WriteLine("Enter a name: ");
                    var name = Console.ReadLine();
                    Console.WriteLine("Enter a number: ");
                    var number = Console.ReadLine();

                    contacts.Add(name, number);
                }
                else if (response == 2)
                {
                    Console.WriteLine("Enter a name you want to remove : ");
                    string name = Console.ReadLine();
                    if (contacts.ContainsKey(name))
                    {
                        contacts.Remove(name);
                        Console.WriteLine($"{name} has been removed successfully");
                    }
                    else
                    {
                        Console.WriteLine($"{name} is not in the contacts");
                    }
                }
                else if (response == 3)
                {
                    foreach (var contact in contacts)
                    {
                        Console.WriteLine($"{contact.Key} : {contact.Value}");
                    }
                }
                else
                {
                    break;
                }


            }

            #endregion



            #region Task 3

            List<int> numbers = new List<int>();

            Console.WriteLine("How many numbers do you want to enter?");
            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                Console.WriteLine($"Enter number #{i + 1}: ");
                int num = int.Parse(Console.ReadLine());
                numbers.Add(num);
            }

            var results = numbers.GroupBy(n => n).Select(g => new { Number = g.Key, Count = g.Count(), Sum = g.Sum() });

            foreach (var result in results)
            {
                if (result.Count > 1)
                {
                    Console.WriteLine($"{result.Number} appears {result.Count} times. Sum: {result.Sum}");
                }
                else
                {
                    Console.WriteLine($"{result.Number} appears {result.Count} time. Sum: {result.Sum}");
                }
                    
            }


            #endregion



            #region Task 4

            List<int> participantsScores = new List<int>();
            Console.WriteLine("Enter the number of participants: ");
            int quantity = int.Parse(Console.ReadLine());

            for (int i=0; i <quantity; i++)
            {
                Console.WriteLine($"Enter score for participant {i + 1}: ");
                int score = int.Parse(Console.ReadLine());
                participantsScores.Add(score);
            }


            Console.WriteLine($"How many top scores do you want to see? ");
            int numberOfTopScorers = int.Parse(Console.ReadLine());
            
            var topScores = participantsScores.OrderByDescending(s => s).Take(numberOfTopScorers);
            Console.WriteLine($"Top {numberOfTopScorers} scores: {string.Join(", ", topScores)}");

            #endregion
        }
    }
}
