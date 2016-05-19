using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShip.BLL.GameLogic;
using BattleShip.BLL.Requests;
using BattleShip.BLL.Responses;
using BattleShip.BLL.Ships;

namespace BattleShip.UI
{
    public class GameWorkflow
    {

        Board player1Board = new Board();
        Board player2Board = new Board();
        Player p2 = new Player();
        Player p1 = new Player();


        public void PlayGame()
        {
            Console.Clear();
            SplashScreen();
            GetPlayerOneName();
            GetPlayerTwoName();
            ShipSetup();
            TakeTurns();
            if (PlayAgain())
            {
                Console.Clear();
                ShipSetup();
            }
        }

        public void SplashScreen()
        {
            StartMenu.drawSplashScreen();
            
            StartMenu.DrawSplashScreen();
        }
        public Player GetPlayerOneName()
        {
            Console.WriteLine("\t\t\t   Welcome to Battleship!");
            while (true)
            {
                
                Console.Write("\t\t\tPlayer One, enter your name...");
                p1.PlayerName = Console.ReadLine();
                if (p1.PlayerName == "")
                {
                    continue;
                }
                   
                break;
            }
            
            return p1;
        }

        public Player GetPlayerTwoName()
        {

            while (true)
            {
                Console.Write("\t\t\tPlayer Two, enter your name...");
                p2.PlayerName = Console.ReadLine();
                if (p2.PlayerName == "")
                    continue;
                break;
            }
            Console.Clear();
            return p2;
        }


        private void SetupShipForPlayer(Player player, Board board)
        {
            Console.WriteLine("{0}, press enter to place your ships...", player.PlayerName);
            Console.ReadLine();
            Console.Clear();

            foreach (ShipType shipType in Enum.GetValues(typeof(ShipType)))
            {

                while (true)
                {
                    try
                    {
                        PlaceShipRequest shipRequest = new PlaceShipRequest(shipType);
                        Console.WriteLine("{0}, where would you like your {1}?", player.PlayerName, shipType);
                        shipRequest.Coordinate = TranslateShotRequest.TranslateShot(Console.ReadLine());
                        Console.WriteLine("Which direction? (Up, Down, Left, Right):");
                        shipRequest.Direction = TranslateDirectionRequest.TranslateDirection(Console.ReadLine());
                        CheckOverlapping(board.PlaceShip(shipRequest));
                        Console.Clear();
                        break;
                    }
                    catch (Exception exception)
                    {
                        Console.WriteLine(exception.Message);
                        Console.ReadLine();
                        Console.Clear();
                        continue;
                    }
                }

            }
        }


