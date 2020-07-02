using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationBulletSpawner : MonoBehaviour
{

    public float m_AttackCooltime = 0;
    public float m_AttackInterval = 1f;
    public float m_RotationSpeed = 60f;

    public GameObject m_Bullet;

    // Update is called once per frame
    void Update()
    {
        m_AttackCooltime += Time.deltaTime;
        if (m_AttackCooltime >= m_AttackInterval)
        {
            //총알생성
            GameObject bullet = GameObject.Instantiate(m_Bullet);
            bullet.transform.position = transform.position;
            bullet.transform.rotation = transform.rotation;

            //공격 선쿨타임 초기화
            m_AttackCooltime = 0;
        }

       transform.Rotate(0, m_RotationSpeed * Time.deltaTime, 0);
       

    }
}
