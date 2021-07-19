using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// �Ի���ui��
/// </summary>
public class TalkPanel : UIBase
{
    [Header("==============�������=============")]
    public TalkData talkData;   //xml�ļ��еĶԻ�����
    Transform fTalkPanel;   //��һ���Ի����
    Transform sTalkPanel;   //�ڶ����Ի����
    Image fHead;       //��һ������ͷ��
    Image sHead;       //�ڶ�������ͷ��
    Button btnClick;    //������ť
    string[] talkStr;   //�Ի������
    int next;
    Text[] talkTexts = new Text[2]; //�Ի����е������ı���

    /// <summary>
    /// ����Ի�
    /// </summary>
    /// <param name="tidx">�Ի���xml�ļ��е�����</param>
     public void SetTalk(int tidx)
     {
        MyPlayer.myPlayer.CtrlEnable = false;
        next = 1;   //�趨Ĭ�ϵ�һ�仰����һ������Ϊ 1
        btnBack.interactable = false;
        talkData = GameManager.GetTalk(tidx);
        talkStr = talkData.talkStr.Split('_');

        //���ݶԻ���������ͷ��
        fHead.sprite = GameManager.Load<Sprite>("Pic/Head/" + talkData.ftalk) as Sprite;
        sHead.sprite = GameManager.Load<Sprite>("Pic/Head/" + talkData.stalk) as Sprite;

        //Ϊ�Ի��ı���󶨶Ի�����
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
            //�޶Ի����˳�
            if (next>=talkStr.Length)
            {
                btnBack.interactable = true;
                //MyPlayer.myPlayer.CtrlEnable = true;
                return;
            }
            //���Ի������ı��������Ӧ�ַ���
            talkTexts[next % talkTexts.Length].text = talkStr[next];
            if (next==talkStr.Length-1)
            {
                btnBack.interactable = true;
                //��ӶԻ�����������
                if(talkData.msn!=null)
                    GameManager.AddMission(talkData.msn);
                MyPlayer.myPlayer.AddMoney(talkData.money);
            }
        });
     }

    // Start is called before the first frame update
    void Start()
    {
        //�󶨶�Ӧ���������
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
