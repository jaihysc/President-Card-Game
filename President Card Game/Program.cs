using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardInformation;

namespace President_Card_Game
{
    class Program
    {

        static void Main(string[] args)
        {
            CardInfo cardInfo = new CardInfo();
            CardProcessing cardProcessing = new CardProcessing();

            //Startup
            int turnNumber = 0;

            string playerLastCard = "N/A";
            string aiLastCard = "N/A";

            //Generates a one time random string representing dealt cards
            string storedCardMemory = cardProcessing.CardDealer();
            string newStoredCardMemory = "";

            bool currentTurnIsPlayer = cardProcessing.StartingTeamDecider(storedCardMemory);

            //Main
            while (true)
            {
                /*
                string[] cardType = new string[14];

                cardType[0] = "Two";
                cardType[1] = "Three";
                cardType[2] = "Four";
                cardType[3] = "Five";
                cardType[4] = "Six";
                cardType[5] = "Seven";
                cardType[6] = "Eight";
                cardType[7] = "Nine";
                cardType[8] = "Ten";
                cardType[9] = "Jack";
                cardType[10] = "Queen";
                cardType[11] = "King";
                cardType[12] = "Ace";
                cardType[13] = "Joker";

                string[] cardSuit = new string[5];

                cardSuit[0] = "Hearts";
                cardSuit[1] = "Spades";
                cardSuit[2] = "Clubs";
                cardSuit[3] = "Diamonds";
                cardSuit[4] = "";
                */

                currentTurnIsPlayer = true;

                //Turn Processing
                if (currentTurnIsPlayer == true)
                {
                    newStoredCardMemory = cardProcessing.PlayerCardInputHandler(storedCardMemory, turnNumber, playerLastCard, aiLastCard);
                } else
                {

                }

                playerLastCard = cardInfo.GetLastCard(storedCardMemory, newStoredCardMemory, true);
                aiLastCard = cardInfo.GetLastCard(storedCardMemory, newStoredCardMemory, false);

                //Prior to loop
                storedCardMemory = newStoredCardMemory;
                turnNumber++;
            }
        }
    }

    public class CardProcessing
    {
        //Startup
        public string CardDealer()
        {
            string playerStorage = "000000000000000000000000000000000000000000000000000000";
            string playerStorageNew = "000000000000000000000000000000000000000000000000000000";

            //Ghetto method for prevending duplicate cards. Card Order 3,4,5,6,7,8,9,10,j,q,k,a,2,joker
            //                                              Suit order heart, spade, club, diamond
            //                                              E.G 3h,3s,3c,3d,4h,4s,4c,4d etc

            for (int i = 0; i < 27; i++)
            {
                Random rand = new Random();

                while (playerStorageNew == playerStorage)
                {
                    int playerCardType = rand.Next(14);
                    int playerCardSuit = rand.Next(4);

                    int aiCardType = rand.Next(14);
                    int aiCardSuit = rand.Next(4);

                    if (playerCardType == 13) playerCardSuit = rand.Next(2);

                    int playerStorageAccessLocation = playerCardType * 4 + playerCardSuit;
                    playerStorageNew = playerStorage.Substring(0, playerStorageAccessLocation) + "1" + playerStorage.Substring(playerStorageAccessLocation + 1, 53 - playerStorageAccessLocation);

                }

                playerStorage = playerStorageNew;

                //Console.WriteLine(playerStorage);
                //Console.WriteLine("{0}, {1}, {2}, {3}", playerStorageAccessLocation, playerCardType, playerCardSuit, playerStorage);
            }

            return playerStorage;

        }

        public bool StartingTeamDecider(string inputCardString)
        {
            //Decides which player goes first, Player or AI
            CardInfo cardInfo = new CardInfo();

            if (cardInfo.HasCard(inputCardString, 1, 1, true) == true)
            {
                return true;
                //Player starts first
            } else
            {
                return false;
                //AI starts first
            }
        }

