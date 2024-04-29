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
    internal class Game//internal class for Game, which is used as a hub to go to games, statistics or to quit the program.
    {
        private static Testing test = new Testing(); //a new object for Testing is created here, so that tests can be made as soon as possible
        SevensOut sevensOut = new SevensOut(); //new object for SevensOut
        ThreeOrMore threeOrMore = new ThreeOrMore();//new object for ThreeOrMore
        Statistics statistics = new Statistics();//new object for Statistics
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

    internal class SevensOut //internal class for the game 'Sevens out'
    {
        private static Testing test = new Testing();//initialises testing which will be carried on later
        public static List<int> scores = new List<int>(); //creates a list to keep score for the statistics

        public void SevensOutGame()
        {
            //initialises various variables used for making sure the game works correctly
            bool StoppingGame = false;
            int TotalValue = 0;
            int TotalRollValue = 0;
            
            while (true)
            {
                //creates 2 die objects.
                Die dieOne = new Die();
                dieOne.Roll();
                int DieOneValue = dieOne.DieValue;

                Die dieTwo = new Die();
                dieTwo.Roll();
                int DieTwoValue = dieTwo.DieValue;

                //checks for if the two die objects are the same, and if they are, the value of them is double the altogether value
                if (DieOneValue == DieTwoValue)
                {
                    TotalRollValue = 2 * (DieOneValue + DieTwoValue);
                }
                else
                {
                    TotalRollValue = DieOneValue + DieTwoValue;
                }

                //adds the value to the total value (for keeping score)
                TotalValue += TotalRollValue;
                Console.WriteLine($"\nDie rolls are: {DieOneValue} and {DieTwoValue}\nTotal (current) throw value: {TotalRollValue}\nTotal: {TotalValue}");
                Console.ReadKey();

                //checks if the value of both die equal to 7, and if they do, the value is tested, added to statistics, and the game ends
                if (TotalRollValue == 7)
                {
                    StoppingGame = true;
                    test.SevensOutGame(TotalRollValue, StoppingGame);
                    Console.WriteLine($"\n\nA '7' was rolled!\nFinal Score: {TotalValue}\n\n");
                    scores.Add(TotalValue); //adds the ending score to a list, which is used foir the statistics
                    break;
                }
            }
        }
    }


    internal class ThreeOrMore //internal class for the gasme 'Three or More'
    {
        private static Testing test = new Testing(); //initialises testing which will be carried on later
        public static List<int> playerOneScores = new List<int>(); //creates a list with player 1 scores (which is passed later on to statistics
        public static List<int> playerTwoOrComputerScores = new List<int>(); //creates a list with player 2/computer scores (which is passed later on to statistics
        public void ThreeOrMoreMenu()
        {
            int players = 0; 

            while (true)
            {
                try
                {
                    //adds logic for choosing singleplayer/multiplayer modes.
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
            int playerOneScore = 0;//variable used to showcase player 1 score
            int computerOrPlayerTwoScore = 0; //variable used to show player 2 / computer score
            int currentPlayer = 1; //game start with player 1
            Random rng = new Random(); //initialises randomness for computer rerolls

            while (true)
            {
                if (players == 1) //logic to make sure that player 2 in the singleplayer game is reffered as 'Computer'
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
                else if (players == 2) //logic to make sure that player 2 in the multiplayer game is reffered as 'Player 2'
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

                int awardedScore = 0; //initialises the variable for awarding score to players

                Die dieOne = new Die();
                dieOne.Roll();
                int DieOneValue = dieOne.DieValue;

                Die dieTwo = new Die();
                dieTwo.Roll();
                int DieTwoValue = dieTwo.DieValue;

                if (DieOneValue == DieTwoValue)
                {
                    Console.WriteLine($"Identical Rolls Detected! : {DieOneValue}, {DieTwoValue}");
                    if (players == 2 || (players == 1 && currentPlayer == 1)) //if multiplayer or singleplayer (human's turn)
                    {
                        int restartChoice = 0;
                        bool validChoice = false;

                        while (!validChoice)
                        {
                            Console.WriteLine("\n\nPlease enter a number based on the action you want to occur: \n\n1 = Roll three remaining Die\n2 = Reroll all 5 Die\n\nMake your choice below:");
                            if (int.TryParse(Console.ReadLine(), out restartChoice) && (restartChoice == 1 || restartChoice == 2))
                            {
                                validChoice = true;  //when the input is valid, exits the loop
                            }
                            else
                            {
                                Console.WriteLine("Invalid input. Please enter either 1 or 2.");
                            }
                        }

                        if (restartChoice == 2) //if choice for if the player wants reroll all dice
                        {
                            continue; // Skips rolling remaining die, and goes back to the beginning, causing all five die to roll again at the start of the loop
                        }
                    }
                    else if (players == 1 && currentPlayer == 2) // Computer's turn in singleplayer mode
                    {
                        int computerChoice = rng.Next(1, 3); // Randomly decide between 1 and 2, in order to reroll 3 or all
                        Console.WriteLine($"Computer chooses to {(computerChoice == 2 ? "reroll all dice." : "roll the remaining three dice.")}");
                        if (computerChoice == 2)
                        {
                            continue; // Computer rerolls all die.
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

                int[] rolls = { DieOneValue, DieTwoValue, DieThreeValue, DieFourValue, DieFiveValue }; //puts all the rolls into a single array
                Console.WriteLine($"Rolls Are: {String.Join(", ", rolls)}"); //shows all the rolls to the user.

                Dictionary<int, int> counts = new Dictionary<int, int>(); //creating a dictionary object for easier checking of multiples
                
                
                foreach (var roll in rolls)
                {
                    if (counts.ContainsKey(roll))
                        counts[roll]++;
                    else
                        counts[roll] = 1;
                }

                int duplicates = counts.Values.Max(); //gets the mlargest duplicate figure from the counts dictionary

                switch (duplicates) //adds score based on the largest roll frequency
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

                test.ThreeOrMore(awardedScore); //tests three or more game's score that has been awarded

                if (currentPlayer == 1) //awards score to the current player
                {
                    playerOneScore += awardedScore;
                    Console.WriteLine($"Player 1's Score: {playerOneScore}\n");
                    currentPlayer = 2; //switches to player 2 or the computer depending on the mode chosen by the user
                }
                else
                {
                    computerOrPlayerTwoScore += awardedScore;
                    Console.WriteLine($"{(players == 1 ? "Computer" : "Player 2")}'s Score: {computerOrPlayerTwoScore}\n");
                    currentPlayer = 1; //switches back to player 1
                }

                if (playerOneScore >= 20 || computerOrPlayerTwoScore >= 20) //checks if any player / computer has won the game
                {
                    playerOneScores.Add(playerOneScore);
                    playerTwoOrComputerScores.Add(computerOrPlayerTwoScore);

                    test.ThreeOrMore(playerOneScore, computerOrPlayerTwoScore);
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
}