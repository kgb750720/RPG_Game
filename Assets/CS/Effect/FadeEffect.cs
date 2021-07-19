using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 用于控制被挂上的实例化物体贴图组件亮度通道的类
/// </summary>
public class FadeEffect : MonoBehaviour
{

    /// <summary>
    /// 控制贴图变成目标亮度的协程方法
    /// </summary>
    /// <param name="value">贴图的目标alpha通道亮度</param>
    /// <param name="FadeHandle">转变完毕后执行的的带string参数的方法（项目中是使用了SceneManager.LoadScene(string)方法）</param>
    /// <param name="s">转变完毕后执行方法的参数</param>
    /// <returns></returns>
    public IEnumerator Fade(float value, Action<string> FadeHandle, string s)
    {
        //获取贴图alpha通道（亮度通道）
        float alpha = GetComponent<Image>().color.a;
        while (Mathf.Abs(alpha - value) > 0.1f)
        {
            alpha = Mathf.Lerp(alpha, value, 0.05f);    //做当前贴图alpha值对应目标value的插值
            GetComponent<Image>().color = new Color(0, 0, 0, alpha);
            yield return new WaitForFixedUpdate();  //每fixed帧执行一次
        }
        FadeHandle(s);
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
