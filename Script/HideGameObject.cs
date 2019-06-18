using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideGameObject : MonoBehaviour
{
    public int obj_num;
    public GameObject[] obj = new GameObject[10];

    public void HideObject() {
        for (int i = 0; i < obj_num; ++i)
            obj[i].SetActive(false);
    }

}
