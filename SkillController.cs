using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillController : MonoBehaviour
{
   
    [SerializeField]
    Player m_player; // Player 기능을 사용하기 위해 변수선언

    [ContextMenu(nameof(Skill1))]


    public void Skill1()
    {
        StartCoroutine(CoAutoAttackSkill(5)); // 코루틴 일시정지 가능한 함수 : STartCoroutine으로 시작
    }

    IEnumerator CoAutoAttackSkill(float duration) //5초동안 자동공격하기 코루틴 정의
    {
        float t = 0f;
        float tick = 0.5f;
        print($"{duration}동안 {tick}마다 공격");
        while (t < duration)
        {
            t += tick;
            print($"{t} 공격");
            m_player.OnClick(); // Player 자동 클릭

            yield return new WaitForSeconds(tick); //yield return 일시정지


        }
    }




}
