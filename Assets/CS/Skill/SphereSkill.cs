using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ��Χ����
/// </summary>
public class SphereSkill : SkillBase
{
    float r;
    /// <summary>
    /// ��Χ���ܹ��캯��
    /// </summary>
    /// <param name="n">������</param>
    /// <param name="_type">�˺�����</param>
    /// <param name="_dic">����</param>
    /// <param name="att">�˺�</param>
    /// <param name="_mp">mp����</param>
    /// <param name="_skillTime">����cdʱ��</param>
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
