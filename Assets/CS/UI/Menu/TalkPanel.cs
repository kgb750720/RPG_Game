using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 对话框ui类
/// </summary>
public class TalkPanel : UIBase
{
    [Header("==============子类变量=============")]
    public TalkData talkData;   //xml文件中的对话数据
    Transform fTalkPanel;   //第一个对话面板
    Transform sTalkPanel;   //第二个对话面板
    Image fHead;       //第一个人物头像
    Image sHead;       //第二个人物头像
    Button btnClick;    //继续按钮
    string[] talkStr;   //对话储存池
    int next;
    Text[] talkTexts = new Text[2]; //对话框中的两个文本框

    /// <summary>
    /// 引入对话
    /// </summary>
    /// <param name="tidx">对话在xml文件中的序列</param>
     public void SetTalk(int tidx)
     {
        MyPlayer.myPlayer.CtrlEnable = false;
        next = 1;   //设定默认第一句话的下一句索引为 1
        btnBack.interactable = false;
        talkData = GameManager.GetTalk(tidx);
        talkStr = talkData.talkStr.Split('_');

        //根据对话数据设置头像
        fHead.sprite = GameManager.Load<Sprite>("Pic/Head/" + talkData.ftalk) as Sprite;
        sHead.sprite = GameManager.Load<Sprite>("Pic/Head/" + talkData.stalk) as Sprite;

        //为对话文本框绑定对话内容
        talkTexts[0].text = talkStr[0];
        talkTexts[1].text = talkStr[1];
        


        tween.SetMenuStart();

        btnBack.onClick.AddListener(delegate
        {
            tween.SetMenuBack();
            MyPlayer.myPlayer.CtrlEnable = true;
        });
        btnClick.onClick.AddListener(delegate
        {
            next++;
            //无对话就退出
            if (next>=talkStr.Length)
            {
                btnBack.interactable = true;
                //MyPlayer.myPlayer.CtrlEnable = true;
                return;
            }
            //将对话池内文本分配给对应字符串
            talkTexts[next % talkTexts.Length].text = talkStr[next];
            if (next==talkStr.Length-1)
            {
                btnBack.interactable = true;
                //添加对话奖励和任务
                if(talkData.msn!=null)
                    GameManager.AddMission(talkData.msn);
                MyPlayer.myPlayer.AddMoney(talkData.money);
            }
        });
     }

    // Start is called before the first frame update
    void Start()
    {
        //绑定对应的组件引用
        fTalkPanel = transform.Find("FTalk");
        fHead = GameManager.FindType<Image>(fTalkPanel, "Head");
        talkTexts[0] = fTalkPanel.GetComponentInChildren<Text>();

        sTalkPanel = transform.Find("STalk");
        sHead = GameManager.FindType<Image>(sTalkPanel, "Head");
        talkTexts[1] = sTalkPanel.GetComponentInChildren<Text>();

        btnClick = GameManager.FindType<Button>(transform, "BtnClick");
        btnBack = GameManager.FindType<Button>(transform, "BtnX");
        tween = GetComponent<UITween>();

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
