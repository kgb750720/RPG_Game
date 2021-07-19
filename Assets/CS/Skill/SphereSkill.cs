using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 范围技能
/// </summary>
public class SphereSkill : SkillBase
{
    float r;
    /// <summary>
    /// 范围技能构造函数
    /// </summary>
    /// <param name="n">技能名</param>
    /// <param name="_type">伤害类型</param>
    /// <param name="_dic">距离</param>
    /// <param name="att">伤害</param>
    /// <param name="_mp">mp消耗</param>
    /// <param name="_skillTime">技能cd时间</param>
    public SphereSkill(string n,SkillType _type,float _r,float att,float _mp,float _skillTiem)
    {
        skillName = n;
        r = _r;
        mp = _mp;
        type = _type;
        attValue = att;
        skillTime = _skillTiem;
        Init();

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
