using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum SkillType { magic,physics,Up };

/// <summary>
/// 技能当前的数据信息
/// </summary>
public class SkillBase 
{
    protected GameObject prefab;    //技能特效预制体
    protected SkillType type;       //技能伤害类型
    protected string path = "Prefabs/Skill/";    // 技能预制体路径
    protected string skillName;     //技能名
    protected float attValue = 30;  //技能伤害
    public float mp;                //技能消耗mp
    public People from;             //技能施放者
    protected People tPeaple;       //技能对象目标
    protected Dictionary<SkillType, UnityAction<Vector3, Quaternion>> typeWithSkill //不同技能类型对应的伤害函数
        = new Dictionary<SkillType, UnityAction<Vector3, Quaternion>>();
    public float CDTiem = 0;          //技能时间计时器
    protected float skillTime;      //技能时间
    public float disPos;
    public bool isRelease { get; private set; }  //技能可释放标志

    protected void Init()
    {
        isRelease = true;
        prefab = GameManager.Load<GameObject>(path + skillName) as GameObject;
        typeWithSkill.Add(SkillType.magic, MagicHurt);
        typeWithSkill.Add(SkillType.physics, PhysicHurt);
        typeWithSkill.Add(SkillType.Up, HpUp);
    }

    /// <summary>
    /// 获得当前技能CD时间
    /// </summary>
    /// <returns></returns>
    public float GetFillTime()
    {
        return CDTiem / skillTime;
    }

    public virtual void HpUp(Vector3 arg0, Quaternion arg1)
    {
        
    }

    public virtual void PhysicHurt(Vector3 arg0, Quaternion arg1)
    {
        
    }

    public virtual void MagicHurt(Vector3 arg0, Quaternion arg1)
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame

    /// <summary>
    /// 更新技能CD时间
    /// </summary>
    public void Update()
    {
        if (isRelease)
        {
            return;
        }
        CDTiem -= Time.deltaTime;
        //技能时间结束后将可释放标志置为可以释放状态
        if (CDTiem<=0)
        {
            isRelease = true;
        }
    }

    /// <summary>
    /// 根据当前技能状态释放技能
    /// </summary>
    public virtual void Release()
    {
        if (!isRelease)
        {
            return;
        }
        isRelease = false;
        CDTiem = skillTime;
    }

    /// <summary>
    /// 产生技能对应预制体
    /// </summary>
    public virtual void SkillPrefab()
    {
        Vector3 pos = from.transform.position + from.transform.forward;//施放对象的世界坐标
        Quaternion qua = from.transform.rotation;           //释放对象的世界旋转
        //GameObject effect = GameObject.Instantiate(prefab, pos, qua);  //产生技能特效
        //GameObject.Destroy(effect = GameObject.Instantiate(prefab, pos, qua));
        GameObject.Destroy(GameObject.Instantiate(prefab, pos, qua),5f); //产生技能特效5s后删除
    }
}
