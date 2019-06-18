using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    public static int player_num;
    public static int selected_player_num;
    public static int[] player_order = new int[4];
    public static bool[] player_chosen = new bool[4];
    public static int playing_player;
    public static bool game_mode;
    public static bool player_die;
    public static bool player_goal;
    public static bool focus;
    public static int[] player_score = new int[4];
    public static int winner;
    public static bool show_score;
    public static int game_round;
    // Start is called before the first frame update
    void Start()
    {
        InitGame();
    }

    public static void InitGame() {

        player_num = 1;
        selected_player_num = 0;
        player_order[0] = 0;
        player_order[1] = -1;
        player_order[2] = -1;
        player_order[3] = -1;

        for(int i = 0;i < 4;++i)
            player_chosen[i] = false;

        InitMatch();

    }

    public static void InitMatch() {
        focus = false;
        player_die = false;
        game_mode = false;
        playing_player = 1;
        player_score[0] = 0;
        player_score[1] = 0;
        player_score[2] = 0;
        player_score[3] = 0;
        player_goal = false;
        winner = -1;
        show_score = false;
        game_round = 5;
    }

}
