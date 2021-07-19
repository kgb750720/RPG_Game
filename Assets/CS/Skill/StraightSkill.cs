using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 指向性技能
/// </summary>
public class StraightSkill : SkillBase
{
    float dic;  //技能距离

    /// <summary>
    /// 直线技能构造函数
    /// </summary>
    /// <param name="n">技能名</param>
    /// <param name="_type">伤害类型</param>
    /// <param name="_dic">距离</param>
    /// <param name="att">伤害</param>
    /// <param name="_mp">mp消耗</param>
    /// <param name="_skillTime">技能cd时间</param>
    public StraightSkill(string n, SkillType _type, float _dic,float att, float _mp, float _skillTime)
    {
        skillName = n;
        type = _type;
        dic = _dic;
        attValue = att;
        mp = _mp;
        skillTime = _skillTime;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
