using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.BLL.Requests
{
    public class TranslateShotRequest
    {

        public static Coordinate TranslateShot(string userInput)
        {
            if (String.IsNullOrWhiteSpace(userInput) || userInput.Length > 3)
                return null;

            int x = GetX(userInput);
            int y = GetY(userInput);
            Coordinate newCoord = new Coordinate(x, y);
            return newCoord;
        }
        
        public static int GetY(string userInput)
        {
            
            string secondValue = userInput.Substring(0, 1);
            int x = 0;
            switch (secondValue.ToUpper())
            {
                case "A":
                    x = 1;
                    break;
                case "B":
                    x = 2;
                    break;
                case "C":
                    x = 3;
                    break;
                case "D":
                    x = 4;
                    break;
                case "E":
                    x = 5;
                    break;
                case "F":
                    x = 6;
                    break;
                case "G":
                    x = 7;
                    break;
                case "H":
                    x = 8;
                    break;
                case "I":
                    x = 9;
                    break;
                case "J":
                    x = 10;
                    break;
                default:
                    Console.WriteLine("{0} is not a valid X coordinate", secondValue);
                    break;
            }
            return x;
        }

        public static int GetX(string userInput)
        {
            
            string firstValue = userInput.Substring(1);
            return int.Parse(firstValue);
        }
    }
}
