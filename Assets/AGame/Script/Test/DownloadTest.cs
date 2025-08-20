using System;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class DownloadTest : MonoBehaviour
{
    private string remote = "http://localhost:9999/";
    private string path = "Log.txt";
    
    public Button downloadBtn;

    private void Awake()
    {
        Debug.Log("++++++++++++awake" + gameObject.name);
    }

    private void Start()
    {
        // downloadBtn.onClick.AddListener(() =>
        // {
        //     ADebug.Log("开始下载");
        //     var url = remote + path;
        //     string savePath = System.IO.Path.Combine(Application.persistentDataPath, "Remote_Log.txt");
        //     AUtility.Http.DownloadFile(url, savePath, request =>
        //     {
        //         if (request.result == UnityWebRequest.Result.Success)
        //         {
        //             if (request.isDone)
        //             {
        //                 ADebug.Log($"下载完成: {savePath}");
        //             }
        //         }
        //         else
        //         {
        //             ADebug.Log($"下载失败: {request.result}, {request.error}");
        //             if (File.Exists(savePath))
        //             {
        //                 File.Delete(savePath);
        //             }
        //         }
        //         request.Dispose();
        //     });
        // });
    }
}