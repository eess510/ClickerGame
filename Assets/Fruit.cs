using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Fruit : MonoBehaviour
{

    [field: SerializeField]
    public int Level { get; private set; } = 0; //과일 종류 구분 변수 : Level

    [SerializeField]
    public UnityEvent<Fruit, Fruit> ContactedEvent; // 같은 과일끼리 접촉이벤트


    protected bool Contacted { get; set; } //이벤트 중복방지ㅣ충돌변수 추가

    [field: SerializeField] //마지막 변수 구분
    public bool IsBoss { get;private set; }

    [SerializeField]
    BombFX m_prefabBombFX;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.TryGetComponent<Fruit>(out var fruit)) //스크립트 존재하는 지 확인 
        {
            if (Level == fruit.Level && Contacted == false && fruit.Contacted ==false)
            {
                Debug.Log($"{name}과 {collision.gameObject.name}충돌함"); //충돌한 상대방 정보 : collision
                
                Contacted = true; 
                fruit.Contacted = true;
                StopPhysics();
                fruit.StopPhysics(); //과일 충돌하면 물리중단


                ContactedEvent.Invoke(this, fruit);
            }
            }
        }


    public void StopPhysics()  
    { 
        GetComponent<Rigidbody2D>().isKinematic = true;  //물리작용 on off

    }
    public void StartPhysics() {
        GetComponent<Rigidbody2D>().isKinematic=false;
    }

    public void PlayBombFX()
    {
        var fx = Instantiate(m_prefabBombFX);
        fx.transform.position = transform.position;
    }

}
