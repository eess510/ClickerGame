using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DeadLineController : MonoBehaviour
{
    [SerializeField]
    int m_detectedCount = 0;

    [SerializeField]
    float m_deadTime = 0f;

    [SerializeField]
    float m_maxDeadTime = 5f;

    [SerializeField]
    Animator anim;


    [SerializeField]
    UnityEvent m_deadLineEvent;


    [ContextMenu(nameof(Dead))]
    void Dead() //������� ����Ǹ� �� ������Ʈ �ʿ� ���� . ��Ȱ��ȭ
    {
        Debug.Log("������� ����");
        m_deadLineEvent.Invoke(); //������� ���� �̺�Ʈ�˸�
        enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        m_detectedCount++;
        Debug.Log("������� ������ ����");
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        m_detectedCount--;
        if (m_detectedCount == 0)
            m_deadTime = 0f;  /// ���� ������ �����ϰ� ���������� ������ ����
    }

    public void Update()
    {
        if(m_detectedCount != 0)
        {
            m_deadTime += Time.deltaTime;
            if(m_deadTime > m_maxDeadTime)
            {
                Dead();
            }
        }
        anim.SetFloat("DateTime",m_deadTime);
    }
}
