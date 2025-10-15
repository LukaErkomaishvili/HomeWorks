using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Banking_Application
{
    public static class ActionMenu
    {
        public static void ShowMenu(Card card, List<Card> cards, List<Transaction> transactions)
        {
            while (true)
            {
                Console.WriteLine("---Select the desired action (enter the action number):---");
                Console.WriteLine("1. Check Balance");
                Console.WriteLine("2. Withdraw");
                Console.WriteLine("3. Deposit");
                Console.WriteLine("4. Convert Currency");
                Console.WriteLine("5. Change Pin");
                Console.WriteLine("6. View Last Five Operations");
                Console.WriteLine("7. Exit");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine($"Your Current Balance is: {card.Balance} {card.Currency}");
                        break;

                    case "2":
                        Withdraw(card, cards, transactions);
                        break;

                    case "3":
                        Deposit(card, cards, transactions);
                        break;

                    case "4":
                        ConvertCurrency(card, cards, transactions);
                        break;

                    case "5":
                        ChangePin(card, cards, transactions);
                        break;

                    case "6":
                        LastFiveOperations(card, transactions);
                        break;

                    case "7":
                        Console.WriteLine("Thank you for using our bank. Goodbye!");
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Please select a valid action number:");
                        break;


                }

            }
        }

        public static void Withdraw(Card card, List<Card> cards, List<Transaction> transactions)
        {
            Console.Write("Enter amount to withdraw: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal amount))
            {
                if (amount <= 0)
                {
                    Console.WriteLine("Invalid amount.");
                    return;
                }
                if (amount > card.Balance)
                {
                    Console.WriteLine("Insufficient funds.");
                    return;
                }

                card.Balance -= amount;
                CardManager.Save(cards);

                TransactionsManager.AddTransaction(transactions, new Transaction
                {
                    Date = DateTime.Now,
                    CardNumber = card.CardNumber,
                    Type = "Withdraw",
                    Amount = amount,
                    Currency = card.Currency,
                    BalanceAfter = card.Balance
                });

                Console.WriteLine($"You withdrew {amount} {card.Currency}. New balance: {card.Balance} {card.Currency}");
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }

        }

        public static void Deposit(Card card, List<Card> cards, List<Transaction> transactions)
        {
            Console.Write("Enter amount to deposit: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal amount))
            {
                if (amount <= 0)
                {
                    Console.WriteLine("Invalid amount.");
                    return;
                }

                card.Balance += amount;
                CardManager.Save(cards);

                TransactionsManager.AddTransaction(transactions, new Transaction
                {
                    Date = DateTime.Now,
                    CardNumber = card.CardNumber,
                    Type = "Deposit",
                    Amount = amount,
                    Currency = card.Currency,
                    BalanceAfter = card.Balance
                });

                Console.WriteLine($"You deposited {amount} {card.Currency}. New balance: {card.Balance} {card.Currency}");
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }
        }

        public static void ConvertCurrency(Card card, List<Card> cards, List<Transaction> transactions)
        {
            Console.Write("Enter target currency (USD/EUR/GEL): ");
            string targetCurrency = Console.ReadLine().ToUpper();

            if (targetCurrency == card.Currency)
            {
                Console.WriteLine("You already have this currency.");
                return;
            }

            decimal rate = 0m;

            if (card.Currency == "GEL" && targetCurrency == "USD") rate = 0.37m;
            else if (card.Currency == "GEL" && targetCurrency == "EUR") rate = 0.34m;
            else if (card.Currency == "USD" && targetCurrency == "GEL") rate = 2.70m;
            else if (card.Currency == "EUR" && targetCurrency == "GEL") rate = 2.95m;
            else if (card.Currency == "USD" && targetCurrency == "EUR") rate = 0.92m;
            else if (card.Currency == "EUR" && targetCurrency == "USD") rate = 1.09m;

            if (rate == 0)
            {
                Console.WriteLine("Unsupported currency.");
                return;
            }

            decimal newBalance = card.Balance * rate;

            var cardToUpdate = cards.FirstOrDefault(c => c.CardNumber == card.CardNumber);
            if (cardToUpdate != null)
            {
                cardToUpdate.Balance = newBalance;
                cardToUpdate.Currency = targetCurrency;
            }


            CardManager.Save(cards);
            Console.WriteLine($"Your balance in {targetCurrency}: {card.Balance:F2}");

            TransactionsManager.AddTransaction(transactions, new Transaction
            {
                Date = DateTime.Now,
                CardNumber = card.CardNumber,
                Type = $"Currency Conversion ({card.Currency} → {targetCurrency})",
                Amount = 0,
                Currency = targetCurrency,
                BalanceAfter = newBalance
            });
        }

        public static void ChangePin(Card card, List<Card> cards, List<Transaction> transactions)
        {
            Console.Write("Enter new PIN (4 digits): ");
            string newPin = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(newPin) || newPin.Length != 4 || !newPin.All(char.IsDigit))
            {
                Console.WriteLine("Invalid PIN format. It must be 4 digits.");
                return;
            }

            Console.Write("Confirm new PIN: ");
            string confirmPin = Console.ReadLine();

            if (newPin != confirmPin)
            {
                Console.WriteLine("PINs do not match. Try again.");
                return;
            }

            card.Pin = newPin;
            CardManager.Save(cards);
            Console.WriteLine("PIN successfully changed!");

            TransactionsManager.AddTransaction(transactions, new Transaction
            {
                Date = DateTime.Now,
                CardNumber = card.CardNumber,
                Type = "PIN Change",
                Amount = 0,
                Currency = card.Currency,
                BalanceAfter = card.Balance
            });
        }

        public static void LastFiveOperations(Card card, List<Transaction> transactions)
        {
            var lastFive = transactions
                .Where(t => t.CardNumber == card.CardNumber)
                .OrderByDescending(t => t.Date)
                .Take(5)
                .ToList();

            if (lastFive.Count == 0)
            {
                Console.WriteLine("No transactions found.");
                return;
            }

            Console.WriteLine("\n--- Last 5 Transactions ---");
            foreach (var t in lastFive)
            {
                string amountDisplay = t.Amount == 0 ? "-" : $"{t.Amount:F2}";
                Console.WriteLine($"{t.Date:G} | {t.Type,-15} | {amountDisplay,8} {t.Currency} | Balance after: {t.BalanceAfter}");
            }
        }

    }
}
