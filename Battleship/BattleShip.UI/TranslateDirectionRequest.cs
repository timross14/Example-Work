using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShip.BLL.Requests;

namespace BattleShip.UI
{
   public class TranslateDirectionRequest
    {
       public static ShipDirection TranslateDirection(string request)
       {
           switch ((request).ToUpper())
           {
               case "UP":
                   return ShipDirection.Up;
               case "DOWN":
                   return ShipDirection.Down;
               case "LEFT":
                   return ShipDirection.Left;
               case "RIGHT":
                   return ShipDirection.Right;
               default:
                   throw new Exception("Please enter value in the following format: Up, Down, Left, Right!!!");

           }
       }
    }
}
