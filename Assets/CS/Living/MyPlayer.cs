using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

/// <summary>
/// 玩家单例类
/// </summary>
public class MyPlayer : People
{
    [Header("=============子类变量=============")]
    public Transform objPanel;
    public Control action;
    public static MyPlayer myPlayer;
    CharacterController controller;
    Animator animator;

    float wValue;   //前进的值
    float rValue;   //转向的值
    float spdFast = 1;

    public int lv { set; get; }

    public int exp { set; get; }

    public int offsetHp { set; get; }

    public int offsetMp { set; get; }

    public int offsetAtt { set; get; }
    public int offsetDef { set; get; }
    public int offsetMdf { set; get; }

    public int offsetSpd { set; get; }

    public bool CtrlEnable { get => _CtrlEnable; set => _CtrlEnable = value; }

    bool isHlod;

    public int money;

    GameObject sword;
    GameObject swordBack;

    public Image imageHp;
    public Image imageMp;

    bool _CtrlEnable=true;  //当前玩家能被控制标志

    public Dictionary<GameObj, int> bagTools = new Dictionary<GameObj, int>();

    Dictionary<int, SkillBase> skills = new Dictionary<int, SkillBase>();

    public Transform skillsParent;

    //设置绑定按键输入所调用的方法
    void SetInput()
    {
        //var t = PlayerPanel.playerPanel;
        objPanel = PlayerPanel.playerPanel.transform.Find("BtnParent").Find("Tool");
        action = new Control();
        action.Enable();
        //控制
        action.MyControls.Move.started += Move;     //按下交互时
        action.MyControls.Move.performed += Move;   //按住交互时
        action.MyControls.Move.canceled += StopMove;//松开交互时
        action.MyControls.MoveBack.started += MoveBack;
        action.MyControls.MoveBack.canceled += StopMove;
        action.MyControls.Rotate.started += Rotare;
        action.MyControls.Rotate.performed += Rotare;
        action.MyControls.Rotate.canceled += Rotare;
        action.MyControls.HoldRotate.started += Hold;
        action.MyControls.HoldRotate.canceled += Hold;
        action.MyControls.Fast.started += FastSpeed;
        action.MyControls.Fast.canceled += FastSpeed;
        action.MyControls.GetTool.started += CilckNpcAndTool;
        action.MyControls.Jump.started += Jump;
        //攻击
        action.MyAtt.SwordOut.started += SwordOut;
        action.MyAtt.Att.started += Attack;
        //药品使用
        action.Hmp._1.started += GetKeyClick;
        action.Hmp._2.started += GetKeyClick;
        action.Hmp._3.started += GetKeyClick;
        action.Hmp._4.started += GetKeyClick;
        action.Hmp._5.started += GetKeyClick;
        action.Hmp._6.started += GetKeyClick;
        action.Hmp._7.started += GetKeyClick;
        action.Hmp._8.started += GetKeyClick;
        //技能使用
        action.Skill.F1.started += SkillAtt;
        action.Skill.F2.started += SkillAtt;
        action.Skill.F3.started += SkillAtt;
        action.Skill.F4.started += SkillAtt;
        action.Skill.F5.started += SkillAtt;
        action.Skill.F6.started += SkillAtt;
    }

    /// <summary>
    /// 调用技能对应特效预制体
    /// </summary>
    /// <param name="num">特效预制体编号</param>
    void SkillPrefab(int num)
    {
        //print(num);
        skills[num].SkillPrefab();
    }

    /// <summary>
    /// 更新技能CD时间
    /// 需在每帧调用才能正确生效
    /// </summary>
    void UpdateSkillTime()
    {
        for (int i = 0; i < skillsParent.childCount; i++)
        {
            if (skills[i+1].isRelease)
            {
                continue;
            }
            Image image;
            image = skillsParent.GetChild(i).GetChild(0).GetComponent<Image>(); //获取技能CD表示的img引用
            skills[i + 1].Update();     //手动进行技能对象Update方法的调用
            image.fillAmount = skills[i+1].GetFillTime();   // 更新技能CD表示对应的img的fillAmount填充信息
            //print(skills[i + 1].GetFillTime());
        }
    }

