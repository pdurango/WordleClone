using NUnit.Framework;
using Wordle;

namespace Wordle
{
    public class Tests
    {
        private WordleClone _worlde;

        [SetUp]
        public void Setup()
        {
            _worlde = new WordleClone();
        }

        [Test]
        public void InvalidWord()
        {
            Assert.IsFalse(_worlde.GuessWord("derp"));
        }
    }
}