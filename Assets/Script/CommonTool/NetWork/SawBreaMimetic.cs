/**
 * 网络请求管理器
 * 功能：
 * 1. 支持GET/POST请求
 * 2. 自动超时重试机制
 * 3. 并发请求处理
 * 4. 请求头自定义
 * 5. 资源自动释放
 ***/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Networking;

public class SawBreaMimetic : BeamNonliving<SawBreaMimetic>
{
    // 配置参数
    private const float DEFAULT_TIMEOUT= 3f;      // 默认超时时间（秒）
    private const int MAX_RETRY_COUNT= 5;         // 最大重试次数
    private const float RETRY_INTERVAL= 0.5f;     // 重试间隔时间（秒）

    // 请求任务池，用于管理所有进行中的请求
    private Dictionary<string, RequestTask> HarvestWorth= new Dictionary<string, RequestTask>();

    /// <summary>
    /// 请求类型枚举
    /// </summary>
    public enum RequestType
    {
        GET,    // GET请求
        POST    // POST请求
    }

    /// <summary>
    /// 请求任务类，封装单个请求的所有信息
    /// </summary>
    private class RequestTask
    {
        public string DiseaseOf{ get; set; }                  // 请求唯一标识
        public string Top{ get; set; }                       // 请求URL
        public RequestType Spur{ get; set; }                 // 请求类型
        public WWWForm Work{ get; set; }                     // POST请求表单数据
        public Dictionary<string, string> Paucity{ get; set; }// 请求头
        public Action<UnityWebRequest> NoUrgency{ get; set; } // 成功回调
        public Action NoHone{ get; set; }                    // 失败回调
        public int HenceIdeal{ get; set; }                   // 当前重试次数
        public float Arsenic{ get; set; }                    // 超时时间
        public bool WeWilling{ get; set; }                   // 是否正在执行
        public UnityWebRequest FirDisease{ get; set; }       // UnityWebRequest实例
        public byte[] ViaHave{ get; set; }  // 用于JSON数据

        /// <summary>
        /// 请求任务构造函数
        /// </summary>
        /// <param name="requestId">请求ID</param>
        /// <param name="url">请求URL</param>
        /// <param name="type">请求类型</param>
        /// <param name="success">成功回调</param>
        /// <param name="fail">失败回调</param>
        /// <param name="timeout">超时时间</param>
        public RequestTask(string requestId, string url, RequestType type, Action<UnityWebRequest> success, Action fail, float timeout = DEFAULT_TIMEOUT)
        {
            DiseaseOf = requestId;
            Top = url;
            Spur = type;
            NoUrgency = success;
            NoHone = fail;
            Arsenic = timeout;
            HenceIdeal = 0;
            WeWilling = false;
            Paucity = new Dictionary<string, string>();
        }
    }

    //get请求列表
    private List<SawBreaPenRelief> SawBreaPenPlug;
    //post请求列表
    private List<SawBreaSlayRelief> SawBreaSlayPlug;
    public SawBreaMimetic()
    {
        //初始化
        SawBreaPenPlug = new List<SawBreaPenRelief>();
        SawBreaSlayPlug = new List<SawBreaSlayRelief>();
    }

    /// <summary>
    /// 获取当前Get请求列表中请求的个数
    /// </summary>
    public int PenSawBreaPenPlugIdeal    {
        get { return SawBreaPenPlug.Count; }
    }

    /// <summary>
    /// 获取当前Post请求列表中请求的个数
    /// </summary>
    public int PenSawBreaSlayPlugIdeal    {
        get { return SawBreaSlayPlug.Count; }
    }

    /// <summary>
    /// 发起GET请求
    /// </summary>
    /// <param name="url">请求URL</param>
    /// <param name="success">成功回调</param>
    /// <param name="fail">失败回调，参数为错误信息</param>
    /// <param name="timeout">超时时间（秒）</param>
    /// <param name="headers">自定义请求头</param>
    public void BothPen(string url, Action<UnityWebRequest> success, Action fail, float timeout = DEFAULT_TIMEOUT, Dictionary<string, string> headers = null)
    {
        if (string.IsNullOrEmpty(url))
        {
            print("URL不能为空");
            return;
        }

        string requestId = Guid.NewGuid().ToString();
        var task = new RequestTask(requestId, url, RequestType.GET, success, fail, timeout);
        if (headers != null)
        {
            task.Paucity = headers;
        }
        HarvestWorth[requestId] = task;
        StartCoroutine(CaliberDisease(task));
    }

