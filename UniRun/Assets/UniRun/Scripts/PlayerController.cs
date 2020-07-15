using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D m_Rigidbody2D;
    public Animator m_Animator;
    public AudioSource m_AudioSource;

    public AudioClip m_Jump;
    public AudioClip m_Die;

    public bool m_IsGround = false;
    public bool m_IsDead = false;
    public int m_JumpCount = 0;

    // Update is called once per frame
    void Update()
    {
        if (m_IsDead) return;

        m_Animator.SetBool("IsGround", m_IsGround); 
        
        if (Input.GetKeyDown(KeyCode.Space)
            && m_JumpCount<2)

        {
            m_Rigidbody2D.velocity
                = Vector2.zero;
            m_Rigidbody2D.AddForce(Vector2.up * 400);
            m_JumpCount++;

            m_AudioSource.clip = m_Jump;
            m_AudioSource.Play();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Ground")
        {
            m_JumpCount = 0;
            m_IsGround = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            m_IsGround = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Deadzone")
        {
            m_IsDead = true;
            m_Animator.SetBool("IsDead", m_IsDead);

            GameManager.Instance.OnplayerDead();

            m_AudioSource.clip = m_Die;
            m_AudioSource.Play();
        }
    }


}
