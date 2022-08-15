using System.Collections.Generic;
using System;

class Kata
{
  private static List<List<int>> levelList;
  
  public static List<int> TreeByLevels(Node node)
  {
    levelList = new List<List<int>>();
    var resultList = new List<int>();
    if(node != null){
        InsertNumbers(node, 0);
    }
    foreach(var list in levelList){
      resultList.AddRange(list);
    }
    return resultList;
  }
  
  private static void InsertNumbers(Node node, int level){
    if(levelList.Count != level + 1){
      levelList.Add(new List<int>());
    }
    levelList[level].Add(node.Value);

    if(node.Left != null){
      InsertNumbers(node.Left, level + 1);
    }
    if(node.Right != null){
      InsertNumbers(node.Right, level + 1);
    }
  }
}