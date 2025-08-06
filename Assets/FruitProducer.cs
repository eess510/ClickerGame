using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class FruitProducer : MonoBehaviour
{
    [SerializeField]
    FruitSpawner m_spawner;

    [SerializeField]
    float m_productionTime = 1f;

    [SerializeField]
    UnityEvent<Fruit> m_productedEvent; //과일 생산 이벤트
   
    public int m_nextFruitLevel = 0;
    [SerializeField] GameManager m_gameManager;


    [ContextMenu(nameof(ProduceFruit))]
    public void ProduceFruit()
    {
        StartCoroutine(CoProduceFruit(m_productionTime));
    }
    IEnumerator CoProduceFruit(float duration) //생산 시간동안 대기하고 과일을 생신하는 코루틴
    {
        yield return new WaitForSeconds(duration);

        int maxSpawnLevel = 3; //  떨어지는 과일 최대 레벨
        int maxLevel = m_gameManager.GetCurrentMaxFruitLevel();
        int upperLimit = Mathf.Min(maxSpawnLevel, maxLevel);
        // int level = Random.Range(0, maxLevel + 1);       // 0부터 maxLevel까지 중 랜덤

        int level = Random.Range(0, upperLimit + 1);

        // var fruit = m_spawner.Spawn(0);
        var fruit = m_spawner.Spawn(level);
        m_productedEvent.Invoke(fruit); //과일 생산 이벤트 알림
    }
    private void Awake()
    {
        if (m_gameManager == null)
            m_gameManager = FindFirstObjectByType<GameManager>();
    }

}
