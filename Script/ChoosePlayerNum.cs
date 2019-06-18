using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoosePlayerNum : MonoBehaviour
{

    public void SetPlayerNum(int n) {
        GameData.player_num = n;
        Debug.Log(n.ToString());
    }

}