    /// <summary>
    /// 攻击输入的绑定函数
    /// </summary>
    /// <param name="obj"></param>
    private void SkillAtt(InputAction.CallbackContext obj)
    {
        //if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Idle_Fight"))
        //{
        //    return;
        //}
        if (!animator.GetBool("SwordOut"))
        {
            return;
        }

        //obj.control.ToString()会获得InputActions文件中该控制输入的名称以"ActionMaps/Actions"为格式的字符串形式
        string[] str = obj.control.ToString().Split('/');   //以'/'给控制字符串分段
        int idx = int.Parse(str[2][1].ToString());  //str[2]为具体输入的"FN"，此处获取具体的技能编号
        SkillBase skill = skills[idx];      //根据技能编号获取对应技能数据信息

        //若当前技能可释放
        if (skill.isRelease)
        {
            animator.SetTrigger("CSkill" + idx);    //调用对应动画
            skill.Release();        //释放技能
        }
    }

    /// <summary>
    /// 初始化技能
    /// 绑定对应技能数据信息
    /// </summary>
    void InitSkill()
    {
        SphereSkill thunderBombCut = new SphereSkill("雷爆斩", SkillType.magic, 3, -att * 3, 100, 20);
        skills.Add(1, thunderBombCut);
        SphereSkill windCircleCut = new SphereSkill("旋风斩", SkillType.physics, 4, -att * 2.5f, 50, 15);
        skills.Add(2, windCircleCut);
        SphereSkill thunderLightCut = new SphereSkill("雷光斩", SkillType.physics, 4, -att * 1.5f, 80, 10);
        skills.Add(3, thunderLightCut);
        SphereSkill oneCut = new SphereSkill("归一斩", SkillType.physics, 3, -att * 1.5f, 30, 8);
        skills.Add(4, oneCut);
        SphereSkill crossCut = new SphereSkill("十字斩", SkillType.physics, 05, -att * 1, 40, 20);
        skills.Add(5, crossCut);
        SphereSkill thunderLargeCut = new SphereSkill("轰雷斩", SkillType.physics, 1.5f, -att * 5, 120, 25);
        skills.Add(6, thunderLargeCut);

        //绑定技能施放者
        foreach (SkillBase item in skills.Values)
        {
            item.from = this;
        }
    }

    /// <summary>
    /// 获取道具使用输入
    /// </summary>
    /// <param name="obj"></param>
    private void GetKeyClick(InputAction.CallbackContext obj)
    {
        //bj.control.ToString()获得的是control文件里的按键绑定按键路径
        string[] str = obj.control.ToString().Split('/');
        int idx = int.Parse(str[2]) - 1;
        UseObj(idx);
    }

    /// <summary>
    /// 根据对应道具栏编号使用道具
    /// </summary>
    /// <param name="idx">道具栏编号</param>
    private void UseObj(int idx)
    {
        Transform temp = objPanel.GetChild(idx);
        //若道具使用栏未被绑上道具，未被绑上道具时childCount为1
        if (temp.childCount < 2)
        {
            return;
        }
        Transform t = temp.GetChild(0);
        GameObj obj = GetBagToolWithName(t.name);
        obj.AddValue();     //使用道具
        bagTools[obj]--;    //背包内道具减1
        
        UpdataObjPanel();   //更新物品道具使用栏
    }

    /// <summary>
    /// 更新物品道具使用栏
    /// </summary>
    private void UpdataObjPanel()
    {
        for (int i = 0; i < objPanel.childCount; i++)
        {
            Transform temp = objPanel.GetChild(i);
            //跳过未绑定物品的物品栏更新
            if (temp.childCount < 2)
            {
                continue;
            }
            GameObj obj = GetBagToolWithName(temp.GetChild(0).name);
            
            if (obj == null )   //若物品已经无法在玩家身上找到
            {
                Destroy(temp.GetChild(0).gameObject);   //销毁道具使用栏上的道具图标
            }
            else if (bagTools[obj] == 0)    //若物品已被用光（数量为0）
            {
                bagTools.Remove(obj);       //将物品信息从玩家身上移除
                Destroy(temp.GetChild(0).gameObject);   //销毁道具使用栏上的道具图标
            }
            else
                temp.GetChild(0).GetComponentInChildren<Text>().text = bagTools[obj].ToString();    //以玩家身上的物品存量更新物品栏信息
        }

    }

    private void Jump(InputAction.CallbackContext obj)
    {
        if (!CtrlEnable)
        {
            return;
        }
        if (animator.GetCurrentAnimatorStateInfo(0).IsTag("JumpReady"))
        {
            animator.SetTrigger("Jump");
        }
        //animator.SetTrigger()
    }

