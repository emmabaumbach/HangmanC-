using System;

class HangmanGame
{
    static void Main(string[] args)
    {
        // Set up the game
        string[] words = { "hello", "world", "hangman", "game", "computer" };
        Random rand = new Random();
        string wordToGuess = words[rand.Next(words.Length)];
        char[] lettersToGuess = wordToGuess.ToCharArray();
        char[] displayLetters = new char[lettersToGuess.Length];
        for (int i = 0; i < displayLetters.Length; i++)
        {
            displayLetters[i] = '_';
        }
        int guessesRemaining = 6;
        bool gameOver = false;

        // Play the game
        while (!gameOver)
        {
            // Display the game status
            Console.WriteLine("Word: {0}", new string(displayLetters));
            Console.WriteLine("Guesses remaining: {0}", guessesRemaining);

            // Get the user's guess
            Console.Write("Guess a letter: ");
            char guess = Console.ReadLine()[0];

            // Check if the letter is in the word
            bool correctGuess = false;
            for (int i = 0; i < lettersToGuess.Length; i++)
            {
                if (lettersToGuess[i] == guess)
                {
                    displayLetters[i] = guess;
                    correctGuess = true;
                }
            }

            // Update the game status based on the guess
            if (correctGuess)
            {
                Console.WriteLine("Correct!");
                if (new string(displayLetters) == wordToGuess)
                {
                    Console.WriteLine("You win!");
                    gameOver = true;
                }
            }
            else
            {
                Console.WriteLine("Incorrect.");
                guessesRemaining--;
                if (guessesRemaining == 0)
                {
                    Console.WriteLine("You lose. The word was {0}.", wordToGuess);
                    gameOver = true;
                }
            }
        }

        // Wait for user input to close the window
        Console.WriteLine("Press any key to exit.");
        Console.ReadKey();
    }
}
