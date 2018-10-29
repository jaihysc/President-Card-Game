using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace President_Card_Game
{
    public class CardInfo
    {
        public void PrintPlayerCards(string inputCardString)
        {
            int referencedCardPos;

            //Print player cards to screen
            for (int i = 0; i < 54; i++)
            {
                referencedCardPos = i;
                string referencedCardValue = inputCardString.Substring(i, 1);

                //Card headings
                Console.ForegroundColor = ConsoleColor.Gray;
                switch (referencedCardPos)
                {
                    case 0:
                        Console.WriteLine("###----#----------------------#----###");
                        Console.WriteLine("###----##-<<< Your Cards >>>-##----###");
                        Console.WriteLine("###----#----------------------#----###");
                        Console.WriteLine("");
                        Console.WriteLine("=-----=---< 2 >---=-----=");
                        break;
                    case 4:
                        Console.WriteLine("=-----=---< 3 >---=-----=");
                        break;
                    case 8:
                        Console.WriteLine("=-----=---< 4 >---=-----=");
                        break;
                    case 12:
                        Console.WriteLine("=-----=---< 5 >---=-----=");
                        break;
                    case 16:
                        Console.WriteLine("=-----=---< 6 >---=-----=");
                        break;
                    case 20:
                        Console.WriteLine("=-----=---< 7 >---=-----=");
                        break;
                    case 24:
                        Console.WriteLine("=-----=---< 8 >---=-----=");
                        break;
                    case 28:
                        Console.WriteLine("=-----=---< 9 >---=-----=");
                        break;
                    case 32:
                        Console.WriteLine("=-----=---< 10 >---=----=");
                        break;
                    case 36:
                        Console.WriteLine("=-----=---< JACK >---=--=");
                        break;
                    case 40:
                        Console.WriteLine("=-----=---< QUEEN >---=--=");
                        break;
                    case 44:
                        Console.WriteLine("=-----=---< KING >---=---=");
                        break;
                    case 48:
                        Console.WriteLine("=-----=---< ACE >---=----=");
                        break;
                    case 52:
                        Console.WriteLine("=-----=---< *JOKER* >-=--=");
                        break;

                    default:
                        break;
                }
                Console.ForegroundColor = ConsoleColor.Cyan;

                if (referencedCardValue == "0")
                {

                    //card suit and type
                    switch (referencedCardPos)
                    {

                        case 0: Console.WriteLine("2 - Hearts"); break;
                        case 1: Console.WriteLine("2 - Spades"); break;
                        case 2: Console.WriteLine("2 - Clubs"); break;
                        case 3: Console.WriteLine("2 - Diamonds"); break;

                        case 4: Console.WriteLine("3 - Hearts"); break;
                        case 5: Console.WriteLine("3 - Spades"); break;
                        case 6: Console.WriteLine("3 - Clubs"); break;
                        case 7: Console.WriteLine("3 - Diamonds"); break;

                        case 8: Console.WriteLine("4 - Hearts"); break;
                        case 9: Console.WriteLine("4 - Spades"); break;
                        case 10: Console.WriteLine("4 - Clubs"); break;
                        case 11: Console.WriteLine("4 - Diamonds"); break;

                        case 12: Console.WriteLine("5 - Hearts"); break;
                        case 13: Console.WriteLine("5 - Spades"); break;
                        case 14: Console.WriteLine("5 - Clubs"); break;
                        case 15: Console.WriteLine("5 - Diamonds"); break;

                        case 16: Console.WriteLine("6 - Hearts"); break;
                        case 17: Console.WriteLine("6 - Spades"); break;
                        case 18: Console.WriteLine("6 - Clubs"); break;
                        case 19: Console.WriteLine("6 - Diamonds"); break;

                        case 20: Console.WriteLine("7 - Hearts"); break;
                        case 21: Console.WriteLine("7 - Spades"); break;
                        case 22: Console.WriteLine("7 - Clubs"); break;
                        case 23: Console.WriteLine("7 - Diamonds"); break;

                        case 24: Console.WriteLine("8 - Hearts"); break;
                        case 25: Console.WriteLine("8 - Spades"); break;
                        case 26: Console.WriteLine("8 - Clubs"); break;
                        case 27: Console.WriteLine("8 - Diamonds"); break;

                        case 28: Console.WriteLine("9 - Hearts"); break;
                        case 29: Console.WriteLine("9 - Spades"); break;
                        case 30: Console.WriteLine("9 - Clubs"); break;
                        case 31: Console.WriteLine("9 - Diamonds"); break;

                        case 32: Console.WriteLine("10 - Hearts"); break;
                        case 33: Console.WriteLine("10 - Spades"); break;
                        case 34: Console.WriteLine("10 - Clubs"); break;
                        case 35: Console.WriteLine("10 - Diamonds"); break;

                        case 36: Console.WriteLine("J - Hearts"); break;
                        case 37: Console.WriteLine("J - Spades"); break;
                        case 38: Console.WriteLine("J - Clubs"); break;
                        case 39: Console.WriteLine("J - Diamonds"); break;

                        case 40: Console.WriteLine("Q - Hearts"); break;
                        case 41: Console.WriteLine("Q - Spades"); break;
                        case 42: Console.WriteLine("Q - Clubs"); break;
                        case 43: Console.WriteLine("Q - Diamonds"); break;

                        case 44: Console.WriteLine("K - Hearts"); break;
                        case 45: Console.WriteLine("K - Spades"); break;
                        case 46: Console.WriteLine("K - Clubs"); break;
                        case 47: Console.WriteLine("K - Diamonds"); break;

                        case 48: Console.WriteLine("A - Hearts"); break;
                        case 49: Console.WriteLine("A - Spades"); break;
                        case 50: Console.WriteLine("A - Clubs"); break;
                        case 51: Console.WriteLine("A - Diamonds"); break;

                        case 52: Console.WriteLine("Small Joker"); break;
                        case 53: Console.WriteLine("Large Joker"); break;

                        default:
                            break;
                    }
                }
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        public bool HasCardSingular(string inputCardString, int cardType, int cardSuit, bool isPlayer)
        {
            int checkPos = cardType * 4 + cardSuit;

            string checkPosValue = inputCardString.Substring(checkPos, 1);

            if (isPlayer == true)
            {
                if (checkPosValue == "0")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                if (checkPosValue == "1")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

        }

        public bool HasCard(string storedCardString, string inputPlayerCardString, bool isPlayer)
        {
            int checkPos = 0;

            bool quit = false;
            while (quit == false)
            {
                string tempStoredCardString = storedCardString.Substring(checkPos, 1);
                string tempPlayerCardString = inputPlayerCardString.Substring(checkPos, 1);

                if (tempStoredCardString != tempPlayerCardString)
                {
                    if (isPlayer == true && tempPlayerCardString == "0")
                    {
                        return false;
                    }
                    else if (isPlayer == false && tempPlayerCardString == "1")
                    {
                    }
                }

                if (checkPos == 53) quit = true;
                checkPos++;
            }

            return true;
        }

        public string RemoveCards(string storedCardString, string inputPlayerCardString, bool isPlayer)
        {
            int checkPos = 0;
            string newStoredCardString = storedCardString;

            bool quit = false;
            while (quit == false)
            {
                string tempStoredCardString = storedCardString.Substring(checkPos, 1);
                string tempPlayerCardString = inputPlayerCardString.Substring(checkPos, 1);

                if (tempStoredCardString == tempPlayerCardString)
                {
                    if (isPlayer == true && tempPlayerCardString == "0")
                    {
                        newStoredCardString = newStoredCardString.Substring(0, checkPos) + "2" + newStoredCardString.Substring(checkPos + 1, 53 - checkPos);
                    }
                }

                if (checkPos == 53) quit = true;
                checkPos++;
            }

            return newStoredCardString;
        }

        public string GetLastCard(string storedCardString, string newStoredCardString, bool isPlayer)
        {
            bool quit = false;
            int checkPos = 0;
            string lastCards = "";

            while (quit == false)
            {

                string tempStoredCardString = storedCardString.Substring(checkPos, 1);
                string tempNewStoredCardString = newStoredCardString.Substring(checkPos, 1);

                if (tempStoredCardString != tempNewStoredCardString)
                {
                    if (isPlayer == true && tempNewStoredCardString == "2")
                    {
                        lastCards += StringPosToCard(checkPos);
                    }
                    else if (isPlayer == false && tempNewStoredCardString == "3")
                    {
                        lastCards += StringPosToCard(checkPos);
                    }
                }

                if (checkPos == 53) quit = true;

                checkPos++;
            }

            if (lastCards == "")
            {
                return "N/A";
            }
            else
            {
                return lastCards;
            }
        }

        private string StringPosToCard(int inputCardPos)
        {
            string[] cardTypes = new string[14];

            cardTypes[0] = "2";
            cardTypes[1] = "3";
            cardTypes[2] = "4";
            cardTypes[3] = "5";
            cardTypes[4] = "6";
            cardTypes[5] = "7";
            cardTypes[6] = "8";
            cardTypes[7] = "9";
            cardTypes[8] = "10";
            cardTypes[9] = "J";
            cardTypes[10] = "Q";
            cardTypes[11] = "K";
            cardTypes[12] = "A";

            int cardType = 0;
            string cardSuit = "";

            if (inputCardPos == 52)
            {
                return "SJ";
            }
            if (inputCardPos == 53)
            {
                return "LJ";
            }

            if ((inputCardPos - 0) % 4 == 0)
            {
                cardSuit = "h";
                cardType = (inputCardPos - 0) / 4;
            }
            if ((inputCardPos - 1) % 4 == 0)
            {
                cardSuit = "s";
                cardType = (inputCardPos - 1) / 4;
            }
            if ((inputCardPos - 2) % 4 == 0)
            {
                cardSuit = "c";
                cardType = (inputCardPos - 2) / 4;
            }
            if ((inputCardPos - 3) % 4 == 0)
            {
                cardSuit = "d";
                cardType = (inputCardPos - 3) / 4;
            }

            return cardTypes[cardType] + "-" + cardSuit + " ";
        }
    }
}