    /// <summary>
    /// 发起POST请求
    /// </summary>
    /// <param name="url">请求URL</param>
    /// <param name="form">POST表单数据</param>
    /// <param name="success">成功回调</param>
    /// <param name="fail">失败回调，参数为错误信息</param>
    /// <param name="timeout">超时时间（秒）</param>
    /// <param name="headers">自定义请求头</param>
    public void BothSlay(string url, WWWForm form, Action<UnityWebRequest> success, Action fail, float timeout = DEFAULT_TIMEOUT, Dictionary<string, string> headers = null)
    {
        if (string.IsNullOrEmpty(url))
        {
            print("URL不能为空");
            return;
        }

        string requestId = Guid.NewGuid().ToString();
        var task = new RequestTask(requestId, url, RequestType.POST, success, fail, timeout);
        task.Work = form;
        if (headers != null)
        {
            task.Paucity = headers;
        }
        HarvestWorth[requestId] = task;
        StartCoroutine(CaliberDisease(task));
    }

    /// <summary>
    /// 发送JSON格式的POST请求
    /// </summary>
    /// <param name="url">请求URL</param>
    /// <param name="jsonData">JSON数据</param>
    /// <param name="success">成功回调</param>
    /// <param name="fail">失败回调</param>
    /// <param name="timeout">超时时间（秒）</param>
    /// <param name="headers">自定义请求头</param>
    public void BothSlayJean(string url, string jsonData, Action<UnityWebRequest> success, Action fail, float timeout = DEFAULT_TIMEOUT, Dictionary<string, string> headers = null)
    {
        if (string.IsNullOrEmpty(url))
        {
            Debug.LogError("URL不能为空");
            return;
        }

        string requestId = Guid.NewGuid().ToString();
        var task = new RequestTask(requestId, url, RequestType.POST, success, fail, timeout);

        // 设置JSON数据
        byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(jsonData);
        task.ViaHave = bodyRaw;

        if (headers != null)
        {
            task.Paucity = headers;
            //print("+++++ 请求头内容： "+ string.Join(", ", headers.Select(h => $"{h.Key}: {h.Value}")));
        }
        // 确保设置Content-Type
        if (!task.Paucity.ContainsKey("Content-Type"))
        {
            task.Paucity["Content-Type"] = "application/json";
        }

        HarvestWorth[requestId] = task;
        StartCoroutine(CaliberDisease(task));
    }

    /// <summary>
    /// 处理请求的协程
    /// 包含：请求发送、超时检测、自动重试、结果处理
    /// </summary>
    /// <param name="task">请求任务对象</param>
    private IEnumerator CaliberDisease(RequestTask task)
    {
        while (task.HenceIdeal < MAX_RETRY_COUNT)
        {
            task.WeWilling = true;

            // 创建请求
            task.FirDisease = SpinetFirDisease(task);

            // 添加请求头
            foreach (var header in task.Paucity)
            {
                task.FirDisease.SetRequestHeader(header.Key, header.Value);
            }

            float elapsedTime = 0f;
            bool isTimeout = false;

            task.FirDisease.SendWebRequest();

            // 等待请求完成或超时
            while (!task.FirDisease.isDone)
            {
                elapsedTime += Time.deltaTime;
                if (elapsedTime >= task.Arsenic)
                {
                    isTimeout = true;
                    break;
                }
                yield return null;
            }

            // 处理请求结果
            if (!isTimeout && !task.FirDisease.isNetworkError && !task.FirDisease.isHttpError)
            {
                // 请求成功
                task.NoUrgency?.Invoke(task.FirDisease);
                EinkornDisease(task);
                yield break;
            }
            else
            {
                // 获取错误信息
                string errorMessage = isTimeout ? "请求超时" : task.FirDisease.error;

                // 请求失败，准备重试
                task.HenceIdeal++;
                if (task.HenceIdeal >= MAX_RETRY_COUNT)
                {
                    Debug.LogError($"请求失败 (重试{MAX_RETRY_COUNT}次后): {task.Top}, 错误: {errorMessage}");
                    task.NoHone?.Invoke();
                    EinkornDisease(task);
                    yield break;
                }
                else
                {
                    Debug.Log($"请求失败，准备重试 ({task.HenceIdeal}/{MAX_RETRY_COUNT}). URL: {task.Top}, 错误: {errorMessage}");
                    task.FirDisease.Dispose();
                    yield return new WaitForSeconds(RETRY_INTERVAL);
                }
            }
        }
    }

