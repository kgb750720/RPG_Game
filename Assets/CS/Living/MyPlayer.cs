using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

/// <summary>
/// ��ҵ�����
/// </summary>
public class MyPlayer : People
{
    [Header("=============�������=============")]
    public Transform objPanel;
    public Control action;
    public static MyPlayer myPlayer;
    CharacterController controller;
    Animator animator;

    float wValue;   //ǰ����ֵ
    float rValue;   //ת���ֵ
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

    bool _CtrlEnable=true;  //��ǰ����ܱ����Ʊ�־

    public Dictionary<GameObj, int> bagTools = new Dictionary<GameObj, int>();

    Dictionary<int, SkillBase> skills = new Dictionary<int, SkillBase>();

    public Transform skillsParent;

    //���ð󶨰������������õķ���
    void SetInput()
    {
        //var t = PlayerPanel.playerPanel;
        objPanel = PlayerPanel.playerPanel.transform.Find("BtnParent").Find("Tool");
        action = new Control();
        action.Enable();
        //����
        action.MyControls.Move.started += Move;     //���½���ʱ
        action.MyControls.Move.performed += Move;   //��ס����ʱ
        action.MyControls.Move.canceled += StopMove;//�ɿ�����ʱ
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
        //����
        action.MyAtt.SwordOut.started += SwordOut;
        action.MyAtt.Att.started += Attack;
        //ҩƷʹ��
        action.Hmp._1.started += GetKeyClick;
        action.Hmp._2.started += GetKeyClick;
        action.Hmp._3.started += GetKeyClick;
        action.Hmp._4.started += GetKeyClick;
        action.Hmp._5.started += GetKeyClick;
        action.Hmp._6.started += GetKeyClick;
        action.Hmp._7.started += GetKeyClick;
        action.Hmp._8.started += GetKeyClick;
        //����ʹ��
        action.Skill.F1.started += SkillAtt;
        action.Skill.F2.started += SkillAtt;
        action.Skill.F3.started += SkillAtt;
        action.Skill.F4.started += SkillAtt;
        action.Skill.F5.started += SkillAtt;
        action.Skill.F6.started += SkillAtt;
    }

    /// <summary>
    /// ���ü��ܶ�Ӧ��ЧԤ����
    /// </summary>
    /// <param name="num">��ЧԤ������</param>
    void SkillPrefab(int num)
    {
        //print(num);
        skills[num].SkillPrefab();
    }

