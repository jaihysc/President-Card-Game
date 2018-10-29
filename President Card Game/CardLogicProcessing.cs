using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace President_Card_Game
{
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
                                }
                                else
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
