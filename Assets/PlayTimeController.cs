using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayTimeController : MonoBehaviour
{

    [field: SerializeField]
    public float PlayTime { get; private set; }

    [SerializeField]
    UnityEvent<float> m_changedPlayTimeEvent;

    [ContextMenu(nameof(StartTime))]
    public void StartTime()
    {
        StartCoroutine(nameof(CoTimer));
    }


    [ContextMenu(nameof(StopTime))]
    public void StopTime()
    {
        StopCoroutine(nameof(CoTimer));
    }

    IEnumerator CoTimer()
    {
        while (true)
        {
            PlayTime += Time.deltaTime;
            m_changedPlayTimeEvent.Invoke(PlayTime);
            yield return null;
        }

    }
}
