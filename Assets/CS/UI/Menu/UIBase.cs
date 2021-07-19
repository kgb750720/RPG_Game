using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

/// <summary>
/// 单个UI基类控制类
/// </summary>
public class UIBase : MonoBehaviour
{
    public Transform btnParent;     //按钮父物体的Transform引用
    public GameObject prefab;       //UI中存在的被列出的单个的元素项的预制体引用（其中包含了两个text组件，分别名为"title"、"text"）
    public UnityAction<int> funClickHandle; //UI当前指向的点击执行事件
    protected UITween tween;        //UI移动控制类
    protected List<RectTransform> childRect = new List<RectTransform>();
    protected Button btnBack;       //UI菜单返回按钮的引用
    protected Text text;            //UI文本
    
    /// <summary>
    /// 销毁指定的btnParent Transform下的按钮
    /// </summary>
    /// <param name="parent">待销毁按钮所绑定的btnParent Transform</param>
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
    /// 菜单启动
    /// </summary>
    /// <param name="uis">菜单启动所调用的待弹出ui</param>
    public virtual void MenuStart(params UITween[] uis)
    {
        //弹出所有待弹出ui
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
