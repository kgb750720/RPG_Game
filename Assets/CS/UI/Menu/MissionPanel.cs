using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 任务菜单类
/// </summary>
public class MissionPanel : UIBase
{
    // Start is called before the first frame update
    private void Start()
    {
        //绑定对应引用
        tween = GetComponent<UITween>();
        prefab = (GameObject)GameManager.Load<GameObject>("Prefabs/UI/ToggleMission");  
        btnBack = GameManager.FindType<Button>(transform, "BtnX");
        btnBack.onClick.AddListener(delegate
        {
            tween.SetMenuBack();
        });
    }
    public void MsnUpdate()
    {
        ClearBtn(btnParent);
        //获取任务字典中存在的任务值
        Dictionary<int, Mission>.ValueCollection values = GameManager.missions.Values;
        int i = 0;
        foreach (Mission item in values)
        {
            //在任务面板添加任务项
            GameObject p = Instantiate(prefab, btnParent);
            GameManager.FindType<Text>(p.transform, "Title").text = "任务" + (i + 1);
            GameManager.FindType<Text>(p.transform, "Text").text = GameManager.GetMission(item.idx).msg;
            i++;
        }
    }
}
