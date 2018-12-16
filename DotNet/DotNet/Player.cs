using System;
using System.Collections.Generic;
using System.Linq;

namespace DotNet
{
    public class Player
    {
        private readonly string id;
        public readonly List<Card> currentCards;
        public int NumberOfTricks { get; private set; }

        public Player(string id)
        {
            this.id = id;
            currentCards = new List<Card>();
            NumberOfTricks = 0;
        }

        public Player Receive(Card card)
        {
            currentCards.Add(card);
            return this;
        }

        public Player Use(Card card)
        {
            bool removed = currentCards.Remove(card);
            if (!removed)
            {
                throw new ArgumentOutOfRangeException("Cannot use a card the player does not have");
            }
            return this;
        }

        public override string ToString()
        {
            return $"player-{id}";
        }

        public Card ChooseDownFacingCard(Deck deck)
        {
            Random rng = new Random();
            int randomIndex = rng.Next(deck.downFacingCards.Count());
            Card card = deck.downFacingCards.Skip(randomIndex).First();
            Receive(card);
            card.TurnOver();
            deck.RefreshDownFacingCards();
            return card;
        }

        public bool CheckForTricks()
        {
            return currentCards[0].Rank == currentCards[1].Rank;
        }

        public void TurnCurrentCardsOver()
        {
            currentCards[0].TurnOver();
            currentCards[1].TurnOver();
        }

        public void UseCurrentCards()
        {
            while (currentCards.Any())
            {
                Use(currentCards[0]);
            }
        }

        public void IncrementTricks()
        {
            NumberOfTricks += 1;
        }
    }
}
