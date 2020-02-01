using System;
using System.IO;
using System.Text;
using System.Linq;

namespace Hangman
{
    class Hangman
    {
        private bool _status = true;
        
        private string _word;
        private StringBuilder _display;
        private string _lettersUsed = "";
        
        private int _guesses;
        
        private readonly Random _random = new Random();

        public Hangman()
        {
            // Load the words and then randomly allocate one to be the actual word.
            LoadWordsFromFile();

            // Generate the StringBuilder for the word display.
            _display = new StringBuilder(_word);
            for (int i = 0; i < _word.Length; i++)
            {
                _display[i] = '_';
            }
            
            // Begin actual game loop.
            while (GetStatus())
            {
                // Display all visual aspects.
                ConstructGameplay();
                // Check for any game completions.
                PerformGameChecks();
                // Read in a character and then attempt a guess.
                MakeGuess(Console.ReadKey().KeyChar);
                
                Console.WriteLine();
            }
        }

        private string GetUsedLetters()
        {
            return _lettersUsed;
        }

        public bool GetStatus()
        {
            return _status;
        }

        public void ConstructGameplay()
        {
            // Display the lines with any letters guessed.
            Console.WriteLine(_display.ToString());
            Console.WriteLine("");
            // Display the incorrect guesses with the amount of guesses used.
            Console.WriteLine(GetUsedLetters() + "(" + _guesses + "/6)");
        }

        public void MakeGuess(char theLetter)
        {
            // Check if they've used the letter already yet.
            if (!GetUsedLetters().Contains(theLetter))
            {
                // Check if the word contains the letter yet.
                if (_word.Contains(theLetter))
                {
                    // Find the letter's position.
                    for (int i = 0; i < _word.Length; i++)
                    {
                        // Check if the letter guessed equals the position i letter in the word.
                        if (_word[i] == theLetter)
                        {
                            // As it does set the display to show this.
                            _display[i] = theLetter;
                        }
                    }

                    return;
                }
                // Add the letter to the letters used string.
                _lettersUsed = _lettersUsed + theLetter + " ";
                // Increment the incorrect guesses count.
                _guesses++;
            }
        }

        private void PerformGameChecks()
        {
            // Check if they've guessed the word.
            if (_display.ToString() == _word)
            {
                _status = false;
                Console.WriteLine("Well done! You got the word in {0} guesses!", _guesses);
                return;
            }
            
            // Check if they've run out of guesses (should this be higher?)
            if (_guesses == 6)
            {
                _status = false;
                Console.WriteLine("Unlucky! The word was {0}. Better luck next time!", _word);
            }
        }

        private void LoadWordsFromFile()
        {
            // Load the file.
            StreamReader theInputStream =
                new StreamReader("/Users/danwilliams/Projects/HSFC/Hangman/Hangman/hangman.txt");
            
            // Temporary dictionary to store the words.
            string[] tempDictionary = new string[150];
            // Word counter.
            int counter = 0;
            
            // Process the file line by line
            while (!theInputStream.EndOfStream)
            {
                // Split the words (I suppose this could help with any thing with multiple words in the future)
                string[] tokenizedString = theInputStream.ReadLine().Split('\n', StringSplitOptions.RemoveEmptyEntries);
                
                // Process each string in the array.
                for (int i = 0; i < tokenizedString.Length; i++)
                {
                    // Add it to the temporary array/dictionary.
                    tempDictionary[counter] = tokenizedString[i].ToLower();
                    counter++;
                }
            }
            // Randomly choose a word from the list.
            _word = tempDictionary[_random.Next(0, counter)];
            theInputStream.Close();
        }
    }
}