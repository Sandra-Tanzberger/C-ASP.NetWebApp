using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text.RegularExpressions;
using System.Collections;

namespace ATG.Utilities.CreditCard {

    /// <summary>
    /// Summary description for CreditCardValidation
    /// </summary>
    public class CreditCardValidation {
        [Flags, Serializable]
        public enum CardType {
            MasterCard = 0x0001,
            VISA = 0x0002,
            Amex = 0x0004,
            DinersClub = 0x0008,
            enRoute = 0x0010,
            Discover = 0x0020,
            JCB = 0x0040,
            Unknown = 0x0080,
            All = CardType.Amex | CardType.DinersClub |
                             CardType.Discover | CardType.Discover |
                             CardType.enRoute | CardType.JCB |
                             CardType.MasterCard | CardType.VISA
        }

        /**
         * accepted credit card types
         */
        private CardType _acceptedCardTypes;
        public string AcceptedCardTypes {
            get {
                return _acceptedCardTypes.ToString();
            }
            set {
                _acceptedCardTypes = (CardType)Enum.Parse(typeof(CardType), value, false);
            }
        }

        /**
         * Default constructor
         */
        public CreditCardValidation() {
            _acceptedCardTypes = CardType.All;
        }

        /**
         * Test if credit card # is valid for the specified credit card type.
         * The test is respectful of the current setting of _acceptedCardTypes.
         */
        public bool IsValidCard(
		      string cardNumber
		    , string cardType
		) {
            // Check the length, if the length is fine then validate the
            // card number
            if (_IsValidCardType(cardNumber)) {
                return _ValidateCardNumber(cardNumber);
            }
            else {
                return false;        // Invalid length
            }
		}

        /**
         * Test if card number is valid for any of the current _acceptedCardTypes.
         */
        private bool _IsValidCardType(
            string cardNumber
        ) {
            // AMEX -- 34 or 37 -- 15 length
            if ((Regex.IsMatch(cardNumber, "^(34|37)"))
                 && ((_acceptedCardTypes & CardType.Amex) != 0))
                return (15 == cardNumber.Length);

            // MasterCard -- 51 through 55 -- 16 length
            else if ((Regex.IsMatch(cardNumber, "^(51|52|53|54|55)")) &&
                      ((_acceptedCardTypes & CardType.MasterCard) != 0))
                return (16 == cardNumber.Length);

            // VISA -- 4 -- 13 and 16 length
            else if ((Regex.IsMatch(cardNumber, "^(4)")) &&
                      ((_acceptedCardTypes & CardType.VISA) != 0))
                return (13 == cardNumber.Length || 16 == cardNumber.Length);

            // Diners Club -- 300-305, 36 or 38 -- 14 length
            else if ((Regex.IsMatch(cardNumber, "^(300|301|302|303|304|305|36|38)")) &&
                      ((_acceptedCardTypes & CardType.DinersClub) != 0))
                return (14 == cardNumber.Length);

            // enRoute -- 2014,2149 -- 15 length
            else if ((Regex.IsMatch(cardNumber, "^(2014|2149)")) &&
                      ((_acceptedCardTypes & CardType.DinersClub) != 0))
                return (15 == cardNumber.Length);

            // Discover -- 6011 -- 16 length
            else if ((Regex.IsMatch(cardNumber, "^(6011)")) &&
                     ((_acceptedCardTypes & CardType.Discover) != 0))
                return (16 == cardNumber.Length);

            // JCB -- 3 -- 16 length
            else if ((Regex.IsMatch(cardNumber, "^(3)")) &&
                     ((_acceptedCardTypes & CardType.JCB) != 0))
                return (16 == cardNumber.Length);

            // JCB -- 2131, 1800 -- 15 length
            else if ((Regex.IsMatch(cardNumber, "^(2131|1800)")) &&
                       ((_acceptedCardTypes & CardType.JCB) != 0))
                return (15 == cardNumber.Length);
            else {
                // Card type wasn't recognised, provided Unknown is in the 
                // CardTypes property, then return true, otherwise return false.
                if ((_acceptedCardTypes & CardType.Unknown) != 0)
                    return true;
                else
                    return false;
            }
        }

        /**
         * Validate whether or not the card number is valid
         */
        private static bool _ValidateCardNumber(
            string cardNumber
        ) {
            try {
                // Array to contain individual numbers
                ArrayList CheckNumbers = new ArrayList();
                // So, get length of card
                int CardLength = cardNumber.Length;

                // Double the value of alternate digits, starting with the second digit
                // from the right, i.e. back to front.
                // Loop through starting at the end
                for (int i = CardLength - 2; i >= 0; i = i - 2) {
                    // Now read the contents at each index, this
                    // can then be stored as an array of integers

                    // Double the number returned
                    CheckNumbers.Add(Int32.Parse(cardNumber[i].ToString()) * 2);
                }

                int CheckSum = 0;    // Will hold the total sum of all checksum digits

                // Second stage, add separate digits of all products
                for (int iCount = 0; iCount <= CheckNumbers.Count - 1; iCount++) {
                    int _count = 0;    // will hold the sum of the digits

                    // determine if current number has more than one digit
                    if ((int)CheckNumbers[iCount] > 9) {
                        int _numLength = ((int)CheckNumbers[iCount]).ToString().Length;
                        // add count to each digit
                        for (int x = 0; x < _numLength; x++) {
                            _count = _count + Int32.Parse(
                                  ((int)CheckNumbers[iCount]).ToString()[x].ToString());
                        }
                    }
                    else {
                        // single digit, just add it by itself
                        _count = (int)CheckNumbers[iCount];
                    }
                    CheckSum = CheckSum + _count;    // add sum to the total sum
                }
                // Stage 3, add the unaffected digits
                // Add all the digits that we didn't double still starting from the
                // right but this time we'll start from the rightmost number with 
                // alternating digits
                int OriginalSum = 0;
                for (int y = CardLength - 1; y >= 0; y = y - 2) {
                    OriginalSum = OriginalSum + Int32.Parse(cardNumber[y].ToString());
                }

                // Perform the final calculation, if the sum Mod 10 results in 0 then
                // it's valid, otherwise its false.
                return (((OriginalSum + CheckSum) % 10) == 0);
            }
            catch {
                return false;
            }
        }
    }
}