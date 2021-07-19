using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// NPC对话控制类
/// </summary>
public class NPC : MonoBehaviour
{
    public TalkPanel panel;     //对胡面板
    public int[] tidx;          //对话池，储存了对话在xml文件中的所对应的序号
    public GameObject enemy;    //发布的任务所要求的敌人目标
    int idx = 0;        //指向对话池对应的下标
    bool mission=false; //NPC任务

    public void StartTalk()
    {
        if (mission)    //完成任务
        {
            if (enemy!=null)    //未解决敌人
            {
                return;
            }
            else
            {
                //设置面板对话
                panel.SetTalk(tidx[idx]);

                //结束对话
                Destroy(this);
                gameObject.layer = LayerMask.NameToLayer("Default");
            }
        }
        else
        {
            mission = true;
            //设置面板对话
            panel.SetTalk(tidx[idx]);

            //Destroy(this);
        }
        idx++;  //对话池下标位置+1以指向下一句对话在xml文件中的序号
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
