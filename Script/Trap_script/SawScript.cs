using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawScript : MonoBehaviour
{
    public GameObject wood;
    public GameObject saw_obj;
    public GameObject player;
    public float move;

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if((saw_obj.transform.position.x - wood.transform.position.x >= 60 && move > 0) || (saw_obj.transform.position.x - wood.transform.position.x <= -60 && move < 0))
        {
            move = -move;
        }
        else
        {
            saw_obj.transform.position = new Vector3(saw_obj.transform.position.x + move, saw_obj.transform.position.y, saw_obj.transform.position.z);
        }
    }
}
