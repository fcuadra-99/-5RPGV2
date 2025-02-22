using System;
using System.Reflection.PortableExecutable;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Transactions;
using Projects;

namespace Projects
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "The Hidden Village";
            Game game = new();
            GUI gui = new();
            Console.CursorVisible = false;

            gui.StartMenu();
            gui.MainMenu();
            game.GetEnemy();
            while (game.eventValue != "a7")
            {
                game.BattleStart();
                gui.BattleLoop();
            }

            //Wait before closing.
            //Console.ReadKey();
        }
    }
}