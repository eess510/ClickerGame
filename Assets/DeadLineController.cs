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
    void Dead() //데드라인 적용되면 이 컴포넌트 필요 없음 . 비활성화
    {
        Debug.Log("데드라인 적용");
        m_deadLineEvent.Invoke(); //데드라인 적용 이벤트알림
        enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        m_detectedCount++;
        Debug.Log("데드라인 영역에 들어옴");
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        m_detectedCount--;
        if (m_detectedCount == 0)
            m_deadTime = 0f;  /// 감지 영역에 진입하고 나갈때마다 감지수 관리
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
