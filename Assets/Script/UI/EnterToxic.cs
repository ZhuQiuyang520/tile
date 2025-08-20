using UnityEngine;
using UnityEngine.UI;

/// <summary> 屏蔽界面 阻止玩家操作 退出游戏 </summary>
public class EnterToxic : FormUIBasin
{
[UnityEngine.Serialization.FormerlySerializedAs("InfoText")]    public Text SelfEdit;
[UnityEngine.Serialization.FormerlySerializedAs("QuitBtn")]    public Button RollCab;

    private void Start()
    {
        RollCab.onClick.AddListener(Application.Quit);
    }

    public void BlueSelf(string info)
    {
        SelfEdit.text = info;
    }
}
