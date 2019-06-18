using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(BoxCollider2D))]
public class ChoosePlayer : MonoBehaviour
{
    public int num;

    public void SelectPlayer() {

        Debug.Log("Choose Player " + num.ToString());
        int n = GameData.selected_player_num;
        int m = GameData.player_num;
        if (n < m) {
            GameData.player_order[n++] = num;
            GameData.selected_player_num++;
        }
        if(n == m)
            SceneManager.LoadScene("main_scene", 0);

    }

    private void OnMouseDown()
    {
        int n = GameData.selected_player_num;
        int m = GameData.player_num;
        if (n < m)
        {
            if (!GameData.player_chosen[num])
            {
                GameData.player_chosen[num] = true;
                GameData.player_order[n++] = num;
                GameData.selected_player_num++;
            }
        }
        if (n == m)
            SceneManager.LoadScene("main_scene", 0);
    }

}
