using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking_Application
{
    internal class CardValidator
    {
        public static string CheckCardNumber(string cardNumber)
        {
            if (string.IsNullOrWhiteSpace(cardNumber))
                return "Card number cannot be empty.";

            if (cardNumber.Length != 16)
            return "Card number must be 16 digits.";

            if (!cardNumber.All(char.IsDigit))
                return "Card number must contain only digits.";

            return null;

        }
        public static string CheckExpiry(string expiry)
        {
            if (string.IsNullOrWhiteSpace(expiry))
                return "Expiry date cannot be empty.";

            if (!DateTime.TryParseExact(expiry, "MM/yy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out DateTime expDate))
                return "Expiry date format is invalid. Use MM/YY.";

            if (expDate < DateTime.Now)
                return "Card has expired.";

            return null;

        }

        public static Card FindCard(string cardNumber, List<Card> cards, out string message)
        {
            message = "";
            foreach (var c in cards)
            {
                if (c.CardNumber == cardNumber)
                    return c;
            }

            message = "Card not found in our system.";
            return null;
        }

        internal static Card FindCard(string cardNumber, object cards, out string msg)
        {
            throw new NotImplementedException();
        }

        public static string CheckPin(string enteredPin, Card card)
        {
            if (enteredPin != card.Pin)
                return "Incorrect PIN.";
            return null;
        }
    }
}
