using System;

namespace CardInformation
{
    public class CardInfo
    {
        public void PrintPlayerCards(string inputCardString)
        {
            int referencedCardPos;

            for (int i = 0; i < 54; i++)
            {
                referencedCardPos = i;
                string referencedCardValue = inputCardString.Substring(i, 1);

                //Card headings
                Console.ForegroundColor = ConsoleColor.Gray;
                if (referencedCardPos == 0) Console.WriteLine("###----#----------------------#----###");
                if (referencedCardPos == 0) Console.WriteLine("###----##-<<< Your Cards >>>-##----###");
                if (referencedCardPos == 0) Console.WriteLine("###----#----------------------#----###");
                if (referencedCardPos == 0) Console.WriteLine("");
                if (referencedCardPos == 0) Console.WriteLine("=-----=---< 2 >---=-----=");
                if (referencedCardPos == 4) Console.WriteLine("=-----=---< 3 >---=-----=");
                if (referencedCardPos == 8) Console.WriteLine("=-----=---< 4 >---=-----=");
                if (referencedCardPos == 12) Console.WriteLine("=-----=---< 5 >---=-----=");
                if (referencedCardPos == 16) Console.WriteLine("=-----=---< 6 >---=-----=");
                if (referencedCardPos == 20) Console.WriteLine("=-----=---< 7 >---=-----=");
                if (referencedCardPos == 24) Console.WriteLine("=-----=---< 8 >---=-----=");
                if (referencedCardPos == 28) Console.WriteLine("=-----=---< 9 >---=-----=");
                if (referencedCardPos == 32) Console.WriteLine("=-----=---< 10 >---=----=");
                if (referencedCardPos == 36) Console.WriteLine("=-----=---< JACK >---=--=");
                if (referencedCardPos == 40) Console.WriteLine("=-----=---< QUEEN >---=--=");
                if (referencedCardPos == 44) Console.WriteLine("=-----=---< KING >---=---=");
                if (referencedCardPos == 48) Console.WriteLine("=-----=---< ACE >---=----=");
                if (referencedCardPos == 52) Console.WriteLine("=-----=---< *JOKER* >-=--=");
                Console.ForegroundColor = ConsoleColor.Cyan;

                //Cards
                if (referencedCardValue == "0")
                {

                    //Prints player cards to screen
                    if (referencedCardPos == 0) Console.WriteLine("2 - Hearts");
                    if (referencedCardPos == 1) Console.WriteLine("2 - Spades");
                    if (referencedCardPos == 2) Console.WriteLine("2 - Clubs");
                    if (referencedCardPos == 3) Console.WriteLine("2 - Diamonds");

                    if (referencedCardPos == 4) Console.WriteLine("3 - Hearts");
                    if (referencedCardPos == 5) Console.WriteLine("3 - Spades");
                    if (referencedCardPos == 6) Console.WriteLine("3 - Clubs");
                    if (referencedCardPos == 7) Console.WriteLine("3 - Diamonds");

                    if (referencedCardPos == 8) Console.WriteLine("4 - Hearts");
                    if (referencedCardPos == 9) Console.WriteLine("4 - Spades");
                    if (referencedCardPos == 10) Console.WriteLine("4 - Clubs");
                    if (referencedCardPos == 11) Console.WriteLine("4 - Diamonds");

                    if (referencedCardPos == 12) Console.WriteLine("5 - Hearts");
                    if (referencedCardPos == 13) Console.WriteLine("5 - Spades");
                    if (referencedCardPos == 14) Console.WriteLine("5 - Clubs");
                    if (referencedCardPos == 15) Console.WriteLine("5 - Diamonds");

                    if (referencedCardPos == 16) Console.WriteLine("6 - Hearts");
                    if (referencedCardPos == 17) Console.WriteLine("6 - Spades");
                    if (referencedCardPos == 18) Console.WriteLine("6 - Clubs");
                    if (referencedCardPos == 19) Console.WriteLine("6 - Diamonds");

                    if (referencedCardPos == 20) Console.WriteLine("7 - Hearts");
                    if (referencedCardPos == 21) Console.WriteLine("7 - Spades");
                    if (referencedCardPos == 22) Console.WriteLine("7 - Clubs");
                    if (referencedCardPos == 23) Console.WriteLine("7 - Diamonds");

                    if (referencedCardPos == 24) Console.WriteLine("8 - Hearts");
                    if (referencedCardPos == 25) Console.WriteLine("8 - Spades");
                    if (referencedCardPos == 26) Console.WriteLine("8 - Clubs");
                    if (referencedCardPos == 27) Console.WriteLine("8 - Diamonds");

                    if (referencedCardPos == 28) Console.WriteLine("9 - Hearts");
                    if (referencedCardPos == 29) Console.WriteLine("9 - Spades");
                    if (referencedCardPos == 30) Console.WriteLine("9 - Clubs");
                    if (referencedCardPos == 31) Console.WriteLine("9 - Diamonds");

                    if (referencedCardPos == 32) Console.WriteLine("10 - Hearts");
                    if (referencedCardPos == 33) Console.WriteLine("10 - Spades");
                    if (referencedCardPos == 34) Console.WriteLine("10 - Clubs");
                    if (referencedCardPos == 35) Console.WriteLine("10 - Diamonds");

                    if (referencedCardPos == 36) Console.WriteLine("J - Hearts");
                    if (referencedCardPos == 37) Console.WriteLine("J - Spades");
                    if (referencedCardPos == 38) Console.WriteLine("J - Clubs");
                    if (referencedCardPos == 39) Console.WriteLine("J - Diamonds");

                    if (referencedCardPos == 40) Console.WriteLine("Q - Hearts");
                    if (referencedCardPos == 41) Console.WriteLine("Q - Spades");
                    if (referencedCardPos == 42) Console.WriteLine("Q - Clubs");
                    if (referencedCardPos == 43) Console.WriteLine("Q - Diamonds");

                    if (referencedCardPos == 44) Console.WriteLine("K - Hearts");
                    if (referencedCardPos == 45) Console.WriteLine("K - Spades");
                    if (referencedCardPos == 46) Console.WriteLine("K - Clubs");
                    if (referencedCardPos == 47) Console.WriteLine("K - Diamonds");

                    if (referencedCardPos == 48) Console.WriteLine("A - Hearts");
                    if (referencedCardPos == 49) Console.WriteLine("A - Spades");
                    if (referencedCardPos == 50) Console.WriteLine("A - Clubs");
                    if (referencedCardPos == 51) Console.WriteLine("A - Diamonds");

                    if (referencedCardPos == 52) Console.WriteLine("Small Joker");
                    if (referencedCardPos == 53) Console.WriteLine("Large Joker");
                }
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        public bool HasCard(string inputCardString, int cardType, int cardSuit, bool isPlayer)
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

        public string RemoveCard(string inputCardString, int cardType, int cardSuit, bool isPlayer)
        {
            int checkPos = cardType * 4 + cardSuit;

            string inputCardStringNew  = inputCardString.Substring(0, checkPos);
            string inputCardStringNew2 = inputCardString.Substring(checkPos + 1, 54 - checkPos - 1);

            return inputCardStringNew + "2" + inputCardStringNew2;
        }

        public string GetLastCard(string storedCardString, string newStoredCardString, bool isPlayer)
        {
            bool quit = false;
            int checkPos = 0;

            while (quit == false)
            {

                string tempStoredCardString = storedCardString.Substring(checkPos, 1);
                string tempNewStoredCardString = newStoredCardString.Substring(checkPos, 1);

                if (tempStoredCardString != tempNewStoredCardString)
                {
                    if (isPlayer == true && tempNewStoredCardString == "2")
                    {
                        return StringPosToCard(checkPos);
                    }
                    else if (isPlayer == false && tempNewStoredCardString == "3")
                    {
                        return StringPosToCard(checkPos);
                    }
                }

                if (checkPos == 53) quit = true;

                checkPos++;
            }

            return "N/A";
        }

        public string StringPosToCard(int inputCardPos)
        {
            string[] cardTypes = new string[14];

            cardTypes[0] = "Two";
            cardTypes[1] = "Three";
            cardTypes[2] = "Four";
            cardTypes[3] = "Five";
            cardTypes[4] = "Six";
            cardTypes[5] = "Seven";
            cardTypes[6] = "Eight";
            cardTypes[7] = "Nine";
            cardTypes[8] = "Ten";
            cardTypes[9] = "Jack";
            cardTypes[10] = "Queen";
            cardTypes[11] = "King";
            cardTypes[12] = "Ace";

            int cardType = 0;
            string cardSuit = "";

            if (inputCardPos == 52)
            {
                return "Small Joker";
            }
            if (inputCardPos == 53)
            {
                return "Large Joker";
            }

            if ((inputCardPos - 0) % 4 == 0)
            {
                cardSuit = "Hearts";
                cardType = (inputCardPos - 0) / 4;
            }
            if ((inputCardPos - 1) % 4 == 0)
            {
                cardSuit = "Spades";
                cardType = (inputCardPos - 1) / 4;
            }
            if ((inputCardPos - 2) % 4 == 0)
            {
                cardSuit = "Clubs";
                cardType = (inputCardPos - 2) / 4;
            }
            if ((inputCardPos - 3) % 4 == 0)
            {
                cardSuit = "Diamonds";
                cardType = (inputCardPos - 3) / 4;
            }

            return cardTypes[cardType] + " - " + cardSuit;
        }

        public bool PlayedCardTurnProcessing()
        {


            return false;
        }
    }
}