        //Player card input handler
        public string PlayerCardInputHandler(string storedCardMemory, int turnNumber, string playerLastCard, string aiLastCard)
        {
            bool playerCardInputHandlerFinishedProcessing = false;
            while (playerCardInputHandlerFinishedProcessing == false)
            {
                Console.Clear();

                CardInfo cardInfo = new CardInfo();

                //Print player cards + last turn
                PrintPlayerCardsToScreen(storedCardMemory);
                PrintLastPlayedCardsToScreen(playerLastCard, aiLastCard, turnNumber);

                //Processes card input
                string newStoredCardMemory = PlayerCardInput(storedCardMemory);
                storedCardMemory = newStoredCardMemory.Substring(0, 54);
                string playerHasCards = newStoredCardMemory.Substring(54, newStoredCardMemory.Length - 54);


                //Breaks while loop
                if (playerHasCards == "True") playerCardInputHandlerFinishedProcessing = true;
            }

            return storedCardMemory;
        }

        private string PlayerCardInput(string storedCardMemory)
        {
            CardInfo cardInfo = new CardInfo();
            string playerSelectedCardTypeInput = "";
            string playerSelectedCardSuitInput = "";

            string storedPlayerCardInput = "000000000000000000000000000000000000000000000000000000";


            bool quit = false;
            //Get player card choice input
            while (quit == false)
            {
                playerSelectedCardTypeInput = GetPlayerCardTypeInput();
                playerSelectedCardSuitInput = GetPlayerCardSuitInput(playerSelectedCardTypeInput);

                //14 is used to differentiate between large and small joker, 13 is large, 14 is small. 14 is used here so the method can return one value instead of two
                if (playerSelectedCardTypeInput == "14") playerSelectedCardTypeInput = "13";

                if (playerSelectedCardTypeInput == "111")
                {
                    quit = true;
                }
                else
                {
                    MultiPlayerCardHandler(storedPlayerCardInput, playerSelectedCardTypeInput, playerSelectedCardSuitInput);
                }

            }

            //Informs player of invalid card input if exist
            if (playerSelectedCardTypeInput == "000" || playerSelectedCardSuitInput == "000") InformPlayerOfInvalidCards(false);

            //Verify player has inputed cards
            bool playerHasCards = false;
            if (playerSelectedCardTypeInput != "000" && playerSelectedCardSuitInput != "000") playerHasCards = cardInfo.HasCard(storedCardMemory, Int32.Parse(playerSelectedCardTypeInput), Int32.Parse(playerSelectedCardSuitInput), true);

            //Removes card if player has inputed card
            if (playerHasCards == true) storedCardMemory = cardInfo.RemoveCard(storedCardMemory, Int32.Parse(playerSelectedCardTypeInput), Int32.Parse(playerSelectedCardSuitInput), true);
            if (playerHasCards == false) InformPlayerOfInvalidCards(true);

            return storedCardMemory + playerHasCards.ToString();

        }

        private string GetPlayerCardTypeInput()
        {
            string playerSelectedCardTypeInput = "0";

            Console.WriteLine("##---<<<----------<<< YOUR TURN >>> ---------->>>---##");

            Console.WriteLine("Input card type (E.G: 2, 4, Jack, Ace, Small Joker, done)");
            Console.WriteLine(">");

            //Gets card type
            string cardTypeInput = Console.ReadLine();

            switch (cardTypeInput)
            {
                //13 Standard cards, 2 jokers
                case "2":
                    playerSelectedCardTypeInput = "0";
                    break;
                case "3":
                    playerSelectedCardTypeInput = "1";
                    break;
                case "4":
                    playerSelectedCardTypeInput = "2";
                    break;
                case "5":
                    playerSelectedCardTypeInput = "3";
                    break;
                case "6":
                    playerSelectedCardTypeInput = "4";
                    break;
                case "7":
                    playerSelectedCardTypeInput = "5";
                    break;
                case "8":
                    playerSelectedCardTypeInput = "6";
                    break;
                case "9":
                    playerSelectedCardTypeInput = "7";
                    break;
                case "10":
                    playerSelectedCardTypeInput = "8";
                    break;
                case "jack":
                    playerSelectedCardTypeInput = "9";
                    break;
                case "queen":
                    playerSelectedCardTypeInput = "10";
                    break;
                case "king":
                    playerSelectedCardTypeInput = "11";
                    break;
                case "ace":
                    playerSelectedCardTypeInput = "12";
                    break;
                case "small joker":
                    playerSelectedCardTypeInput = "13";
                    break;
                case "large joker":
                    //14 will be set to 13 by the second method, it is used to differentiate between the two jokers
                    playerSelectedCardTypeInput = "14";
                    break;
                case "done":
                    playerSelectedCardTypeInput = "111";
                    break;
                default:
                    playerSelectedCardTypeInput = "000";
                    break;
            }

            return playerSelectedCardTypeInput;
        }

