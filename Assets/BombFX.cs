using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombFX : MonoBehaviour
{
    [SerializeField]
    ParticleSystem m_ps;

    private void Start()
    {
        m_ps.Play();
    }
}
