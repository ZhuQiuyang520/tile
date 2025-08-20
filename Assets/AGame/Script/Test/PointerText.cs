using UnityEngine;
using UnityEngine.EventSystems;

public class PointerText : MonoBehaviour
{
    public PointerEvent OnPointerEvent;

    private void Start()
    {
        OnPointerEvent.onDrag += OnDrag;
    }

    private void OnDrag(PointerEventData eventData)
    {
        Debug.Log("OnDrag");
        // 获取当前物体的RectTransform组件
        RectTransform rectTransform = transform as RectTransform;
        if (rectTransform != null)
        {
            // 获取父对象的RectTransform（通常是Canvas或父UI元素）
            RectTransform parentRect = rectTransform.parent as RectTransform;
            Vector2 localPosition;
            
            // 将屏幕坐标转换为父对象RectTransform下的本地坐标
            // 最后一个参数为null表示使用Canvas的渲染相机（Overlay模式下可省略）
            if (RectTransformUtility.ScreenPointToLocalPointInRectangle(
                    parentRect, 
                    eventData.position, 
                    Camera.main, 
                    out localPosition))
            {
                // 设置本地坐标（保持Z轴不变）
                rectTransform.localPosition = new Vector3(
                    localPosition.x, 
                    localPosition.y, 
                    0);
            }
        }
    }
}