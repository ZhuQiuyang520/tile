using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System;
public class SlayNeverSpiral : BeamNonliving<SlayNeverSpiral>
{
    public string version = "1.2";
    public string OilyDime= SawSelfEke.instance.OilyDime;
    //channel
#if UNITY_IOS
    private string Flatter= "AppStore";
#elif UNITY_ANDROID
    private string Channel = "GooglePlay";
#else
    private string Channel = "GooglePlay";
#endif


    private void OnApplicationPause(bool pause)
    {
        SlayNeverSpiral.PenMonopoly().ErieOilyPortugal();
    }
    
    public Text Wren;

    protected override void Awake()
    {
        base.Awake();
        
        version = Application.version;
        StartCoroutine(nameof(DoorDeviate));
    }
    IEnumerator DoorDeviate()
    {
        while (true)
        {
            yield return new WaitForSeconds(120f);
            SlayNeverSpiral.PenMonopoly().ErieOilyPortugal();
        }
    }
    private void Start()
    {
        if (LuckHaveMimetic.PenSon("event_day") != DateTime.Now.Day && LuckHaveMimetic.PenAcross("user_servers_id").Length != 0)
        {
            LuckHaveMimetic.LaySon("event_day", DateTime.Now.Day);
        }
    }
    public void JumpByMuteNever(string event_id)
    {
        JumpNever(event_id);
    }
    public void ErieOilyPortugal(List<string> valueList = null)
    {
        if (LuckHaveMimetic.PenZigzag(CLagoon.No_WintertimeIsleBank) == 0)
        {
            LuckHaveMimetic.LayZigzag(CLagoon.No_WintertimeIsleBank, LuckHaveMimetic.PenZigzag(CLagoon.No_IsleBank));
        }
        if (LuckHaveMimetic.PenZigzag(CLagoon.No_WintertimeTusk) == 0)
        {
            LuckHaveMimetic.LayZigzag(CLagoon.No_WintertimeTusk, LuckHaveMimetic.PenZigzag(CLagoon.No_Steer));
        }
        if (valueList == null)
        {
            valueList = new List<string>() {
                LuckHaveMimetic.PenMaple("CashOut_Money").ToString(),
                LuckHaveMimetic.PenAcross(CLagoon.BankFloral),
                LuckHaveMimetic.PenMaple("CashOut_Money_All").ToString(),
                LuckHaveMimetic.PenMaple(CLagoon.BankFloral_All).ToString(),
                (PlayerPrefs.GetInt(CLagoon.No_RyeClump) + 1).ToString(),

                
                //LuckHaveMimetic.GetInt(CLagoon.sv_AlreadyPassLevels).ToString(),
                //LuckHaveMimetic.GetString(CLagoon.sv_CumulativeCash),
                //LuckHaveMimetic.GetFloat(CLagoon.sv_TotalGameTime).ToString()
                //LuckHaveMimetic.GetInt(SlotConfig.sv_SlotSpinCount).ToString()
            };
        }
        
        if (LuckHaveMimetic.PenAcross(CLagoon.No_TimidRegimeOf) == null)
        {
            return;
        }
        WWWForm wwwForm = new WWWForm();
        wwwForm.AddField("gameCode", OilyDime);
        wwwForm.AddField("userId", LuckHaveMimetic.PenAcross(CLagoon.No_TimidRegimeOf));

        wwwForm.AddField("gameVersion", version);

        wwwForm.AddField("channel", Flatter);

        for (int i = 0; i < valueList.Count; i++)
        {
            wwwForm.AddField("resource" + (i + 1), valueList[i]);
        }



        StartCoroutine(JumpSlay(SawSelfEke.instance.FormTop + "/api/client/game_progress", wwwForm,
        (error) =>
        {
            Debug.Log(error);
        },
        (message) =>
        {
            Debug.Log(message);
        }));
    }
    public void JumpNever(string event_id, string p1 = null, string p2 = null, string p3 = null, string p4 = null, string p5 = null, string p6 = null)
    {
        if (Wren != null)
        {
            if (int.Parse(event_id) < 9100 && int.Parse(event_id) >= 9000)
            {
                if (p1 == null)
                {
                    p1 = "";
                }
                Wren.text += "\n" + DateTime.Now.ToString() + "id:" + event_id + "  p1:" + p1;
            }
        }
        if (LuckHaveMimetic.PenAcross(CLagoon.No_TimidRegimeOf) == null)
        {
            SawSelfEke.instance.Chafe();
            return;
        }
        WWWForm wwwForm = new WWWForm();
        wwwForm.AddField("gameCode", OilyDime);
        wwwForm.AddField("userId", LuckHaveMimetic.PenAcross(CLagoon.No_TimidRegimeOf));
        //Debug.Log("userId:" + LuckHaveMimetic.GetString(CLagoon.sv_LocalServerId));
        wwwForm.AddField("version", version);
        //Debug.Log("version:" + version);
        wwwForm.AddField("channel", Flatter);
        //Debug.Log("channel:" + channal);
        wwwForm.AddField("operateId", event_id);
        Debug.Log("operateId:" + event_id);


        if (p1 != null)
        {
            wwwForm.AddField("params1", p1);
        }
        if (p2 != null)
        {
            wwwForm.AddField("params2", p2);
        }
        if (p3 != null)
        {
            wwwForm.AddField("params3", p3);
        }
        if (p4 != null)
        {
            wwwForm.AddField("params3", p4);
        }
        if (p5 != null)
        {
            wwwForm.AddField("params3", p5);
        }
        if (p6 != null)
        {
            wwwForm.AddField("params3", p6);
        }
        StartCoroutine(JumpSlay(SawSelfEke.instance.FormTop + "/api/client/log", wwwForm,
        (error) =>
        {
            Debug.Log(error);
        },
        (message) =>
        {
            Debug.Log(message);
        }));
    }
    IEnumerator JumpSlay(string _url, WWWForm wwwForm, Action<string> fail, Action<string> success)
    {
        //Debug.Log(SerializeDictionaryToJsonString(dic));
        using UnityWebRequest request = UnityWebRequest.Post(_url, wwwForm);
        yield return request.SendWebRequest();
        if (request.isNetworkError || request.isNetworkError)
        {
            fail(request.error);
            LogDisease();
        }
        else
        {
            success(request.downloadHandler.text);
            LogDisease();
        }
    }
    private void LogDisease()
    {
        StopCoroutine(nameof(JumpSlay));
    }


}