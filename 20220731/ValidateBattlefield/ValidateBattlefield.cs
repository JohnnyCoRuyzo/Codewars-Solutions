namespace Solution {
  using System;
  using System.Linq;
  
  public class BattleshipField {
      private static int[,] _field;

      public static bool ValidateBattlefield(int[,] field) {
        _field = field;
        var battleShipsFound = FindTypeOfShip(4,1);
        var cruiserShipsFound = FindTypeOfShip(3,2);
        var destroyerShipsFound = FindTypeOfShip(2,3);
        var submarineShipsFound = FindTypeOfShip(1,4);
        return battleShipsFound && cruiserShipsFound && destroyerShipsFound && submarineShipsFound;
      }

      private static bool FindTypeOfShip(int typeOfShip, int ammountOfShips){
        var shipsCount = ammountOfShips;
        foreach(var row in Enumerable.Range(0,11-typeOfShip)){
            foreach(var col in Enumerable.Range(0,11-typeOfShip)){
                if(_field[row,col] == 1){
                    var horizontalShip = 0;
                    var verticalShip = 0;
                    foreach(var cell in Enumerable.Range(0,typeOfShip)){
                      verticalShip += _field[row+cell,col];
                      horizontalShip += _field[row,col+cell];
                    }

                    if(horizontalShip==typeOfShip||verticalShip==typeOfShip){
                      shipsCount--;
                      foreach(int cell in Enumerable.Range(0,typeOfShip)){
                        if(verticalShip==typeOfShip){
                          _field[row+cell,col] = 2;
                          if(VerticalSurrounding(typeOfShip, cell, row, col)){
                            return false;
                          }
                        }
                        if(horizontalShip==typeOfShip){
                          _field[row,col+cell] = 2;
                          if(HorizontalSurrounding(typeOfShip, cell, row, col)){
                            return false;
                          }
                        }
                      }
                    }
                }
            }
        }
        return shipsCount == 0;
      }

      private static bool VerticalSurrounding(int typeOfShip, int cell, int row, int col){
         return (row > 0 && col > 0) && (
                                  ((cell == 0) && (_field[row+cell-1,col-1] == 2 || _field[row+cell-1,col] == 2 || _field[row+cell-1,col+1] == 2)) ||
                                  ((cell == typeOfShip) && (_field[row+cell+1,col-1] == 2 || _field[row+cell+1,col] == 2 || _field[row+cell+1,col+1] == 2)) ||
                                  (_field[row+cell,col-1] == 2 || _field[row+cell,col+1] == 2));
      }
    
      private static bool HorizontalSurrounding(int typeOfShip, int cell, int row, int col){
         return (row > 0 && col > 0) && (
                                 ((cell == 0) && (_field[row-1,col+cell-1] == 2 || _field[row-1,col+cell] == 2 || _field[row-1,col+cell+1] == 2)) || 
                                 ((cell == typeOfShip) && (_field[row+1,col+cell-1] == 2 || _field[row+1,col+cell] == 2 || _field[row+1,col+cell+1] == 2)) ||
                                 (_field[row-1,col+cell] == 2 || _field[row+1,col+cell] == 2));
      }
    }
}