        private void ShipSetup()
        {

            SetupShipForPlayer(p1, player1Board);
            SetupShipForPlayer(p2, player2Board);


            /*            
                        PlaceShipRequest playerOneDestroyerRequest = new PlaceShipRequest(ShipType.Destroyer);
                        PlaceShipRequest playerOneCruiserRequest = new PlaceShipRequest(ShipType.Cruiser);
                        PlaceShipRequest playerOneSubmarineRequest = new PlaceShipRequest(ShipType.Submarine);
                        PlaceShipRequest playerOneBattleshipRequest = new PlaceShipRequest(ShipType.Battleship);
                        PlaceShipRequest playerOneCarrierRequest = new PlaceShipRequest(ShipType.Carrier);
                        PlaceShipRequest playerTwoDestroyerRequest = new PlaceShipRequest(ShipType.Destroyer);
                        PlaceShipRequest playerTwoCruiserRequest = new PlaceShipRequest(ShipType.Cruiser);
                        PlaceShipRequest playerTwoSubmarineRequest = new PlaceShipRequest(ShipType.Submarine);
                        PlaceShipRequest playerTwoBattleshipRequest = new PlaceShipRequest(ShipType.Battleship);
                        PlaceShipRequest playerTwoCarrierRequest = new PlaceShipRequest(ShipType.Carrier);

                        Console.WriteLine("{0}, press enter to place your ships...", p1.PlayerName);
                        Console.ReadLine();
                        Console.Clear();

                        Console.WriteLine("Where would you like to place your Destroyer?");
                        playerOneDestroyerRequest.Coordinate = TranslateShotRequest.TranslateShot(Console.ReadLine());
                        Console.WriteLine("Which direction? (Up, Down, Left, Right):");
                        playerOneDestroyerRequest.Direction = TranslateDirectionRequest.TranslateDirection(Console.ReadLine());
                        CheckOverlapping(player1Board.PlaceShip(playerOneDestroyerRequest));


                        Console.WriteLine("Where would you like to place your Submarine?");
                        playerOneSubmarineRequest.Coordinate = TranslateShotRequest.TranslateShot(Console.ReadLine());
                        Console.WriteLine("Which direction? (Up, Down, Left, Right):");
                        playerOneSubmarineRequest.Direction = TranslateDirectionRequest.TranslateDirection(Console.ReadLine());
                        CheckOverlapping(player1Board.PlaceShip(playerOneSubmarineRequest));

                        Console.WriteLine("Where would you like to place your Cruiser?");
                        playerOneCruiserRequest.Coordinate = TranslateShotRequest.TranslateShot(Console.ReadLine());
                        Console.WriteLine("Which direction? (Up, Down, Left, Right):");
                        playerOneCruiserRequest.Direction = TranslateDirectionRequest.TranslateDirection(Console.ReadLine());
                        CheckOverlapping(player1Board.PlaceShip(playerOneCruiserRequest));

                        Console.WriteLine("Where would you like to place your Battleship?");
                        playerOneBattleshipRequest.Coordinate = TranslateShotRequest.TranslateShot(Console.ReadLine());
                        Console.WriteLine("Which direction? (Up, Down, Left, Right):");
                        playerOneBattleshipRequest.Direction = TranslateDirectionRequest.TranslateDirection(Console.ReadLine());
                        CheckOverlapping(player1Board.PlaceShip(playerOneBattleshipRequest));

                        Console.WriteLine("Where would you like to place your Carrier?");
                        playerOneCarrierRequest.Coordinate = TranslateShotRequest.TranslateShot(Console.ReadLine());
                        Console.WriteLine("Which direction? (Up, Down, Left, Right):");
                        playerOneCarrierRequest.Direction = TranslateDirectionRequest.TranslateDirection(Console.ReadLine());
                        CheckOverlapping(player1Board.PlaceShip(playerOneCarrierRequest));

                        Console.Clear();
                        Console.WriteLine("{0} press Enter to place your ships.", p2.PlayerName);
                        Console.ReadLine();
                        Console.Clear();

                        Console.WriteLine("Where would you like to place your Destroyer?");
                        playerTwoDestroyerRequest.Coordinate = TranslateShotRequest.TranslateShot(Console.ReadLine());
                        Console.WriteLine("Which direction? (Up, Down, Left, Right):");
                        playerTwoDestroyerRequest.Direction = TranslateDirectionRequest.TranslateDirection(Console.ReadLine());
                        CheckOverlapping(player2Board.PlaceShip(playerTwoDestroyerRequest));

                        Console.WriteLine("Where would you like to place your Submarine?");
                        playerTwoSubmarineRequest.Coordinate = TranslateShotRequest.TranslateShot(Console.ReadLine());
                        Console.WriteLine("Which direction? (Up, Down, Left, Right):");
                        playerTwoSubmarineRequest.Direction = TranslateDirectionRequest.TranslateDirection(Console.ReadLine());
                        CheckOverlapping(player2Board.PlaceShip(playerTwoSubmarineRequest));

                        Console.WriteLine("Where would you like to place your Cruiser?");
                        playerTwoCruiserRequest.Coordinate = TranslateShotRequest.TranslateShot(Console.ReadLine());
                        Console.WriteLine("Which direction? (Up, Down, Left, Right):");
                        playerTwoCruiserRequest.Direction = TranslateDirectionRequest.TranslateDirection(Console.ReadLine());
                        CheckOverlapping(player2Board.PlaceShip(playerTwoCruiserRequest));

                        Console.WriteLine("Where would you like to place your Battleship?");
                        playerTwoBattleshipRequest.Coordinate = TranslateShotRequest.TranslateShot(Console.ReadLine());
                        Console.WriteLine("Which direction? (Up, Down, Left, Right):");
                        playerTwoBattleshipRequest.Direction = TranslateDirectionRequest.TranslateDirection(Console.ReadLine());
                        CheckOverlapping(player2Board.PlaceShip(playerTwoBattleshipRequest));

                        Console.WriteLine("Where would you like to place your Carrier?");
                        playerTwoCarrierRequest.Coordinate = TranslateShotRequest.TranslateShot(Console.ReadLine());
                        Console.WriteLine("Which direction? (Up, Down, Left, Right):");
                        playerTwoCarrierRequest.Direction = TranslateDirectionRequest.TranslateDirection(Console.ReadLine());
                        CheckOverlapping(player2Board.PlaceShip(playerTwoCarrierRequest));

                        Console.Clear();
                        Console.WriteLine("{0}, press Enter to begin.", p1.PlayerName);
                        Console.ReadLine();

                */
        }