        private string GetPlayerCardSuitInput(string playerSelectedCardTypeInput)
        {
            string playerSelectedCardSuitInput = "0";

            //Get card suit if not the jokers
            if (playerSelectedCardTypeInput != "13" && playerSelectedCardTypeInput != "14" && playerSelectedCardTypeInput != "000" && playerSelectedCardTypeInput != "111")
            {
                Console.WriteLine("Input card suit (E.G: Hearts, Spades, Clubs, Diamonds)");
                Console.WriteLine(">");
                string cardSuitInput = Console.ReadLine();

                switch (cardSuitInput)
                {
                    case "hearts":
                        playerSelectedCardSuitInput = "0";
                        break;
                    case "spades":
                        playerSelectedCardSuitInput = "1";
                        break;
                    case "clubs":
                        playerSelectedCardSuitInput = "2";
                        break;
                    case "diamonds":
                        playerSelectedCardSuitInput = "3";
                        break;

                    default:
                        playerSelectedCardSuitInput = "000";
                        break;
                }

            }

            if (playerSelectedCardTypeInput == "14") playerSelectedCardSuitInput = "1";


            return playerSelectedCardSuitInput;
        }

        private string MultiPlayerCardHandler(string storedPlayerCardInput, string cardTypeInput, string cardSuitInput)
        {
            int cardType = Int32.Parse(cardTypeInput);
            int cardSuit = Int32.Parse(cardSuitInput);

            int checkPos = cardType * 4 + cardSuit;

            string inputCardStringNew = storedPlayerCardInput.Substring(0, checkPos);
            string inputCardStringNew2 = storedPlayerCardInput.Substring(checkPos + 1, 54 - checkPos - 1);

            storedPlayerCardInput = inputCardStringNew + "1" + inputCardStringNew2;

            return storedPlayerCardInput;
        }

        private void InformPlayerOfInvalidCards(bool validButNotExist)
        {
            if (validButNotExist == true)
            {
                Console.WriteLine();
                Console.WriteLine("******************************************");
                Console.WriteLine("You do not have the inputted card");
                Console.WriteLine("Please verify your selection and try again");
                Console.WriteLine();
                Console.WriteLine("******************************************");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("**********************************");
                Console.WriteLine("OI BLOODY MORON INPUT A VALID CARD");
                Console.WriteLine();
                Console.WriteLine("**********************************");
                Console.WriteLine();
            }

            Console.ReadLine();
        }

        private void PrintPlayerCardsToScreen(string storedCardMemory)
        {
            CardInfo cardInfo = new CardInfo();
            cardInfo.PrintPlayerCards(storedCardMemory);
        }

        private void PrintLastPlayedCardsToScreen(string playerLastCard, string aiLastCard, int turnNumber)
        {
            Console.WriteLine();

            //Turn Number
            Console.WriteLine();
            Console.WriteLine("     << TURN " + (turnNumber + 1) + " >>");

            //Write last played card
            Console.WriteLine();
            Console.Write("##---<<< ");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("YOUR CARD");
            Console.ForegroundColor = ConsoleColor.White;

            Console.Write(" | ");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(playerLastCard);
            Console.ForegroundColor = ConsoleColor.White;

            Console.Write(" >>> ---------- <<< ");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("OPPONENT CARD");
            Console.ForegroundColor = ConsoleColor.White;

            Console.Write(" | ");

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write(aiLastCard);
            Console.ForegroundColor = ConsoleColor.White;

            Console.Write(" >>>---##");
            Console.WriteLine();
            Console.WriteLine();
        }
        
    }

}
