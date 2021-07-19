using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//����ί��Funback��Ϊ�ص������¼�
public delegate void Funback();

/// <summary>
/// UI�ƶ�������
/// ������̬UI
/// </summary>
public class UITween : MonoBehaviour
{
    Vector2 startPos;   //�����Ļ�ⵯ��Ŀ�ʼ����
    Vector2 targetPos;  //Ŀ������
    public Vector2 offsetPos;
    public event Funback funBack;   //���ƶ���ʼ�¼�
    public event Funback funStart;  //����ƶ�����¼�
    public event Funback funPop;    //��嵯���¼�
    public event Funback funPush;   //���ѹ�������¼�
    RectTransform rect;     //��������UI����

    public Vector2 StartPos { get => startPos; }    //�����Ļ�ⵯ�����ʼ����
    public Vector2 TargetPos { get => targetPos; }  //�����Ļ�ڵ����Ŀ������

    public float MoveSpeedOfFrame=0.1f; //����ƶ��ٶ�
    private void Awake()
    {
        startPos = transform.position;
        rect = GetComponent<RectTransform>();
        //targetPos = transform.parent.position;
    }

    /// <summary>
    /// �ƶ�����Э�̷���
    /// </summary>
    /// <returns></returns>
    public IEnumerator MoveTo()
    {
        while(Mathf.Abs(rect.position.x-targetPos.x)>5)
        {
            rect.position = Vector2.Lerp(rect.position, targetPos, MoveSpeedOfFrame);   //������������Ŀ����������ֵ��ÿִ֡��һ��
            yield return new WaitForFixedUpdate();  //Э�̵ȴ�һ֡��ʱ��
        }
        //������ƶ�Э��ִ����Ϻ�ִ������ƶ�����¼�
        if (funBack!=null)
        {
            funBack();
            funBack = null;
        }
        //�������
        if (targetPos==startPos)
        {
            if(funPush != null)
                funPush();
            funPush = null;
            funPop = null;
        }
    }

    /// <summary>
    /// �˵���ʼ�ƶ�
    /// </summary>
    public void SetMenuStart()
    {
        //��嵯���¼�
        if (funPop != null)
        {
            funPop();
        }

        targetPos = offsetPos + new Vector2(Screen.width / 2, Screen.height / 2);
        StartCoroutine(MoveTo());
        //��Э��ִ������ƶ����̵�ʱ��ִ������ƶ���ʼ�¼�
        if (funStart!=null)
            funStart();
        
    }

    /// <summary>
    /// �˵��������ط���
    /// </summary>
    public void SetMenuBack()
    {
        //Debug.Log("Move");
        targetPos = startPos;
        StartCoroutine(MoveTo());
    }

    /// <summary>
    /// �����������¼�
    /// </summary>
    /// <param name="fun">�����¼�����</param>
    public void AddEventBackHandle(Funback fun)
    {
        funBack += fun;
    }

    /// <summary>
    /// �������������������ui���
    /// </summary>
    /// <param name="uis">��������ui���</param>
    public void SetBtnHandle(params UITween[] uis)
    {
        for (int i = 0; i < uis.Length; i++)
        {
            //�����봰�ڵĵ���ָ����ӵ������¼���ִ��ί�е���
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
