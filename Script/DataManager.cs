using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

public class DataManager : MonoBehaviour
{
    private string url = "https://script.google.com/macros/s/AKfycbyHzYzp26bHPPFRrKzHlDSBp3aFHx9iE_Pm9Loq9Pz90tyMfg4WId63o4NmQLPlmiNj/exec";  // 替換成你的 Web App 部署網址
    public void Start()
    {
        UploadData("fuckyou", 100); //成功2025/02/15
        Debug.Log("test");
    }
    public void UploadData(string name, int score)
    {
        StartCoroutine(UploadCoroutine(name, score));
    }

    IEnumerator UploadCoroutine(string name, int score)
    {
        // 建立 JSON 物件
        string jsonData = "{\"name\":\"" + name + "\",\"score\":" + score + ",\"time\":\"" + System.DateTime.Now.ToString() + "\"}";
        byte[] postData = Encoding.UTF8.GetBytes(jsonData);

        // 建立請求
        UnityWebRequest request = new UnityWebRequest(url, "POST");
        request.uploadHandler = new UploadHandlerRaw(postData);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");

        // 發送請求
        yield return request.SendWebRequest();

        // 檢查結果
        if (request.result == UnityWebRequest.Result.Success)
        {
            Debug.Log("資料上傳成功：" + request.downloadHandler.text);
        }
        else
        {
            Debug.LogError("資料上傳失敗：" + request.error);
        }
    }
}
