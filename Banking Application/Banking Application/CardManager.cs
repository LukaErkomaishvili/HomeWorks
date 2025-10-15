using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Banking_Application
{
    public class CardManager
    {
        public static void Save(List<Card> cards)
        {
            string path = @"D:\Desktop\.NET\HomeWorks\Banking Application\Banking Application\Data\cards.json";
            string json = JsonSerializer.Serialize(cards, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(path, json);
        }
    }
}
