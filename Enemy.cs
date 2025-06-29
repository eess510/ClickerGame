using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    Animator m_anim;

    [SerializeField]
    int m_maxHP = 10;

    [SerializeField]
    int m_hp = 10;

    [SerializeField]
    public UnityEvent<Enemy> KilledEnent; // 죽음 이벤트 추가



    [SerializeField]  //체력변화 이벤트 추가
    public UnityEvent<int, int> ChangedHPEvent;


    [ContextMenu(nameof(TakeDamage))] // ContextMenu: 인스펙터 팝업메뉴 추가 , 


    private void Start()
    {
        //시작할 때 체력 변화를 구독자에게 알림 
        ChangedHPEvent.Invoke(m_hp,m_maxHP);
    }


    public void TakeDamage(int damage)   //지휘자가 직접 때릴 수 있게 메소드 만듦
    {

        m_hp -= damage;
        m_anim.SetTrigger("Damage");
        ChangedHPEvent.Invoke(m_hp,m_maxHP); //맞을때 체력 변화를 구독자에게 알림



        if (m_hp <= 0)
        {
            m_anim.SetTrigger("Death");
            Destroy(gameObject, 1f);

            KilledEnent.Invoke(this); //죽었다면 구독자에게 알림

        }
    }
    


}
