using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BlockItem : AUIWidget, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public Image Icon;
    public Text NumTxt;
    public Canvas canvas;    

    public int num;
    public int Index;
    private bool isDragging;

    public bool IsDragging
    {
        get => isDragging;
        set
        {
            isDragging = value;
            canvas.overrideSorting = value;
            if (value)
            {
                canvas.sortingOrder = 2100;
            }
        }
    }

    public void Init(int index, int num)
    {
        this.Index = index;
        Num = num;
        gameObject.name = $"Block_{num}";
        IsDragging = false;
    }
    
    public string GetInfo()
    {
        return $"Block_{num}_{Index}_({Pos.x},{Pos.y})";
    }
    
    public Vector2Int Pos 
    {
        get => AGameManager.GetBlockPos(Index);
        set => Index = AGameManager.GetBlockIndex(value.x, value.y);
    }
    public int Num
    {
        get => num;
        set
        {
            num = value;
            NumTxt.text = num.ToString();
            Icon.sprite = AGameManager.Instance.BlockSprites[num % 20];
        }
    }
    
    public void OnDrag(PointerEventData eventData)
    {
        AEventModule.Send(AEventType.BlockDrag, this, eventData);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        AEventModule.Send(AEventType.BlockBeginDrag, this, eventData);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        AEventModule.Send(AEventType.BlockEndDrag, this, eventData);
    }
}
