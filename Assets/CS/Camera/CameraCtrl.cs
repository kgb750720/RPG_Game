using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 控制摄像机跟随玩家移动的脚本
/// </summary>
public class CameraCtrl : MonoBehaviour
{
    public float dis;   //摄像机距离
    public float height;    //摄像机高度
    public float speed;     //摄像机速度
    Transform target;   //对准目标的Transform引用
    Vector3 targetPos;  //摄像机在世界坐标位移目标的v3信息
    // Start is called before the first frame update
    void Start()
    {
        //绑定玩家对象的Transform引用
        target = MyPlayer.myPlayer.transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target.position+Vector3.up*1.5f);  //摄像机朝向玩家脚底向上1.5m高的位置
        targetPos = target.forward * (-dis) + target.up * height + target.position; //根据当前target信息以及dis、height变量设置摄像机的目标世界坐标位移V3位置
    }

    private void LateUpdate()
    {
        //在针执行后根据最新的targetPos信息做摄像机世界坐标到目标位置的位移插值
        transform.position = Vector3.Lerp(transform.position, targetPos, speed);
    }
}
