using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataSaveManager : MonoBehaviour
{
   public int  CountScore(string Data)
    {
      //霸凌1 中2 好3
       if(Data == "霸凌")
        {
            return 1;
        }
       else if (Data =="中")
        {
            return 2;
        }
       else if (Data =="好")
        {
            return 3;
        }
        return 0;
    }

}
