using System;
using System.Text;
using System.Threading;
using System.Globalization;
using System.Numerics;

public static class Decoder
{
    public static string Decode(string p_what)
    {
        var charactersDecoded =  "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789.,? \n";
        var charactersEncoded = "bdfhjlnprtvxzBDFHJLNPRTVXZ13579,\nacegikmoqsuwyACEGIKMOQSUWY02468.?................................. ";
        var charactersNotEncoded = "!@#$%^&*()_+-";
        var decoded = "";
        for(int i = 0; i<p_what.Length;i++){
            if(charactersNotEncoded.IndexOf(p_what[i]+"",0,charactersNotEncoded.Length, StringComparison.CurrentCulture) != -1){
              decoded += p_what[i];
            }
          else{
            var indexE = charactersEncoded.IndexOf(p_what[i]+"",0,charactersEncoded.Length, StringComparison.CurrentCulture)+1;
            var newIndexE = 1;
            for(int j=1;j<=66;j++){
              if( (j*BigInteger.Pow(2,i)-indexE) % 67 == 0){
                newIndexE = j;
                break;
              }
            }
            decoded += charactersDecoded[newIndexE-1];
          }
        }
        return decoded;
    }
}