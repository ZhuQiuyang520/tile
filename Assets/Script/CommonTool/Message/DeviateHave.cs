using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 消息传递的参数
/// </summary>
public class DeviateHave
{
    /*
     *  1.创建独立的消息传递数据结构，而不使用object，是为了避免数据传递时的类型强转
     *  2.制作过程中遇到实际需要传递的数据类型，在这里定义即可
     *  3.实际项目中需要传递参数的类型其实并没有很多种，这种方式基本可以满足需求
     */
    public bool CarveKeep;
    public bool CarveKeep2;
    public int CarveSon;
    public int CarveSon2;
    public int CarveSon3;
    public float CarveMaple;
    public float CarveMaple2;
    public double CarveZigzag;
    public double CarveZigzag2;
    public string CarveAcross;
    public string CarveAcross2;
    public GameObject CarveOilyRelief;
    public GameObject CarveOilyRelief2;
    public GameObject CarveOilyRelief3;
    public GameObject CarveOilyRelief4;
    public Transform CarveVenerable;
    public List<string> CarveAcrossPlug;
    public List<Vector2> CarveGet2Plug;
    public List<int> CarveSonPlug;
    public System.Action SlanderDoseWarm;
    public Vector2 Mob2_1;
    public Vector2 Mob2_2;
    public DeviateHave()
    {
    }
    public DeviateHave(Vector2 v2_1)
    {
        Mob2_1 = v2_1;
    }
    public DeviateHave(Vector2 v2_1, Vector2 v2_2)
    {
        Mob2_1 = v2_1;
        Mob2_2 = v2_2;
    }
    /// <summary>
    /// 创建一个带bool类型的数据
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public DeviateHave(bool value)
    {
        CarveKeep = value;
    }
    public DeviateHave(bool value, bool value2)
    {
        CarveKeep = value;
        CarveKeep2 = value2;
    }
    /// <summary>
    /// 创建一个带int类型的数据
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public DeviateHave(int value)
    {
        CarveSon = value;
    }
    public DeviateHave(int value, int value2)
    {
        CarveSon = value;
        CarveSon2 = value2;
    }
    public DeviateHave(int value, int value2, int value3)
    {
        CarveSon = value;
        CarveSon2 = value2;
        CarveSon3 = value3;
    }
    public DeviateHave(List<int> value,List<Vector2> value2)
    {
        CarveSonPlug = value;
        CarveGet2Plug = value2;
    }
    /// <summary>
    /// 创建一个带float类型的数据
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public DeviateHave(float value)
    {
        CarveMaple = value;
    }
    public DeviateHave(float value,float value2)
    {
        CarveMaple = value;
        CarveMaple = value2;
    }
    /// <summary>
    /// 创建一个带double类型的数据
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public DeviateHave(double value)
    {
        CarveZigzag = value;
    }
    public DeviateHave(double value, double value2)
    {
        CarveZigzag = value;
        CarveZigzag = value2;
    }
    /// <summary>
    /// 创建一个带string类型的数据
    /// </summary>
    /// <param name="value"></param>
    public DeviateHave(string value)
    {
        CarveAcross = value;
    }
    /// <summary>
    /// 创建两个带string类型的数据
    /// </summary>
    /// <param name="value1"></param>
    /// <param name="value2"></param>
    public DeviateHave(string value1,string value2)
    {
        CarveAcross = value1;
        CarveAcross2 = value2;
    }
    public DeviateHave(GameObject value1)
    {
        CarveOilyRelief = value1;
    }

    public DeviateHave(Transform transform)
    {
        CarveVenerable = transform;
    }
}

