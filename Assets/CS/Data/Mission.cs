using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// ��������
/// </summary>
public class Mission
{
    public string title { get;}
    public string msg { get; }
    //��������
    public int idx;
    //����󴥷�����һ������
    public Mission msn;
    //������ɺ�ִ��
    public UnityAction callBack;
    //������ɺ�����Ʒ
    public GameObj gameObj;
    //������ɺ��ý�Ǯ
    public int money;

    public Mission(string title,string message)
    {
        this.title = title;
        msg = message;
    }
}
