using System;
using System.Threading.Tasks;
using System.Linq;
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
        public Player[] _players;
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

        public Player[] GetPlayers()
        {
            return _players;
        }

        public Game Assign(Player[] players)
        {
            _players = players;
            _gameDisplay = new GameDisplay(_deck, _players);
            return this;
        }

        public async Task Start()
        {
            _gameDisplay.Update();
            int count = 0;
            Card firstCard, secondCard;
            bool condition = true;
            while (condition)
            {
                for (int i = 0; i < _players.Length; i++)
                {
                    _gameDisplay.PromptUser();
                    firstCard = _players[i].ChooseDownFacingCard(_deck);
                    _gameDisplay.Update();
                    _gameDisplay.ShowChosenCard(firstCard, _players[i]);
                    _gameDisplay.PromptUser();
                    secondCard = _players[i].ChooseDownFacingCard(_deck);
                    _gameDisplay.Update();
                    _gameDisplay.ShowChosenCard(secondCard, _players[i]);
                    bool trickMade = _players[i].CheckForTricks();
                    if (trickMade)
                    {
                        _players[i].IncrementTricks();
                        _gameDisplay.DisplayTrick(_players[i]);
                    }
                    else
                    {
                        _players[i].TurnCurrentCardsOver();
                    }
                    _players[i].UseCurrentCards();
                    if (trickMade) i--;
                }
                count++;
                condition = count < 2 && _deck.downFacingCards.Any();
            }
            Player winner = await Winner();
            _gameDisplay.DeclareWinner(winner);
        }

        public Task<Player> Winner()
        {
            return Task.Run(() =>
            {
                Player winner = _players.OrderBy(player => player.NumberOfTricks).First();
                return winner;
            });
        }
    }
}
