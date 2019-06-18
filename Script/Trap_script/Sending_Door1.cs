using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;


public class Sending_Door1 : MonoBehaviour
{
    public GameObject sending;
    static public bool isColl = false;
    private Rigidbody2D rd;

    private void Start()
    {
        isColl = false;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Contains("character") && Sending_Door.isColl == false )
        {
            isColl = true;
            rd = collision.gameObject.GetComponent<Rigidbody2D>();
            collision.gameObject.transform.position = new Vector3(sending.transform.position.x, sending.transform.position.y, sending.transform.position.z);
            rd = collision.GetComponent<Rigidbody2D>();
            rd.velocity = new Vector2(0.0f, 0.0f);
        }
        else
        {
            Sending_Door.isColl = false;
        }
    }
}
