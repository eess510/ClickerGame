using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DropController : MonoBehaviour
{

    [SerializeField]
     FruitSpawner m_fruitSpawner;

    [SerializeField]
    Transform m_dropPoint;

    [SerializeField]
    int m_fruitLevel; //지정한 레벨로 과일을 스폰시키기 위한 변수추가


    [SerializeField]
    UnityEvent m_dropEvent;
    Fruit m_fruit;

    [SerializeField]
    Transform m_fruitContainer;


    private void OnMouseDown()
    {

        if (m_fruit != null) // 과일이 있을때만 드롭
        {
            Debug.Log("과일 드랍해");

           
            m_fruit.transform.SetParent(m_fruitContainer); 
            m_fruit.StartPhysics(); // 클릭하면 물리작용 시작


            m_dropEvent.Invoke();
            m_fruit = null;
            
        }
    }

    public void SetFruits(Fruit fruit) //생산된 과일을 넣어줄 수 있는 함수추가
    {
        if(m_fruit != null)
            Destroy(m_fruit.gameObject);


        m_fruit = fruit;
        m_fruit.transform.SetParent(m_dropPoint); //생산된 과일을 드롭포인트 자식으로 넣기
        m_fruit.transform.localPosition = Vector3.zero; //부모 좌표 기준에서 위치 

        m_fruit.StopPhysics(); //클릭 전까지 물리작용 중단
    }
    private void OnMouseOver()
    
    {
        var pos = Camera.main.ScreenToWorldPoint(Input.mousePosition); 
        pos.y = m_dropPoint.position.y; 
        pos.z = 0;
        m_dropPoint.position = pos;
    }


}
