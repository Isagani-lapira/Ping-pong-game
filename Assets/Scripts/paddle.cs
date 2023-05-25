using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paddle : MonoBehaviour
{

    public GameObject player;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(gameObject.name);
        Debug.Log(player.name);
    }
}
