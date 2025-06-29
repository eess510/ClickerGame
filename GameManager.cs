using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField]
    EnemySpawner m_enemySpawner;

    Enemy m_spawnedEnemy;

    private void Start()  //게임 시작할 때 스폰 시키기
    {
        m_enemySpawner.Spawn();
    }


    public void OnClickPlayer() {
        print("플레이어 클릭함"); //플레이어 클릭 알림받는 함수
        int damage = Random.Range(1, 5);
        m_spawnedEnemy.TakeDamage(damage); // 플레이어 클릭 알림 받으면 저장해둔 적때림


    }


    public void OnSpawnEnemy(Enemy enemy) //적 스폰 알림받는 함수
    {
        print("몹이 스폰 되었음");
        m_spawnedEnemy = enemy; //스폰 알림받으면 적을 저장
        m_spawnedEnemy.KilledEnent.AddListener(OnKillEnemy); // 죽음 이벤트 구독
    
    }
    void OnKillEnemy(Enemy enemy) {
        m_enemySpawner.Spawn(); // 알림받는 함수 연결
    }

}
