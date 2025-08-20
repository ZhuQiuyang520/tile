using UnityEngine;

public class ADebug
{
    private const string TAG = "AGame";
    
    public static void Log(string message)
    {
        Debug.Log($"<color=#CFCFCF><b>{message}</b>\n{TAG} Log</color>");
    }
    
    public static void Error(string message)
    {
        Debug.Log($"<color=red><b>{message}</b>\n{TAG} Error</color>");
    }
    
    public static void Warning(string message)
    {
        Debug.Log($"<color=#FF9400><b>{message}</b>\n{TAG} Warning</color>");
    }
    
    public static void LogError(string message)
    {
        Debug.LogError($"<color=red><b>{message}</b>\n{TAG} LogError</color>");
    }
    
    public static void LogWarning(string message)
    {
        Debug.LogWarning($"<color=#FF9400><b>{message}</b>\n{TAG} LogWarning</color>");
    }

    
}