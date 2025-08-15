using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BigWheelItem : MonoBehaviour
{
[UnityEngine.Serialization.FormerlySerializedAs("text")]    public Text Fail;
[UnityEngine.Serialization.FormerlySerializedAs("cashIcon")]    public Image TermPost;
[UnityEngine.Serialization.FormerlySerializedAs("goldIcon")]    public Image NamePost;
[UnityEngine.Serialization.FormerlySerializedAs("UndoIcon")]    public Image CubePost;
[UnityEngine.Serialization.FormerlySerializedAs("ShuffleIcon")]    public Image SuccessPost;
[UnityEngine.Serialization.FormerlySerializedAs("WandIcon")]    public Image FarePost;
    
    public void FlawPost(string type)
    {
        TermPost.gameObject.SetActive(false);
        NamePost.gameObject.SetActive(false);
        CubePost.gameObject.SetActive(false);
        SuccessPost.gameObject.SetActive(false);
        FarePost.gameObject.SetActive(false);
        switch (type)
        {
            case "cash":
                TermPost.gameObject.SetActive(true);
                break;
            case "gold":
                NamePost.gameObject.SetActive(true);
                break;

            case "undo":
                CubePost.gameObject.SetActive(true);
                break;
            case "shuffle":
                SuccessPost.gameObject.SetActive(true);
                break;
            case "wand":
                FarePost.gameObject.SetActive(true);
                break;
        }

    }
}
