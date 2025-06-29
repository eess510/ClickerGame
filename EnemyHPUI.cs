using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class EnemyHPUI : MonoBehaviour
{

  
    [SerializeField]
    Guage m_hpBar;

  

  //  [ContextMenu(nameof(HpBar))]

    public void OnSpawnEnemy(Enemy enemy) //적 스폰되면 알림받는 함수 //enemy.spawner.스폰이벤트
    {
        //적 체력변화 이벤트에 구독하고 알림 받을 함수 연결하기
        enemy.ChangedHPEvent.AddListener(OnChangedEnemyHP);

     

    }

     void OnChangedEnemyHP(int hp, int maxHP) //--Enemy.체력변화 이벤트
    {
        print("체력변화");
        //게이지변경
        m_hpBar.SetGuage((float)hp/maxHP);

        m_hpBar.SetLable($"{hp}/{maxHP}");
        
    }


    //public void HpBar()
 //   {
  //  }

}
