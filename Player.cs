using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField]
    Animator m_anim;


    [SerializeField]
    UnityEvent m_clickEvent; // 클릭했음 이벤트 추가

    // Update is called once per frame
    private void OnMouseDown()
    {     
        OnClick();
    }

    public void OnClick()  //스킬 컨트롤러에서 클릭할 수 있도록 메소드 만ㄷ름
    {

        m_anim.SetTrigger("Attack");
        m_clickEvent.Invoke(); //구독자에게 알림
    }


}