        public bool TakePlayerTurn(Player player, Board board)
        {

            Console.WriteLine("{0}, press enter to start your turn...", player.PlayerName);
            Console.ReadLine();


            bool isValidShot = false;
            while (isValidShot == false)
            {
                Console.Clear();

                DrawBoard.DrawCurrentBoard(board);

                Console.WriteLine("\n\n   {0}, Please enter coordinates:", player.PlayerName);

                Coordinate inputShot = TranslateShotRequest.TranslateShot(Console.ReadLine());

                if (inputShot == null)
                {
                    Console.WriteLine("Please enter a value... Press enter to try again.");
                    Console.ReadLine();
                    continue;
                }

                FireShotResponse result = board.FireShot(inputShot);
                if (result.ShotStatus == ShotStatus.Invalid)
                {
                    Console.WriteLine("\nYou went off the grid.");
                    Console.ReadLine();
                }
                if (result.ShotStatus == ShotStatus.Duplicate)
                {
                    Console.WriteLine("\nYou've already tried that coordinate.");
                    Console.ReadLine();
                }
                if (result.ShotStatus == ShotStatus.Hit)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(@"            )  (            ____");
                    Console.WriteLine(@"         ( /(  )\ )  *   ) |   /");
                    Console.WriteLine(@"         )\())(()/(` )  /( |  /");
                    Console.WriteLine(@"        ((_)\  /(_))( )(_))| /");
                    Console.WriteLine(@"         _((_)(_)) (_(_()) |/ ");
                    Console.WriteLine(@"        | || ||_ _||_   _|(");
                    Console.WriteLine(@"        | __ | | |   | |  )\ ");
                    Console.WriteLine(@"        |_||_||___|  |_| ((_)");  

                    Console.WriteLine("\n       You hit one of the opponents ships!");

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.ReadLine();
                    isValidShot = true;
                }
                if (result.ShotStatus == ShotStatus.HitAndSunk)
                {

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(@"       ██████  ██░ ██  ██▓ ██▓███       ██████  █    ██  ███▄    █  ██ ▄█▀ ▐██▌  ▐██▌  ▐██▌ ");
            Console.WriteLine(@"     ▒██    ▒ ▓██░ ██▒▓██▒▓██░  ██▒   ▒██    ▒  ██  ▓██▒ ██ ▀█   █  ██▄█▒  ▐██▌  ▐██▌  ▐██▌ ");
            Console.WriteLine(@"     ░ ▓██▄   ▒██▀▀██░▒██▒▓██░ ██▓▒   ░ ▓██▄   ▓██  ▒██░▓██  ▀█ ██▒▓███▄░  ▐██▌  ▐██▌  ▐██▌ ");
            Console.WriteLine(@"       ▒   ██▒░▓█ ░██ ░██░▒██▄█▓▒ ▒     ▒   ██▒▓▓█  ░██░▓██▒  ▐▌██▒▓██ █▄  ▓██▒  ▓██▒  ▓██▒ ");
            Console.WriteLine(@"     ▒██████▒▒░▓█▒░██▓░██░▒██▒ ░  ░   ▒██████▒▒▒▒█████▓ ▒██░   ▓██░▒██▒ █▄ ▒▄▄   ▒▄▄   ▒▄▄   ");
            Console.WriteLine(@"     ▒ ▒▓▒ ▒ ░ ▒ ░░▒░▒░▓  ▒▓▒░ ░  ░   ▒ ▒▓▒ ▒ ░░▒▓▒ ▒ ▒ ░ ▒░   ▒ ▒ ▒ ▒▒ ▓▒ ░▀▀▒  ░▀▀▒  ░▀▀▒ ");
            Console.WriteLine(@"     ░ ░▒  ░ ░ ▒ ░▒░ ░ ▒ ░░▒ ░        ░ ░▒  ░ ░░░▒░ ░ ░ ░ ░░   ░ ▒░░ ░▒ ▒░ ░  ░  ░  ░  ░  ░ ");
            Console.WriteLine(@"     ░  ░  ░   ░  ░░ ░ ▒ ░░░          ░  ░  ░   ░░░ ░ ░    ░   ░ ░ ░ ░░ ░     ░     ░     ░ ");
            Console.WriteLine(@"           ░   ░  ░  ░ ░                    ░     ░              ░ ░  ░    ░     ░     ░    ");
            Console.ForegroundColor = ConsoleColor.Green;

                Console.WriteLine("\n   You sunk your opponent's {0}!", result.ShipImpacted);
                    Console.ReadLine();
                    isValidShot = true;
                }
                if (result.ShotStatus == ShotStatus.Miss)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(@"    ·▄▄▄ ▄▄▄· ▪  ▄▄▌  ▄▄▄▄·        ▄▄▄· ▄▄▄▄▄▄▄     ");
                    Console.WriteLine(@"    ▐▄▄·▐█ ▀█ ██ ██•  ▐█ ▀█▪▪      ▐█ ▀█  •██  ██▌    ");
                    Console.WriteLine(@"    ██▪ ▄█▀▀█ ▐█·██▪  ▐█▀▀█▄ ▄█▀▄ ▄█▀▀█  ▐█.▪▐█·    ");
                    Console.WriteLine(@"    ██▌.▐█ ▪▐▌▐█▌▐█▌▐▌██▄▪▐█▐█▌.▐▌▐█ ▪▐▌ ▐█▌·.▀     ");
                    Console.WriteLine(@"    ▀▀▀  ▀  ▀ ▀▀▀.▀▀▀ ·▀▀▀▀  ▀█▄▀▪ ▀  ▀  ▀▀▀  ▀     ");
                    Console.ForegroundColor = ConsoleColor.Green;

                    Console.WriteLine("\n   You missed!");
                    Console.ReadLine();
                    isValidShot = true;
                }
                if (result.ShotStatus == ShotStatus.Victory)
                {
                    DrawBoard.DrawVictory();
                    
                    return true;
                }
            }

