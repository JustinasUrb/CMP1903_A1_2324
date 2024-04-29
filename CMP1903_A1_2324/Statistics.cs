using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_A1_2324
{
    internal class Statistics
    {
        public void GameStatistis()
        {
            while (true)
            {
                try
                {
                    //allows the user to select the choice of viewing statistics from both games, or going back to the menu
                    Console.WriteLine("\n\nPlease enter a number based on the action you want to occur: \n\n1 = See 'Sevens Out' Statistics\n2 = See 'Three or More' Statistics\n3 = Exit back to Menu\n\nMake your choice below:");
                    int statChoice = int.Parse(Console.ReadLine());
                    if (statChoice < 1 || statChoice > 3)
                    {
                        Console.WriteLine("Please remember to put an integer that is either: 1, 2, or 3");
                    }
                    else if (statChoice == 1)
                    {
                        // displays 'Sevens Out' scores from the previous games
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
                        //displays 'Three or More' scores from the previous games
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
                        break; //exits back to 'game' menu
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
