using NUnit.Framework;
using DotNet;

namespace DotNet.Tests
{
    [TestFixture]
    class PairsGameTest
    {
        [Test]
        public void ShouldRemoveCardsFromPlayersPosession()
        {
            //arrange
            Player tom = new Player("Tom");
            Card card = new Card(Suit.DIAMNODS, Rank.KING, "deckId");
            tom.Receive(card);
            //act
            tom.Use(card);
            //assert
            Assert.That(tom.currentCards.Count == 0);
        }
    }
}
