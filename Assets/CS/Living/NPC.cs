using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// NPC�Ի�������
/// </summary>
public class NPC : MonoBehaviour
{
    public TalkPanel panel;     //�Ժ����
    public int[] tidx;          //�Ի��أ������˶Ի���xml�ļ��е�����Ӧ�����
    public GameObject enemy;    //������������Ҫ��ĵ���Ŀ��
    int idx = 0;        //ָ��Ի��ض�Ӧ���±�
    bool mission=false; //NPC����

    public void StartTalk()
    {
        if (mission)    //�������
        {
            if (enemy!=null)    //δ�������
            {
                return;
            }
            else
            {
                //�������Ի�
                panel.SetTalk(tidx[idx]);

                //�����Ի�
                Destroy(this);
                gameObject.layer = LayerMask.NameToLayer("Default");
            }
        }
        else
        {
            mission = true;
            //�������Ի�
            panel.SetTalk(tidx[idx]);

            //Destroy(this);
        }
        idx++;  //�Ի����±�λ��+1��ָ����һ��Ի���xml�ļ��е����
        //if (idx >= tidx.Length)
            //Destroy(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
