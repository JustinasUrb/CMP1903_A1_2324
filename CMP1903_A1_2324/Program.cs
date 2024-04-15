using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_A1_2324
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Game DieRoller = new Game(); //creates a game object called 'DieRoller'
            SevensOut sevensOut = new SevensOut(); //creates a game object for the game 'Sevens Out'
            ThreeOrMore threeOrMore = new ThreeOrMore(); //creates a game object for the game 'Three or More'

            DieRoller.DieGame(); //calls the DieGame() method, which is the starting point of the program
            sevensOut.SevensOutGame(); //calls the method for the Sevens Out game
            threeOrMore.ThreeOrMoreGame(); //calls the method for the Three or More Game
        }
    }
}
