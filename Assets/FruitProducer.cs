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
    UnityEvent<Fruit> m_productedEvent; //���� ���� �̺�Ʈ
   
    public int m_nextFruitLevel = 0;
    [SerializeField] GameManager m_gameManager;


    [ContextMenu(nameof(ProduceFruit))]
    public void ProduceFruit()
    {
        StartCoroutine(CoProduceFruit(m_productionTime));
    }
    IEnumerator CoProduceFruit(float duration) //���� �ð����� ����ϰ� ������ �����ϴ� �ڷ�ƾ
    {
        yield return new WaitForSeconds(duration);

        int maxSpawnLevel = 3; //  �������� ���� �ִ� ����
        int maxLevel = m_gameManager.GetCurrentMaxFruitLevel();
        int upperLimit = Mathf.Min(maxSpawnLevel, maxLevel);
        // int level = Random.Range(0, maxLevel + 1);       // 0���� maxLevel���� �� ����

        int level = Random.Range(0, upperLimit + 1);

        // var fruit = m_spawner.Spawn(0);
        var fruit = m_spawner.Spawn(level);
        m_productedEvent.Invoke(fruit); //���� ���� �̺�Ʈ �˸�
    }
    private void Awake()
    {
        if (m_gameManager == null)
            m_gameManager = FindFirstObjectByType<GameManager>();
    }

}
