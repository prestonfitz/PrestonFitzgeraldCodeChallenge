using Microsoft.AspNetCore.Mvc;
using PrestonFitzgeraldCodeChallenge.Models;
using System.Diagnostics;

namespace PrestonFitzgeraldCodeChallenge.Controllers
{
    public class HomeController : Controller
    {

        private playGame gameControls;
        private hangmanGame hangmanGame;

        public HomeController()
        {
        }

        public IActionResult Index()
        {
            if (hangmanGame == null)
            {
                hangmanGame = new hangmanGame();
            }
            ViewBag.game = hangmanGame;
            return View();
        }

        public IActionResult NewGame()
        {
            hangmanGame = playGame.newGame();
            ViewBag.game = hangmanGame;

            return View("Index");
        }

        public IActionResult Guess(char guessedLetter, hangmanGame hangmanGame)
        {
            ViewBag.game = hangmanGame;
            return View("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

    }
}
