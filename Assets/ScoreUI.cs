using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    [SerializeField]
    TMPro.TextMeshProUGUI m_txtScore;

    public void OnChangedScore(int score)
    {
        m_txtScore.text = $"score : {score}";

    }
}