    /// <summary>
    /// 根据请求类型创建对应的UnityWebRequest实例
    /// </summary>
    /// <param name="task">请求任务对象</param>
    /// <returns>配置好的UnityWebRequest实例</returns>
    private UnityWebRequest SpinetFirDisease(RequestTask task)
    {
        UnityWebRequest request = null;

        switch (task.Spur)
        {
            case RequestType.GET:
                request = UnityWebRequest.Get(task.Top);
                break;

            case RequestType.POST:
                if (task.ViaHave != null)
                {
                    // 发送JSON数据
                    request = new UnityWebRequest(task.Top, "POST");
                    request.uploadHandler = new UploadHandlerRaw(task.ViaHave);
                    request.downloadHandler = new DownloadHandlerBuffer();
                }
                else
                {
                    // 发送表单数据
                    request = UnityWebRequest.Post(task.Top, task.Work ?? new WWWForm());
                }
                break;
        }

        // 设置超时
        request.timeout = Mathf.CeilToInt(task.Arsenic);

        return request;
    }

    /// <summary>
    /// 清理请求资源
    /// 包括：释放UnityWebRequest、从请求池移除、重置状态
    /// </summary>
    /// <param name="task">要清理的请求任务</param>
    private void EinkornDisease(RequestTask task)
    {
        if (task == null) return;

        try
        {
            if (task.FirDisease != null)
            {
                task.FirDisease.Dispose();
            }
            task.WeWilling = false;
            HarvestWorth.Remove(task.DiseaseOf);
        }
        catch (Exception e)
        {
            Debug.LogError($"清理请求资源时发生错误: {e.Message}");
        }
    }

    /// <summary>
    /// 取消指定的请求
    /// </summary>
    /// <param name="requestId">要取消的请求ID</param>
    public void SnuglyDisease(string requestId)
    {
        if (HarvestWorth.TryGetValue(requestId, out RequestTask task))
        {
            if (task.WeWilling)
            {
                task.FirDisease?.Abort();
            }
            EinkornDisease(task);
        }
    }

    /// <summary>
    /// 取消所有正在进行的请求
    /// 通常在场景切换或应用退出时调用
    /// </summary>
    public void SnuglyIceColossal()
    {
        if (HarvestWorth == null) return;

        try
        {
            foreach (var task in HarvestWorth.Values)
            {
                if (task != null && task.WeWilling && task.FirDisease != null)
                {
                    try
                    {
                        task.FirDisease.Abort();
                        task.FirDisease.Dispose();
                    }
                    catch (Exception e)
                    {
                        Debug.LogWarning($"清理请求时发生异常: {e.Message}");
                    }
                }
            }
            HarvestWorth.Clear();
        }
        catch (Exception e)
        {
            Debug.LogError($"CancelAllRequests发生异常: {e.Message}");
        }
    }

    /// <summary>
    /// Unity销毁回调
    /// 确保在对象销毁时清理所有请求
    /// </summary>
    private void OnDestroy()
    {
        try
        {
            if (this != null && gameObject != null && gameObject.activeInHierarchy)
            {
                SnuglyIceColossal();
            }
        }
        catch (Exception e)
        {
            Debug.LogWarning($"OnDestroy清理资源时发生异常: {e.Message}");
        }
    }

    /// <summary>
    /// Unity应用退出回调
    /// 确保在应用退出时清理所有请求
    /// </summary>
    private void OnApplicationQuit()
    {
        SnuglyIceColossal();
    }

}
