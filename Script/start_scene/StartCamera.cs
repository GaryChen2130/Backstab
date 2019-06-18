using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartCamera : MonoBehaviour
{
    public Camera cam;
   
    // Start is called before the first frame update
    void Start()
    {
        cam.orthographicSize = 540;
        transform.position = new Vector3(960, 540, transform.position.z);
    }

}
