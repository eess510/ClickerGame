using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Guage : MonoBehaviour
{
    [SerializeField]
    Image m_img;

    [SerializeField]
    Image m_imgShadow;

    [SerializeField]
    TMPro.TextMeshProUGUI m_txtLable;

   
    private void Update()
    {
        if (m_imgShadow != null)
        {
            float v = Mathf.Lerp(m_imgShadow.fillAmount, m_img.fillAmount, Time.deltaTime);
            m_imgShadow.fillAmount = v;
        }
    }

    public void SetGuage(float v)
    {
        m_img.fillAmount = v;

    }

    public void SetLable(string v)
    {
        m_txtLable.text = v;

    }
}
