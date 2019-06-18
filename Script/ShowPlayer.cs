using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowPlayer : MonoBehaviour
{
    public GameObject[] player = new GameObject[4];
    void Start()
    {
        for (int i = 0; i < GameData.player_num; ++i) {
            player[GameData.player_order[i]].SetActive(true);
        }
    }

}
