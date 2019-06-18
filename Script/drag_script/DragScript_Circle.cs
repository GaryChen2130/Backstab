using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(CircleCollider2D))]

public class DragScript_Circle : MonoBehaviour
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
            if (gameObject.transform.parent.name == "select_sending_door" && gameObject.name == "Sending_Door")
            {

                SpriteRenderer sending_door_sprite = gameObject.GetComponent<SpriteRenderer>();
                SpriteRenderer sending_door_sprite2 = gameObject.transform.Find("Sending").GetComponent<SpriteRenderer>();
                sending_door_sprite.sortingOrder = 4;
                sending_door_sprite2.sortingOrder = 5;
                
                

                //gameObject.name = "";
                Destroy(GameObject.Find("select_mace"));
                Destroy(GameObject.Find("select_right_slide"));
                Destroy(GameObject.Find("select_flat_block"));
                Destroy(GameObject.Find("select_saw"));
                Debug.Log("doorrrrrrr");
            }
            else if (gameObject.transform.parent.name == "select_sending_door" && gameObject.name == "Sending_Door1")
            {
                select = true;
                SpriteRenderer sending_door_sprite = gameObject.GetComponent<SpriteRenderer>();
                SpriteRenderer sending_door_sprite2 = gameObject.transform.Find("Sending").GetComponent<SpriteRenderer>();
                sending_door_sprite.sortingOrder = 4;
                sending_door_sprite2.sortingOrder = 5;
                //gameObject.transform.parent.Find("Sending_Door1").gameObject.SetActive(true);


                gameObject.transform.parent.name = "";
                Debug.Log("doorrrrrrr");
            }
            

        }


    }

    void OnMouseDrag()
    {
        if(drag_or_not && gameObject.transform.parent.name == "select_sending_door" && gameObject.name == "Sending_Door")
        {
            Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
            Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
            transform.position = curPosition;
        }
        else if (drag_or_not && select)
        {
            Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
            Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
            transform.position = curPosition;
        }
    }

    private void OnMouseUp()
    {
        if (gameObject.transform.parent.name == "select_sending_door" && gameObject.name == "Sending_Door")
        {
            gameObject.transform.parent.Find("Sending_Door1").gameObject.SetActive(true);
            gameObject.transform.parent.Find("Sending_Door1").transform.position = gameObject.transform.position;
        }
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
