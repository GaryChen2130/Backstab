using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Click_on_score_page : MonoBehaviour
{
    public GameObject score_img;
    public GameObject[] text = new GameObject[4];
    private bool check;
    // Start is called before the first frame update

    private void Start()
    {
        check = false;
    }

    private void Update()
    {
        if(GameData.show_score && !check)
        {
            for (int i = 0; i < GameData.player_num; ++i)
            {
                text[i].GetComponent<UnityEngine.UI.Text>().text = "Player" + (i + 1) + ": "+GameData.player_score[i];
                text[i].gameObject.SetActive(true);
            }
            check = true;
        }
    }

    private void OnMouseDown()
    {
        Debug.Log("Hi U");
        if (GameData.show_score)
        {
            check = false;
            GameData.show_score = false;
            score_img.gameObject.SetActive(false);
        }
    }
}
