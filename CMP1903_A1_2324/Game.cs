using CMP1903_A1_2324;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace CMP1903_A1_2324
{
    internal class Game
    {
        private static Testing test = new Testing(); //A new object for Testing is created here, so that tests can be made as soon as possible
        SevensOut sevensOut = new SevensOut();
        ThreeOrMore threeOrMore = new ThreeOrMore();
        Statistics statistics = new Statistics();
        public void DieGame() //DieGame is the starting point of the program, as seen from Program.cs, which means that these are the first pieces of code to run
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Please enter a number based on the action you want to occur: \n\n1 = Play 'Sevens Out' Game\n2 = Play 'Three or More' Game\n3 = View Statistics Data\n4 = Quit\n\nMake your choice below:");
                    int gameChoice = int.Parse(Console.ReadLine());
                    if (gameChoice < 1 || gameChoice > 4){
                        Console.WriteLine("Please remember to put an integer that is either: 1, 2, 3 or 4.");
                        Console.ReadKey();
                    }
                    else if (gameChoice == 1)
                    {
                        sevensOut.SevensOutGame();
                    }
                    else if (gameChoice == 2)
                    {
                        threeOrMore.ThreeOrMoreMenu();
                    }
                    else if (gameChoice == 3)
                    {
                        statistics.GameStatistis();
                    }
                    else if (gameChoice == 4)
                    {
                        Console.WriteLine("Quitting Application...");
                        break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"\n\nError: {e}\n\nPlease remember to put an integer that is either: 1, 2, 3 or 4.");
                    Console.ReadKey();
                }
                
            }
        }
    }

    internal class SevensOut
    {
        private static Testing test = new Testing();
        public static List<int> scores = new List<int>(); // List to store scores of each game

        public void SevensOutGame()
        {
            bool StoppingGame = false;
            int TotalValue = 0;
            int TotalRollValue = 0;
            while (true)
            {
                Die dieOne = new Die();
                dieOne.Roll();
                int DieOneValue = dieOne.DieValue;

                Die dieTwo = new Die();
                dieTwo.Roll();
                int DieTwoValue = dieTwo.DieValue;

                if (DieOneValue == DieTwoValue)
                {
                    TotalRollValue = 2 * (DieOneValue + DieTwoValue);
                }
                else
                {
                    TotalRollValue = DieOneValue + DieTwoValue;
                }

                TotalValue += TotalRollValue;
                Console.WriteLine($"\nDie rolls are: {DieOneValue} and {DieTwoValue}\nTotal (current) throw value: {TotalRollValue}\nTotal: {TotalValue}");
                Console.ReadKey();

                if (TotalRollValue == 7)
                {
                    StoppingGame = true;
                    test.SevensOutGame(TotalRollValue, StoppingGame);
                    Console.WriteLine($"\n\nA '7' was rolled!\nFinal Score: {TotalValue}\n\n");
                    scores.Add(TotalValue); // Add final score to the list
                    break;
                }
            }
        }
    }


    internal class ThreeOrMore
    {
        private static Testing test = new Testing();
        public static List<int> playerOneScores = new List<int>();
        public static List<int> playerTwoOrComputerScores = new List<int>();
        public void ThreeOrMoreMenu()
        {
            int players = 0; 

            while (true)
            {
                try
                {
                    Console.WriteLine("\n\nPlease enter a number based on the action you want to occur: \n\n1 = Play Singleplayer (against a computer)\n2 = Play Multiplayer (against a person)\n3 = Exit back to Menu\n\nMake your choice below:");
                    int playerChoice = int.Parse(Console.ReadLine());
                    if (playerChoice < 1 || playerChoice > 3)
                    {
                        Console.WriteLine("Please remember to put an integer that is either a: 1 or 2");
                    }
                    else if (playerChoice == 1)
                    {
                        players = 1;
                        ThreeOrMoreGame(players);
                    }
                    else if (playerChoice == 2)
                    {
                        players = 2;
                        ThreeOrMoreGame(players);
                    }
                    else if(playerChoice == 3)
                    {
                        break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"\n\nError: {e}\n\nPlease remember to put an integer that is either a: 1 or 2");
                }
            }
            
        }
        public void ThreeOrMoreGame(int players)
        {
            int playerOneScore = 0;
            int computerOrPlayerTwoScore = 0; // This will represent the computer's score in singleplayer or player 2's score in multiplayer
            int currentPlayer = 1; // Start with player 1 (human)
            Random rng = new Random();

            while (true)
            {
                if (players == 1)
                {
                    if (currentPlayer == 2)
                    {
                        Console.WriteLine($"Computer's turn to roll:");
                    }
                    else
                    {
                        Console.WriteLine($"Player's turn to roll:");
                    }
                }
                else if (players == 2)
                {
                    if (currentPlayer == 2)
                    {
                        Console.WriteLine($"Player 2's turn to roll:");
                    }
                    else
                    {
                        Console.WriteLine($"Player 1's turn to roll:");
                    }
                }
                int awardedScore = 0;
                Die dieOne = new Die();
                dieOne.Roll();
                int DieOneValue = dieOne.DieValue;

                Die dieTwo = new Die();
                dieTwo.Roll();
                int DieTwoValue = dieTwo.DieValue;

                if (DieOneValue == DieTwoValue)
                {
                    Console.WriteLine($"Identical Rolls Detected! : {DieOneValue}, {DieTwoValue}");
                    if (players == 2 || (players == 1 && currentPlayer == 1)) // If multiplayer or singleplayer (human's turn)
                    {
                        Console.WriteLine("\n\nPlease enter a number based on the action you want to occur: \n\n1 = Roll three remaining Die\n2 = Reroll all 5 Die\n\nMake your choice below:");
                        int restartChoice = int.Parse(Console.ReadLine());

                        if (restartChoice == 2) // If choice is to reroll all dice
                        {
                            continue; // Skip the current iteration, causing all five dice to roll again at the start of the loop
                        }
                    }
                    else if (players == 1 && currentPlayer == 2) // Computer's turn in singleplayer
                    {
                        int computerChoice = rng.Next(1, 3); // Randomly decide between 1 and 2
                        Console.WriteLine($"Computer chooses to {(computerChoice == 2 ? "reroll all dice." : "roll the remaining three dice.")}");
                        if (computerChoice == 2)
                        {
                            continue; // Computer rerolls all dice
                        }
                    }
                }

                Die dieThree = new Die(); //creates a new die object
                dieThree.Roll(); //uses the die object to start a unique roll method for it
                int DieThreeValue = dieThree.DieValue;

                Die dieFour = new Die(); //creates a new die object
                dieFour.Roll(); //uses the die object to start a unique roll method for it
                int DieFourValue = dieFour.DieValue;

                Die dieFive = new Die(); //creates a new die object
                dieFive.Roll(); //uses the die object to start a unique roll method for it
                int DieFiveValue = dieFive.DieValue;

                int[] rolls = { DieOneValue, DieTwoValue, DieThreeValue, DieFourValue, DieFiveValue };
                Console.WriteLine($"Rolls Are: {String.Join(", ", rolls)}");

                Dictionary<int, int> counts = new Dictionary<int, int>();
                foreach (var roll in rolls)
                {
                    if (counts.ContainsKey(roll))
                        counts[roll]++;
                    else
                        counts[roll] = 1;
                }

                int duplicates = counts.Values.Max(); // Gets the maximum frequency from the counts dictionary

                switch (duplicates)
                {
                    case 3:
                        awardedScore += 3;
                        break;
                    case 4:
                        awardedScore += 6;
                        break;
                    case 5:
                        awardedScore += 12;
                        break;
                }

                if (currentPlayer == 1)
                {
                    playerOneScore += awardedScore;
                    Console.WriteLine($"Player 1's Score: {playerOneScore}\n");
                    currentPlayer = 2; // Switch to player 2 or computer depending on the mode
                }
                else
                {
                    computerOrPlayerTwoScore += awardedScore;
                    Console.WriteLine($"{(players == 1 ? "Computer" : "Player 2")}'s Score: {computerOrPlayerTwoScore}\n");
                    currentPlayer = 1; // Switch back to player 1
                }

                if (playerOneScore >= 20 || computerOrPlayerTwoScore >= 20)
                {
                    playerOneScores.Add(playerOneScore);
                    playerTwoOrComputerScores.Add(computerOrPlayerTwoScore);

                    Console.WriteLine($"{(playerOneScore >= 20 ? "Player 1" : (players == 1 ? "Computer" : "Player 2"))} wins!");
                    break;
                }
                else if (players == 1 && currentPlayer == 2)
                {
                    continue; // In singleplayer, the computer's turn is automatic, no need to press a key.
                }
                else
                {
                    Console.WriteLine("Press any key for next turn.");
                    Console.ReadKey();
                }
            }
        }
    }
    internal class Statistics
    {
        public void GameStatistis()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("\n\nPlease enter a number based on the action you want to occur: \n\n1 = See 'Sevens Out' Statistics\n2 = See 'Three or More' Statistics\n3 = Exit back to Menu\n\nMake your choice below:");
                    int statChoice = int.Parse(Console.ReadLine());
                    if (statChoice < 1 || statChoice > 3)
                    {
                        Console.WriteLine("Please remember to put an integer that is either: 1, 2, or 3");
                    }
                    else if (statChoice == 1)
                    {
                        // Display 'Sevens Out' scores
                        if (!SevensOut.scores.Any())
                        {
                            Console.WriteLine("No 'Sevens Out' games have been played yet.");
                        }
                        else
                        {
                            Console.WriteLine("\nScores from 'Sevens Out' games:");
                            foreach (int score in SevensOut.scores)
                            {
                                Console.WriteLine(score);
                            }
                        }
                    }
                    else if (statChoice == 2)
                    {
                        // Display 'Three or More' scores
                        Console.WriteLine("\n\nScores from 'Three or More' games:\n");
                        if (!ThreeOrMore.playerOneScores.Any())
                        {
                            Console.WriteLine("No games have been played yet for Player 1.");
                        }
                        else
                        {
                            Console.WriteLine("Player 1 Scores:");
                            foreach (int score in ThreeOrMore.playerOneScores)
                            {
                                Console.WriteLine(score);
                            }
                        }

                        if (!ThreeOrMore.playerTwoOrComputerScores.Any())
                        {
                            Console.WriteLine("No games have been played yet for Player 2 or Computer.");
                        }
                        else
                        {
                            Console.WriteLine("Player 2 / Computer Scores:");
                            foreach (int score in ThreeOrMore.playerTwoOrComputerScores)
                            {
                                Console.WriteLine(score);
                            }
                        }
                    }
                    else if (statChoice == 3)
                    {
                        break; // Exit back to Menu
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"\n\nError: {e}\n\nPlease remember to put an integer that is either a: 1, 2, or 3");
                }
            }
        }
    }

}