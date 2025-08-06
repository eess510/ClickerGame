using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MergeController : MonoBehaviour
{
    [SerializeField]
    FruitSpawner m_spwner;

    [Header("�׽�Ʈ�� ���� ����")]

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

        var obj = m_spwner.Spawn(nextLevel);   //���ο� ���� �����ϰ� �ռ��� ���� ����
        obj.transform.SetParent(from.transform.parent); //�ռ��� ���ϵ� ����� ������
        obj.transform.position = to.transform.position;


        MergedEvent.Invoke(from, to, obj); // �ռ� �̺�Ʈ �˸�

        Destroy(from.gameObject);
        Destroy(to.gameObject);
    }

}
