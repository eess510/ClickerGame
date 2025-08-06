using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    MergeController m_mergeController;

    [SerializeField]
    ScoreController m_scoreController;


    [SerializeField]
    PlayTimeController m_playTimeController;


    [SerializeField]
    FruitProducer m_fuitProducer;

    [SerializeField]
    DropController m_dropController;

    [SerializeField]
    GameOverController m_gameOverController;

    [SerializeField]
    StageContoller m_stageContoller;

    public void OnSpawnedFruit(Fruit v) //과일 스폰 이벤트 알림받는 
    {
        v.ContactedEvent.AddListener(OnContactedFruits);
    }

    void OnContactedFruits(Fruit from, Fruit to)
    {
        m_mergeController.MergeFruits(from, to);
        m_mergeController.MergedEvent.AddListener(OnMergedFruits);

    }
    int m_maxFruitLevel = 0;
    public void OnMergedFruits(Fruit from, Fruit to, Fruit newFruit)
    {
        int score = newFruit.Level * 2;
        m_scoreController.AddScore(score); // 과일 합성 알림 받으면 점수

        if (newFruit.Level > m_maxFruitLevel)
        {
            m_maxFruitLevel = newFruit.Level;
        }
    } 



    private void Start()
    {
        m_fuitProducer.ProduceFruit();
        m_playTimeController.StartTime();
      
        m_mergeController.MergedEvent.AddListener(OnMergedFruits);

    }
    public void OnProducedFruit(Fruit fruit)  //과일 생산 알림받는 함수
    {
        m_dropController.SetFruits(fruit); // 과일 생산 시 드롭컨트롤러에 넣음
    }
    public void OnDropFruit() {
        m_fuitProducer.ProduceFruit();
    }


    public void OnDeadLine()
    {
        m_gameOverController.GameOver();
    }

    public void ReStartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        m_stageContoller.NextStage();
    }
    public int GetCurrentMaxFruitLevel()
    {
        return m_maxFruitLevel;
    }

}
