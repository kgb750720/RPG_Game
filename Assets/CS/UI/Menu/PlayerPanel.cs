using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 玩家面板
/// </summary>
public class PlayerPanel : UIBase
{
    [Header("===========子类变量==========")]   //用于在unity组件界面显示一行额外提示字符串内容
    public UIBase panelMsn; //任务面板基类控制类引用
    public UIBase panelBag; //背包面板基类控制类引用
    public Button btnMsn;   //任务菜单呼出按钮
    public Button btnBag;   //背包菜单呼出按钮
    public Button btnTakeOff;   //背包菜单中的脱下装备按钮
    public Transform bagPanel;  //背包面板的Transform引用
    public static PlayerPanel playerPanel;  //对自身的单例引用
    private void Awake()
    {
        //饿汉单例
        playerPanel = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        //绑定需要的菜单及按钮引用
        btnParent = transform.Find("BtnParent");
        panelMsn = GameManager.FindType<MissionPanel>(transform.parent, "MissionPanel");
        bagPanel = transform.parent.Find("BagPanel");
        panelBag = bagPanel.GetComponent<BagPanel>();
        //bagPanel.gameObject.SetActive(false);

        btnMsn = btnParent.Find("BtnMission").GetComponent<Button>();

        //为任务呼出按钮绑定事件
        btnMsn.onClick.AddListener(delegate 
        {
            //弹出任务菜单
            panelMsn.MenuStart(panelMsn.GetComponent<UITween>());
            //任务菜单刷新
            ((MissionPanel)panelMsn).MsnUpdate();
        });

        btnBag = btnParent.Find("BtnBag").GetComponent<Button>();

        //为背包呼出按钮绑事件
        btnBag.onClick.AddListener(delegate 
        {   
            //获取背包面板下的所有子菜单的移动组件
            var uis = panelBag.GetComponentsInChildren<UITween>();
            foreach (var item in uis)
            {
                item.MoveSpeedOfFrame = 0.2f;
                item.AddEventBackHandle(panelBag.UpdataValue);
            }
            uis[0].funPop += delegate
            {
                //bagPanel.gameObject.SetActive(true);
            };
            uis[0].funPush += delegate
            {
                 //bagPanel.gameObject.SetActive(false);
            };

            //将所有子菜单开启并弹出
            panelBag.MenuStart(uis);
        });
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
