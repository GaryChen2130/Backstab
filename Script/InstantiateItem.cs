using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateItem : MonoBehaviour
{
    public GameObject saw_instantiate;
    public static InstantiateItem instance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Create_Item()
    {
        Instantiate(saw_instantiate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
