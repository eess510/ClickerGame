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
    int m_fruitLevel; //������ ������ ������ ������Ű�� ���� �����߰�


    [SerializeField]
    UnityEvent m_dropEvent;
    Fruit m_fruit;

    [SerializeField]
    Transform m_fruitContainer;


    private void OnMouseDown()
    {

        if (m_fruit != null) // ������ �������� ���
        {
            Debug.Log("���� �����");

           
            m_fruit.transform.SetParent(m_fruitContainer); 
            m_fruit.StartPhysics(); // Ŭ���ϸ� �����ۿ� ����


            m_dropEvent.Invoke();
            m_fruit = null;
            
        }
    }

    public void SetFruits(Fruit fruit) //����� ������ �־��� �� �ִ� �Լ��߰�
    {
        if(m_fruit != null)
            Destroy(m_fruit.gameObject);


        m_fruit = fruit;
        m_fruit.transform.SetParent(m_dropPoint); //����� ������ �������Ʈ �ڽ����� �ֱ�
        m_fruit.transform.localPosition = Vector3.zero; //�θ� ��ǥ ���ؿ��� ��ġ 

        m_fruit.StopPhysics(); //Ŭ�� ������ �����ۿ� �ߴ�
    }
    private void OnMouseOver()
    
    {
        var pos = Camera.main.ScreenToWorldPoint(Input.mousePosition); 
        pos.y = m_dropPoint.position.y; 
        pos.z = 0;
        m_dropPoint.position = pos;
    }


}
