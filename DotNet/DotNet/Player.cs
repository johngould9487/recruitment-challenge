using System;
using System.Collections.Generic;
using System.Linq;

namespace DotNet
{
    public class Player
    {
        private readonly string id;
        private readonly List<Card> currentCards;

        public Player(string id)
        {
            this.id = id;
            currentCards = new List<Card>();
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

        public void ChooseDownFacingCard(Deck deck)
        {
            Random rng = new Random();
            int randomIndex = rng.Next(deck.downFacingCards.Count());
            Receive(deck.downFacingCards.Skip(randomIndex).First());
            deck.downFacingCards.Skip(randomIndex).First().TurnOver();
            deck.RefreshDownFacingCards();
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
            Use(currentCards[0]);
            Use(currentCards[0]);
        }
    }
}
