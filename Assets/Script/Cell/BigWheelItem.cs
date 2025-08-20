using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BigWheelItem : MonoBehaviour
{
    public Text text;
    public Image cashIcon;
    public Image goldIcon;
    public Image UndoIcon;
    public Image ShuffleIcon;
    public Image WandIcon;
    
    public void initIcon(string type)
    {
        cashIcon.gameObject.SetActive(false);
        goldIcon.gameObject.SetActive(false);
        UndoIcon.gameObject.SetActive(false);
        ShuffleIcon.gameObject.SetActive(false);
        WandIcon.gameObject.SetActive(false);
        switch (type)
        {
            case "cash":
                cashIcon.gameObject.SetActive(true);
                break;
            case "gold":
                goldIcon.gameObject.SetActive(true);
                break;

            case "undo":
                UndoIcon.gameObject.SetActive(true);
                break;
            case "shuffle":
                ShuffleIcon.gameObject.SetActive(true);
                break;
            case "wand":
                WandIcon.gameObject.SetActive(true);
                break;
        }

    }
}
