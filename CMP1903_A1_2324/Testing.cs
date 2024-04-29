using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_A1_2324
{
    internal class Testing
    {
        //logic for testing different values which may not pop-up during gameplay
        public void testingMethods()
        {
            while (true)
            {
                Console.WriteLine("\n\n\nWelcome to the testing place. If you get an error pop-up, the value you tested with isn't accepted by the game's logic!");
                Console.WriteLine("\n\n\nPlease enter a number based on the test you want to do:\n\n1 = Die generation Test\n2 = Sevens out Test\n3 = Three or More Test\n4 = Quit to Menu\n\nMake your choice below...");
                int testChoice = int.Parse(Console.ReadLine());
                if (testChoice < 1 || testChoice > 4)
                {
                    Console.WriteLine("Please remember to put an integer that is either: 1, 2, 3 or 4.");
                    Console.ReadKey();
                }
                else if (testChoice == 1)
                {
                    Console.WriteLine("Please enter a value to test with for die generation (usually would work with a value between 1 and 6):");
                    int dieTestValue = int.Parse(Console.ReadLine());
                    DieTest(dieTestValue);
                }
                else if (testChoice == 2)
                {
                    Console.WriteLine("Please enter a value to test with for the 'Seven's Out' game (usually would work with a value between 2 and 24):");
                    int sevensOutTestValue = int.Parse(Console.ReadLine());
                    SevensOutGame(sevensOutTestValue, true);

                    Console.WriteLine("Now, please enter the state of the game (true = game ended successfully, false = game ended when not supposed to))");
                    bool sevensOutGameStateTestValue = bool.Parse(Console.ReadLine().ToLower());
                    SevensOutGame(2, sevensOutGameStateTestValue);
                }
                else if (testChoice == 3)
                {
                    Console.WriteLine("Please enter a value to test score gained for the 'Three or More' game (usually would work with a value up to 12):");
                    int threeOrMoreTestValue = int.Parse(Console.ReadLine());
                    ThreeOrMore(threeOrMoreTestValue);

                    Console.WriteLine("\n\n\nOnto testing the ending...\n\n\nPlease enter the first value to test ending the game with:");
                    int threeOrMoreEndTestValueOne = int.Parse(Console.ReadLine());

                    Console.WriteLine("Please enter the second value to test ending the game with:");
                    int threeOrMoreEndTestValueTwo = int.Parse(Console.ReadLine());
                    ThreeOrMore(threeOrMoreEndTestValueOne, threeOrMoreEndTestValueTwo);
                }
                else if (testChoice == 4)
                {
                    break;
                }
            }
        }
        public void DieTest(int value)
        {
            Debug.Assert(value <= 6, "Die generated above the value of 6 (Max)"); //Using Asserts, the value generated is used to test if it exceeds logical maximums
            Debug.Assert(value >= 1, "Die generated below the value of 1 (Min)"); //Using Asserts, the value generated is used to test if it exceeds logical maximums
        }

        public void SevensOutGame(int value, bool state)
        {
            Debug.Assert(value <= 24, "Die generated with a total above the maximum threshold.");
            Debug.Assert(value >= 2, "Die generated below the minimum value possible.");
            Debug.Assert(state == true, "Game failed to end when the objective of the game was reached.");
        }

        public void ThreeOrMore(int value)
        {
            Debug.Assert(value < 12, "Die adding has failed (maximum score can be +12 per turn)");
        }

        public void ThreeOrMore(int valueOne, int valueTwo)
        {
            Debug.Assert(valueOne >= 20 || valueTwo >= 20, "Error: Game ended before values reached +20");
        }

        public void GameTest(int value)
        {
            Debug.Assert(value <= 18, "Sum above the value of 18 (Max)"); //Using Asserts, the sum is checked to make sure that it is below the logical maximum
            Debug.Assert(value >= 3, "Sum below the value of 3 (Min)"); //Using Asserts, the sum is checked to make sure that it is above the logical minimum
        }
    }
}