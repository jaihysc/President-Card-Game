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
            //Credits
                /*
                 * Description: A recreation of lunch-time President
                 * Author: Johnny Cai
                 * Last Edit: Oct 3, 2018
                 */
            //
            PlayerCards playerCards = new PlayerCards();
            AICards aiCards = new AICards();

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

            //Main game
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

                int referencedCardPos;
                int referencedCardTarget;

                for (int i = 0; i < 54; i++)
                {
                    referencedCardPos = i;
                    string referencedCardValue = storedCardMemory.Substring(i, 1);

                    if (referencedCardValue == "0")
                    {
                        referencedCardTarget = 0;
                    }
                    else
                    {
                        referencedCardTarget = 1;
                    }

                    //Code to assign true or falses to each team cards

                    if (referencedCardPos == 0) { if (referencedCardTarget == 0) { playerCards.TwoHearts = true; } else { aiCards.TwoHearts = true; } }
                    if (referencedCardPos == 1) { if (referencedCardTarget == 0) { playerCards.TwoSpades = true; } else { aiCards.TwoSpades = true; } }
                    if (referencedCardPos == 2) { if (referencedCardTarget == 0) { playerCards.TwoClubs = true; } else { aiCards.TwoClubs = true; } }
                    if (referencedCardPos == 3) { if (referencedCardTarget == 0) { playerCards.TwoDiamonds = true; } else { aiCards.TwoDiamonds = true; } }

                    if (referencedCardPos == 4) { if (referencedCardTarget == 0) { playerCards.ThreeHearts = true; } else { aiCards.ThreeHearts = true; } }
                    if (referencedCardPos == 5) { if (referencedCardTarget == 0) { playerCards.ThreeSpades = true; } else { aiCards.ThreeSpades = true; } }
                    if (referencedCardPos == 6) { if (referencedCardTarget == 0) { playerCards.ThreeClubs = true; } else { aiCards.ThreeClubs = true; } }
                    if (referencedCardPos == 7) { if (referencedCardTarget == 0) { playerCards.ThreeDiamonds = true; } else { aiCards.ThreeDiamonds = true; } }

                    if (referencedCardPos == 8) { if (referencedCardTarget == 0) { playerCards.FourHearts = true; } else { aiCards.FourHearts = true; } }
                    if (referencedCardPos == 9) { if (referencedCardTarget == 0) { playerCards.FourSpades = true; } else { aiCards.FourSpades = true; } }
                    if (referencedCardPos == 10) { if (referencedCardTarget == 0) { playerCards.FourClubs = true; } else { aiCards.FourClubs = true; } }
                    if (referencedCardPos == 11) { if (referencedCardTarget == 0) { playerCards.FourDiamonds = true; } else { aiCards.FourDiamonds = true; } }

                    if (referencedCardPos == 12) { if (referencedCardTarget == 0) { playerCards.FiveHearts = true; } else { aiCards.FiveHearts = true; } }
                    if (referencedCardPos == 13) { if (referencedCardTarget == 0) { playerCards.FiveSpades = true; } else { aiCards.FiveSpades = true; } }
                    if (referencedCardPos == 14) { if (referencedCardTarget == 0) { playerCards.FiveClubs = true; } else { aiCards.FiveClubs = true; } }
                    if (referencedCardPos == 15) { if (referencedCardTarget == 0) { playerCards.FiveDiamonds = true; } else { aiCards.FiveDiamonds = true; } }

                    if (referencedCardPos == 16) { if (referencedCardTarget == 0) { playerCards.SixHearts = true; } else { aiCards.SixHearts = true; } }
                    if (referencedCardPos == 17) { if (referencedCardTarget == 0) { playerCards.SixSpades = true; } else { aiCards.SixSpades = true; } }
                    if (referencedCardPos == 18) { if (referencedCardTarget == 0) { playerCards.SixClubs = true; } else { aiCards.SixClubs = true; } }
                    if (referencedCardPos == 19) { if (referencedCardTarget == 0) { playerCards.SixDiamonds = true; } else { aiCards.SixDiamonds = true; } }

                    if (referencedCardPos == 20) { if (referencedCardTarget == 0) { playerCards.SevenHearts = true; } else { aiCards.SevenHearts = true; } }
                    if (referencedCardPos == 21) { if (referencedCardTarget == 0) { playerCards.SevenSpades = true; } else { aiCards.SevenSpades = true; } }
                    if (referencedCardPos == 22) { if (referencedCardTarget == 0) { playerCards.SevenClubs = true; } else { aiCards.SevenClubs = true; } }
                    if (referencedCardPos == 23) { if (referencedCardTarget == 0) { playerCards.SevenDiamonds = true; } else { aiCards.SevenDiamonds = true; } }

                    if (referencedCardPos == 24) { if (referencedCardTarget == 0) { playerCards.EightHearts = true; } else { aiCards.EightHearts = true; } }
                    if (referencedCardPos == 25) { if (referencedCardTarget == 0) { playerCards.EightSpades = true; } else { aiCards.EightSpades = true; } }
                    if (referencedCardPos == 26) { if (referencedCardTarget == 0) { playerCards.EightClubs = true; } else { aiCards.EightClubs = true; } }
                    if (referencedCardPos == 27) { if (referencedCardTarget == 0) { playerCards.EightDiamonds = true; } else { aiCards.EightDiamonds = true; } }

                    if (referencedCardPos == 28) { if (referencedCardTarget == 0) { playerCards.NineHearts = true; } else { aiCards.NineHearts = true; } }
                    if (referencedCardPos == 29) { if (referencedCardTarget == 0) { playerCards.NineSpades = true; } else { aiCards.NineSpades = true; } }
                    if (referencedCardPos == 30) { if (referencedCardTarget == 0) { playerCards.NineClubs = true; } else { aiCards.NineClubs = true; } }
                    if (referencedCardPos == 31) { if (referencedCardTarget == 0) { playerCards.NineDiamonds = true; } else { aiCards.NineDiamonds = true; } }

                    if (referencedCardPos == 32) { if (referencedCardTarget == 0) { playerCards.TenHearts = true; } else { aiCards.TenHearts = true; } }
                    if (referencedCardPos == 33) { if (referencedCardTarget == 0) { playerCards.TenSpades = true; } else { aiCards.TenSpades = true; } }
                    if (referencedCardPos == 34) { if (referencedCardTarget == 0) { playerCards.TenClubs = true; } else { aiCards.TenClubs = true; } }
                    if (referencedCardPos == 35) { if (referencedCardTarget == 0) { playerCards.TenDiamonds = true; } else { aiCards.TenDiamonds = true; } }

                    if (referencedCardPos == 36) { if (referencedCardTarget == 0) { playerCards.JackHearts = true; } else { aiCards.JackHearts = true; } }
                    if (referencedCardPos == 37) { if (referencedCardTarget == 0) { playerCards.JackSpades = true; } else { aiCards.JackSpades = true; } }
                    if (referencedCardPos == 38) { if (referencedCardTarget == 0) { playerCards.JackClubs = true; } else { aiCards.JackClubs = true; } }
                    if (referencedCardPos == 39) { if (referencedCardTarget == 0) { playerCards.JackDiamonds = true; } else { aiCards.JackDiamonds = true; } }

                    if (referencedCardPos == 40) { if (referencedCardTarget == 0) { playerCards.QueenHearts = true; } else { aiCards.QueenHearts = true; } }
                    if (referencedCardPos == 41) { if (referencedCardTarget == 0) { playerCards.QueenSpades = true; } else { aiCards.QueenSpades = true; } }
                    if (referencedCardPos == 42) { if (referencedCardTarget == 0) { playerCards.QueenClubs = true; } else { aiCards.QueenClubs = true; } }
                    if (referencedCardPos == 43) { if (referencedCardTarget == 0) { playerCards.QueenDiamonds = true; } else { aiCards.QueenDiamonds = true; } }

                    if (referencedCardPos == 44) { if (referencedCardTarget == 0) { playerCards.KingHearts = true; } else { aiCards.KingHearts = true; } }
                    if (referencedCardPos == 45) { if (referencedCardTarget == 0) { playerCards.KingSpades = true; } else { aiCards.KingSpades = true; } }
                    if (referencedCardPos == 46) { if (referencedCardTarget == 0) { playerCards.KingClubs = true; } else { aiCards.KingClubs = true; } }
                    if (referencedCardPos == 47) { if (referencedCardTarget == 0) { playerCards.KingDiamonds = true; } else { aiCards.KingDiamonds = true; } }

                    if (referencedCardPos == 48) { if (referencedCardTarget == 0) { playerCards.AceHearts = true; } else { aiCards.AceHearts = true; } }
                    if (referencedCardPos == 49) { if (referencedCardTarget == 0) { playerCards.AceSpades = true; } else { aiCards.AceSpades = true; } }
                    if (referencedCardPos == 50) { if (referencedCardTarget == 0) { playerCards.AceClubs = true; } else { aiCards.AceClubs = true; } }
                    if (referencedCardPos == 51) { if (referencedCardTarget == 0) { playerCards.AceDiamonds = true; } else { aiCards.AceDiamonds = true; } }

                    if (referencedCardPos == 52) { if (referencedCardTarget == 0) { playerCards.JokerOne = true; } else { aiCards.JokerOne = true; } }
                    if (referencedCardPos == 53) { if (referencedCardTarget == 0) { playerCards.JokerTwo = true; } else { aiCards.JokerTwo = true; } }
                }

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

                //Print player cards
                PrintPlayerCardsToScreen(storedCardMemory);

                //Write last played card + turn
                PrintLastPlayedCardsToScreen(playerLastCard, aiLastCard, turnNumber);

                Console.WriteLine("##---<<<----------<<< YOUR TURN >>> ---------->>>---##");

                //Get player card choice input
                string playerSelectedCardTypeInput = GetPlayerCardTypeInput();
                string playerSelectedCardSuitInput = GetPlayerCardSuitInput(playerSelectedCardTypeInput);

                //14 is used to differentiate between large and small joker, 13 is large, 14 is small. 14 is used here so the method can return one value instead of two
                if (playerSelectedCardTypeInput == "14") playerSelectedCardTypeInput = "13";

                //Informs player of invalid card input if exist
                if (playerSelectedCardTypeInput == "000" || playerSelectedCardSuitInput == "000") InformPlayerOfInvalidCards();

                //Verify player has inputed cards
                bool playerHasCards = false;
                if (playerSelectedCardTypeInput != "000" && playerSelectedCardSuitInput != "000")
                {
                    playerHasCards = cardInfo.HasCard(storedCardMemory, Int32.Parse(playerSelectedCardTypeInput), Int32.Parse(playerSelectedCardSuitInput), true);
                }
                //Removes card if player has inputed card
                if (playerHasCards == true)
                {
                    storedCardMemory = cardInfo.RemoveCard(storedCardMemory, Int32.Parse(playerSelectedCardTypeInput), Int32.Parse(playerSelectedCardSuitInput), true);
                }


                //Debug remove later
                //Console.WriteLine("{0} {1} - {2}", playerSelectedCardTypeInput, playerSelectedCardSuitInput, playerHasCards);
                //Console.ReadLine();


                //Breaks while loop
                if (playerHasCards == true) playerCardInputHandlerFinishedProcessing = true;
            }

            return storedCardMemory;
        }

        private string GetPlayerCardTypeInput()
        {
            string playerSelectedCardTypeInput = "0";

            Console.WriteLine("Input card type (E.G: 2, 4, Jack, Ace, Small Joker)");
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
            if (playerSelectedCardTypeInput != "13" && playerSelectedCardTypeInput != "14" && playerSelectedCardTypeInput != "000")
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

        private void InformPlayerOfInvalidCards()
        {
            Console.WriteLine();
            Console.WriteLine("**********************************");
            Console.WriteLine("OI BLOODY MORON INPUT A VALID CARD");
            Console.WriteLine();
            Console.WriteLine("**********************************");
            Console.WriteLine();

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


        //MISC
        private static void CardTeamOrganizer(string inputCardString)
        {
            PlayerCards playerCards = new PlayerCards();
            AICards aiCards = new AICards();
            int referencedCardPos;
            int referencedCardTarget;

            for (int i = 0; i < 54; i++)
            {
                referencedCardPos = i;
                string referencedCardValue = inputCardString.Substring(i, 1);

                if (referencedCardValue == "0")
                {
                    referencedCardTarget = 0;
                } else
                {
                    referencedCardTarget = 1;
                }

                //Code to assign true or falses to each team cards

                if (referencedCardPos == 0) { if (referencedCardTarget == 0) { playerCards.TwoHearts = true; } else { aiCards.TwoHearts = true; } }
                if (referencedCardPos == 1) { if (referencedCardTarget == 0) { playerCards.TwoSpades = true; } else { aiCards.TwoSpades = true; } }
                if (referencedCardPos == 2) { if (referencedCardTarget == 0) { playerCards.TwoClubs = true; } else { aiCards.TwoClubs = true; } }
                if (referencedCardPos == 3) { if (referencedCardTarget == 0) { playerCards.TwoDiamonds = true; } else { aiCards.TwoDiamonds = true; } }

                if (referencedCardPos == 4) { if (referencedCardTarget == 0) { playerCards.ThreeHearts = true; } else { aiCards.ThreeHearts = true; } }
                if (referencedCardPos == 5) { if (referencedCardTarget == 0) { playerCards.ThreeSpades = true; } else { aiCards.ThreeSpades = true; } }
                if (referencedCardPos == 6) { if (referencedCardTarget == 0) { playerCards.ThreeClubs = true; } else { aiCards.ThreeClubs = true; } }
                if (referencedCardPos == 7) { if (referencedCardTarget == 0) { playerCards.ThreeDiamonds = true; } else { aiCards.ThreeDiamonds = true; } }

                if (referencedCardPos == 8) { if (referencedCardTarget == 0) { playerCards.FourHearts = true; } else { aiCards.FourHearts = true; } }
                if (referencedCardPos == 9) { if (referencedCardTarget == 0) { playerCards.FourSpades = true; } else { aiCards.FourSpades = true; } }
                if (referencedCardPos == 10) { if (referencedCardTarget == 0) { playerCards.FourClubs = true; } else { aiCards.FourClubs = true; } }
                if (referencedCardPos == 11) { if (referencedCardTarget == 0) { playerCards.FourDiamonds = true; } else { aiCards.FourDiamonds = true; } }

                if (referencedCardPos == 12) { if (referencedCardTarget == 0) { playerCards.FiveHearts = true; } else { aiCards.FiveHearts = true; } }
                if (referencedCardPos == 13) { if (referencedCardTarget == 0) { playerCards.FiveSpades = true; } else { aiCards.FiveSpades = true; } }
                if (referencedCardPos == 14) { if (referencedCardTarget == 0) { playerCards.FiveClubs = true; } else { aiCards.FiveClubs = true; } }
                if (referencedCardPos == 15) { if (referencedCardTarget == 0) { playerCards.FiveDiamonds = true; } else { aiCards.FiveDiamonds = true; } }

                if (referencedCardPos == 16) { if (referencedCardTarget == 0) { playerCards.SixHearts = true; } else { aiCards.SixHearts = true; } }
                if (referencedCardPos == 17) { if (referencedCardTarget == 0) { playerCards.SixSpades = true; } else { aiCards.SixSpades = true; } }
                if (referencedCardPos == 18) { if (referencedCardTarget == 0) { playerCards.SixClubs = true; } else { aiCards.SixClubs = true; } }
                if (referencedCardPos == 19) { if (referencedCardTarget == 0) { playerCards.SixDiamonds = true; } else { aiCards.SixDiamonds = true; } }

                if (referencedCardPos == 20) { if (referencedCardTarget == 0) { playerCards.SevenHearts = true; } else { aiCards.SevenHearts = true; } }
                if (referencedCardPos == 21) { if (referencedCardTarget == 0) { playerCards.SevenSpades = true; } else { aiCards.SevenSpades = true; } }
                if (referencedCardPos == 22) { if (referencedCardTarget == 0) { playerCards.SevenClubs = true; } else { aiCards.SevenClubs = true; } }
                if (referencedCardPos == 23) { if (referencedCardTarget == 0) { playerCards.SevenDiamonds = true; } else { aiCards.SevenDiamonds = true; } }

                if (referencedCardPos == 24) { if (referencedCardTarget == 0) { playerCards.EightHearts = true; } else { aiCards.EightHearts = true; } }
                if (referencedCardPos == 25) { if (referencedCardTarget == 0) { playerCards.EightSpades = true; } else { aiCards.EightSpades = true; } }
                if (referencedCardPos == 26) { if (referencedCardTarget == 0) { playerCards.EightClubs = true; } else { aiCards.EightClubs = true; } }
                if (referencedCardPos == 27) { if (referencedCardTarget == 0) { playerCards.EightDiamonds = true; } else { aiCards.EightDiamonds = true; } }

                if (referencedCardPos == 28) { if (referencedCardTarget == 0) { playerCards.NineHearts = true; } else { aiCards.NineHearts = true; } }
                if (referencedCardPos == 29) { if (referencedCardTarget == 0) { playerCards.NineSpades = true; } else { aiCards.NineSpades = true; } }
                if (referencedCardPos == 30) { if (referencedCardTarget == 0) { playerCards.NineClubs = true; } else { aiCards.NineClubs = true; } }
                if (referencedCardPos == 31) { if (referencedCardTarget == 0) { playerCards.NineDiamonds = true; } else { aiCards.NineDiamonds = true; } }

                if (referencedCardPos == 32) { if (referencedCardTarget == 0) { playerCards.TenHearts = true; } else { aiCards.TenHearts = true; } }
                if (referencedCardPos == 33) { if (referencedCardTarget == 0) { playerCards.TenSpades = true; } else { aiCards.TenSpades = true; } }
                if (referencedCardPos == 34) { if (referencedCardTarget == 0) { playerCards.TenClubs = true; } else { aiCards.TenClubs = true; } }
                if (referencedCardPos == 35) { if (referencedCardTarget == 0) { playerCards.TenDiamonds = true; } else { aiCards.TenDiamonds = true; } }

                if (referencedCardPos == 36) { if (referencedCardTarget == 0) { playerCards.JackHearts = true; } else { aiCards.JackHearts = true; } }
                if (referencedCardPos == 37) { if (referencedCardTarget == 0) { playerCards.JackSpades = true; } else { aiCards.JackSpades = true; } }
                if (referencedCardPos == 38) { if (referencedCardTarget == 0) { playerCards.JackClubs = true; } else { aiCards.JackClubs = true; } }
                if (referencedCardPos == 39) { if (referencedCardTarget == 0) { playerCards.JackDiamonds = true; } else { aiCards.JackDiamonds = true; } }

                if (referencedCardPos == 40) { if (referencedCardTarget == 0) { playerCards.QueenHearts = true; } else { aiCards.QueenHearts = true; } }
                if (referencedCardPos == 41) { if (referencedCardTarget == 0) { playerCards.QueenSpades = true; } else { aiCards.QueenSpades = true; } }
                if (referencedCardPos == 42) { if (referencedCardTarget == 0) { playerCards.QueenClubs = true; } else { aiCards.QueenClubs = true; } }
                if (referencedCardPos == 43) { if (referencedCardTarget == 0) { playerCards.QueenDiamonds = true; } else { aiCards.QueenDiamonds = true; } }

                if (referencedCardPos == 44) { if (referencedCardTarget == 0) { playerCards.KingHearts = true; } else { aiCards.KingHearts = true; } }
                if (referencedCardPos == 45) { if (referencedCardTarget == 0) { playerCards.KingSpades = true; } else { aiCards.KingSpades = true; } }
                if (referencedCardPos == 46) { if (referencedCardTarget == 0) { playerCards.KingClubs = true; } else { aiCards.KingClubs = true; } }
                if (referencedCardPos == 47) { if (referencedCardTarget == 0) { playerCards.KingDiamonds = true; } else { aiCards.KingDiamonds = true; } }

                if (referencedCardPos == 48) { if (referencedCardTarget == 0) { playerCards.AceHearts = true; } else { aiCards.AceHearts = true; } }
                if (referencedCardPos == 49) { if (referencedCardTarget == 0) { playerCards.AceSpades = true; } else { aiCards.AceSpades = true; } }
                if (referencedCardPos == 50) { if (referencedCardTarget == 0) { playerCards.AceClubs = true; } else { aiCards.AceClubs = true; } }
                if (referencedCardPos == 51) { if (referencedCardTarget == 0) { playerCards.AceDiamonds = true; } else { aiCards.AceDiamonds = true; } }

                if (referencedCardPos == 52) { if (referencedCardTarget == 0) { playerCards.JokerOne = true; } else { aiCards.JokerOne = true; } }
                if (referencedCardPos == 53) { if (referencedCardTarget == 0) { playerCards.JokerTwo = true; } else { aiCards.JokerTwo = true; } }
            }
        }
        //Card organizer is depreciated until I am smart enough to figure out how to return a class value to the main scope
    }



    public class PlayerCards
    {
        public bool TwoHearts { get; set; }
        public bool TwoSpades { get; set; }
        public bool TwoClubs { get; set; }
        public bool TwoDiamonds { get; set; }

        public bool ThreeHearts { get; set; }
        public bool ThreeSpades { get; set; }
        public bool ThreeClubs { get; set; }
        public bool ThreeDiamonds { get; set; }

        public bool FourHearts { get; set; }
        public bool FourSpades { get; set; }
        public bool FourClubs { get; set; }
        public bool FourDiamonds { get; set; }

        public bool FiveHearts { get; set; }
        public bool FiveSpades { get; set; }
        public bool FiveClubs { get; set; }
        public bool FiveDiamonds { get; set; }

        public bool SixHearts { get; set; }
        public bool SixSpades { get; set; }
        public bool SixClubs { get; set; }
        public bool SixDiamonds { get; set; }

        public bool SevenHearts { get; set; }
        public bool SevenSpades { get; set; }
        public bool SevenClubs { get; set; }
        public bool SevenDiamonds { get; set; }

        public bool EightHearts { get; set; }
        public bool EightSpades { get; set; }
        public bool EightClubs { get; set; }
        public bool EightDiamonds { get; set; }

        public bool NineHearts { get; set; }
        public bool NineSpades { get; set; }
        public bool NineClubs { get; set; }
        public bool NineDiamonds { get; set; }

        public bool TenHearts { get; set; }
        public bool TenSpades { get; set; }
        public bool TenClubs { get; set; }
        public bool TenDiamonds { get; set; }

        public bool JackHearts { get; set; }
        public bool JackSpades { get; set; }
        public bool JackClubs { get; set; }
        public bool JackDiamonds { get; set; }

        public bool QueenHearts { get; set; }
        public bool QueenSpades { get; set; }
        public bool QueenClubs { get; set; }
        public bool QueenDiamonds { get; set; }

        public bool KingHearts { get; set; }
        public bool KingSpades { get; set; }
        public bool KingClubs { get; set; }
        public bool KingDiamonds { get; set; }

        public bool AceHearts { get; set; }
        public bool AceSpades { get; set; }
        public bool AceClubs { get; set; }
        public bool AceDiamonds { get; set; }

        public bool JokerOne { get; set; }
        public bool JokerTwo { get; set; }

        public PlayerCards()
        {
            this.TwoHearts = false;
            this.TwoSpades = false;
            this.TwoClubs = false;
            this.TwoDiamonds = false;

            this.ThreeHearts = false;
            this.ThreeSpades = false;
            this.ThreeClubs = false;
            this.ThreeDiamonds = false;

            this.FourHearts = false;
            this.FourSpades = false;
            this.FourClubs = false;
            this.FourDiamonds = false;

            this.FiveHearts = false;
            this.FiveSpades = false;
            this.FiveClubs = false;
            this.FiveDiamonds = false;

            this.SixHearts = false;
            this.SixSpades = false;
            this.SixClubs = false;
            this.SixDiamonds = false;

            this.SevenHearts = false;
            this.SevenSpades = false;
            this.SevenClubs = false;
            this.SevenDiamonds = false;

            this.EightHearts = false;
            this.EightSpades = false;
            this.EightClubs = false;
            this.EightDiamonds = false;

            this.NineHearts = false;
            this.NineSpades = false;
            this.NineClubs = false;
            this.NineDiamonds = false;

            this.TenHearts = false;
            this.TenSpades = false;
            this.TenClubs = false;
            this.TenDiamonds = false;

            this.JackHearts = false;
            this.JackSpades = false;
            this.JackClubs = false;
            this.JackDiamonds = false;

            this.QueenHearts = false;
            this.QueenSpades = false;
            this.QueenClubs = false;
            this.QueenDiamonds = false;

            this.KingHearts = false;
            this.KingSpades = false;
            this.KingClubs = false;
            this.KingDiamonds = false;

            this.AceHearts = false;
            this.AceSpades = false;
            this.AceClubs = false;
            this.AceDiamonds = false;

            this.JokerOne = false;
            this.JokerTwo = false;
        }

    }

    public class AICards
    {
        public bool TwoHearts { get; set; }
        public bool TwoSpades { get; set; }
        public bool TwoClubs { get; set; }
        public bool TwoDiamonds { get; set; }

        public bool ThreeHearts { get; set; }
        public bool ThreeSpades { get; set; }
        public bool ThreeClubs { get; set; }
        public bool ThreeDiamonds { get; set; }

        public bool FourHearts { get; set; }
        public bool FourSpades { get; set; }
        public bool FourClubs { get; set; }
        public bool FourDiamonds { get; set; }

        public bool FiveHearts { get; set; }
        public bool FiveSpades { get; set; }
        public bool FiveClubs { get; set; }
        public bool FiveDiamonds { get; set; }

        public bool SixHearts { get; set; }
        public bool SixSpades { get; set; }
        public bool SixClubs { get; set; }
        public bool SixDiamonds { get; set; }

        public bool SevenHearts { get; set; }
        public bool SevenSpades { get; set; }
        public bool SevenClubs { get; set; }
        public bool SevenDiamonds { get; set; }

        public bool EightHearts { get; set; }
        public bool EightSpades { get; set; }
        public bool EightClubs { get; set; }
        public bool EightDiamonds { get; set; }

        public bool NineHearts { get; set; }
        public bool NineSpades { get; set; }
        public bool NineClubs { get; set; }
        public bool NineDiamonds { get; set; }

        public bool TenHearts { get; set; }
        public bool TenSpades { get; set; }
        public bool TenClubs { get; set; }
        public bool TenDiamonds { get; set; }

        public bool JackHearts { get; set; }
        public bool JackSpades { get; set; }
        public bool JackClubs { get; set; }
        public bool JackDiamonds { get; set; }

        public bool QueenHearts { get; set; }
        public bool QueenSpades { get; set; }
        public bool QueenClubs { get; set; }
        public bool QueenDiamonds { get; set; }

        public bool KingHearts { get; set; }
        public bool KingSpades { get; set; }
        public bool KingClubs { get; set; }
        public bool KingDiamonds { get; set; }

        public bool AceHearts { get; set; }
        public bool AceSpades { get; set; }
        public bool AceClubs { get; set; }
        public bool AceDiamonds { get; set; }

        public bool JokerOne { get; set; }
        public bool JokerTwo { get; set; }

        public AICards()
        {
            this.TwoHearts = false;
            this.TwoSpades = false;
            this.TwoClubs = false;
            this.TwoDiamonds = false;

            this.ThreeHearts = false;
            this.ThreeSpades = false;
            this.ThreeClubs = false;
            this.ThreeDiamonds = false;

            this.FourHearts = false;
            this.FourSpades = false;
            this.FourClubs = false;
            this.FourDiamonds = false;

            this.FiveHearts = false;
            this.FiveSpades = false;
            this.FiveClubs = false;
            this.FiveDiamonds = false;

            this.SixHearts = false;
            this.SixSpades = false;
            this.SixClubs = false;
            this.SixDiamonds = false;

            this.SevenHearts = false;
            this.SevenSpades = false;
            this.SevenClubs = false;
            this.SevenDiamonds = false;

            this.EightHearts = false;
            this.EightSpades = false;
            this.EightClubs = false;
            this.EightDiamonds = false;

            this.NineHearts = false;
            this.NineSpades = false;
            this.NineClubs = false;
            this.NineDiamonds = false;

            this.TenHearts = false;
            this.TenSpades = false;
            this.TenClubs = false;
            this.TenDiamonds = false;

            this.JackHearts = false;
            this.JackSpades = false;
            this.JackClubs = false;
            this.JackDiamonds = false;

            this.QueenHearts = false;
            this.QueenSpades = false;
            this.QueenClubs = false;
            this.QueenDiamonds = false;

            this.KingHearts = false;
            this.KingSpades = false;
            this.KingClubs = false;
            this.KingDiamonds = false;

            this.AceHearts = false;
            this.AceSpades = false;
            this.AceClubs = false;
            this.AceDiamonds = false;

            this.JokerOne = false;
            this.JokerTwo = false;
        }

    }

}
