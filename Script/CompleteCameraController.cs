using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CompleteCameraController : MonoBehaviour
{
    public GameObject[] player = new GameObject[4];
    private float offset_x;
    private float offset_y;
    public Camera cam;
    private int mode;   // 0 for player mode, 1 for select mode
    // Start is called before the first frame update
    void Start()
    {
        cam.orthographicSize = 180;
    }


    // Update is called once per frame
    void LateUpdate()
    {
        if (SelectItem.instance.cam_mode == 0)
        {
            //Debug.Log("playing_player: " + GameData.playing_player);
            //Debug.Log("x: " + player[GameData.playing_player].transform.position.x);
            //Debug.Log("y: " + player[GameData.playing_player].transform.position.y);
            //Debug.Log("z: " + player[GameData.playing_player].transform.position.z);

            if (player[GameData.player_order[GameData.playing_player-1]].transform.position.x >= 320 && player[GameData.player_order[GameData.playing_player - 1]].transform.position.x <= 1600)
            {
                ///Debug.Log("x: 320 ~ 1600");
                transform.position = new Vector3(player[GameData.player_order[GameData.playing_player - 1]].transform.position.x, transform.position.y, transform.position.z);
            }
            else
            {
                if (player[GameData.player_order[GameData.playing_player - 1]].transform.position.x < 320)
                {
                    //Debug.Log("x < 320");
                    transform.position = new Vector3(320, transform.position.y, transform.position.z);
                }
                else
                {
                    //Debug.Log("x > 1600");
                    transform.position = new Vector3(1600, transform.position.y, transform.position.z);
                }
            }
            if (player[GameData.player_order[GameData.playing_player - 1]].transform.position.y >= 180 && player[GameData.player_order[GameData.playing_player - 1]].transform.position.y <= 900)
            {
                //Debug.Log("y: 180 ~ 900");
                transform.position = new Vector3(transform.position.x, player[GameData.player_order[GameData.playing_player - 1]].transform.position.y, transform.position.z);
            }
            else
            {
                if (player[GameData.player_order[GameData.playing_player - 1]].transform.position.y < 180)
                {
                    //Debug.Log("y < 180");
                    transform.position = new Vector3(transform.position.x, 180, transform.position.z);
                }
                else
                {
                    //Debug.Log("y > 900");
                    transform.position = new Vector3(transform.position.x, 900, transform.position.z);
                }
            }
        }
    }
}