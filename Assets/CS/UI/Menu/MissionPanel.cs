using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ����˵���
/// </summary>
public class MissionPanel : UIBase
{
    // Start is called before the first frame update
    private void Start()
    {
        //�󶨶�Ӧ����
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
        //��ȡ�����ֵ��д��ڵ�����ֵ
        Dictionary<int, Mission>.ValueCollection values = GameManager.missions.Values;
        int i = 0;
        foreach (Mission item in values)
        {
            //������������������
            GameObject p = Instantiate(prefab, btnParent);
            GameManager.FindType<Text>(p.transform, "Title").text = "����" + (i + 1);
            GameManager.FindType<Text>(p.transform, "Text").text = GameManager.GetMission(item.idx).msg;
            i++;
        }
    }
}
