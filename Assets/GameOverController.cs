using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SocialPlatforms.Impl;

public class GameOverController : MonoBehaviour
{
    [SerializeField]
    Transform m_fruitContainer;

   // [SerializeField]
   // UnityEvent m_gameOverEvent;

    public struct GameOverInfo
    {
        public int score;
        public float playTime;
    }


    [SerializeField]
    ScoreController m_scoreController;
    [SerializeField]
    PlayTimeController m_playTimeController;

    [SerializeField]
    UnityEvent<GameOverInfo> m_gameOverEvent;


    [ContextMenu(nameof(GameOver))]
    public void GameOver()
    {
        StartCoroutine(nameof(CoGameOver));
    }
    IEnumerator CoGameOver()
    {
        yield return new WaitForSeconds(0.5f);

        var fruits = m_fruitContainer.GetComponentsInChildren<Fruit>();
        foreach ( var f in fruits )
            f.StopPhysics();



        foreach ( var f in fruits )
        {

            m_scoreController.AddScore(m_scoreController.Score);
            f.PlayBombFX();
            Destroy(f.gameObject);
            yield return new WaitForSeconds(0.1f);

        }

        yield return new WaitForSeconds(0.5f);


        GameOverInfo gameOverInfo;
        gameOverInfo.playTime = m_playTimeController.PlayTime;
        gameOverInfo.score = m_scoreController.Score;
        m_gameOverEvent.Invoke(gameOverInfo);
    }
  



   

}
