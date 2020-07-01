using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public float m_Speed = 7f;
    // Update is called once per frame
    void Update()
    {
        //주석 : 설명 필요없는 스크립트 임시적으로 비활성화하기 위해서 사용
        /* 주석 */
        Rigidbody rigidbody = /*gameObject.*/GetComponent<Rigidbody>();                             
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //transform.position += Vector3.left * m_Speed * Time.deltaTime;
            rigidbody.AddForce(Vector3.left * m_Speed);
        }

        else if (Input.GetKey(KeyCode.RightArrow))
        {
          rigidbody.AddForce(Vector3.right * m_Speed);
        }

        else if (Input.GetKey(KeyCode.UpArrow))
        {
            rigidbody.AddForce(Vector3.forward * m_Speed);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            rigidbody.AddForce(Vector3.back * m_Speed);
        }

        if (Input.GetKeyDown(KeyCode.Space))
            Die();
    }

    public void Die()
    {
        Debug.Log("사망");
        gameObject.SetActive(false);
    }
}
