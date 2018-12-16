using System;
using System.Collections.Generic;

namespace DotNet
{
    public class GameDisplay
    {
        public Deck _deck;
        public IEnumerable<Player> _players;

        public GameDisplay(Deck deck, IEnumerable<Player> players)
        {
            _deck = deck;
            _players = players;
        }

        public void Update()
        {
            Console.Clear();
            int index = 1;
            foreach (var card in _deck.Cards)
            {
                if (card._turnedUp) Console.Write("[X]");
                else Console.Write("[ ]");
                if (index % 13 == 0) Console.WriteLine();
                index++;
            }
            foreach (var player in _players)
            {
                Console.WriteLine($"{player.ToString()} has {player.NumberOfTricks} tricks");
            }
        }

        public void PromptUser()
        {
            Console.WriteLine("Press 'Enter' to pick a card");
            Console.ReadKey(true);
        }

        public void DisplayTrick(Player player)
        {
            Console.WriteLine($"{player.ToString()} matched the {player.currentCards[0].ToString()} with the {player.currentCards[1].ToString()}");
        }

        public void ShowChosenCard(Card card, Player player)
        {
            Console.WriteLine($"{player.ToString()} chose the {card.ToString()}");
        }

        public void DeclareWinner(Player winner)
        {
            Console.Clear();
            foreach (var player in _players)
            {
                Console.WriteLine($"{player.ToString()} has {player.NumberOfTricks} tricks");
            }
            Console.WriteLine($"{winner} has won the game!!!");
        }
    }
}