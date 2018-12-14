using System;
using System.Threading.Tasks;
using System.Collections.Generic;


namespace DotNet
{
    /**
 * Implement Game to play pairs, such that all cards are spread out in a grid
 * and each player takes it in turn to turn over two cards. They make a trick if
 * the cards have the same rank, regardless of suit. If they make a trick, they
 * get to have another go. The winner is the player with the most tricks. No
 * jokers are required.
 */

    public class PairsGame : Game
    {
        public Deck _deck;
        public IEnumerable<Player> _players;
        public GameDisplay _gameDisplay;

        public PairsGame()
        {
            _deck = new Deck(0);
        }

        public Game Shuffle()
        {
            Random rng = new Random();
            for (int i = 0; i < _deck.Cards.Length; i++)
            {
                int randomIndex = rng.Next(_deck.Cards.Length);
                Card temporaryHold = _deck.Cards[i];
                _deck.Cards[i] = _deck.Cards[randomIndex];
                _deck.Cards[randomIndex] = temporaryHold;
            }
            return this;
        }

        public Game Assign(Player[] players)
        {
            _players = players;
            _gameDisplay = new GameDisplay(_deck, _players);
            return this;
        }


        public Game Deal()
        {
            return this;
        }


        public async Task Start()
        {
            throw new NotImplementedException();
        }

        public Task<Player> Winner()
        {
            throw new NotImplementedException();
        }
    }
}
