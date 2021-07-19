using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class BagPanel : UIBase
{
    Transform canvas;   //当前场景的canvas引用
    Transform bagTransform; //背包面板里的子背包面板引用
    Transform equipTransform;   //背包面板里的子装备面板引用
    Button btnTakeOff;      //脱下所有装备按钮引用

    //任务当前的属性显示文本
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
                //更改物品takeosOn值
            }
            UpdataValue();
        });
        text = GameManager.FindType<Text>(bagTransform,"TextGold"); //金钱文本
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
    /// 使用物品事件（可实现物品图标拖拽效果）
    /// </summary>
    /// <param name="obj">物品的GameObj物品数据</param>
    /// <param name="btn">物品按钮的GameObject引用</param>
    void AddEvent(GameObj obj,GameObject btn)
    {
        
        Image image = btn.GetComponent<Image>();
        //UGUI扩展组件，是按钮组件的所带有的负责按钮点击事件的组件
        EventTrigger trigger = btn.GetComponent<EventTrigger>();
        if (!trigger)
        {
            trigger = btn.AddComponent<EventTrigger>();
        }
        //按钮开始拖拽
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.BeginDrag;
        entry.callback.AddListener(delegate
        {
            image.raycastTarget = false;    //射线可穿透（方便检测该按钮后面的ui）
            //SetBtnTakeOff(btn.transform, obj);
            btn.transform.SetParent(canvas);//将ui设置在canvas级，将其置于ui最上层覆盖住所有ui
            //btn.transform.SetParent(transform);//将ui设置在canvas级，将其置于ui最上层覆盖住所有ui
        });
        trigger.triggers.Add(entry);

        //按钮拖拽中
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

        //结束拖拽
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
                        //穿戴装备
                        ChangeGameObj(target, btn);
                        btn.GetComponentInChildren<Text>().text = "";   //放到装备栏后装备按钮数量显示清空
                        //增加数值
                        //AddValue(obj);
                        obj.AddValue();
                        //刷新数值
                        UpdatePlayerValue();
                        
                    }
                    else if (target.name == "Tool" && (int)obj.type < 2)
                    {
                        //更换物品
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
                //丢弃物品
                print("丢弃物体");
            }
            image.raycastTarget = true; //射线不可穿透（只能检测到按钮ui）
        });
        trigger.triggers.Add(entry);

        

        //加值一次性道具使用事件
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
    /// 更换物体
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
    /// 将对应装备脱下
    /// </summary>
    /// <param name="btn">对应装备的按钮Transform引用</param>
    /// <param name="obj">对应装备GameObj装备的数据</param>
    void SetBtnTakeOff(Transform btn,GameObj obj)
    {
        if (obj!=null)
        {
            //将装备图标重新绑定到背包装备栏
            btn.parent=btnParent;
            obj.isTakeOn = false;
            btn.GetComponent<Image>().raycastTarget = true; 
            //GameObj zoreTemp = new GameObj();
            //zoreTemp.type = obj.type;
            //AddValue(zoreTemp);
            obj.AddValue(0);    //接触装备增益
        }
    }

    /// <summary>
    /// 穿上装备
    /// </summary>
    /// <param name="target">穿戴目标栏位的Transform引用</param>
    /// <param name="btn">装备图标按钮的Transform引用</param>
    void SetBtnTakeOn(Transform target, Transform btn)
    {
        btn.transform.parent = target.parent.transform;
        btn.transform.SetAsFirstSibling();
        btn.transform.localPosition = Vector3.zero;
        btn.GetComponent<RectTransform>().sizeDelta =
            target.parent.GetComponent<RectTransform>().sizeDelta;  //设置装备图标大小与目标栏位的大小一致
        GameObj obj = MyPlayer.myPlayer.GetBagToolWithName(btn.name);
        obj.isTakeOn = true;
        //AddValue(obj);
        obj.AddValue();
    }

    /// <summary>
    /// 更新显示的玩家属性
    /// </summary>
    void UpdatePlayerValue()
    {
        textHp.text = "生命：" + MyPlayer.myPlayer.GetHp() + "/" + MyPlayer.myPlayer.hpMax;
        textMp.text = "内力：" + MyPlayer.myPlayer.GetMp() + "/" + MyPlayer.myPlayer.mpMax;
        textAtt.text = "攻击：" + MyPlayer.myPlayer.GetAtt();
        textDef.text = "防御：" + MyPlayer.myPlayer.GetDef();
        textMdf.text = "魔抗：" + MyPlayer.myPlayer.GetMdf();
        textSpd.text = "速度：" + MyPlayer.myPlayer.GetSpd();
        textLv.text = "等级：" + MyPlayer.myPlayer.lv;
        textExp.text = "经验：" + MyPlayer.myPlayer.exp;
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
    /// 初始化属性文本信息
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
