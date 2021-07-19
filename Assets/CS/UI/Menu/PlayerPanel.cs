using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ������
/// </summary>
public class PlayerPanel : UIBase
{
    [Header("===========�������==========")]   //������unity���������ʾһ�ж�����ʾ�ַ�������
    public UIBase panelMsn; //�������������������
    public UIBase panelBag; //�������������������
    public Button btnMsn;   //����˵�������ť
    public Button btnBag;   //�����˵�������ť
    public Button btnTakeOff;   //�����˵��е�����װ����ť
    public Transform bagPanel;  //��������Transform����
    public static PlayerPanel playerPanel;  //������ĵ�������
    private void Awake()
    {
        //��������
        playerPanel = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        //����Ҫ�Ĳ˵�����ť����
        btnParent = transform.Find("BtnParent");
        panelMsn = GameManager.FindType<MissionPanel>(transform.parent, "MissionPanel");
        bagPanel = transform.parent.Find("BagPanel");
        panelBag = bagPanel.GetComponent<BagPanel>();
        //bagPanel.gameObject.SetActive(false);

        btnMsn = btnParent.Find("BtnMission").GetComponent<Button>();

        //Ϊ���������ť���¼�
        btnMsn.onClick.AddListener(delegate 
        {
            //��������˵�
            panelMsn.MenuStart(panelMsn.GetComponent<UITween>());
            //����˵�ˢ��
            ((MissionPanel)panelMsn).MsnUpdate();
        });

        btnBag = btnParent.Find("BtnBag").GetComponent<Button>();

        //Ϊ����������ť���¼�
        btnBag.onClick.AddListener(delegate 
        {   
            //��ȡ��������µ������Ӳ˵����ƶ����
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

            //�������Ӳ˵�����������
            panelBag.MenuStart(uis);
        });
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
