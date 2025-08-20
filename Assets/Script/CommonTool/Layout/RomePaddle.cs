using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public enum TargetType
{
    Scene,
    UGUI
}
public enum LayoutType
{
    Sprite_First_Weight,
    Sprite_First_Height,
    Screen_First_Weight,
    Screen_First_Height,
    Bottom,
    Top,
    Left,
    Right
}
public enum RunTime
{
    Awake,
    Start,
    None
}
public class RomePaddle : MonoBehaviour
{
[UnityEngine.Serialization.FormerlySerializedAs("Target_Type")]    public TargetType Indoor_Spur;
[UnityEngine.Serialization.FormerlySerializedAs("Layout_Type")]    public LayoutType Paddle_Spur;
[UnityEngine.Serialization.FormerlySerializedAs("Run_Time")]    public RunTime Now_Quit;
[UnityEngine.Serialization.FormerlySerializedAs("Layout_Number")]    public float Paddle_Floral;
    private void Awake()
    {
        if (Now_Quit == RunTime.Awake)
        {
            RadiusBeluga();
        }
    }
    private void Start()
    {
        if (Now_Quit == RunTime.Start)
        {
            RadiusBeluga();
        }
    }

    public void RadiusBeluga()
    {
        if (Paddle_Spur == LayoutType.Sprite_First_Weight)
        {
            if (Indoor_Spur == TargetType.UGUI)
            {

                float scale = Screen.width / Paddle_Floral;
                //GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width, Screen.width / w * h);
                transform.localScale = new Vector3(scale, scale, scale);
            }
        }
        if (Paddle_Spur == LayoutType.Screen_First_Weight)
        {
            if (Indoor_Spur == TargetType.Scene)
            {
                float scale = PenSystemHave.PenMonopoly().getCarpetDecay() / Paddle_Floral;
                transform.localScale = transform.localScale * scale;
            }
        }
        
        if (Paddle_Spur == LayoutType.Bottom)
        {
            if (Indoor_Spur == TargetType.Scene)
            {
                float screen_bottom_y = PenSystemHave.PenMonopoly().PenCarpetEleven() / -2;
                screen_bottom_y += (Paddle_Floral + (PenSystemHave.PenMonopoly().PenModernTray(gameObject).y / 2f));
                transform.position = new Vector3(transform.position.x, screen_bottom_y, transform.position.y);
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