    /// <summary>
    /// ���¼���CDʱ��
    /// ����ÿ֡���ò�����ȷ��Ч
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
            image = skillsParent.GetChild(i).GetChild(0).GetComponent<Image>(); //��ȡ����CD��ʾ��img����
            skills[i + 1].Update();     //�ֶ����м��ܶ���Update�����ĵ���
            image.fillAmount = skills[i+1].GetFillTime();   // ���¼���CD��ʾ��Ӧ��img��fillAmount�����Ϣ
            //print(skills[i + 1].GetFillTime());
        }
    }

    /// <summary>
    /// ��������İ󶨺���
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

        //obj.control.ToString()����InputActions�ļ��иÿ��������������"ActionMaps/Actions"Ϊ��ʽ���ַ�����ʽ
        string[] str = obj.control.ToString().Split('/');   //��'/'�������ַ����ֶ�
        int idx = int.Parse(str[2][1].ToString());  //str[2]Ϊ���������"FN"���˴���ȡ����ļ��ܱ��
        SkillBase skill = skills[idx];      //���ݼ��ܱ�Ż�ȡ��Ӧ����������Ϣ

        //����ǰ���ܿ��ͷ�
        if (skill.isRelease)
        {
            animator.SetTrigger("CSkill" + idx);    //���ö�Ӧ����
            skill.Release();        //�ͷż���
        }
    }

    /// <summary>
    /// ��ʼ������
    /// �󶨶�Ӧ����������Ϣ
    /// </summary>
    void InitSkill()
    {
        SphereSkill thunderBombCut = new SphereSkill("�ױ�ն", SkillType.magic, 3, -att * 3, 100, 20);
        skills.Add(1, thunderBombCut);
        SphereSkill windCircleCut = new SphereSkill("����ն", SkillType.physics, 4, -att * 2.5f, 50, 15);
        skills.Add(2, windCircleCut);
        SphereSkill thunderLightCut = new SphereSkill("�׹�ն", SkillType.physics, 4, -att * 1.5f, 80, 10);
        skills.Add(3, thunderLightCut);
        SphereSkill oneCut = new SphereSkill("��һն", SkillType.physics, 3, -att * 1.5f, 30, 8);
        skills.Add(4, oneCut);
        SphereSkill crossCut = new SphereSkill("ʮ��ն", SkillType.physics, 05, -att * 1, 40, 20);
        skills.Add(5, crossCut);
        SphereSkill thunderLargeCut = new SphereSkill("����ն", SkillType.physics, 1.5f, -att * 5, 120, 25);
        skills.Add(6, thunderLargeCut);

        //�󶨼���ʩ����
        foreach (SkillBase item in skills.Values)
        {
            item.from = this;
        }
    }

    /// <summary>
    /// ��ȡ����ʹ������
    /// </summary>
    /// <param name="obj"></param>
    private void GetKeyClick(InputAction.CallbackContext obj)
    {
        //bj.control.ToString()��õ���control�ļ���İ����󶨰���·��
        string[] str = obj.control.ToString().Split('/');
        int idx = int.Parse(str[2]) - 1;
        UseObj(idx);
    }

    /// <summary>
    /// ���ݶ�Ӧ���������ʹ�õ���
    /// </summary>
    /// <param name="idx">���������</param>
    private void UseObj(int idx)
    {
        Transform temp = objPanel.GetChild(idx);
        //������ʹ����δ�����ϵ��ߣ�δ�����ϵ���ʱchildCountΪ1
        if (temp.childCount < 2)
        {
            return;
        }
        Transform t = temp.GetChild(0);
        GameObj obj = GetBagToolWithName(t.name);
        obj.AddValue();     //ʹ�õ���
        bagTools[obj]--;    //�����ڵ��߼�1
        
        UpdataObjPanel();   //������Ʒ����ʹ����
    }

    /// <summary>
    /// ������Ʒ����ʹ����
    /// </summary>
    private void UpdataObjPanel()
    {
        for (int i = 0; i < objPanel.childCount; i++)
        {
            Transform temp = objPanel.GetChild(i);
            //����δ����Ʒ����Ʒ������
            if (temp.childCount < 2)
            {
                continue;
            }
            GameObj obj = GetBagToolWithName(temp.GetChild(0).name);
            
            if (obj == null )   //����Ʒ�Ѿ��޷�����������ҵ�
            {
                Destroy(temp.GetChild(0).gameObject);   //���ٵ���ʹ�����ϵĵ���ͼ��
            }
            else if (bagTools[obj] == 0)    //����Ʒ�ѱ��ù⣨����Ϊ0��
            {
                bagTools.Remove(obj);       //����Ʒ��Ϣ����������Ƴ�
                Destroy(temp.GetChild(0).gameObject);   //���ٵ���ʹ�����ϵĵ���ͼ��
            }
            else
                temp.GetChild(0).GetComponentInChildren<Text>().text = bagTools[obj].ToString();    //��������ϵ���Ʒ����������Ʒ����Ϣ
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
            //��ʱ����ǰ�����˲���
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

        //���ݸı��İε�״̬�趨�ܲ�����״̬
        if (animator.GetBool("SwordOut"))
            animator.SetFloat("ForwardSwordOut", 1);
        else
            animator.SetFloat("ForwardSwordOut", 0);
    }

    /// <summary>
    /// ���ʱNPC����Ʒ��ʹ��
    /// </summary>
    /// <param name="obj"></param>
    private void CilckNpcAndTool(InputAction.CallbackContext obj)
    {
        //���ָ���Ƿ�ָ��UGUI�ϵ��¼������ڱ�����Ҵ��ڲ˵��в���ʱ���������ɽ��������Ͻ��в���Ҫ�Ĳ�����
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
                //���öԻ�
                npc.StartTalk();
            }
            else
            {
                //��'_'Ϊ�ָ�ָ��ַ���
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
    /// �ж����ٹ���
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

    //Ĭ�ϰ󶨰�ס��������������ת��
    private void Hold(InputAction.CallbackContext obj)
    {
        if (!_CtrlEnable)
        {
            return;
        }
        //�жϵ�ǰ����״̬
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
    /// ��ʼ���������
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
    /// Ϊ���������ӵ���
    /// </summary>
    /// <param name="gObj">��������</param>
    /// <param name="num">��������</param>
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
        //0Ϊ�յ�״̬
        sword.SetActive(n == 0);
        swordBack.SetActive(n != 0);
    }

    /// <summary>
    /// ���ݵ�������ȡ�������Я���ĵ�������
    /// </summary>
    /// <param name="str">������</param>
    /// <returns>��������</returns>
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
        //ת��
        if (isHlod)
        {
            transform.Rotate(transform.up * rValue * 0.3f);
        }
        //����������Idle_Fightʱ��������ǰ�����˿���
        if (this.animator.GetCurrentAnimatorStateInfo(0).IsName("Idle_Fight"))
        {
            action.MyControls.Move.Enable();
            action.MyControls.MoveBack.Enable();
        }

        //���¶�����״̬
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
        //������ǰ���ƶ�
        controller.Move(transform.forward * wValue * Time.fixedDeltaTime * spd * spdFast);

        //����������ģ��
        controller.Move(transform.up * -9.8f * Time.fixedDeltaTime);
        
    }
}
