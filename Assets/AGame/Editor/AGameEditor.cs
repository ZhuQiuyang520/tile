using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

[ExecuteInEditMode]
public class AGameEditor
{
    [MenuItem("AGame/ClearPlayerPrefs")]
    public static void ClearPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
    }

    #region 纯A包AppLovin SdkKey加密工具
    
    [MenuItem("AGame/加密SdkKey")]
    static void EncryptDES()
    {
        var adManager = GameObject.FindObjectOfType<A_ADManager>();
        if (adManager == null)
        {
            ADebug.LogError("未找到 A_ADManager 实例");
            return;
        }
        
        // string sdkKey = "Fs-cUqJfRU6DI-3nHAtCUubM2g2mHMT4kl_2_v9IyohMfXicNfA0eEwvSJ6gvrtpXtmu2TpTdL-QrLAMqwaXPS";
        string sdkKey = "LMmBFSE51WdkESTJtltpBCSg5i7E2oerHByZfuBmz0RH8sas13CuJ67hXd_Q5hDeJTUyhArd63GezDaRTOUC6U";
        string encryptSdkKey = AUtility.Crypto.EncryptDES(sdkKey);
        AppLovinSettings.Instance.SdkKey = encryptSdkKey;
        
        adManager.SdkKey = encryptSdkKey;

        ADebug.Log($"加密后的SdkKey: {encryptSdkKey}\nsource: {sdkKey}");
        
        // 手动标记包含 A_ADManager 的场景为已修改
        EditorSceneManager.MarkSceneDirty(adManager.gameObject.scene);
        
        // 自动保存打开的场景
        if (EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo())
        {
            ADebug.Log("场景已保存");
        }
        else
        {
            ADebug.Log("用户取消保存或选择不保存场景");
        }
    }
    
    [MenuItem("AGame/解密SdkKey")]
    static void DecryptDES()
    {
        var adManager = GameObject.FindObjectOfType<A_ADManager>();
        if (adManager == null)
        {
            ADebug.LogError("未找到 A_ADManager 实例");
            return;
        }
    
        string encryptSdkKey = adManager.SdkKey;
        string decryptSdkKey = AUtility.Crypto.DecryptDES(encryptSdkKey);
        
        AppLovinSettings.Instance.SdkKey = decryptSdkKey;
        GameObject.FindObjectOfType<A_ADManager>().SdkKey = decryptSdkKey;
        ADebug.Log($"解密后的SdkKey: {decryptSdkKey}\nsource: {encryptSdkKey}");
        
        // 手动标记包含 A_ADManager 的场景为已修改
        EditorSceneManager.MarkSceneDirty(adManager.gameObject.scene);
        
        // 弹出对话框询问用户是否保存修改的场景
        if (EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo())
        {
            ADebug.Log("场景已保存");
        }
        else
        {
            ADebug.Log("用户取消保存或选择不保存场景");
        }
    }
    #endregion
}