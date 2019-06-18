using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PolygonCollider2D))]

public class DragScript_Poly : MonoBehaviour
{
    private bool drag_or_not = true;
    private Vector3 screenPoint;
    private Vector3 offset;
    private bool select = false;


    void OnMouseDown()
    {
        if (drag_or_not) {
            SelectItem.instance.select_mode = 0;
            offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
            if (gameObject.name == "select_mace")
            {
                select = true;
                SpriteRenderer mace_sprite = gameObject.GetComponent<SpriteRenderer>();
                mace_sprite.sortingOrder = 4;
                gameObject.name = "";
                Destroy(GameObject.Find("select_saw"));
                Destroy(GameObject.Find("select_flat_block"));
                Destroy(GameObject.Find("select_right_slide"));
                Destroy(GameObject.Find("select_sending_door"));
                Debug.Log("maceeeeeee");
            }
            else if (gameObject.name == "select_right_slide")
            {
                select = true;
                SpriteRenderer rs_sprite = gameObject.GetComponent<SpriteRenderer>();
                SpriteRenderer rs_child1 = gameObject.transform.Find("GrassHillRight").GetComponent<SpriteRenderer>();
                SpriteRenderer rs_child2 = gameObject.transform.Find("GrassHillRight2").GetComponent<SpriteRenderer>();
                rs_sprite.sortingOrder = 4;
                rs_child1.sortingOrder = 4;
                rs_child2.sortingOrder = 4;
                gameObject.name = "";
                Destroy(GameObject.Find("select_saw"));
                Destroy(GameObject.Find("select_flat_block"));
                Destroy(GameObject.Find("select_mace"));
                Destroy(GameObject.Find("select_sending_door"));
                Debug.Log("slideeee");
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

    void OnMouseUp()
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
