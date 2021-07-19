using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ���ڿ��Ʊ����ϵ�ʵ����������ͼ�������ͨ������
/// </summary>
public class FadeEffect : MonoBehaviour
{

    /// <summary>
    /// ������ͼ���Ŀ�����ȵ�Э�̷���
    /// </summary>
    /// <param name="value">��ͼ��Ŀ��alphaͨ������</param>
    /// <param name="FadeHandle">ת����Ϻ�ִ�еĵĴ�string�����ķ�������Ŀ����ʹ����SceneManager.LoadScene(string)������</param>
    /// <param name="s">ת����Ϻ�ִ�з����Ĳ���</param>
    /// <returns></returns>
    public IEnumerator Fade(float value, Action<string> FadeHandle, string s)
    {
        //��ȡ��ͼalphaͨ��������ͨ����
        float alpha = GetComponent<Image>().color.a;
        while (Mathf.Abs(alpha - value) > 0.1f)
        {
            alpha = Mathf.Lerp(alpha, value, 0.05f);    //����ǰ��ͼalphaֵ��ӦĿ��value�Ĳ�ֵ
            GetComponent<Image>().color = new Color(0, 0, 0, alpha);
            yield return new WaitForFixedUpdate();  //ÿfixedִ֡��һ��
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
