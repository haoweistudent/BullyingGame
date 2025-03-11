using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;


public class UISystem : MonoBehaviour
{
    public Text[] Question_text; //UI元件
    private List<Question_Data> QData;
    public int Q_Number = 0;//第幾題
    public int maxQuestion = 22;//最大題目數
    public GameObject gamePanel;
    public GameObject ScreenPanel;
    float timeCount = 0f;
    public int score = 0;
    DataSaveManager _DSM= new DataSaveManager();
    void Start()
        {
              Q_Number = PlayerPrefs.GetInt("Q_number",0);
              setJson();
              setUI();
              score = 0;
        }

        // Update is called once per frame
        void Update()
        {
     

        }
   

   
     
   
    //包裝json檔案
    [System.Serializable]
    public class QuestionListWrapper
    {
        public List<Question_Data> Questions;
    }
    [System.Serializable]
    public class Question_Data
    {
        public string Q;
        public string A;
        public string B;
        public string C;
        public string D;
        public string Ans;//答案
    }

    void setJson()
    {
        UnityEngine.TextAsset JsonFile = Resources.Load<UnityEngine.TextAsset>("QuestionData"); //讀取"Resources"資料夾File
        QData = JsonUtility.FromJson<QuestionListWrapper>(JsonFile.text).Questions;
    }
    public void setUI()
    {
            
            Question_text[0].text = $"{QData[Q_Number].Q}\n \n{QData[Q_Number].A}\n{QData[Q_Number].B}\n{QData[Q_Number].C}\n{QData[Q_Number].D}";
      
        
    }
     
 
    public void sent_QuestionAns(string Ans)
    {
         score+= _DSM.CountScore("霸凌");
         Next_Question();


    }
    void Next_Question()
    {
        timeCount = 0;
        Q_Number++; 
        if(Q_Number >= maxQuestion)
        {
            gamePanel.SetActive(false);
            ScreenPanel.SetActive(true);
        }
        setUI();


              
       

    }
  public void endGame()
    {
        gameSave(Q_Number);
        Application.Quit();
    }
  public void gameSave(int n)
    {
        PlayerPrefs.SetInt("Q_number", n);//紀錄回答到第幾題
    }
    public void ReDate()
    {
        //重設存檔
        PlayerPrefs.DeleteAll();
    }
}
