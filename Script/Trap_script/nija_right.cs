using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nija_right : MonoBehaviour
{
    private float begin_pos;
    public GameObject nija_l;
    private float move = 1;
    private float new_pos = 100;
    private bool back = false;

    // Start is called before the first frame update
    void Start()
    {
        begin_pos = nija_l.transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
    //    Debug.Log("" + (begin_pos - nija_l.transform.position.x));
        if (nija_l.transform.position.x - begin_pos <= new_pos && back == false)
        {
    //        Debug.Log("Go");
            nija_l.transform.position = new Vector3(nija_l.transform.position.x + move, nija_l.transform.position.y, nija_l.transform.position.z);
        }
        if (nija_l.transform.position.x - begin_pos > new_pos && back == false)
        {
    //        Debug.Log("Limit");
            back = true;
        }
        if (nija_l.transform.position.x - begin_pos  > new_pos && back == true)
        {
    //        Debug.Log("Back");
            nija_l.transform.position = new Vector3(begin_pos, nija_l.transform.position.y, nija_l.transform.position.z);
        }
        if (nija_l.transform.position.x - begin_pos <= new_pos && back == true)
        {
    //        Debug.Log("Over Begin");
            back = false;
        }
    }

}

