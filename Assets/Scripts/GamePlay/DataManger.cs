using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DataManger 
{
   public static void SaveData(string dataName, int value)
   {
      PlayerPrefs.SetInt(dataName,value);
      
   }

   public static int GetDate(string dataName)
   {
      return PlayerPrefs.GetInt(dataName);
   }
}
