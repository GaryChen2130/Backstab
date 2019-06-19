using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectController : MonoBehaviour
{

    private GameObject select_page;
    public Button left;
    public Button right;
    public Button up;
    //public Button down;

    // Start is called before the first frame update
    void Start()
    {
        select_page = GameObject.Find("select_page");
        select_page.gameObject.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (SelectItem.instance.select_mode == 1)
        {
            left.gameObject.SetActive(false);
            right.gameObject.SetActive(false);
            up.gameObject.SetActive(false);
            //down.gameObject.SetActive(false);
            select_page.gameObject.SetActive(true);
        }
        else
        {
            left.gameObject.SetActive(true);
            right.gameObject.SetActive(true);
            up.gameObject.SetActive(true);
            //down.gameObject.SetActive(true);
            select_page.gameObject.SetActive(false);
        }
    }
}
