using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowGameObject : MonoBehaviour
{
    public int obj_num;
    public GameObject[] obj = new GameObject[10];

    public void ShowObject()
    {
        for (int i = 0; i < obj_num; ++i)
            obj[i].SetActive(true);
    }

}
