using System.Globalization;
using System.Text.Json;
using System.Transactions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Banking_Application
{
    internal class Program
    {
        static void Main()
        {

            string path = @"D:\Desktop\.NET\HomeWorks\Banking Application\Banking Application\Data\cards.json";
            string transactionsPath = @"D:\Desktop\.NET\HomeWorks\Banking Application\Banking Application\Data\transactions.json";

            if (!File.Exists(path))
            {
                Console.WriteLine("cards.json not found.");
                return;
            }

            
            string cardsJson = File.ReadAllText(path);
            List<Card> cards = JsonSerializer.Deserialize<List<Card>>(cardsJson);

            List<Transaction> transactions;
            if (File.Exists(transactionsPath))
            {
                string transactionsJson = File.ReadAllText(transactionsPath);
                transactions = JsonSerializer.Deserialize<List<Transaction>>(transactionsJson);
            }
            else
            {
                transactions = new List<Transaction>();
            }

            Card card;
            while (true)
            {
                string cardNumber;
                while (true)
                {
                    Console.Write("Enter card number: ");
                    cardNumber = Console.ReadLine();


                    string msg = CardValidator.CheckCardNumber(cardNumber);
                    if (msg != null)
                    {
                        Console.WriteLine(msg);
                    }
                    else
                    {
                        break;
                    }
                }

                string userExpiry;
                while (true)
                {
                    Console.Write("Enter expiry date (MM/YY): ");
                    userExpiry = Console.ReadLine();

                    string msg = CardValidator.CheckExpiry(userExpiry);
                    if (msg != null)
                    {
                        Console.WriteLine(msg);
                    }
                    else
                    {
                        break;
                    }

                }


                string findMsg;
                card= CardValidator.FindCard(cardNumber, cards, out findMsg);
                if (card == null || card.Expiry != userExpiry)
                {
                    Console.WriteLine("Card number or expiry does not match our records.");
                    continue;
                }

                Console.Write("Enter PIN: ");
                string enteredPin = Console.ReadLine();
                string pinMsg = CardValidator.CheckPin(enteredPin, card);
                if (pinMsg != null)
                {
                    Console.WriteLine(pinMsg);
                    Console.WriteLine("Restarting from the beginning...");
                    continue;
                }

                Console.WriteLine(($"Welcome, {card.Owner}!"));
                break;
            }

            ActionMenu.ShowMenu(card, cards, transactions);

            string finalTransactionsJson = JsonSerializer.Serialize(transactions, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(transactionsPath, finalTransactionsJson);




        }

    }

}
