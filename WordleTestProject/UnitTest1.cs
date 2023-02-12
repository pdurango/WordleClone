using NUnit.Framework;
using Wordle;

namespace WordleTestProject
{
    public class Tests
    {
        /*[SetUp]
        public void Setup()
        {
        }*/

        [TestCase("abbey", "abbey")]
        [TestCase("tower", "tower")]
        public void WordleGuess_Success(string word, string guess)
        {
            var wordle = new WordleClone(word);

            Assert.IsTrue(wordle.GuessWord(guess));

        }

        [Test]
        public void WordleGuess_Fail()
        {

        }
    }
}