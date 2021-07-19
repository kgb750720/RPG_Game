using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

/// <summary>
/// ���˵���
/// </summary>
public class MainMenu : UIBase
{
    //�󶨿�����Ƶ����Ƶ������
    VideoPlayer vPlayer;

    //���˵����ƶ��ű�����
    UITween mainMenu;
    UITween setMenu;
    UITween loadMenu;
    UITween quitMenu;

    //��Ļ���Ƚ���ű�
    FadeEffect fade;

    //���˵�ҳ�水ť
    Button btnStart;
    Button btnLoad;
    Button btnSet;
    Button btnQuit;

    //�����˵�ҳ�淵�ص����˵��İ�ť����
    private Button btnSetBack;
    private Button btnQuitNo;
    private Button btnLoadBack;

    // Start is called before the first frame update
    void Start()
    {
        //��ȡ��Ļ����ű�
        fade = transform.parent.GetComponentInChildren<FadeEffect>();

        //��ȡ�������������
        vPlayer = transform.parent.GetComponentInChildren<VideoPlayer>();

        //��ȡ���˵�ҳ��������ƶ��ű�
        mainMenu = GetComponent<UITween>();

        //�󶨸��˵����ƶ��ű�����
        loadMenu = GameManager.FindType<UITween>(transform.parent, "MenuLoad");
        setMenu = GameManager.FindType<UITween>(transform.parent, "MenuSet");
        quitMenu = GameManager.FindType<UITween>(transform.parent, "MenuQuit");

        //��ȡ���˵��еĸ���ť
        btnStart = GameManager.FindType<Button>(transform, "BtnStart");
        btnLoad = GameManager.FindType<Button>(transform, "BtnLoad");
        btnSet = GameManager.FindType<Button>(transform, "BtnSet");
        btnQuit = GameManager.FindType<Button>(transform, "BtnQuit");

        //�������˵����ڷ������˵��İ�ť����
        btnSetBack = GameManager.FindType<Button>(setMenu.transform, "BtnBack");
        btnQuitNo = GameManager.FindType<Button>(quitMenu.transform, "BtnQuitNo");
        btnLoadBack = GameManager.FindType<Button>(loadMenu.transform, "BtnLoadBack");

        //�󶨿�ʼ��ť�Ĳ���
        btnStart.onClick.AddListener(delegate
        {
            //����Э��FadeEffect.Fade��������Э�̣�������䰵������"GameScence"�ؿ�
            StartCoroutine(fade.Fade(1, SceneManager.LoadScene, "GameScence"));
        });

        //��ί�а󶨵����˵����ð�ť�ļ�������
        btnSet.onClick.AddListener(delegate
        {
            mainMenu.SetBtnHandle(setMenu);
            mainMenu.SetMenuBack();
        });
        //��ί�а󶨵����˵��˳���ť�ļ�������
        btnQuit.onClick.AddListener(delegate 
        {
            //���˵�������Ŀ�굯��˵���
            mainMenu.SetBtnHandle(quitMenu);
            //���˵�����
            mainMenu.SetMenuBack();
        });
        //��ί�а󶨵����˵����밴ť�ļ�������
        btnLoad.onClick.AddListener(delegate
        {
            mainMenu.SetBtnHandle(loadMenu);
            mainMenu.SetMenuBack();
        });

        //��ί�а󶨵����ò˵����ذ�ť�ļ�������
        btnSetBack.onClick.AddListener(delegate
        {
            //�����˵���Ϊ���ò˵��ĵ��������Ŀ��˵�
            setMenu.SetBtnHandle(mainMenu);
            //�������ò˵�
            setMenu.SetMenuBack();
        });
        //��ί�а󶨵��˳��Ի����ť�ļ�������
        btnQuitNo.onClick.AddListener(delegate
        {
            //���˳��Ի��򵯳������Ŀ��˵�
            quitMenu.SetBtnHandle(mainMenu);
            //�����˳��Ի���
            quitMenu.SetMenuBack();
        });
        //��ί�а󶨵����ط��صİ�ť��
        btnLoadBack.onClick.AddListener(delegate
        {
            //�����˵���Ϊ���ز˵����������Ŀ��˵�
            loadMenu.SetBtnHandle(mainMenu);
            //�������ز˵�
            loadMenu.SetMenuBack();
        });
    }

    // Update is called once per frame
    void Update()
    {
        //����ǰ����֡�����е�����(������֡��ƬԴ֡��-10)ʱִ�����²���
        if (vPlayer.frame>(long)vPlayer.frameCount-10)
        {
            //���ز�����
            vPlayer.gameObject.SetActive(false);
            //�������˵�ҳ��
            mainMenu.SetMenuStart();
        }
        //���ESC������
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //����ǰ����������֡����ΪƬԴ���һ֡�������Ƶ����
            vPlayer.frame = (long)vPlayer.frameCount;
        }

    }
}
