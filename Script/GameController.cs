using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject[] text = new GameObject[4];
    public GameObject[] player = new GameObject[4];
    private bool update_player_flag;
    public GameObject select_icon;
    public Camera cam;
    public int cam_mode;   // 0 for player mode, 1 for select mode
    // Start is called before the first frame update
    public GameObject score_page;
    void Start()
    {
        GameData.game_mode = false;
        update_player_flag = false;
        score_page.gameObject.SetActive(false);
    }

    void FocusOnPlayer()
    {
        cam_mode = 0;
        cam.orthographicSize = 180;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameData.player_goal)
        {
            GameData.player_score[GameData.playing_player - 1] += 2;
            if (GameData.winner == -1)
            {
                GameData.winner = GameData.playing_player;
            }
            else if (GameData.winner >= 0)
            {
                GameData.winner = -2;
            }
            else
            {
                GameData.winner -= 1;
            }
            player[GameData.player_order[GameData.playing_player - 1]].transform.position = new Vector3(90, 790, 0);
            player[GameData.player_order[GameData.playing_player - 1]].SetActive(false);
            GameData.player_goal = false;
            update_player_flag = true;
        }
        if (GameData.player_die)
        {
            player[GameData.player_order[GameData.playing_player - 1]].transform.position = new Vector3(90, 790, 0);
            player[GameData.player_order[GameData.playing_player - 1]].SetActive(false);
            GameData.player_die = false;
            update_player_flag = true;
        }

        if (GameData.playing_player == GameData.player_num && update_player_flag)
        {
            bool gameover = false;
            if (GameData.winner > 0)
            {
                GameData.player_score[GameData.winner - 1] += 1;
            }
            else if (GameData.winner == -GameData.player_num)
            {
                for (int i = 0; i < GameData.player_num; ++i)
                {
                    GameData.player_score[i] -= 2;
                }
            }
            else
            {
                //do nothing
            }
            for (int i = 0; i < GameData.player_num; ++i)
            {
                int score = GameData.player_score[i];
                Debug.Log("" + i + ": " + score);
                if (score >= 10)
                    gameover = true;
            }
            score_page.gameObject.SetActive(true);
            select_icon.gameObject.SetActive(false);
            GameData.show_score = true;
            GameData.game_round -= 1;
            if(GameData.game_round == 0)
            {
                gameover = true;
            }
            //print score page
            GameData.winner = -1;

            if (gameover)
            {
                int max = 0,max_index = 0;
                for (int i = 0; i < GameData.player_num; ++i) {
                    if (max < GameData.player_score[i]) {
                        max = GameData.player_score[i];
                        max_index = i;
                    }
                }

                GameData.end_msg = "";
                for (int i = 0; i < GameData.player_num; ++i)
                {
                    if (GameData.player_score[i] == max)
                    {
                        if(i != max_index)
                            GameData.end_msg += "and ";
                        GameData.end_msg += "Player" + (i+1).ToString() + " ";
                    }
                }
                GameData.end_msg += "Win";
                Debug.Log(GameData.end_msg);

                SceneManager.LoadScene("end_scene", 0);
            }

        }


        //update player
        if (update_player_flag)
        {
            GameData.playing_player++;
            if (GameData.playing_player > GameData.player_num)
            {
                GameData.playing_player %= GameData.player_num;
                GameData.focus = false;
                GameData.game_mode = false;
            }
            update_player_flag = false;
        }

        if (GameData.game_mode)
        {
            player[GameData.player_order[GameData.playing_player - 1]].SetActive(true);
        }
        else
        {
            if (!GameData.show_score)
            {
                select_icon.gameObject.SetActive(true);
            }
            for (int i = 0; i < GameData.player_num; i++)
            {
                player[GameData.player_order[i]].SetActive(false);
            }
        }
        if (!GameData.show_score)
        {
            for (int i = 0; i < 4; ++i)
            {
                text[i].gameObject.SetActive(false);
            }
        }
    }
}