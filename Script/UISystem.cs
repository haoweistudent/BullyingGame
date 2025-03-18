using System.Collections;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
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
    public int maxQuestion = 17;//最大題目數
    public GameObject gamePanel;
    public GameObject ScreenPanel;
    public int score = 0;
    DataSaveManager _DSM= new DataSaveManager();
    public Text end_Panel;
    public Image end_Image;
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
        Question_text[0].text = $"{QData[Q_Number].Q}";
    }
     
 
    public void sent_QuestionAns(string Ans)
    {
        string[] text;

        
         score+= _DSM.CountScore($"{Q_(Ans)}");
         Next_Question();


    }
    string Q_(string a)
    {
        //這個function 是做文字處理
        if( a == "A") return (QData[Q_Number].A);
        if( a == "B") return (QData[Q_Number].B);
        if( a == "C") return (QData[Q_Number].C);
        if( a == "D") return (QData[Q_Number].D);
        return "error";

    
    }
    void Next_Question()
    {
        
        Q_Number++; 
        if(Q_Number >= maxQuestion)
        {
            gamePanel.SetActive(false);
            ScreenPanel.SetActive(true);
            ProcessScore(score);
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
    void ProcessScore(int Score)
    {
        if (Score >= 17 && Score <= 28)
        {
           
}
        if (Score >= 29 && Score <= 39)
        {

        }
        if (Score >=40 && Score <= 51)
        {

        }
    }
    
}
