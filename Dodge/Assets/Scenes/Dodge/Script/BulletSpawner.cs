using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
   
    public float m_AttackCooltime = 0;
    public float m_AttackInterval = 1f;
    public float m_RotationSpeed = 60f;

    public GameObject m_Bullet;
   
    // Update is called once per frame
    void Update()
    {
        m_AttackCooltime += Time.deltaTime;
        if(m_AttackCooltime >= m_AttackInterval)
        {
            //총알생성
            GameObject bullet = GameObject.Instantiate(m_Bullet);
            bullet.transform.position = transform.position;
            bullet.transform.rotation = transform.rotation;

            //공격 선쿨타임 초기화
            m_AttackCooltime = 0;
        }

       // GameObject.Find("Player"); //게임오브젝트의 이름
        GameObject player = GameObject.FindGameObjectWithTag("Player"); //Player
        //GameObject.FindObjectOfType<PlayerController>();

       
        //GameObject.FindGameObjectsWithTag("Player"); //모든 player
        //GameObject.FindObjectOfType<PlayerController>(); // 모든 playerController 검색

        //transform.Rotate(0, m_RotationSpeed * Time.deltaTime, 0);
        if(player != null)
        {
            Vector3 attacketpoint = player.transform.position;
            attacketpoint.y = transform.position.y;
            transform.LookAt(attacketpoint);
        }
        
    }
}
