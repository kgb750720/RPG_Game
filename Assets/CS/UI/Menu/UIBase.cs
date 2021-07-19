using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

/// <summary>
/// ����UI���������
/// </summary>
public class UIBase : MonoBehaviour
{
    public Transform btnParent;     //��ť�������Transform����
    public GameObject prefab;       //UI�д��ڵı��г��ĵ�����Ԫ�����Ԥ�������ã����а���������text������ֱ���Ϊ"title"��"text"��
    public UnityAction<int> funClickHandle; //UI��ǰָ��ĵ��ִ���¼�
    protected UITween tween;        //UI�ƶ�������
    protected List<RectTransform> childRect = new List<RectTransform>();
    protected Button btnBack;       //UI�˵����ذ�ť������
    protected Text text;            //UI�ı�
    
    /// <summary>
    /// ����ָ����btnParent Transform�µİ�ť
    /// </summary>
    /// <param name="parent">�����ٰ�ť���󶨵�btnParent Transform</param>
    protected void ClearBtn(Transform parent)
    {
        foreach (Transform item in parent)
        {
            Destroy(item.gameObject);
        }
    }

    public virtual void UpdataValue()
    { }

    /// <summary>
    /// �˵�����
    /// </summary>
    /// <param name="uis">�˵����������õĴ�����ui</param>
    public virtual void MenuStart(params UITween[] uis)
    {
        //�������д�����ui
        foreach (UITween item in uis)
        {
            item.SetMenuStart();
        }
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
