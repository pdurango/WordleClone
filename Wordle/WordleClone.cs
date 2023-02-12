using System.Reflection;

namespace Wordle
{
    public class WordleClone
    {
        public enum Accuracy
        {
            Invalid,
            Close,
            Correct
        }

        public class Element
        {
            public char Letter { get; set; }
            public Accuracy Accuracy { get; set; }
        }

        public List<List<Element>> Elements { get; private set; }
        public List<string> Words { get; private set; }
        
        private readonly string _word;

        public WordleClone(string feed = "")
        {
            //Load file into memory
            var file = Path.Combine(Directory.GetCurrentDirectory(), "words.txt");
            Words = new List<string>(File.ReadAllLines(file));

            //Select random word
            if (!string.IsNullOrEmpty(feed))
                _word = feed;
            else
            {
                var random = new Random();
                int index = random.Next(Words.Count);
                _word = Words[index];
            }

            //Initialize Worldle object
            Elements = new List<List<Element>>();

            //todo - deelte me
            //Console.WriteLine($"Word is: {_word}");
        }

        public bool GuessWord(string guess) //return true if word is guessed successfully
        {
            guess = guess.ToLower();

            if (string.IsNullOrEmpty(guess) || guess.Length != 5 || !Words.Contains(guess))
                return false; //Word is not valid;
            else if (guess == _word)
                return true;

            var wordValidity = new List<Element>();
            char[] chars = _word.ToCharArray();

            for (int i = 0; i < 5; i++)
            {
                wordValidity.Add(new Element
                {
                    Letter = guess[i],
                    Accuracy = IsLetterValid(guess, i, chars)
                });
            }

            Elements.Add(wordValidity);
            return false; //Word is valid
        }

        private Accuracy IsLetterValid(string guess, int index, char[] chars)
        {
            char letter = guess[index];
            Accuracy accuracy = Accuracy.Invalid;

            if (letter == chars[index])
            {
                accuracy = Accuracy.Correct;
            }
            else if (chars.Contains(letter))
            {
                
                var actual = new string(chars);
                var indicesActual = AllIndexesOf(actual, letter);
                var indicesGuess = AllIndexesOf(guess, letter);

                var indicesCorrect = indicesActual.Intersect(indicesGuess);
                var guessable = indicesActual.Except(indicesCorrect).ToList();
                var guessed = indicesGuess.Where(x => x < index).Except(indicesCorrect).ToList();

                var unguessedClose = guessable.Count - guessed.Count;
                if (unguessedClose > 0)
                {
                    accuracy = Accuracy.Close;
                }
                
            }
            //else not valid

            return accuracy;
        }

        private static List<int> AllIndexesOf(string str, char searchChar)
        {
            var list = new List<int>();

            int minIndex = str.IndexOf(searchChar);
            while (minIndex != -1)
            {
                list.Add(minIndex);
                minIndex = str.IndexOf(searchChar, minIndex + 1);
            }

            return list;
        }
    }
}