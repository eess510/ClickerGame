using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FruitSpawner : MonoBehaviour
{
    [SerializeField]
    Fruit[] m_prefabFruits; //배열에 과일 연결

    [SerializeField] 
    UnityEvent<Fruit> m_spawnedEvent;

    public Fruit Spawn(int level)
    {
        var obj = Instantiate(m_prefabFruits[level]);  //레벨에 맞는 과일 생성
        m_spawnedEvent.Invoke(obj);

        return obj;
    }

}
