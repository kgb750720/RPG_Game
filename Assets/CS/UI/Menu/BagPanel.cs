using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class BagPanel : UIBase
{
    Transform canvas;   //��ǰ������canvas����
    Transform bagTransform; //�����������ӱ����������
    Transform equipTransform;   //������������װ���������
    Button btnTakeOff;      //��������װ����ť����

    //����ǰ��������ʾ�ı�
    Text textHp;
    Text textMp;
    Text textLv;
    Text textExp;
    Text textAtt;
    Text textDef;
    Text textSpd;
    Text textMdf;
    // Start is called before the first frame update
    void Start()
    {
        //MyPlayer.myPlayer.AddTool(GameManager.GetGameObj(16), 3);

        canvas = transform.parent;
        bagTransform = transform.Find("Bag");
        equipTransform = transform.Find("Equip");
        btnTakeOff = GameManager.FindType<Button>(equipTransform, "BtnTakeOff");
        btnTakeOff.onClick.AddListener(delegate 
        {
            foreach (Transform item in equipTransform.Find("Eq"))
            {
                if (item.childCount >= 2)
                    SetBtnTakeOff(item.GetChild(0), MyPlayer.myPlayer.GetBagToolWithName(item.GetChild(0).name));
                    ////////
                    //item.GetChild(0).parent = btnParent;    
                //������ƷtakeosOnֵ
            }
            UpdataValue();
        });
        text = GameManager.FindType<Text>(bagTransform,"TextGold"); //��Ǯ�ı�
        tween = bagTransform.GetComponent<UITween>();
        tween.AddEventBackHandle(UpdataValue);

        btnBack = GameManager.FindType<Button>(bagTransform, "BtnX");
        btnBack.onClick.AddListener(delegate 
        {
            tween.SetMenuBack();
            equipTransform.GetComponent<UITween>().SetMenuBack();
        });
        InitText();
    }

    public override void UpdataValue()
    {
        ClearBtn(btnParent);
        text.text = MyPlayer.myPlayer.AddMoney(0).ToString();
        Dictionary<GameObj, int>.KeyCollection keys = MyPlayer.myPlayer.bagTools.Keys;
        foreach (GameObj item in keys)
        {

            GameObject btn = Instantiate(prefab, btnParent);
            //GameObj objData = GameManager.GetGameObj(item.idx);
            //string objNumString = "";
            //if (objData.isTakeOn && MyPlayer.myPlayer.bagTools[objData.idx]==1)
            //{
            //    continue;
            //}
            //else if(objData.isTakeOn && MyPlayer.myPlayer.bagTools[objData.idx] >1)
            //{
            //    objNumString = (MyPlayer.myPlayer.bagTools[objData.idx] - 1).ToString();
            //}
            //btn.GetComponent<Image>().sprite = GameManager.Load<Sprite>("Pic/Obj/" + objData.oname) as Sprite;
            btn.GetComponent<Image>().sprite = GameManager.Load<Sprite>("Pic/Obj/" + item.oname) as Sprite;
            //btn.name = objData.oname;
            btn.name = item.oname;
            //btn.GetComponentInChildren<Text>().text = MyPlayer.myPlayer.bagTools[objData.idx].ToString();
            btn.GetComponentInChildren<Text>().text = MyPlayer.myPlayer.bagTools[item].ToString();
            //btn.GetComponentInChildren<Text>().text = objNumString;
            //btn.GetComponent<Button>().onClick.AddListener(delegate 
            //{
            //    //objData.AddValue();
            //});
            //AddEvent(objData, btn);
            AddEvent(item, btn);
            
         }
        UpdatePlayerValue();
    }

    /// <summary>
    /// ʹ����Ʒ�¼�����ʵ����Ʒͼ����קЧ����
    /// </summary>
    /// <param name="obj">��Ʒ��GameObj��Ʒ����</param>
    /// <param name="btn">��Ʒ��ť��GameObject����</param>
    void AddEvent(GameObj obj,GameObject btn)
    {
        
        Image image = btn.GetComponent<Image>();
        //UGUI��չ������ǰ�ť����������еĸ���ť����¼������
        EventTrigger trigger = btn.GetComponent<EventTrigger>();
        if (!trigger)
        {
            trigger = btn.AddComponent<EventTrigger>();
        }
        //��ť��ʼ��ק
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.BeginDrag;
        entry.callback.AddListener(delegate
        {
            image.raycastTarget = false;    //���߿ɴ�͸��������ð�ť�����ui��
            //SetBtnTakeOff(btn.transform, obj);
            btn.transform.SetParent(canvas);//��ui������canvas������������ui���ϲ㸲��ס����ui
            //btn.transform.SetParent(transform);//��ui������canvas������������ui���ϲ㸲��ס����ui
        });
        trigger.triggers.Add(entry);

        //��ť��ק��
        entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.Drag;
        entry.callback.AddListener(delegate (BaseEventData arg)
        {
            PointerEventData ped = (PointerEventData)arg;
            Vector3 newPos;
            RectTransformUtility.ScreenPointToWorldPointInRectangle(
                btn.GetComponent<RectTransform>(), Mouse.current.position.ReadValue(),
                ped.enterEventCamera,
                out newPos);
            btn.transform.position = newPos;
            
        });
        trigger.triggers.Add(entry);

        //������ק
        entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.EndDrag;
        entry.callback.AddListener(delegate (BaseEventData arg)
        {
            PointerEventData ped = (PointerEventData)arg;
            if (ped.pointerEnter != null)
            {
                Transform target = ped.pointerEnter.transform;
                if (target)
                {
                    if (target.name == "Eq" + obj.type)
                    {
                        //����װ��
                        ChangeGameObj(target, btn);
                        btn.GetComponentInChildren<Text>().text = "";   //�ŵ�װ������װ����ť������ʾ���
                        //������ֵ
                        //AddValue(obj);
                        obj.AddValue();
                        //ˢ����ֵ
                        UpdatePlayerValue();
                        
                    }
                    else if (target.name == "Tool" && (int)obj.type < 2)
                    {
                        //������Ʒ
                        if (target.parent.childCount >= 2)
                        {
                            GameObj temp = MyPlayer.myPlayer.GetBagToolWithName(target.parent.GetChild(0).name);
                            SetBtnTakeOff(target.parent.GetChild(0), temp);
                        }
                        //btn.parent = btnParent;
                        btn.GetComponent<Image>().raycastTarget = true;
                        btn.transform.parent = target.parent.transform;
                        btn.transform.SetAsFirstSibling();
                        btn.transform.localPosition = Vector3.zero;
                        btn.GetComponent<RectTransform>().sizeDelta =
                            target.parent.GetComponent<RectTransform>().sizeDelta;
                        GameObj obj = MyPlayer.myPlayer.GetBagToolWithName(btn.name);
                        obj.isTakeOn = true;
                        //ChangeGameObj(target, btn);
                    }
                    else
                    {
                        btn.transform.parent = bagTransform.Find("Scroll View").Find("Viewport").Find("Content");
                    }
                    UpdataValue();
                }
            }
            else
            {
                //������Ʒ
                print("��������");
            }
            image.raycastTarget = true; //���߲��ɴ�͸��ֻ�ܼ�⵽��ťui��
        });
        trigger.triggers.Add(entry);

        

        //��ֵһ���Ե���ʹ���¼�
        if (obj.type == ObjType.Hp || obj.type == ObjType.MP)
        {
            btn.GetComponent<Button>().onClick.AddListener(delegate
            {
                obj.AddValue();
                //MyPlayer.myPlayer.bagTools[obj.idx]--;
                MyPlayer.myPlayer.bagTools[obj]--;
                //btn.GetComponentInChildren<Text>().text = MyPlayer.myPlayer.bagTools[obj.idx].ToString();
                btn.GetComponentInChildren<Text>().text = MyPlayer.myPlayer.bagTools[obj].ToString();
                //if (MyPlayer.myPlayer.bagTools[obj.idx] == 0)
                //{
                //    MyPlayer.myPlayer.bagTools.Remove(obj.idx);
                //    Destroy(btn);
                //}
                if (MyPlayer.myPlayer.bagTools[obj] == 0)
                {
                    MyPlayer.myPlayer.bagTools.Remove(obj);
                    Destroy(btn);
                }
                UpdataValue();
            }
            );
        }
    }
    /// <summary>
    /// ��������
    /// </summary>
    /// <param name="target"></param>
    /// <param name="btn"></param>
    void ChangeGameObj(Transform target,GameObject btn)
    {
        GameObj temp = new GameObj();
        if (target.parent.childCount>=2)
        {
            //temp = GameManager.GetGameObj(target.parent.GetChild(0).name);
            temp = MyPlayer.myPlayer.GetBagToolWithName(target.parent.GetChild(0).name);
            //if (temp != null)
            //{
            //    target.parent.GetChild(0).parent = btnParent;
            //    //btnParent = target;
            //    temp.isTakeOn = false;
            //}
            SetBtnTakeOff(target.parent.GetChild(0), temp);
        }
        SetBtnTakeOn(target, btn.transform);
        //btn.transform.parent = target.parent.transform;
        //btn.transform.SetAsFirstSibling();
        //btn.transform.localPosition = Vector3.zero;
        //btn.GetComponent<RectTransform>().sizeDelta =
        //    target.parent.GetComponent<RectTransform>().sizeDelta;
        ////temp = GameManager.GetGameObj(btn.name);
        //temp = MyPlayer.myPlayer.GetBagToolWithName(btn.name);
        //temp.isTakeOn = true;
    }

    /// <summary>
    /// ����Ӧװ������
    /// </summary>
    /// <param name="btn">��Ӧװ���İ�ťTransform����</param>
    /// <param name="obj">��Ӧװ��GameObjװ��������</param>
    void SetBtnTakeOff(Transform btn,GameObj obj)
    {
        if (obj!=null)
        {
            //��װ��ͼ�����°󶨵�����װ����
            btn.parent=btnParent;
            obj.isTakeOn = false;
            btn.GetComponent<Image>().raycastTarget = true; 
            //GameObj zoreTemp = new GameObj();
            //zoreTemp.type = obj.type;
            //AddValue(zoreTemp);
            obj.AddValue(0);    //�Ӵ�װ������
        }
    }

    /// <summary>
    /// ����װ��
    /// </summary>
    /// <param name="target">����Ŀ����λ��Transform����</param>
    /// <param name="btn">װ��ͼ�갴ť��Transform����</param>
    void SetBtnTakeOn(Transform target, Transform btn)
    {
        btn.transform.parent = target.parent.transform;
        btn.transform.SetAsFirstSibling();
        btn.transform.localPosition = Vector3.zero;
        btn.GetComponent<RectTransform>().sizeDelta =
            target.parent.GetComponent<RectTransform>().sizeDelta;  //����װ��ͼ���С��Ŀ����λ�Ĵ�Сһ��
        GameObj obj = MyPlayer.myPlayer.GetBagToolWithName(btn.name);
        obj.isTakeOn = true;
        //AddValue(obj);
        obj.AddValue();
    }

    /// <summary>
    /// ������ʾ���������
    /// </summary>
    void UpdatePlayerValue()
    {
        textHp.text = "������" + MyPlayer.myPlayer.GetHp() + "/" + MyPlayer.myPlayer.hpMax;
        textMp.text = "������" + MyPlayer.myPlayer.GetMp() + "/" + MyPlayer.myPlayer.mpMax;
        textAtt.text = "������" + MyPlayer.myPlayer.GetAtt();
        textDef.text = "������" + MyPlayer.myPlayer.GetDef();
        textMdf.text = "ħ����" + MyPlayer.myPlayer.GetMdf();
        textSpd.text = "�ٶȣ�" + MyPlayer.myPlayer.GetSpd();
        textLv.text = "�ȼ���" + MyPlayer.myPlayer.lv;
        textExp.text = "���飺" + MyPlayer.myPlayer.exp;
    }

    //void AddValue(GameObj obj)
    //{
    //    switch (obj.type)
    //    {
    //        case ObjType.Hp:
    //            MyPlayer.myPlayer.offsetHp = obj.value;
    //            break;
    //        case ObjType.MP:
    //            MyPlayer.myPlayer.offsetMp = obj.value;
    //            break;
    //        case ObjType.Def:
    //            MyPlayer.myPlayer.offsetDef = obj.value;
    //            break;
    //        case ObjType.Att:
    //            MyPlayer.myPlayer.offsetAtt = obj.value;
    //            break;
    //        case ObjType.Spd:
    //            MyPlayer.myPlayer.offsetSpd= obj.value;
    //            break;
    //        case ObjType.Mdf:
    //            MyPlayer.myPlayer.offsetMdf = obj.value;
    //            break;
    //        default:
    //            break;
    //    }
    //}

    /// <summary>
    /// ��ʼ�������ı���Ϣ
    /// </summary>
    void InitText()
    {
        Transform temp = equipTransform.Find("TextParent");
        textHp = GameManager.FindType<Text>(temp, "TextHp");
        textMp = GameManager.FindType<Text>(temp, "TextMp");
        textAtt = GameManager.FindType<Text>(temp, "TextAtt");
        textDef = GameManager.FindType<Text>(temp, "TextDef");
        textSpd = GameManager.FindType<Text>(temp, "TextSpd");
        textMdf = GameManager.FindType<Text>(temp, "TextMdf");
        textLv = GameManager.FindType<Text>(temp, "TextLv");
        textExp = GameManager.FindType<Text>(temp, "TextExp");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
