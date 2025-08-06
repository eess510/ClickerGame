using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MergeController : MonoBehaviour
{
    [SerializeField]
    FruitSpawner m_spwner;

    [Header("테스트를 위한 변수")]

    [SerializeField]
    Fruit m_from;

    [SerializeField]
    Fruit m_to;


    [SerializeField]
    public UnityEvent<Fruit, Fruit, Fruit> MergedEvent;

    [SerializeField]
    float m_mergeSpeed = 10f;




    [ContextMenu(nameof(MergeFruits))]
    void MergeFruits()
    {
        MergeFruits(m_from, m_to);
    }

    public void MergeFruits(Fruit from, Fruit to)
    {
       
        StartCoroutine(CoMerge(from, to));
    }
    
    IEnumerator CoMerge(Fruit from, Fruit to)
    {
        float t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime * m_mergeSpeed;
            var pos = Vector3.Lerp(from.transform.position, to.transform.position, t);
            from.transform.position = pos;  
            yield return null;
        }
        to.PlayBombFX();

        var nextLevel = from.Level + 1;
        if (from.IsBoss)
            nextLevel = 0;

        var obj = m_spwner.Spawn(nextLevel);   //새로운 과일 생성하고 합성된 과일 제거
        obj.transform.SetParent(from.transform.parent); //합성된 과일도 모아진 곳으로
        obj.transform.position = to.transform.position;


        MergedEvent.Invoke(from, to, obj); // 합성 이벤트 알림

        Destroy(from.gameObject);
        Destroy(to.gameObject);
    }

}
