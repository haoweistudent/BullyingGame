using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

public class DataManager : MonoBehaviour
{
    private string url = "https://script.google.com/macros/s/AKfycbyHzYzp26bHPPFRrKzHlDSBp3aFHx9iE_Pm9Loq9Pz90tyMfg4WId63o4NmQLPlmiNj/exec";  // �������A�� Web App ���p���}
    public void Start()
    {
        UploadData("fuckyou", 100); //���\2025/02/15
        Debug.Log("test");
    }
    public void UploadData(string name, int score)
    {
        StartCoroutine(UploadCoroutine(name, score));
    }

    IEnumerator UploadCoroutine(string name, int score)
    {
        // �إ� JSON ����
        string jsonData = "{\"name\":\"" + name + "\",\"score\":" + score + ",\"time\":\"" + System.DateTime.Now.ToString() + "\"}";
        byte[] postData = Encoding.UTF8.GetBytes(jsonData);

        // �إ߽ШD
        UnityWebRequest request = new UnityWebRequest(url, "POST");
        request.uploadHandler = new UploadHandlerRaw(postData);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");

        // �o�e�ШD
        yield return request.SendWebRequest();

        // �ˬd���G
        if (request.result == UnityWebRequest.Result.Success)
        {
            Debug.Log("��ƤW�Ǧ��\�G" + request.downloadHandler.text);
        }
        else
        {
            Debug.LogError("��ƤW�ǥ��ѡG" + request.error);
        }
    }
}
