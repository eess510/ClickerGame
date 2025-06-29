using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemySpawner : MonoBehaviour  //적을 생성
{
    [SerializeField]
    Enemy m_prefab;

    [SerializeField]
    UnityEvent<Enemy> m_spawnedEvent; //스폰 이벤트 추가

    

    [ContextMenu(nameof(Spawn))]
    public void Spawn()
    {
        var enemy = Instantiate(m_prefab); // 게임 오브젝트 생성
        enemy.transform.position = Vector3.zero;


        m_spawnedEvent.Invoke(enemy); // 스폰되면 구독자에게 알림
    }

   
}
