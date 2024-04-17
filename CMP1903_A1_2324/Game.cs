using CMP1903_A1_2324;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
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
                        Console.WriteLine("Opening Statistics...");
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
        public void SevensOutGame()
        {
            bool StoppingGame = false;
            int TotalValue = 0;
            int TotalRollValue = 0;
            while (true)
            {
                Die dieOne = new Die(); //creates a die object, which will be used to roll a number between 1 and 6
                dieOne.Roll(); //uses the die object to start a unique roll method for it
                int DieOneValue = dieOne.DieValue; //returned integer is set as a value for the die object

                Die dieTwo = new Die(); //creates a new die object
                dieTwo.Roll(); //uses the die object to start a unique roll method for it
                int DieTwoValue = dieTwo.DieValue; //returned integer is set as a value for this unique die object

                if (DieOneValue == DieTwoValue)
                {
                    TotalRollValue = 2 * (DieOneValue + DieTwoValue);
                }
                else
                {
                    TotalRollValue = DieOneValue + DieTwoValue;
                }

                TotalValue = TotalValue += TotalRollValue;
                Console.WriteLine($"\nDie rolls are: {DieOneValue} and {DieTwoValue}\nTotal (current) throw value: {TotalRollValue}\nTotal: {TotalValue}");
                Console.ReadKey();
                if (TotalRollValue == 7)
                {
                    StoppingGame = true;
                    test.SevensOutGame(TotalRollValue, StoppingGame);
                    Console.WriteLine($"\n\nA '7' was rolled!\nFinal Score: {TotalValue}\n\n");
                    break;
                }
            }
        }
    }

    internal class ThreeOrMore
    {
        private static Testing test = new Testing();
        public void ThreeOrMoreMenu()
        {
            int playerOneScore = 0; 
            int playerTwoScore = 0;
            int computerScore = 0;
            int players = 0; 

            while (true)
            {
                try
                {
                    Console.WriteLine("\n\nPlease enter a number based on the action you want to occur: \n\n1 = Play Multiplayer\n2 = Play against a computer\n\nMake your choice below:");
                    int playerChoice = int.Parse(Console.ReadLine());
                    if (playerChoice < 1 || playerChoice > 2)
                    {
                        Console.WriteLine("Please remember to put an integer that is either a: 1 or 2");
                    }
                    else if (playerChoice == 1)
                    {
                        players = 2;
                        ThreeOrMoreGame(players);
                    }
                    else if (playerChoice == 2)
                    {
                        players = 1;
                        ThreeOrMoreGame(players);
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
            Console.WriteLine(players);
            Console.ReadKey();
            if (players == 1)
            {
                //Playing against a computer
            }
            else if (players == 2)
            {
                //Playing against another player
            }
        }
    }
}


//old leftover code if needed for later use:

//Die dieOne = new Die(); //creates a die object, which will be used to roll a number between 1 and 6
//dieOne.Roll(); //uses the die object to start a unique roll method for it
//int DieOneValue = dieOne.DieValue; //returned integer is set as a value for the die object

//Die dieTwo = new Die(); //creates a new die object
//dieTwo.Roll(); //uses the die object to start a unique roll method for it
//int DieTwoValue = dieTwo.DieValue; //returned integer is set as a value for this unique die object

//Die dieThree = new Die(); //creates a new die object
//dieThree.Roll(); //uses the die object to start a unique roll method for it
//int DieThreeValue = dieThree.DieValue; //returned integer is set as a value for this unique die object

//test.GameTest(DieOneValue + DieTwoValue + DieThreeValue); //Tests the sum of the three die objects
//Console.WriteLine($"The sum of three randomly rolled dice is: {DieOneValue + DieTwoValue + DieThreeValue}");
//Console.WriteLine($"Individual rolls are: {DieOneValue}, {DieTwoValue}, {DieThreeValue}");
//Console.ReadKey(); //ReadKey is used to show the user the outputs, but also to simply close the program with any key press, instead of an input with 'ReadLine'