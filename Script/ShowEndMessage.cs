using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowEndMessage : MonoBehaviour
{
    public Text msg;

    // Start is called before the first frame update
    void Start()
    {
        msg.text = GameData.end_msg;
    }

}
