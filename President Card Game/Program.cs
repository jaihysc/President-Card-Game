using System;

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

            string storedAICardInput = "222222222222222222222222222222222222222222222222222222";

            bool currentTurnIsPlayer = cardProcessing.StartingTeamDecider(storedCardMemory);

            //Main
            while (true)
            {
                /*
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
                    newStoredCardMemory = cardProcessing.PlayerCardInputHandler(storedCardMemory, storedAICardInput, turnNumber, playerLastCard, aiLastCard);
                } else
                {
                    //Ai code
                }

                playerLastCard = cardInfo.GetLastCard(storedCardMemory, newStoredCardMemory, true);
                aiLastCard = cardInfo.GetLastCard(storedCardMemory, newStoredCardMemory, false);

                //Prior to loop
                storedCardMemory = newStoredCardMemory;
                turnNumber++;
            }
        }
    }
}
