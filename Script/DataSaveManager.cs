using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataSaveManager : MonoBehaviour
{
   public int  CountScore(string Data)
    {
      //�Q��1 ��2 �n3
       if(Data == "�Q��")
        {
            return 1;
        }
       else if (Data =="��")
        {
            return 2;
        }
       else if (Data =="�n")
        {
            return 3;
        }
        return 0;
    }

}
