using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Fruit : MonoBehaviour
{

    [field: SerializeField]
    public int Level { get; private set; } = 0; //���� ���� ���� ���� : Level

    [SerializeField]
    public UnityEvent<Fruit, Fruit> ContactedEvent; // ���� ���ϳ��� �����̺�Ʈ


    protected bool Contacted { get; set; } //�̺�Ʈ �ߺ��������浹���� �߰�

    [field: SerializeField] //������ ���� ����
    public bool IsBoss { get;private set; }

    [SerializeField]
    BombFX m_prefabBombFX;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.TryGetComponent<Fruit>(out var fruit)) //��ũ��Ʈ �����ϴ� �� Ȯ�� 
        {
            if (Level == fruit.Level && Contacted == false && fruit.Contacted ==false)
            {
                Debug.Log($"{name}�� {collision.gameObject.name}�浹��"); //�浹�� ���� ���� : collision
                
                Contacted = true; 
                fruit.Contacted = true;
                StopPhysics();
                fruit.StopPhysics(); //���� �浹�ϸ� �����ߴ�


                ContactedEvent.Invoke(this, fruit);
            }
            }
        }


    public void StopPhysics()  
    { 
        GetComponent<Rigidbody2D>().isKinematic = true;  //�����ۿ� on off

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
