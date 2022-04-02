using NUnit.Framework;
using Wordle;

namespace WordleTestProject
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            WordleClone wordle = new WordleClone("tower");

            wordle.GuessWord("flees");

        }
    }
}