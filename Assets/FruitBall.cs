using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FruitBall : Fruit
{
    [SerializeField]
    int m_bounceCount;

    [SerializeField]
    int m_maxBounceCount = 5;

    [SerializeField]
    public UnityEvent<Fruit> HitSkillEvent;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log($"{gameObject.name} OnCollisionEnter2D with {collision.gameObject.name}");

        if (collision.transform.TryGetComponent<Fruit>(out var fruit))
        {
            HitSkillEvent.Invoke(fruit);
            return;
        }

        m_bounceCount++;

        if(m_bounceCount == m_maxBounceCount)
        {
            PlayBombFX();
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        Contacted = true;
    }
}
