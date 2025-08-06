using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FruitSpawner : MonoBehaviour
{
    [SerializeField]
    Fruit[] m_prefabFruits; //�迭�� ���� ����

    [SerializeField] 
    UnityEvent<Fruit> m_spawnedEvent;

    public Fruit Spawn(int level)
    {
        var obj = Instantiate(m_prefabFruits[level]);  //������ �´� ���� ����
        m_spawnedEvent.Invoke(obj);

        return obj;
    }

}
