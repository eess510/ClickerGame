using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StageContoller : MonoBehaviour
{
    [SerializeField]
    public static int m_stage = 0;

    [SerializeField]
    GameObject[] m_bglist;


    private void Start()
    {
        UpdateStage();  // ���� ���� �� ���� �������� ��� ����
    }
    [ContextMenu(nameof(NextStage))]
    public void NextStage()
    {
        m_stage++;
        if (m_stage >= m_bglist.Length)
        {
            Debug.LogWarning("������ ���������� �����߽��ϴ�.");
            m_stage = m_bglist.Length - 1;
            return;

        }
        UpdateStage();
        
    
    }
    void UpdateStage()
    {


        for (int i = 0; i < m_bglist.Length; i++)

            m_bglist[i].SetActive(false);

        if (m_stage < m_bglist.Length)
            m_bglist[m_stage].SetActive(true);
    }
}