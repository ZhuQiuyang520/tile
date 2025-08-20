/**
 * 
 * 网络请求的post对象
 * 
 * ***/
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public class SawBreaSlayRelief 
{
    //post请求地址
    public string URL;
    //post的数据表单
    public WWWForm Work;
    //post成功回调
    public Action<UnityWebRequest> SlayUrgency;
    //post失败回调
    public Action SlayHone;
    public SawBreaSlayRelief(string url,WWWForm  form,Action<UnityWebRequest> success,Action fail)
    {
        URL = url;
        Work = form;
        SlayUrgency = success;
        SlayHone = fail;
    }
}
