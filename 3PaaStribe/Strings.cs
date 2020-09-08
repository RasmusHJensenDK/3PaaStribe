using System;
using System.Collections.Generic;
using System.Text;

namespace _3PaaStribe
{
    public class Strings
    {
        public static string STRwelcometothirdonarow = "Hello! - Welcome to 3 on a line";
        public static string STRsingleormulti = "(S)ingle or (M)ultiplayer?";
        public static string STRwelcometosingle = "Welcome to Singleplayer";
        public static string STRwelcometomultiplayer = "Welcome to Multiplayer";
        public static string STRpiece = "Which piece do you want to use? X / O";
        public static string STRbot = "bot";
        public static string STRplaceyourpiece = "Place your piece ";
        public static string STRwin = " won the game!";
        public static string STRplayagain = "Do you want to play again? Y / N";
        public static string STRthanksforplaying = "Thanks for playing!";
        public static string STRcongratulations = "Congratulations ";
        public static string STRpleacemoveapiece = " please move a piece";
        public static string STRallreadythere = "You chose a spot allready there.. Chose again..";

        public static string STRplayerone = "PlayerOne";
        public static string STRplayertwo = "PlayerTwo";

        public static char CHRpieceO = 'O';
        public static char CHRpieceX = 'X';

        public static string[] ARRbuilderwelcome = { STRwelcometothirdonarow, STRsingleormulti };
        public static string[] ARRwelcomesingle = { STRwelcometosingle, STRpiece };
        public static string[] ARRwelcomemulti = { STRwelcometomultiplayer, STRpiece };

        public static void Type(string output)
        {
            Console.WriteLine(output);
        }

        public static void TypeMulti(string[] strings)
        {
            foreach (string str in strings)
            {
                Console.WriteLine(str.ToString());
            }
        }
    }
}
