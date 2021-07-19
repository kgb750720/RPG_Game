using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// ���ڻ�ȡxml�ļ��еĶԻ�����
/// </summary>
public class TalkData 
{

    //�Ի����һ��ͷ����Ϣ
    public int ftalk { get; }

    //�Ի���ڶ���ͷ����Ϣ
    public int stalk { get; }

    //�Ի�����
    public string talkStr { get; }
    public TalkData(int f,int s,string talk)
    {
        ftalk = f;
        stalk = s;
        talkStr = talk;
    }

    //�Ի���ɺ��ȡ������
    public Mission msn;

    //��ɺ��õ���
    public GameObj obj;

    public UnityAction action;
    public int idx;

    //��ɺ��ý�Ǯ
    public int money;
}
