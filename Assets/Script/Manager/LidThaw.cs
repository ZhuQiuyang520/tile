using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Watermelon;

public class LidThaw : MonoBehaviour , IClickableObject
{
[UnityEngine.Serialization.FormerlySerializedAs("Ani")]    public Animator Era;
    public virtual void OnObjectClicked()
    {
        Era.Play("Cube_change", 0, 0);
        //gameObject.SetActive(false);

        RoadBrother.instance.LidThaw();
    }
}
