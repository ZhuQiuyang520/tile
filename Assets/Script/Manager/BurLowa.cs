using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Watermelon;

public class BurLowa : MonoBehaviour , IClickableObject
{
[UnityEngine.Serialization.FormerlySerializedAs("Ani")]    public Animator Zoo;
    public virtual void OnObjectClicked()
    {
        Zoo.Play("Cube_change", 0, 0);
        //gameObject.SetActive(false);

        OilyVillage.instance.BurLowa();
    }
}
