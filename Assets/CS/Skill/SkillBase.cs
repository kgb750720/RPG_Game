using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum SkillType { magic,physics,Up };

/// <summary>
/// ���ܵ�ǰ��������Ϣ
/// </summary>
public class SkillBase 
{
    protected GameObject prefab;    //������ЧԤ����
    protected SkillType type;       //�����˺�����
    protected string path = "Prefabs/Skill/";    // ����Ԥ����·��
    protected string skillName;     //������
    protected float attValue = 30;  //�����˺�
    public float mp;                //��������mp
    public People from;             //����ʩ����
    protected People tPeaple;       //���ܶ���Ŀ��
    protected Dictionary<SkillType, UnityAction<Vector3, Quaternion>> typeWithSkill //��ͬ�������Ͷ�Ӧ���˺�����
        = new Dictionary<SkillType, UnityAction<Vector3, Quaternion>>();
    public float CDTiem = 0;          //����ʱ���ʱ��
    protected float skillTime;      //����ʱ��
    public float disPos;
    public bool isRelease { get; private set; }  //���ܿ��ͷű�־

    protected void Init()
    {
        isRelease = true;
        prefab = GameManager.Load<GameObject>(path + skillName) as GameObject;
        typeWithSkill.Add(SkillType.magic, MagicHurt);
        typeWithSkill.Add(SkillType.physics, PhysicHurt);
        typeWithSkill.Add(SkillType.Up, HpUp);
    }

    /// <summary>
    /// ��õ�ǰ����CDʱ��
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
    /// ���¼���CDʱ��
    /// </summary>
    public void Update()
    {
        if (isRelease)
        {
            return;
        }
        CDTiem -= Time.deltaTime;
        //����ʱ������󽫿��ͷű�־��Ϊ�����ͷ�״̬
        if (CDTiem<=0)
        {
            isRelease = true;
        }
    }

    /// <summary>
    /// ���ݵ�ǰ����״̬�ͷż���
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
    /// �������ܶ�ӦԤ����
    /// </summary>
    public virtual void SkillPrefab()
    {
        Vector3 pos = from.transform.position + from.transform.forward;//ʩ�Ŷ������������
        Quaternion qua = from.transform.rotation;           //�ͷŶ����������ת
        //GameObject effect = GameObject.Instantiate(prefab, pos, qua);  //����������Ч
        //GameObject.Destroy(effect = GameObject.Instantiate(prefab, pos, qua));
        GameObject.Destroy(GameObject.Instantiate(prefab, pos, qua),5f); //����������Ч5s��ɾ��
    }
}
