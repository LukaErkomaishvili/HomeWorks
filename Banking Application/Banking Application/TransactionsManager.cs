using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Banking_Application
{
    public class TransactionsManager
    {
        public static string path = @"D:\Desktop\.NET\HomeWorks\Banking Application\Banking Application\Data\transactions.json";

        public static List<Transaction> LoadTransactions()
        {
            if (!File.Exists(path))
                return new List<Transaction>();

            string json = File.ReadAllText(path);
            return JsonSerializer.Deserialize<List<Transaction>>(json) ?? new List<Transaction>();
        }

        public static void SaveTransactions(List<Transaction> transactions)
        {
            string json = JsonSerializer.Serialize(transactions, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(path, json);
        }

        public static void AddTransaction(List<Transaction> transactions, Transaction transaction)
        {
            transactions.Add(transaction);
            SaveTransactions(transactions);
        }
    }
}
