using NUnit.Framework;
using UglyTrivia;

namespace Tests
{
    public class Tests
    {
        private Game _game;

        [SetUp]
        public void Setup()
        {
            _game = new Game();
        }

        [Test]
        public void TestCreateTockQuestionHasConsistentReturnValue()
        {
            var index = 123;

            var result = _game.createRockQuestion(index);

            Assert.True( result.EndsWith( index.ToString() ));
        }

        [Test]
        public void TestIsPlayableFalseWhenNoPlayers()
        {
            var result = _game.isPlayable();

            Assert.False( result );
        }

        [Test]
        public void TestIsPlayableTrueWhenMultiplePlayers()
        {
            _game.add("player1"); // Relying on add method? Are we really testing just one thing?
            _game.add("player2");

            var result = _game.isPlayable();

            Assert.True( result );
        }

        [Test]
        public void TestAddAlwaysReturnsTrue()
        {
            var result = _game.add("player1"); // Relying on add method? Are we really testing just one thing?
           
            Assert.True( result );
        }

        [Test]
        public void TestHowManyPlayersHasConsistentReturnValue()
        {
            _game.add("player1"); // Relying on add method? Are we really testing just one thing?
            _game.add("player2");

            var result = _game.howManyPlayers();

            Assert.AreEqual(2,  result );
        }

    }
}