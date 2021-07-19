using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

/// <summary>
/// GM脚本，可在其中编写一些常用的工具方法或全局变量
/// </summary>
public class GameManager : MonoBehaviour
{
    //任务字典
    public static Dictionary<int, Mission> missions = new Dictionary<int, Mission>();

    /// <summary>
    /// 根据脚本名获取指定Transform上的脚本引用
    /// </summary>
    /// <typeparam name="T">获取脚本的类型</typeparam>
    /// <param name="t">方法目标作用Transform</param>
    /// <param name="n">获取的脚本名</param>
    /// <returns>t上名为n的T类型脚本引用</returns>
    public static T FindType<T>(Transform t,string n)
    {
        return t.Find(n).GetComponent<T>();
    }

    public static Object Load<T>(string path) where T : Object
    {
        return Resources.Load<T>(path);
    }

    /// <summary>
    /// 根据索引查找xml文件中的对话数据
    /// </summary>
    /// <param name="tidx">xml文件中的对话序列</param>
    /// <returns>tidx在xml文件中对应的TalkData数据</returns>
    public static TalkData GetTalk(int tidx)
    {
        //加载Xml文件夹下的/XML文件
        TextAsset t = Load<TextAsset>("Xml/XML") as TextAsset;
        XmlDocument xml = new XmlDocument();
        xml.LoadXml(t.ToString().Trim()/*去掉空格的路径*/);
        XmlElement root = xml.DocumentElement;      //   获取根节点
        XmlElement tinfo = (XmlElement)root.SelectSingleNode("TalkInfo");   //获取TalkInfo节点
        XmlElement node = tinfo.ChildNodes[tidx] as XmlElement; //获取TalkInfo内的子节点
        int fHidx = int.Parse(node.GetAttribute("FHead"));  //获取xml文件TalkInfo内节点的头像信息
        int sHidx = int.Parse(node.GetAttribute("SHead"));
        string tStr = node.GetAttribute("Message");
        TalkData data = new TalkData(fHidx, sHidx, tStr);
        data.idx = tidx;
        if (node.HasAttribute("Money"))
        {
            data.money = int.Parse(node.GetAttribute("Money"));
        }

        //判断是否有任务
        if (node.HasAttribute("Mission"))
        {
            Mission msn = GetMission(int.Parse(node.GetAttribute("Mission")));
            data.msn = msn;
        }

        //判断是否有物品
        if (node.HasAttribute("Obj"))
        {
            data.obj = GetGameObj(int.Parse(node.GetAttribute("Obj")));
        }
        return data;
    }

    /// <summary>
    /// 获取任务信息
    /// </summary>
    /// <param name="midx">xml文件中的任务序列</param>
    /// <returns>midx在xml文件中对应的Mission数据</returns>
    public static Mission GetMission(int midx)
    {
        //加载Xml文件夹下的/XML文件
        TextAsset t = Load<TextAsset>("Xml/XML") as TextAsset;
        XmlDocument xml = new XmlDocument();
        xml.LoadXml(t.ToString().Trim()/*去掉空格的路径*/);
        XmlElement root = xml.DocumentElement;
        XmlElement minfo = (XmlElement)root.SelectSingleNode("MissionInfo");
        XmlElement node = minfo.ChildNodes[midx] as XmlElement;

        Mission mdata = new Mission(node.GetAttribute("Title"), node.GetAttribute("Msg"));
        mdata.idx = midx;
        if (node.HasAttribute("Obj"))
        {
            mdata.gameObj = GetGameObj(int.Parse(node.GetAttribute("Obj")));
        }
        if (node.HasAttribute("Msn"))
        {
            mdata.msn = GetMission(int.Parse(node.GetAttribute("Msn")));
        }
        if (node.HasAttribute("Money"))
        {
            mdata.msn = GetMission(int.Parse(node.GetAttribute("Money")));
        }
        return mdata;
    }

    /// <summary>
    /// 获取物品
    /// </summary>
    /// <param name="oidx">xml文件中的物品序列</param>
    /// <returns>oidx在xml文件中对应的GameObj数据</returns>
    public static GameObj GetGameObj(int oidx)
    {
        //加载Xml文件夹下的/XML文件
        TextAsset t = Load<TextAsset>("Xml/XML") as TextAsset;
        XmlDocument xml = new XmlDocument();
        xml.LoadXml(t.ToString().Trim()/*去掉空格的路径*/);
        XmlElement root = xml.DocumentElement;
        XmlElement oinfo = (XmlElement)root.SelectSingleNode("GameObjInfo");
        XmlElement node = oinfo.ChildNodes[oidx] as XmlElement;

        GameObj odata = new GameObj();
        odata.oname = node.GetAttribute("Name");
        odata.msg = node.GetAttribute("Msg");
        odata.idx = int.Parse(node.GetAttribute("Idx"));
        odata.value = int.Parse(node.GetAttribute("Value"));
        odata.type = (ObjType)System.Enum.Parse(typeof(ObjType), node.GetAttribute("Type"));
        return odata;
    }


    /// <summary>
    /// 获取物品
    /// </summary>
    /// <param name="oname">xml文件中的物品名称</param>
    /// <returns>oname在xml文件中对应的GameObj数据</returns>
    public static GameObj GetGameObj(string oname)
    {
        //加载Xml文件夹下的/XML文件
        TextAsset t = Load<TextAsset>("Xml/XML") as TextAsset;
        XmlDocument xml = new XmlDocument();
        xml.LoadXml(t.ToString().Trim()/*去掉空格的路径*/);
        XmlElement root = xml.DocumentElement;
        XmlElement oinfo = (XmlElement)root.SelectSingleNode("GameObjInfo");
        foreach (XmlElement item in oinfo.ChildNodes)
        {
            if(item.GetAttribute("Name")==oname)
            {
                GameObj odata = new GameObj();
                odata.oname = item.GetAttribute("Name");
                odata.msg = item.GetAttribute("Msg");
                odata.idx = int.Parse(item.GetAttribute("Idx"));
                odata.value = int.Parse(item.GetAttribute("Value"));
                odata.type = (ObjType)System.Enum.Parse(typeof(ObjType), item.GetAttribute("Type"));
                return odata;
            }
        }
        return null;
    }

    /// <summary>
    /// 添加任务
    /// </summary>
    /// <param name="msn">任务数据</param>
    public static void AddMission(Mission msn)
    {
        //为任务字典添加任务
        missions.Add(msn.idx, msn);
    }
}
