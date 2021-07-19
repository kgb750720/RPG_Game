using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// 任务数据
/// </summary>
public class Mission
{
    public string title { get;}
    public string msg { get; }
    //任务索引
    public int idx;
    //任务后触发的下一个任务
    public Mission msn;
    //任务完成后执行
    public UnityAction callBack;
    //任务完成后获得物品
    public GameObj gameObj;
    //任务完成后获得金钱
    public int money;

    public Mission(string title,string message)
    {
        this.title = title;
        msg = message;
    }
}
