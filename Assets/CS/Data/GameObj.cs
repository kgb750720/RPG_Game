using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

/// <summary>
/// 道具类型
/// </summary>
public enum ObjType
{
    Hp,
    MP,
    Def,
    Att,
    Spd,
    Mpx,
    Hpx,
    Mdf
};

/// <summary>
/// 道具数据
/// </summary>
public class GameObj
{
    //道具名
    public string oname;
    //道具说明
    public string msg;
    //道具索引
    public int idx;
    //加成属性
    public int value=0;
    //道具类型
    public ObjType type;
    //穿戴状态
    public bool isTakeOn;

    
    //public void AddValue()
    //{

    //    if (type==ObjType.Hp)
    //    {
    //        MyPlayer.myPlayer.AddHp(value);
    //    }
    //    else if (type==ObjType.MP)
    //    {
    //        MyPlayer.myPlayer.AddMp(value);
    //    }
    //}

    /// <summary>
    /// 使用物品道具加值
    /// </summary>
    /// <param name="nums">加值类型</param>
    public void AddValue(params int[] nums)
    {
        if (type == ObjType.Hp)
        {
            MyPlayer.myPlayer.AddHp(value);
        }
        else if (type == ObjType.MP)
        {
            MyPlayer.myPlayer.AddMp(value);
        }
        int v;
        if (nums.Length == 0)
            v = this.value;
        else
            v = nums[0];

        switch (type)
        {
            case ObjType.Hp:
                MyPlayer.myPlayer.offsetHp = v;
                break;
            case ObjType.MP:
                MyPlayer.myPlayer.offsetMp = v;
                break;
            case ObjType.Def:
                MyPlayer.myPlayer.offsetDef = v;
                break;
            case ObjType.Att:
                MyPlayer.myPlayer.offsetAtt = v;
                break;
            case ObjType.Spd:
                MyPlayer.myPlayer.offsetSpd = v;
                break;
            case ObjType.Mdf:
                MyPlayer.myPlayer.offsetMdf = v;
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// 从玩家身上脱掉该装备
    /// </summary>
    void TakeOff()
    {
        //若道具类型不是可穿戴装备时退出方法
        if ((int)type<2)
        {
            return;
        }

        //将装备对于玩家的加值置为0以解除装备对玩家的加成效果
        AddValue(0);
        //反射机制(可以通过字符串调用对应函数)
        //MethodInfo method = typeof(MyPlayer).GetMethod("Get" + type.ToString());
        //method.Invoke(MyPlayer.myPlayer, null/*参数列表对象的object数组*/); //MyPlayeer.myPlayer.GetAtt()
    }
}
