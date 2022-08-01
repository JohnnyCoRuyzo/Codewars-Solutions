using System;

public class Spiralizor
{
    private static int[,] _spiral;
    public static int[,] Spiralize(int size)
    {
      _spiral = new int[size,size];
      var toogleContent = true;
      var variantSize = size;
      var middle = Convert.ToInt32(size/2);
      for(int i = 0; i<middle; i++){
        if(!toogleContent){
          _spiral[i+1,i] = 1;
        }
        else{
          for(int j = 0; j<variantSize; j++){
            _spiral[i,i+j] = 1;
            _spiral[i+j, size-i-1] = 1;
            _spiral[i+variantSize-1, i+j] = 1;
            _spiral[i+j, i] = 1;
          }
          _spiral[i+1,i] = 0;
        }
        variantSize-=2;
        toogleContent = !toogleContent;
        
      }
      if(size%2==0 && toogleContent){
        _spiral[middle-1,middle-1] = 0;
        _spiral[middle,middle-1] = 0;
        _spiral[middle-1,middle] = 0;
        _spiral[middle,middle] = 0;
      }
      else if(size%2!=0 && toogleContent){
        _spiral[middle,middle] = 1;
        _spiral[middle+1,middle] = 0;
        _spiral[middle,middle+1] = 0;
        _spiral[middle+1,middle+1] = 0;
      }
      return _spiral;      
    }
}