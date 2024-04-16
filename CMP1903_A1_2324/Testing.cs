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
        public void DieTest(int value)
        {
            Debug.Assert(value <= 6, "Die generated above the value of 6 (Max)"); //Using Asserts, the value generated is used to test if it exceeds logical maximums
            Debug.Assert(value >= 1, "Die generated below the value of 1 (Min)"); //Using Asserts, the value generated is used to test if it exceeds logical maximums
        }

        public void SevensOutGame(int value, bool state)
        {
            Debug.Assert(value <= 24, "Die generated with a total above the maximum threshold.");
            Debug.Assert(value >= 1, "Die generated below the minimum value possible.");
            Debug.Assert(state == true, "Game failed to end when the objective of the game was reached.");
        }

        public void GameTest(int value)
        {
            Debug.Assert(value <= 18, "Sum above the value of 18 (Max)"); //Using Asserts, the sum is checked to make sure that it is below the logical maximum
            Debug.Assert(value >= 3, "Sum below the value of 3 (Min)"); //Using Asserts, the sum is checked to make sure that it is above the logical minimum
        }
    }
}
