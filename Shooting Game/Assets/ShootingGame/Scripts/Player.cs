using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.UpArrow))
            transform.position += new Vector3(0, 6, 0) * Time.deltaTime;
        if (Input.GetKey(KeyCode.DownArrow))
            transform.position -= new Vector3(0, 6, 0) * Time.deltaTime;
        if (Input.GetKey(KeyCode.RightArrow))
            transform.position += new Vector3(6, 0, 0) * Time.deltaTime;
        if (Input.GetKey(KeyCode.LeftArrow))
            transform.position -= new Vector3(6, 0, 0) * Time.deltaTime;


    }
}
