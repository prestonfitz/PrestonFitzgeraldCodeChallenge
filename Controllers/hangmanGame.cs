using PrestonFitzgeraldCodeChallenge.Controllers;
using PrestonFitzgeraldCodeChallenge.Models;

namespace PrestonFitzgeraldCodeChallenge.Controllers
{
    public class hangmanGame
    {
        // constants
        private static string[] gameWords = ["potato", "caramel", "hamburger", "pizza", "sandwich", "cheesecake", "chocolate", "ketchup", "mayonnaise", "barbecue"];

        // variables
        private bool gameActive = false;
        private bool gameLost = false;
        private int numWrongGuesses = 0;
        private string word = "";
        private char[] correctLetters = [];
        private char[] guessedLetters = [];
        private string displayedText = "<h1>Welcome<h1><p>Thank you for coming to play hangman. When you are ready to start, please press new game.</p>";
        private string guessedText = "";
        private string[] gallows = [];


        // getters and setters
        public string[] GameWords
        {
            get { return gameWords; }
        }
        public bool GameActive
        {
            get { return gameActive; }
            set { gameActive = !gameActive; }
        }

        public bool Gamelost
        {
            get { return gameLost; }
            set { gameLost = !gameLost; }
        }

        public int WrongGuesses
        {
            get { return numWrongGuesses; }
            set { numWrongGuesses = value; }
        }

        public string Word
        {
            get { return word; }
            set { word = value; }
        }

        public char[] CorrectLetters
        {
            get { return correctLetters; }
            set { correctLetters = value; }
        }

        public char[] GuessedLetters
        {
            get { return guessedLetters; }
            set { guessedLetters = value; }
        }

        public string DisplayedText
        {
            get { return displayedText; }
            set { displayedText = value; }
        }

        public string GuessedText
        {
            get { return guessedText; }
            set { guessedText = value; }
        }

        public string[] Gallows
        {
            get { return gallows; }
        }
    }

    internal class playGame
    {
        public static hangmanGame newGame()
        {
            Random rand = new Random();
            hangmanGame game = new hangmanGame();
            game.Word = game.GameWords[rand.Next(game.GameWords.Length)];
            game.GameActive = true;

            for (int i = 0; i < game.Word.Length; i++)
            {
                if (!game.CorrectLetters.Contains(game.Word[i]))
                {
                    game.CorrectLetters.Append(game.Word[i]);
                }

                game.GuessedText = game.GuessedText + "_ ";
            }

            return game;
        }

        static void guess(hangmanGame game, char guessedLetter)
        {
            game.GuessedLetters.Append(guessedLetter);

            if (game.Word.Contains(guessedLetter))
            {
                correct(game, guessedLetter);
            }
            else
            {
                incorrect(game, guessedLetter);
            }
        }

        static void correct(hangmanGame game, char guessedLetter)
        {
            game.CorrectLetters.Append(guessedLetter);

            game.GuessedText = "";

            int correctLetters = 0;

            for (int i = 0; i < game.Word.Length; i++)
            {
                if (game.CorrectLetters.Contains(game.Word[i]))
                {
                    game.GuessedText += game.Word[i] + " ";
                    correctLetters++;
                }
                else
                {
                    game.GuessedText += "_ ";
                }
            }

            if (correctLetters == game.Word.Length)
            {
                game.GameActive = false;
                game.DisplayedText = $"""
                <p>You did it! You guessed the word {game.Word}!</p>
                <p>If you want to play again, please press new game.</p>
                """;
            }
        }

        static void incorrect(hangmanGame game, char guessedLetter)
        {
            game.WrongGuesses++;
        }
    }
}


