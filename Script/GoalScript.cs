using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalScript : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Contains("character"))
        {
            Debug.Log("GOAL!");
            GameData.player_goal = true;
            //Destroy(collision.gameObject);
        }
    }
}