            Console.Clear();
                DrawBoard.DrawCurrentBoard(board);
                Console.WriteLine("   \n\n  Press enter to continue...");
                Console.ReadLine();
                //isPlayer1Turn = false;
                Console.Clear();
                
                return false;
            
        }


        private void TakeTurns()
        {
            bool hasPlayerWon = false;
            while (!hasPlayerWon)
            {
                hasPlayerWon = TakePlayerTurn(p1, player2Board);
                if (hasPlayerWon)
                    break;
                hasPlayerWon = TakePlayerTurn(p2, player1Board);
            }

            
        }


        private bool PlayAgain()
        {
            Console.Clear();
            Console.WriteLine("Would you like to play again? (y/n)");
            string response = Console.ReadLine();
            if (response.ToUpper() == "Y" || response.ToUpper() == "YES")
            {
                player1Board._currentShipIndex = 0;
                player2Board._currentShipIndex = 0;
                Array.Clear(player1Board._ships, 0, 5);
                Array.Clear(player2Board._ships, 0, 5);
                return true;
            }
                
            return false;
        }
        

        private static void CheckOverlapping(ShipPlacement xShipPlacement)
        {
            if (xShipPlacement == ShipPlacement.Overlap || xShipPlacement == ShipPlacement.NotEnoughSpace)
            {
                //Console.WriteLine("Ship overlapped, cannot place here. Please restart the game and fix your own mistakes.");
                throw new Exception("You can't do that.  Please place ship again.");
            }

        }

        
    }
}
