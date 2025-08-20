using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 由于UI节点上直接使用LayoutGroup组件，会导致无法正确获取子元素的世界坐标
/// 所以自己写一个脚本，实现自动排列
/// </summary>
public class RomePaddlePolarize : MonoBehaviour
{
[UnityEngine.Serialization.FormerlySerializedAs("spacing")]    public float Ascribe= 0;

    // Start is called before the first frame update
    void Start()
    {
        StudentPaddle();
    }

    public void StudentPaddle()
    {
        float y = 0;
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).gameObject.activeSelf)
            {
                RectTransform Dirt= transform.GetChild(i).GetComponent<RectTransform>();
                Dirt.anchorMin = new Vector2(0.5f, 1);
                Dirt.anchorMax = new Vector2(0.5f, 1);
                Dirt.anchoredPosition = new Vector2(Dirt.position.x, y - Dirt.sizeDelta.y / 2 - Ascribe * i);
                y -= Dirt.sizeDelta.y;
            }
        }
    }
}
