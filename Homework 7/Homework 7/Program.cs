using System.Linq;

namespace Homework_7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            #region Task 1

            Console.WriteLine("Enter the radius of the circle:");
            int radius = int.Parse(Console.ReadLine());

            int areaOfBigSquare = radius * 2 * radius * 2;
            int areaOfSmallSquare = radius * radius;

            Console.WriteLine($"Difference between areas of squares is: {areaOfBigSquare - areaOfSmallSquare}");


            #endregion


            #region Task 2





            #endregion


            #region Task 3

            Console.WriteLine("Enter the number of matches team won: ");
            int won = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the number of matches team played draw: ");
            int draw = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the number of matches team lost: ");
            int lost = int.Parse(Console.ReadLine());

            int totalPoints = won * 3 + draw * 1 + lost * 0;
            Console.WriteLine($"Total points of the team is: {totalPoints}");

            #endregion
            

            #region Task 4

            int hoursWorked = 0;
            Dictionary<string, int> workHours = new Dictionary<string, int>()
            {
                { "Monday", 0 },
                { "Tuesday", 0 },
                { "Wednesday", 0 },
                { "Thursday", 0 },
                { "Friday", 0 },
                { "Saturday", 0 },
                { "Sunday", 0 }
            };

            List<string> days = new List<string> { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
            int weekdayPay = 0;
            int weekendPay = 0;

            for (int i = 0; i < days.Count; i++)
            {
                string day = days[i];
                Console.WriteLine($"Enter the number of hours worked on {days[i]}: ");
                hoursWorked = int.Parse(Console.ReadLine());
                workHours[day] = hoursWorked;
                if (i <= days.Count - 3)
                { 
                    
                    if (hoursWorked > 8)
                    {
                        weekdayPay += 8 * 10 + (hoursWorked - 8) * 15;
                    }
                    else
                    {
                        weekdayPay += hoursWorked * 10;
                    }
                }
                else if (i >= days.Count - 2)
                {
                    weekendPay += hoursWorked * 20;
                }
                    
            }

            Console.WriteLine($"Total pay for the week is: {weekdayPay + weekendPay}");
           
            #endregion
            */

            #region Task 5

            while (true)
                Console.WriteLine


            #endregion
        }
    }
}
