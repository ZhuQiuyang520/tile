using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Tab按钮样式脚本
/// </summary>

public class SumOozeAssumption : MonoBehaviour
{
[UnityEngine.Serialization.FormerlySerializedAs("Icon")]    public Image Bold;
[UnityEngine.Serialization.FormerlySerializedAs("Title")]    public Text Color;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void LayBattleUI(bool active, SumAssumption controller, TabItem tabItem)
    {
        if (Color != null && controller.BattleTread != null)
        {
            Color.color = active ? controller.BattleTread : controller.AffluentTread;
        }
        if (gameObject.GetComponent<Image>() != null && controller.BattleBG != null)
        {
            gameObject.GetComponent<Image>().sprite = active ? controller.BattleBG : controller.AffluentBG;
        }
        if (Bold != null && tabItem.BattleBold != null)
        {
            Bold.sprite = active ? tabItem.BattleBold : tabItem.AffluentBold;
        }
    }
}
