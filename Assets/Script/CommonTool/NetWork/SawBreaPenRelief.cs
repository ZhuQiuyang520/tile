/***
 * 
 * 网络请求的get对象
 * 
 * **/
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public class SawBreaPenRelief 
{
    //get的url
    public string Top;
    //get成功的回调
    public Action<UnityWebRequest> PenUrgency;
    //get失败的回调
    public Action PenHone;
    public SawBreaPenRelief(string url,Action<UnityWebRequest> success,Action fail)
    {
        Top = url;
        PenUrgency = success;
        PenHone = fail;
    }
   
}
