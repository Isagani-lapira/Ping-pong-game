using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paddle : MonoBehaviour
{

    public GameObject paddle1,paddle2;

    public void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
            movement(paddle2, true);
        if(Input.GetKey(KeyCode.DownArrow))
            movement(paddle2,false);
        if(Input.GetKey(KeyCode.W))
            movement(paddle1, true);
        if (Input.GetKey(KeyCode.S))
            movement(paddle1, false);

    }

    private void movement(GameObject paddle, bool isUp)
    {
        if(isUp)
            paddle.transform.position += new Vector3(0, 1, 0) * (3 * Time.deltaTime);
        else
            paddle.transform.position -= new Vector3(0, 1, 0) * (3 * Time.deltaTime);
    }


}
