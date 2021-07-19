using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

/// <summary>
/// GM�ű����������б�дһЩ���õĹ��߷�����ȫ�ֱ���
/// </summary>
public class GameManager : MonoBehaviour
{
    //�����ֵ�
    public static Dictionary<int, Mission> missions = new Dictionary<int, Mission>();

    /// <summary>
    /// ���ݽű�����ȡָ��Transform�ϵĽű�����
    /// </summary>
    /// <typeparam name="T">��ȡ�ű�������</typeparam>
    /// <param name="t">����Ŀ������Transform</param>
    /// <param name="n">��ȡ�Ľű���</param>
    /// <returns>t����Ϊn��T���ͽű�����</returns>
    public static T FindType<T>(Transform t,string n)
    {
        return t.Find(n).GetComponent<T>();
    }

    public static Object Load<T>(string path) where T : Object
    {
        return Resources.Load<T>(path);
    }

    /// <summary>
    /// ������������xml�ļ��еĶԻ�����
    /// </summary>
    /// <param name="tidx">xml�ļ��еĶԻ�����</param>
    /// <returns>tidx��xml�ļ��ж�Ӧ��TalkData����</returns>
    public static TalkData GetTalk(int tidx)
    {
        //����Xml�ļ����µ�/XML�ļ�
        TextAsset t = Load<TextAsset>("Xml/XML") as TextAsset;
        XmlDocument xml = new XmlDocument();
        xml.LoadXml(t.ToString().Trim()/*ȥ���ո��·��*/);
        XmlElement root = xml.DocumentElement;      //   ��ȡ���ڵ�
        XmlElement tinfo = (XmlElement)root.SelectSingleNode("TalkInfo");   //��ȡTalkInfo�ڵ�
        XmlElement node = tinfo.ChildNodes[tidx] as XmlElement; //��ȡTalkInfo�ڵ��ӽڵ�
        int fHidx = int.Parse(node.GetAttribute("FHead"));  //��ȡxml�ļ�TalkInfo�ڽڵ��ͷ����Ϣ
        int sHidx = int.Parse(node.GetAttribute("SHead"));
        string tStr = node.GetAttribute("Message");
        TalkData data = new TalkData(fHidx, sHidx, tStr);
        data.idx = tidx;
        if (node.HasAttribute("Money"))
        {
            data.money = int.Parse(node.GetAttribute("Money"));
        }

        //�ж��Ƿ�������
        if (node.HasAttribute("Mission"))
        {
            Mission msn = GetMission(int.Parse(node.GetAttribute("Mission")));
            data.msn = msn;
        }

        //�ж��Ƿ�����Ʒ
        if (node.HasAttribute("Obj"))
        {
            data.obj = GetGameObj(int.Parse(node.GetAttribute("Obj")));
        }
        return data;
    }

    /// <summary>
    /// ��ȡ������Ϣ
    /// </summary>
    /// <param name="midx">xml�ļ��е���������</param>
    /// <returns>midx��xml�ļ��ж�Ӧ��Mission����</returns>
    public static Mission GetMission(int midx)
    {
        //����Xml�ļ����µ�/XML�ļ�
        TextAsset t = Load<TextAsset>("Xml/XML") as TextAsset;
        XmlDocument xml = new XmlDocument();
        xml.LoadXml(t.ToString().Trim()/*ȥ���ո��·��*/);
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
    /// ��ȡ��Ʒ
    /// </summary>
    /// <param name="oidx">xml�ļ��е���Ʒ����</param>
    /// <returns>oidx��xml�ļ��ж�Ӧ��GameObj����</returns>
    public static GameObj GetGameObj(int oidx)
    {
        //����Xml�ļ����µ�/XML�ļ�
        TextAsset t = Load<TextAsset>("Xml/XML") as TextAsset;
        XmlDocument xml = new XmlDocument();
        xml.LoadXml(t.ToString().Trim()/*ȥ���ո��·��*/);
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
    /// ��ȡ��Ʒ
    /// </summary>
    /// <param name="oname">xml�ļ��е���Ʒ����</param>
    /// <returns>oname��xml�ļ��ж�Ӧ��GameObj����</returns>
    public static GameObj GetGameObj(string oname)
    {
        //����Xml�ļ����µ�/XML�ļ�
        TextAsset t = Load<TextAsset>("Xml/XML") as TextAsset;
        XmlDocument xml = new XmlDocument();
        xml.LoadXml(t.ToString().Trim()/*ȥ���ո��·��*/);
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
    /// �������
    /// </summary>
    /// <param name="msn">��������</param>
    public static void AddMission(Mission msn)
    {
        //Ϊ�����ֵ��������
        missions.Add(msn.idx, msn);
    }
}
