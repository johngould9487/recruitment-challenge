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
    }
}