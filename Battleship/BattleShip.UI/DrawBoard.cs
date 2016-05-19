using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BattleShip.BLL.GameLogic;
using BattleShip.BLL.Requests;
using BattleShip.BLL.Responses;

namespace BattleShip.UI
{
    public class DrawBoard
    {
        //public static void FlashScreen(Board board)//place something other than the board here... some ASCII maybe.
        //{
        //    Console.Clear();
        //    Console.BackgroundColor = ConsoleColor.Red;
        //    DrawCurrentBoard(board);
        //    Thread.Sleep(100);
        //    Console.Clear();
        //    Console.BackgroundColor = ConsoleColor.Black;
        //    DrawCurrentBoard(board);
        //    Thread.Sleep(100);
        //    Console.Clear();
        //    Console.BackgroundColor = ConsoleColor.Red;
        //    DrawCurrentBoard(board);
        //    Thread.Sleep(100);
        //    Console.Clear();
        //    Console.BackgroundColor = ConsoleColor.Black;
        //    DrawCurrentBoard(board);
        //    Thread.Sleep(100);
        //    Console.Clear();
        //    Console.BackgroundColor = ConsoleColor.Red;
        //    DrawCurrentBoard(board);
        //    Thread.Sleep(100);
        //    Console.Clear();
        //    Console.BackgroundColor = ConsoleColor.Black;
        //    DrawCurrentBoard(board);
        //    Console.Clear();
        //}
        public static void DrawCurrentBoard(Board currentBoard)
        {



            int unicode = 65;
            
           
            for (int y = 1; y <= 10; y++)
            {
                //localShotHistory = Dictionary<x, currentBoard.ShotHistory>;
                Console.WriteLine();
                Console.WriteLine();
                if (y == 1)
                {
                    Console.WriteLine("     __1_____2_____3_____4_____5_____6_____7_____8_____9_____10_\n");
                }

                char letter = (char) unicode;
                Console.Write("  " +letter+ " |");
                unicode++;

                for (int x = 1; x <= 10; x++)
                {
                    Coordinate localCoord = new Coordinate(x, y);

                    if (!currentBoard.ShotHistory.ContainsKey(localCoord))
                    {
                        Console.Write("__X__|");
                    }
                    else
                    {
                        ShotHistory sh = currentBoard.ShotHistory[localCoord];

                        if (sh == ShotHistory.Hit)
                        {
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.Write("__H__|");
                            Console.ResetColor();
                            Console.ForegroundColor = ConsoleColor.Green;
                           
                        }
                        else if (sh == ShotHistory.Miss)
                        {
                            Console.BackgroundColor = ConsoleColor.Yellow;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.Write("__M__|");
                            Console.ResetColor();
                            Console.ForegroundColor = ConsoleColor.Green;
                        }
                    }

                }

            }
            



        }

        public static void DrawVictory()
        {
            for (int i = 0; i < 4; i++)
            {



                Console.Clear();

                Console.WriteLine("        __ __            _ _ _ _          ");
                Console.WriteLine("       |  |  |___ _ _   | | | |_|___      ");
                Console.WriteLine("       |_   _| . | | |  | | | | |   |     ");
                Console.WriteLine("         |_| |___|___|  |_____|_|_|_|     ");

                Thread.Sleep(700);

                Console.WriteLine("        __ __            _ _ _ _          ");
                Console.WriteLine("       |  |  |___ _ _   | | | |_|___      ");
                Console.WriteLine("       |_   _| . | | |  | | | | |   |     ");
                Console.WriteLine("         |_| |___|___|  |_____|_|_|_|     ");

                Thread.Sleep(700);

                Console.WriteLine("        __ __            _ _ _ _          ");
                Console.WriteLine("       |  |  |___ _ _   | | | |_|___      ");
                Console.WriteLine("       |_   _| . | | |  | | | | |   |     ");
                Console.WriteLine("         |_| |___|___|  |_____|_|_|_|     ");

                Thread.Sleep(700);

                Console.Clear();
            }
        }

    }
    

}