    private void Attack(InputAction.CallbackContext obj)
    {
        if (!CtrlEnable)
        {
            return;
        }


        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Idle_Fight") ||
            (animator.GetCurrentAnimatorStateInfo(0).IsName("RunBySpeed") && animator.GetBool("SwordOut")))
        {

            animator.SetBool("IsRun", false);
            //暂时禁用前进后退操作
            action.MyControls.Move.Disable();
            action.MyControls.MoveBack.Disable();

            wValue = 0;
            animator.SetFloat("ForwardSpeed", 0);
            animator.SetInteger("Att", 1);
            animator.SetTrigger("AttTrigger");
        }
        else
        {
            int num = animator.GetInteger("Att");
            if (num==5)
            {
                return;
            }
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("Light_Attk_"+num))
            {
                animator.SetInteger("Att", num + 1);
            }
        }
    }

    private void SwordOut(InputAction.CallbackContext obj)
    {
        if (!_CtrlEnable)
        {
            return;
        }
        //print("Sword");
        //if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Sword-Out")&&
        //    !animator.GetCurrentAnimatorStateInfo(0).IsName("Sword-In"))
        //{

        //}

        

        animator.SetBool("SwordOut", !animator.GetBool("SwordOut"));
        animator.SetTrigger("ChangeSword");

        //根据改变后的拔刀状态设定跑步动画状态
        if (animator.GetBool("SwordOut"))
            animator.SetFloat("ForwardSwordOut", 1);
        else
            animator.SetFloat("ForwardSwordOut", 0);
    }

    /// <summary>
    /// 点击时NPC或物品的使用
    /// </summary>
    /// <param name="obj"></param>
    private void CilckNpcAndTool(InputAction.CallbackContext obj)
    {
        //检测指针是否指在UGUI上的事件（用于避免玩家处于菜单中操作时意外点击到可交互物体上进行不必要的操作）
        if (UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        Vector2 pos = Mouse.current.position.ReadValue();
        Ray ray = Camera.main.ScreenPointToRay(pos);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 1000, LayerMask.GetMask("NpcAndTool")))
        {
            NPC npc = hit.collider.GetComponent<NPC>();
            if (npc)
            {
                //设置对话
                npc.StartTalk();
            }
            else
            {
                //以'_'为分割，分割字符串
                string[] str = hit.collider.name.Split('_');
                int oidx = int.Parse(str[0]);
                int num = int.Parse(str[1]);
                GameObj gObj = GameManager.GetGameObj(oidx);
                AddTool(gObj, num);
                Destroy(hit.collider.gameObject);
            } 
        }
    }

    /// <summary>
    /// 行动加速功能
    /// </summary>
    /// <param name="obj"></param>
    private void FastSpeed(InputAction.CallbackContext obj)
    {
        if (!_CtrlEnable)
        {
            return;
        }
        //if (!animator.GetCurrentAnimatorStateInfo(0).IsName("RunBySpeed"))
        if (wValue==0)
        {
            return;
        }
        if (obj.phase==InputActionPhase.Canceled)
        {
            spdFast = 1f;
            
            //animator.SetFloat("ForwardSpeed", wValue * spdFast);
        }
        else
        {
            spdFast = 2f;
            //animator.speed = 2f;
            //animator.SetFloat("ForwardSpeed", wValue * spdFast);
        }
        animator.speed = spdFast;
    }

    //默认绑定按住鼠标左键用于启动转向
    private void Hold(InputAction.CallbackContext obj)
    {
        if (!_CtrlEnable)
        {
            return;
        }
        //判断当前控制状态
        if (obj.phase==InputActionPhase.Canceled)
        {
            isHlod = false;
        }
        else
        {
            isHlod = true;
        }
    }

    private void Rotare(InputAction.CallbackContext obj)
    {
        if (!_CtrlEnable)
        {
            return;
        }
        rValue = obj.ReadValue<float>();
    }

    /// <summary>
    /// 初始化玩家属性
    /// </summary>
    void InitValue()
    {
        if(hpMax==0)
            hpMax = 200;
        //hp = hpMax;
        if(mpMax==0)
            mpMax = 200;
        //mp = mpMax;
        att = 10;
        def = 3;
        spd = 3;
        mdf = 3;
        lv = 1;
    }

    private void StopMove(InputAction.CallbackContext obj)
    {
        wValue = obj.ReadValue<float>();
        animator.SetBool("IsRun", false);
        wValue = 0;
        
    }

    private void Move(InputAction.CallbackContext obj)
    {
        if (!_CtrlEnable)
        {
            return;
        }
        //print(wValue);
        //wValue = obj.ReadValue<float>();
        wValue = 1;
        animator.SetBool("IsRun", true);
        
    }

    private void MoveBack(InputAction.CallbackContext obj)
    {
        if (!_CtrlEnable)
        {
            return;
        }
        animator.SetBool("IsRun", true);
        wValue = -1;
    }

    public int AddMoney(int money)
    {
        this.money += money;
        return money;
    }

    //public   void AddTool(GameObj gObj,int num)
    //{
    //    if (gObj==null)
    //    {
    //        return;
    //    }

    //    //int oidx = gObj.idx;
    //    //if (bagTools.ContainsKey(oidx))
    //    //{
    //           //bagTools[oidx] += num;
    //    //}
    //    if (bagTools.ContainsKey(gObj))
    //    {
    //        bagTools[gObj] += num;
    //    }
    //    else
    //        //bagTools.Add(oidx, num);
    //        bagTools.Add(gObj, num);
    //}
    /// <summary>
    /// 为玩家身上添加道具
    /// </summary>
    /// <param name="gObj">道具数据</param>
    /// <param name="num">道具数量</param>
    public void AddTool(GameObj gObj, int num)
    {
        if (gObj == null)
        {
            return;
        }
        //int oidx = gObj.idx;
        GameObj temp = MyPlayer.myPlayer.GetBagToolWithName(gObj.oname);
        if (temp != null)
        {
            bagTools[temp] += num;
        }
        else
        {
            bagTools.Add(gObj, num);
        }
    }

    public void AddHp(float f)
    {
        hp =Mathf.Clamp(hp + f, 0, hpMax+offsetHp);
        imageHp.fillAmount = hp / (hpMax + offsetHp);
        if (hp==0)
        {
            print("Over");
        }
    }

    public void AddMp(float f)
    {
        mp = Mathf.Clamp(mp + f, 0, mpMax+offsetMp);
        imageMp.fillAmount = hp / (hpMax + offsetMp);
    }

    void SetSwordVisible(int n)
    {
        if (!_CtrlEnable)
        {
            return;
        }
        //0为收刀状态
        sword.SetActive(n == 0);
        swordBack.SetActive(n != 0);
    }

    /// <summary>
    /// 根据道具名获取玩家身上携带的道具数据
    /// </summary>
    /// <param name="str">道具名</param>
    /// <returns>道具数据</returns>
    public GameObj GetBagToolWithName(string str)
    {
        foreach (GameObj obj in bagTools.Keys)
        {
            if (obj.oname==str)
            {
                return obj;
            }
        }
        return null;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        myPlayer = this;
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        sword = transform.Find("Sword_Hand").gameObject;
        sword.SetActive(false);
        swordBack = transform.Find("Sword_Back").gameObject;
        if (skillsParent==null)
        {
            skillsParent = PlayerPanel.playerPanel.transform.Find("BtnParent/Skill");
        }
        InitValue();
        SetInput();
        InitSkill();
    }

    public float GetHp()
    {
        return hp + offsetHp;
    }
    public float GetMp()
    {
        return mp + offsetMp;
    }
    public float GetSpd()
    {
        return spd + offsetSpd;
    }
    public float GetDef()
    {
        return def + offsetDef;
    }
    public float GetMdf()
    {
        return mdf + offsetMdf;
    }

    public float GetAtt()
    {
        return att + offsetAtt;
    }

    public float GetHpx()
    {
        return offsetHp+hpMax;
    }
    public float GetMpx()
    {
        return mpMax + offsetMp;
    }


    // Update is called once per frame
    void Update()
    {

        //print(transform.forward * wValue * Time.deltaTime * spd * spdFast);
        //controller.Move(transform.forward * wValue * Time.deltaTime * spd * spdFast);
        //controller.Move(transform.up * -9.8f * Time.deltaTime);
        if (!_CtrlEnable)
        {
            return;
        }
        UpdateSkillTime();
        //转向
        if (isHlod)
        {
            transform.Rotate(transform.up * rValue * 0.3f);
        }
        //当动画器是Idle_Fight时重新启动前进后退控制
        if (this.animator.GetCurrentAnimatorStateInfo(0).IsName("Idle_Fight"))
        {
            action.MyControls.Move.Enable();
            action.MyControls.MoveBack.Enable();
        }

        //更新动画器状态
        animator.SetFloat("ForwardSpeed", animator.GetBool("SwordOut")&&spdFast>0?spdFast*wValue+1:spdFast*wValue);

    }

    private void FixedUpdate()
    {
        if (!action.MyControls.Move.enabled)
        {
            wValue = 0;
        }
        //print(wValue);
        //print(action.MyControls.Move.enabled);
        //控制器前后移动
        controller.Move(transform.forward * wValue * Time.fixedDeltaTime * spd * spdFast);

        //控制器重力模拟
        controller.Move(transform.up * -9.8f * Time.fixedDeltaTime);
        
    }
}
