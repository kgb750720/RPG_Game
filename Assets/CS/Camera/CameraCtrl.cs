using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �����������������ƶ��Ľű�
/// </summary>
public class CameraCtrl : MonoBehaviour
{
    public float dis;   //���������
    public float height;    //������߶�
    public float speed;     //������ٶ�
    Transform target;   //��׼Ŀ���Transform����
    Vector3 targetPos;  //���������������λ��Ŀ���v3��Ϣ
    // Start is called before the first frame update
    void Start()
    {
        //����Ҷ����Transform����
        target = MyPlayer.myPlayer.transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target.position+Vector3.up*1.5f);  //�����������ҽŵ�����1.5m�ߵ�λ��
        targetPos = target.forward * (-dis) + target.up * height + target.position; //���ݵ�ǰtarget��Ϣ�Լ�dis��height���������������Ŀ����������λ��V3λ��
    }

    private void LateUpdate()
    {
        //����ִ�к�������µ�targetPos��Ϣ��������������굽Ŀ��λ�õ�λ�Ʋ�ֵ
        transform.position = Vector3.Lerp(transform.position, targetPos, speed);
    }
}
