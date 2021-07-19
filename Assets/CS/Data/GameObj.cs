using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

/// <summary>
/// ��������
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
/// ��������
/// </summary>
public class GameObj
{
    //������
    public string oname;
    //����˵��
    public string msg;
    //��������
    public int idx;
    //�ӳ�����
    public int value=0;
    //��������
    public ObjType type;
    //����״̬
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
    /// ʹ����Ʒ���߼�ֵ
    /// </summary>
    /// <param name="nums">��ֵ����</param>
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
    /// ����������ѵ���װ��
    /// </summary>
    void TakeOff()
    {
        //���������Ͳ��ǿɴ���װ��ʱ�˳�����
        if ((int)type<2)
        {
            return;
        }

        //��װ��������ҵļ�ֵ��Ϊ0�Խ��װ������ҵļӳ�Ч��
        AddValue(0);
        //�������(����ͨ���ַ������ö�Ӧ����)
        //MethodInfo method = typeof(MyPlayer).GetMethod("Get" + type.ToString());
        //method.Invoke(MyPlayer.myPlayer, null/*�����б�����object����*/); //MyPlayeer.myPlayer.GetAtt()
    }
}
