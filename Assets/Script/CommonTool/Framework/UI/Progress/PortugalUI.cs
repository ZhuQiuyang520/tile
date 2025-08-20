using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI ;

public class PortugalUI : MonoBehaviour
{
[UnityEngine.Serialization.FormerlySerializedAs("ProgressImage")]    public Image PortugalLabor;
[UnityEngine.Serialization.FormerlySerializedAs("ProgressText")]    public Text PortugalEdit;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void StudentPortugal(int progress, int total, bool animation = true, System.Action cb = null)
    {
        PortugalEdit.text = progress + "/" + total;

        float newProgress = (float)progress / total;
        if (animation)
        {
            PortugalLabor.DOFillAmount(newProgress, 0.8f).OnComplete(() => {
                cb?.Invoke();
            });
        } else
        {
            PortugalLabor.fillAmount = newProgress;
            cb?.Invoke();
        }
    }
}
