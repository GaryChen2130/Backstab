using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectItem : MonoBehaviour
{
    public Camera cam;
    public int cam_mode;   // 0 for player mode, 1 for select mode
    public static SelectItem instance;
    public int select_mode;
    public GameObject select_page;
    public Button select_icon;
    private int tmp_select;

    public GameObject saw_instantiate;
    public GameObject mace_instantiate;
    public GameObject flat_block_instantiate;
    public GameObject right_slide_instantiate;
    public GameObject sending_door_instantiate;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        //select_page.gameObject.SetActive(false);
        select_mode = 0;
        cam_mode = 0;
        tmp_select = select_mode;
        select_icon.onClick.AddListener(Click_Icon);
    }

    void Click_Icon()
    {
        if(select_mode == 0 && GameData.game_mode == false)
        {
            //panel.gameObject.SetActive(true);
            select_mode = 1;
            ButtonClicked();
        }
        else
        {
            //panel.gameObject.SetActive(false);
            select_mode = 0;
            DestroyItem();
        }
    }

    void Create_Item()
    {
        GameObject saw = Instantiate(saw_instantiate, new Vector3(212,282,0), Quaternion.identity);
        GameObject mace = Instantiate(mace_instantiate, new Vector3(600,282,0), Quaternion.identity);
        GameObject flat_block = Instantiate(flat_block_instantiate, new Vector3(138,738,0), Quaternion.identity);
        GameObject right_slide = Instantiate(right_slide_instantiate, new Vector3(578, 813, 0), Quaternion.identity);
        GameObject sending_door = Instantiate(sending_door_instantiate, new Vector3(1320, 650, 0), Quaternion.identity);
        saw.name = ("select_saw");
        mace.name = ("select_mace");
        flat_block.name = ("select_flat_block");
        right_slide.name = ("select_right_slide");
        sending_door.name = ("select_sending_door");
        sending_door.transform.Find("Sending_Door1").gameObject.SetActive(false);

        // change object order
        // mace
        SpriteRenderer mace_sprite = mace.GetComponent<SpriteRenderer>();

        // saw
        SpriteRenderer saw_sprite = saw.GetComponent<SpriteRenderer>();
        SpriteRenderer saw_child = saw.transform.Find("Saw").GetComponent<SpriteRenderer>();

        // flat
        SpriteRenderer flat_sprite = flat_block.GetComponent<SpriteRenderer>();
        SpriteRenderer flat_child1 = flat_block.transform.Find("Grass").GetComponent<SpriteRenderer>();
        SpriteRenderer flat_child2 = flat_block.transform.Find("GrassCliffMid").GetComponent<SpriteRenderer>();

        // Right_slide
        SpriteRenderer rs_sprite = right_slide.GetComponent<SpriteRenderer>();
        SpriteRenderer rs_child1 = right_slide.transform.Find("GrassHillRight2").GetComponent<SpriteRenderer>();
        SpriteRenderer rs_child2 = right_slide.transform.Find("GrassHillRight").GetComponent<SpriteRenderer>();

        // Sending door
        SpriteRenderer sending_door_sprite = sending_door.GetComponent<SpriteRenderer>();
        SpriteRenderer sending_door_sprite2 = sending_door.transform.Find("Sending_Door").GetComponent<SpriteRenderer>();
        SpriteRenderer sending_door_sprite3 = sending_door.transform.Find("Sending_Door").Find("Sending").GetComponent<SpriteRenderer>();


        mace_sprite.sortingOrder = 11;
        saw_sprite.sortingOrder = 12;
        saw_child.sortingOrder = 11;
        flat_sprite.sortingOrder = 11;
        flat_child1.sortingOrder = 11;
        flat_child2.sortingOrder = 12;
        rs_sprite.sortingOrder = 11;
        rs_child1.sortingOrder = 11;
        rs_child2.sortingOrder = 11;
        sending_door_sprite2.sortingOrder = 11;
        sending_door_sprite3.sortingOrder = 12;
    }   

    void ButtonClicked()
    {
        cam_mode = 1;
        cam.orthographicSize = 540;
        cam.transform.position = new Vector3(960, 540, cam.transform.position.z);
        //Instantiate(saw_instantiate);
        Create_Item();
    }

    void DestroyItem()
    {
        Destroy(GameObject.Find("select_saw"));
        Destroy(GameObject.Find("select_mace"));
        Destroy(GameObject.Find("select_flat_block"));
        Destroy(GameObject.Find("select_right_slide"));
        Destroy(GameObject.Find("select_sending_door"));
    }

    void FocusOnPlayer()
    {
        cam_mode = 0;
        cam.orthographicSize = 180;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameData.game_mode && GameData.focus == false)
        {
            FocusOnPlayer();
            GameData.focus = true;
            select_icon.gameObject.SetActive(false);
        }
        else
        {
            cam_mode = 1;
            cam.orthographicSize = 540;
            cam.transform.position = new Vector3(960, 540, cam.transform.position.z);
        }
        if (tmp_select != select_mode)
        {
            if (select_mode == 1)
            {
                tmp_select = select_mode;
            }
            else
            {
                tmp_select = select_mode;
            }
        }
    }
}
