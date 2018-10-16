using System;

namespace CardInformation
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

    public class CardLogicProcessing
    {
        //****0 == SELECTED || 2 == NOT SELECTED
        //Processes card inputs for validity
        //000 is general error code for invalid card. Specific messages can be specified. E.g 001, 002
        public bool CardInputProcessing(string inputPlayerCardString, string storedAICardString)
        {
            //Calls all the private methods for card logic
            CardInputBurnProcessing(inputPlayerCardString, storedAICardString);
            CardInputDoublesProcessing(inputPlayerCardString);

            return true;
        }

        //Burns
        private string CardInputBurnProcessing(string inputPlayerCardString, string storedAICardString)
        {
            //Gets burn amount / type
            string burnStatus = CardInputBurnCounter(inputPlayerCardString);
            //Checks if usage is valid
            bool burnUsageIsValid = CardInputValidBurnPlacement(inputPlayerCardString, storedAICardString, burnStatus);

            return "";
        }

        private string CardInputBurnCounter(string inputPlayerCardString)
        {
            string returnStatus = "000";
            int[] subStringPos = new int[6];
            subStringPos[0] = 0;
            subStringPos[1] = 1;
            subStringPos[2] = 2;
            subStringPos[3] = 3;
            subStringPos[4] = 52;
            subStringPos[5] = 53;

            //Twos processing
            int twosAmount = 0;
            for (int i = 0; i < 4; i++)
            {
                if (inputPlayerCardString.Substring(subStringPos[i], 1) == "0")
                {
                    twosAmount += 1;
                }
            }
            if (twosAmount >= 3) returnStatus = "000";
            if (twosAmount == 1) returnStatus = "1";
            if (twosAmount == 2) returnStatus = "2";

            //Jokers processing
            int jokersAmount = 0;
            for (int i = 0; i < 2; i++)
            {
                if (inputPlayerCardString.Substring(subStringPos[i + 4], 1) == "0")
                {
                    jokersAmount += 1;
                }
            }
            if (jokersAmount >= 2) returnStatus = "000";
            if (jokersAmount == 2) returnStatus = "2";

            //Quadruple processing
            //Gets a string of number of cards for each card type
            string playerCardsStatus = CardInputDoublesCounter(inputPlayerCardString);
            for (int i = 0; i < 12; i++)
            {
                //Cycles through each digit of the string, converts to integer, sees if is 4
                if (Int32.Parse(playerCardsStatus.Substring(i, 1)) == 4)
                {
                    returnStatus = "3";
                }
            }

                return returnStatus;
        }

        private bool CardInputValidBurnPlacement(string inputPlayerCardString, string storedAICardString, string burnStatus)
        {
            //Checks if burn usage is valid
            //Not a free turn
            //2 Twos for triples / one joker

            //AI Free turn check
            if (storedAICardString == "222222222222222222222222222222222222222222222222222222" && burnStatus == "1" || burnStatus == "2")
            {
                return false;
            }

            //See if AI has burnable cards for single 2
            if (burnStatus == "1")
            {
                //Gets a string of number of doubles for each card type
                string AIDoublesStatus = CardInputDoublesCounter(storedAICardString);
                for (int i = 0; i < 12; i++)
                {
                    //Cycles through each digit of the string, converts to integer, sees if is 3, omits quadruples
                    if (Int32.Parse(AIDoublesStatus.Substring(i, 1)) == 3)
                    {
                        return false;
                    }
                }
            }
            //See if AI has burnable cards for double 2s or joker
            if (burnStatus == "2")
            {
                //Gets a string of number of doubles for each card type
                string AIDoublesStatus = CardInputDoublesCounter(storedAICardString);
                for (int i = 0; i < 12; i++)
                {
                    //Cycles through each digit of the string, converts to integer, sees if is 2 or lower
                    if (Int32.Parse(AIDoublesStatus.Substring(i, 1)) <= 2)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        //Doubles
        private string CardInputDoublesProcessing(string inputPlayerCardString)
        {
            //Temp placeholder
            int doublesStatus = 0;
            string cardDoubleStatus = CardInputDoublesCounter(inputPlayerCardString);

            if (CardInputChainLengthCounter(CardInputDoublesCounter(inputPlayerCardString)) == "0") doublesStatus = 0;
            return "";
        }

        private string CardInputDoublesCounter(string inputTargetCardString)
        {
            //Returns a string of the number of played cards for each type (E.G 101011111000) Twos and jokers omitted
            int doublesAmount = 0;
            string doublesAmountFinal = "";

            for (int i = 0; i < 12; i++)
            {
                string tempInputTargetCardString = inputTargetCardString.Substring((i + 1) * 4, 4);

                string tempInputTargetCardString1 = tempInputTargetCardString.Substring(0, 1);
                string tempInputTargetCardString2 = tempInputTargetCardString.Substring(1, 1);
                string tempInputTargetCardString3 = tempInputTargetCardString.Substring(2, 1);
                string tempInputTargetCardString4 = tempInputTargetCardString.Substring(3, 1);

                if (tempInputTargetCardString1 == "0") doublesAmount += 1;
                if (tempInputTargetCardString2 == "0") doublesAmount += 1;
                if (tempInputTargetCardString3 == "0") doublesAmount += 1;
                if (tempInputTargetCardString4 == "0") doublesAmount += 1;

                doublesAmountFinal += doublesAmount.ToString();
                doublesAmount = 0;
            }

            return doublesAmountFinal;
        }

        private bool CardInputValidDoublesPlacement(string storedAICardString)
        {
            //Checks if doubles usage is valid
            //Is same amount
            return false;
        }

        //Chains
        private bool CardChainInputProcessing()
        {
            return false;
        }

        private string CardInputChainLengthCounter(string doubleStatus)
        {
            int chainLength = 0;
            for (int i = 0; i < 12; i++)
            {
                //When it detects that a card has been played, [0]. It immediately looks at the next card + 2. to check for potential chain formations
                //If it doesn't, it notes that a chain arrangement is not possible and checks for any additional played cards.
                //If there IS additional played cards, it returns an invalid card arrangement, otherwise a valid one
                if (doubleStatus.Substring(i, 1) != "0" && chainLength == 0)
                {
                    for (int ii = 0; ii < 12; ii++)
                    {
                        try
                        {
                            //Looks at next character in string to see if it is a chain continuation w/ same number of cards
                            if (doubleStatus.Substring(i + ii + 1, 1) != doubleStatus.Substring(i, 1))
                            {
                                //Tests to see if next card in chain does not have the same amount of cards as previous chain cards
                                if (doubleStatus.Substring(i + ii + 1, 1) != "0" && doubleStatus.Substring(i + ii + 1, 1) != doubleStatus.Substring(i, 1))
                                {
                                    return "000";
                                } else
                                {
                                    chainLength = ii + 1;
                                    break;
                                }
                            }
                        }
                        catch
                        {
                            //If at end of string, return card length
                            chainLength = ii + 1;
                            break;
                        }
                    }
                }

                //Tests for cards out of chain order
                if (chainLength != 0 && doubleStatus.Substring(i, 1) != "0") return "000";
            }

            //Tests for chains shorter than 2 cards
            if (chainLength > 0 && chainLength > 2) return "000";
            return chainLength.ToString();
        }

        private bool CardInputValidChainPlacement(string storedAICardString)
        {
            //Checks if chain usage is valid
            //Same length
            //Same starting card OR higher
            return false;
        }
    }
}
