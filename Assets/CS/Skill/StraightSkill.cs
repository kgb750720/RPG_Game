using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ָ���Լ���
/// </summary>
public class StraightSkill : SkillBase
{
    float dic;  //���ܾ���

    /// <summary>
    /// ֱ�߼��ܹ��캯��
    /// </summary>
    /// <param name="n">������</param>
    /// <param name="_type">�˺�����</param>
    /// <param name="_dic">����</param>
    /// <param name="att">�˺�</param>
    /// <param name="_mp">mp����</param>
    /// <param name="_skillTime">����cdʱ��</param>
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
