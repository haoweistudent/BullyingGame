using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;



public class UISystem : MonoBehaviour
{
    public Text[] Question_text; //UI����
    private List<Question_Data> QData;
    public int Q_Number = 0;//�ĴX�D
    public int maxQuestion = 22;//�̤j�D�ؼ�
    public GameObject gamePanel;
    public GameObject ScreenPanel;
    float timeCount = 0f;

    void Start()
        {
        Q_Number = 0;
              setJson();
               UpdateUI();
        }

        // Update is called once per frame
        void Update()
        {
     

        }
   

   
     
   
    //�]��json�ɮ�
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
        public string Ans;//����
    }
    void setJson()
    {
        UnityEngine.TextAsset JsonFile = Resources.Load<UnityEngine.TextAsset>("QuestionData"); //Ū��"Resources"��Ƨ�File
        QData = JsonUtility.FromJson<QuestionListWrapper>(JsonFile.text).Questions;
    }
    public void UpdateUI()
    {
            
            Question_text[0].text = $"{QData[Q_Number].Q}\n \n{QData[Q_Number].A}\n{QData[Q_Number].B}\n{QData[Q_Number].C}\n{QData[Q_Number].D}";
            //timer(10f);
        
    }
     
    void timer(float Qtime)
    {
        
        timeCount += Time.deltaTime;
        //Question_text[5].text = $"time:{timeCount}";
                if (timeCount> Qtime)
                {
                    timeCount = 0;
                }

       
        

        
    }   
    public void sent_QuestionAns(string Ans)
    {
        if (Ans == QData[Q_Number].Ans)
        {
            Next_Question();
        }
        else
        {
            Next_Question();
        }

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
        UpdateUI();
       

    }
   

}
