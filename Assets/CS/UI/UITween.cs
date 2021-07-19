using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//声明委托Funback作为回调函数事件
public delegate void Funback();

/// <summary>
/// UI移动控制类
/// 制作动态UI
/// </summary>
public class UITween : MonoBehaviour
{
    Vector2 startPos;   //面板屏幕外弹入的开始坐标
    Vector2 targetPos;  //目标坐标
    public Vector2 offsetPos;
    public event Funback funBack;   //面移动开始事件
    public event Funback funStart;  //面板移动完毕事件
    public event Funback funPop;    //面板弹出事件
    public event Funback funPush;   //面板压入收起事件
    RectTransform rect;     //自身面板的UI坐标

    public Vector2 StartPos { get => startPos; }    //面板屏幕外弹入的起始坐标
    public Vector2 TargetPos { get => targetPos; }  //面板屏幕内弹入的目标坐标

    public float MoveSpeedOfFrame=0.1f; //面板移动速度
    private void Awake()
    {
        startPos = transform.position;
        rect = GetComponent<RectTransform>();
        //targetPos = transform.parent.position;
    }

    /// <summary>
    /// 移动过程协程方法
    /// </summary>
    /// <returns></returns>
    public IEnumerator MoveTo()
    {
        while(Mathf.Abs(rect.position.x-targetPos.x)>5)
        {
            rect.position = Vector2.Lerp(rect.position, targetPos, MoveSpeedOfFrame);   //面板自身坐标对目标坐标做插值，每帧执行一次
            yield return new WaitForFixedUpdate();  //协程等待一帧的时间
        }
        //在面板移动协程执行完毕后执行面板移动完毕事件
        if (funBack!=null)
        {
            funBack();
            funBack = null;
        }
        //面板收起
        if (targetPos==startPos)
        {
            if(funPush != null)
                funPush();
            funPush = null;
            funPop = null;
        }
    }

    /// <summary>
    /// 菜单开始移动
    /// </summary>
    public void SetMenuStart()
    {
        //面板弹出事件
        if (funPop != null)
        {
            funPop();
        }

        targetPos = offsetPos + new Vector2(Screen.width / 2, Screen.height / 2);
        StartCoroutine(MoveTo());
        //在协程执行面板移动过程的时候执行面板移动开始事件
        if (funStart!=null)
            funStart();
        
    }

    /// <summary>
    /// 菜单返回隐藏方法
    /// </summary>
    public void SetMenuBack()
    {
        //Debug.Log("Move");
        targetPos = startPos;
        StartCoroutine(MoveTo());
    }

    /// <summary>
    /// 添加面板收起事件
    /// </summary>
    /// <param name="fun">收起事件方法</param>
    public void AddEventBackHandle(Funback fun)
    {
        funBack += fun;
    }

    /// <summary>
    /// 设置面板收起后待弹出的ui面板
    /// </summary>
    /// <param name="uis">待弹出的ui面板</param>
    public void SetBtnHandle(params UITween[] uis)
    {
        for (int i = 0; i < uis.Length; i++)
        {
            //将传入窗口的弹入指令添加到弹出事件的执行委托当中
            AddEventBackHandle(uis[i].SetMenuStart);
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
