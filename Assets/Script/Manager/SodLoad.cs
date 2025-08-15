using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Watermelon;

public class SodLoad : MonoBehaviour , IClickableObject
{
[UnityEngine.Serialization.FormerlySerializedAs("Ani")]    [UnityEngine.Serialization.FormerlySerializedAs("Era")]public Animator Joy;
    public virtual void OnObjectClicked()
    {
        Joy.Play("Cube_change", 0, 0);
        //gameObject.SetActive(false);

        RaftMeeting.instance.SodLoad();
    }
}
