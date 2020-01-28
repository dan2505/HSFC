using System;
using System.Text;
using System.Linq;

namespace Hangman
{
    class Hangman
    {
        private String word;
        private StringBuilder display;

        private char[] lettersUsed = new char[20];

        private bool status = true;
        private int guesses = 6;

        public Hangman()
        {
            restartGame();
        }

        public String getCurrentWord()
        {
            return word;
        }

        public String getReveal()
        {
            return display.ToString();
        }

        public char[] getLetters()
        {
            return lettersUsed;
        }

        public bool getStatus()
        {
            return status;
        }

        public int getGuesses()
        {
            return guesses;
        }

        public void restartGame()
        {
            guesses = 6;
            word = "hello";

            display = new StringBuilder(word);
            for (int i = 0; i < word.Length; i++)
            {
                display[i] = '_';
            }
        }

        public void makeGuess(char theLetter)
        {
            if (!getLetters().Contains(theLetter)) {
                if (word.Contains(theLetter))
                {
                    lettersUsed.Append(theLetter);
                    for (int i = 0; i < word.Length; i++)
                    {
                        if (word[i] == theLetter)
                        {
                            display[i] = theLetter;
                        }
                    }
                }
                guesses--;
            }
        }
    }
}