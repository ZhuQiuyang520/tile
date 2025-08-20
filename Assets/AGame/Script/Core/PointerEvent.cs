using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class PointerEvent : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    private void OnDestroy()
    {
        onPointerDown = null;
        onPointerUp = null;
        onDrag = null;
        onPointerClick = null;
    }

    #region 拖拽事件
    
    private bool isDragging;
    private Vector2 startPosition;
    private Vector2 endPosition;
    // 滑动阈值，可根据实际情况调整
    public float swipeThreshold = 5; 
    public event Action<PointerEventData> onBeginDrag;
    public event Action<PointerEventData> onEndDrag;
    public event Action<PointerEventData> onDrag;

    public void OnBeginDrag(PointerEventData eventData)
    {
        isDragging = true;
        startPosition = eventData.position;
        onBeginDrag?.Invoke(eventData);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        isDragging = false;
        onEndDrag?.Invoke(eventData);
    }
    
    public void OnDrag(PointerEventData eventData)
    {
        if (isDragging)
        {
            float swipeDistance = Mathf.Abs(eventData.position.x - startPosition.x);
            if (swipeDistance >= swipeThreshold)
            {
                endPosition = eventData.position;
                onDrag?.Invoke(eventData);
                startPosition = eventData.position;
            }
        }
    }

    #endregion

    #region 点击事件
    
    public event Action<PointerEventData> onPointerDown;
    public event Action<PointerEventData> onPointerUp;
    public event Action<PointerEventData> onPointerClick;
    
    public void OnPointerDown(PointerEventData eventData)
    {
        onPointerDown?.Invoke(eventData);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        onPointerUp?.Invoke(eventData);
    }
    
    public void OnPointerClick(PointerEventData eventData)
    {
        onPointerClick?.Invoke(eventData);
    }

    #endregion

    
    
}