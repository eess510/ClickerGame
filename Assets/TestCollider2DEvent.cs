using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

/*public class TestCollider2DEvent : MonoBehaviour
{

    [SerializeField]
    Vector3 m_offset;

    [SerializeField]
    float m_trailTime = 1f;

    [SerializeField]
    int collisionCount = 0;

    [SerializeField]
    int triggerCount = 0;


    enum ColliderEvent
    {
        Nothing,
        CollisionEnter,
        CollisionStay,
        CollisionExit,
        TriggerEnter,
        TriggerStay,
        TriggerExit,
    }
    ColliderEvent m_colliderEvent;
    Vector3 m_prePos;

    private void Start()
    {
        m_prePos = transform.position;
    }

   
    private void OnCollisionEnter2D(Collision2D collision)
    {
       m_colliderEvent = ColliderEvent.CollisionEnter;
       collisionCount++;

    }
    

    private void OnCollisionStay2D(Collision2D collision)
    {
        m_colliderEvent = ColliderEvent.CollisionStay;

    }

    private void OnCollisionExit2D(Collision2D collision) 
    {
        m_colliderEvent = ColliderEvent.CollisionExit;
    }



    private void OnTriggerEnter2D(Collider2D collision) // 감지영역 진입
    {
        m_colliderEvent = ColliderEvent.TriggerEnter;
        triggerCount++;



    }
    private void OnTriggerStay2D(Collider2D collision) // 감지 영역 머무르는 중
    {
        m_colliderEvent = ColliderEvent.TriggerStay;

    }

    private void OnTriggerExit2D(Collider2D collision) // 감지 영역을 떠남
    {
        m_colliderEvent = ColliderEvent.TriggerExit;


    }


    private void OnDrawGizmos()  //디버깅 정보 시각적으로
    {
        var style = new GUIStyle( GUI.skin.GetStyle("Label" ));
        style.normal.textColor = Color.white;
        style.fontSize = 15;

        switch (m_colliderEvent)
        {
            case ColliderEvent.CollisionEnter:
            case ColliderEvent.TriggerEnter:
                style.normal.textColor = Color.red;
                break;
            case ColliderEvent.CollisionStay:
            case ColliderEvent.TriggerStay:
                style.normal.textColor = Color.green;
                break;
            case ColliderEvent.CollisionExit:
            case ColliderEvent.TriggerExit:
                style.normal.textColor = Color.blue;
                break;


        }
    Handles.Label(transform.position + m_offset, $"Event:{m_colliderEvent}", style); //텍스트 화면에 출력
        var collider = GetComponent<Collider2D>();
        string label = collider.isTrigger ? "IsTrigger[v]" : "IsTrigger[ ]";
        var pos = collider.transform.position + m_offset + Vector3.down * 0.5f;
        
        Handles.Label(pos,label,style);

        Vector3 countPos = transform.position + m_offset + Vector3.down * 1.0f;
        Handles.Label(countPos + Vector3.down * 1.0f, $"Collision Count: {collisionCount}", style);
        Handles.Label(countPos + Vector3.down * 1.5f, $"Trigger Count: {triggerCount}", style);

        Debug.DrawLine(m_prePos,transform.position, Color.white, m_trailTime); // 선을 화면에 그림 . 잔상시간
        m_prePos = transform.position;
    
    
    }


}
*/