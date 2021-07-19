using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

/// <summary>
/// 主菜单类
/// </summary>
public class MainMenu : UIBase
{
    //绑定开场视频的视频播放器
    VideoPlayer vPlayer;

    //各菜单的移动脚本引用
    UITween mainMenu;
    UITween setMenu;
    UITween loadMenu;
    UITween quitMenu;

    //屏幕亮度渐变脚本
    FadeEffect fade;

    //主菜单页面按钮
    Button btnStart;
    Button btnLoad;
    Button btnSet;
    Button btnQuit;

    //其他菜单页面返回到主菜单的按钮引用
    private Button btnSetBack;
    private Button btnQuitNo;
    private Button btnLoadBack;

    // Start is called before the first frame update
    void Start()
    {
        //获取屏幕渐变脚本
        fade = transform.parent.GetComponentInChildren<FadeEffect>();

        //获取视屏播放器组件
        vPlayer = transform.parent.GetComponentInChildren<VideoPlayer>();

        //获取主菜单页面自身的移动脚本
        mainMenu = GetComponent<UITween>();

        //绑定各菜单的移动脚本引用
        loadMenu = GameManager.FindType<UITween>(transform.parent, "MenuLoad");
        setMenu = GameManager.FindType<UITween>(transform.parent, "MenuSet");
        quitMenu = GameManager.FindType<UITween>(transform.parent, "MenuQuit");

        //获取主菜单中的各按钮
        btnStart = GameManager.FindType<Button>(transform, "BtnStart");
        btnLoad = GameManager.FindType<Button>(transform, "BtnLoad");
        btnSet = GameManager.FindType<Button>(transform, "BtnSet");
        btnQuit = GameManager.FindType<Button>(transform, "BtnQuit");

        //绑定其他菜单用于返回主菜单的按钮引用
        btnSetBack = GameManager.FindType<Button>(setMenu.transform, "BtnBack");
        btnQuitNo = GameManager.FindType<Button>(quitMenu.transform, "BtnQuitNo");
        btnLoadBack = GameManager.FindType<Button>(loadMenu.transform, "BtnLoadBack");

        //绑定开始按钮的操作
        btnStart.onClick.AddListener(delegate
        {
            //开启协程FadeEffect.Fade方法开启协程，将界面变暗后载入"GameScence"关卡
            StartCoroutine(fade.Fade(1, SceneManager.LoadScene, "GameScence"));
        });

        //将委托绑定到主菜单设置按钮的监听器上
        btnSet.onClick.AddListener(delegate
        {
            mainMenu.SetBtnHandle(setMenu);
            mainMenu.SetMenuBack();
        });
        //将委托绑定到主菜单退出按钮的监听器上
        btnQuit.onClick.AddListener(delegate 
        {
            //主菜单弹出后目标弹入菜单绑定
            mainMenu.SetBtnHandle(quitMenu);
            //主菜单弹出
            mainMenu.SetMenuBack();
        });
        //将委托绑定到主菜单载入按钮的监听器上
        btnLoad.onClick.AddListener(delegate
        {
            mainMenu.SetBtnHandle(loadMenu);
            mainMenu.SetMenuBack();
        });

        //将委托绑定到设置菜单返回按钮的监听器上
        btnSetBack.onClick.AddListener(delegate
        {
            //绑定主菜单作为设置菜单的弹出后弹入的目标菜单
            setMenu.SetBtnHandle(mainMenu);
            //弹出设置菜单
            setMenu.SetMenuBack();
        });
        //将委托绑定到退出对话框否按钮的监听器上
        btnQuitNo.onClick.AddListener(delegate
        {
            //绑定退出对话框弹出后弹入的目标菜单
            quitMenu.SetBtnHandle(mainMenu);
            //弹出退出对话框
            quitMenu.SetMenuBack();
        });
        //将委托绑定到加载返回的按钮上
        btnLoadBack.onClick.AddListener(delegate
        {
            //绑定主菜单作为加载菜单弹出后弹入的目标菜单
            loadMenu.SetBtnHandle(mainMenu);
            //弹出加载菜单
            loadMenu.SetMenuBack();
        });
    }

    // Update is called once per frame
    void Update()
    {
        //当当前播放帧数进行到大于(播放器帧数片源帧数-10)时执行以下操作
        if (vPlayer.frame>(long)vPlayer.frameCount-10)
        {
            //隐藏播放器
            vPlayer.gameObject.SetActive(false);
            //弹出主菜单页面
            mainMenu.SetMenuStart();
        }
        //点击ESC键操作
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //将当前播放器播放帧数置为片源最后一帧以完成视频播放
            vPlayer.frame = (long)vPlayer.frameCount;
        }

    }
}
