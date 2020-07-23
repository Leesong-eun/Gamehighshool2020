using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public Animator m_Animator;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            m_Animator.SetTrigger("Attack");
        }
    }
}