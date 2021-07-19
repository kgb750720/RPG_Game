using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// 用于获取xml文件中的对话数据
/// </summary>
public class TalkData 
{

    //对话框第一个头像信息
    public int ftalk { get; }

    //对话框第二个头像信息
    public int stalk { get; }

    //对话内容
    public string talkStr { get; }
    public TalkData(int f,int s,string talk)
    {
        ftalk = f;
        stalk = s;
        talkStr = talk;
    }

    //对话完成后获取的任务
    public Mission msn;

    //完成后获得道具
    public GameObj obj;

    public UnityAction action;
    public int idx;

    //完成后获得金钱
    public int money;
}
