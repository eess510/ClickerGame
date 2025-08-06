using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillController : Fruit
{
    [SerializeField]
    FruitSword m_prefabFruitSword;


    [SerializeField]
    DropController m_dropController;

    [SerializeField]
    FruitBall m_prefabFruitBall;

    [ContextMenu(nameof(Skill1))]
    public void Skill1()
    {
        var obj = Instantiate(m_prefabFruitSword);
        m_dropController.SetFruits(obj);
        obj.HitSkillEvent.AddListener(OnHitSkill);

    }
    void OnHitSkill(Fruit to)
    {
        Debug.Log($"OnHitSkill 호출, 대상: {to.name}");
        to.PlayBombFX();
        Destroy(to.gameObject);
    }

    [ContextMenu(nameof(Skill2))]
    public void Skill2()
    {
        var obj = Instantiate(m_prefabFruitBall);
        m_dropController.SetFruits(obj);
        obj.HitSkillEvent.AddListener(OnHitSkill);
    }

}
