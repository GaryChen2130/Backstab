using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaceScript : MonoBehaviour
{
    public GameObject mace;
    public float move;
    public float mace_position_y;
    // Start is called before the first frame update
    void Start()
    {
        mace_position_y = mace.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if ((mace.transform.position.y - mace_position_y >= 70 && move > 0) || (mace.transform.position.y - mace_position_y <= -70 && move < 0))
        {
            move = -move;
        }
        else
        {
            mace.transform.position = new Vector3(mace.transform.position.x, mace.transform.position.y + move, mace.transform.position.z);
        }
    }
}
