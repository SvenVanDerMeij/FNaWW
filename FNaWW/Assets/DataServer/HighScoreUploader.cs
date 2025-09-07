using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Text;

public class HighscoreUploader : MonoBehaviour
{
    private string endpointUrl = "http://localhost:8080/rest/myservice/v1/endpoint"; 

    public void UploadScore(string playerName, int finalScore)
    {
        StartCoroutine(PostScore(playerName, finalScore));
    }

    IEnumerator PostScore(string playerName, int finalScore)
    {
        string json = "{\"Name\":\"" + playerName + "\",\"HighScore\":" + finalScore + "}";
        
        byte[] bodyRaw = Encoding.UTF8.GetBytes(json);
        
        UnityWebRequest request = new UnityWebRequest(endpointUrl, "POST");
        request.uploadHandler = new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");
        
        yield return request.SendWebRequest();

        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError("Error: " + request.error);
        }
        else
        {
            Debug.Log("Score uploaded! Response: " + request.downloadHandler.text);
        }
    }
}