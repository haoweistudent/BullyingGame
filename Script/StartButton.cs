using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour
{
    public GameObject gamePanel;
    public GameObject beginScreen;

    private void Start()
    {
       
    }
    public void gameStart()
    {
        gamePanel.SetActive(true);
        beginScreen.SetActive(false);
  
    }
}
