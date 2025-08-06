using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScoreController : MonoBehaviour
{
    [field: SerializeField]
    public int Score { get; private set; }

    [SerializeField]
     UnityEvent<int> m_changedScoreEvent;

    private void Start()
    {
       m_changedScoreEvent.Invoke(Score);
    }

    [ContextMenu(nameof(AddScore))]
    void AddScore()
    { 
        AddScore(Random.Range(1, 5));

    }
    public void AddScore(int v)
    {
       
        //�Էµ� v��ŭ  ������ ����
        Score += v;
        m_changedScoreEvent?.Invoke(Score);
    }

}
