using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]

public class DragScript : MonoBehaviour
{
    private bool drag_or_not = true;
    private Vector3 screenPoint;
    private Vector3 offset;
    private bool select = false;

    void OnMouseDown()
    {
        if (drag_or_not)
        {
            SelectItem.instance.select_mode = 0;
            offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
            if (gameObject.name == "select_saw")
            {
                select = true;
                SpriteRenderer saw_sprite = gameObject.GetComponent<SpriteRenderer>();
                SpriteRenderer saw_child = gameObject.transform.Find("Saw").GetComponent<SpriteRenderer>();
                saw_sprite.sortingOrder = 4;
                saw_child.sortingOrder = 3;
                gameObject.name = "";
                Destroy(GameObject.Find("select_mace"));
                Destroy(GameObject.Find("select_right_slide"));
                Destroy(GameObject.Find("select_flat_block"));
                Destroy(GameObject.Find("select_sending_door"));
                Debug.Log("sawwww");
            }
            else if (gameObject.name == "select_flat_block")
            {
                select = true;
                SpriteRenderer flat_sprite = gameObject.GetComponent<SpriteRenderer>();
                SpriteRenderer flat_child1 = gameObject.transform.Find("Grass").GetComponent<SpriteRenderer>();
                SpriteRenderer flat_child2 = gameObject.transform.Find("GrassCliffMid").GetComponent<SpriteRenderer>();

                flat_sprite.sortingOrder = 4;
                flat_child1.sortingOrder = 4;
                flat_child2.sortingOrder = 5;
                gameObject.name = "";
                Destroy(GameObject.Find("select_mace"));
                Destroy(GameObject.Find("select_saw"));
                Destroy(GameObject.Find("select_right_slide"));
                Destroy(GameObject.Find("select_sending_door"));
            }


        }
        
        
    }

    void OnMouseDrag()
    {
        if (drag_or_not && select)
        {
            Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
            Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
            transform.position = curPosition;
        }
    }

    private void OnMouseUp()
    {
        drag_or_not = false;
        if (select)
        {
            Debug.Log("" + GameData.playing_player);
            GameData.playing_player += 1;
            if (GameData.playing_player > GameData.player_num)
            {
                GameData.game_mode = true;
                GameData.playing_player %= GameData.player_num;
            }
            select = false;
        }
    }
}
