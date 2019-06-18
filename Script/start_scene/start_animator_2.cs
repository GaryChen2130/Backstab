using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class start_animator_2 : MonoBehaviour
{
    public GameObject player;
    private float move = -5;
    private float right_btn_pos_x = 1315;
    private float half_btn_high = 5;
    private Rigidbody2D rb;
    private Animator animator;
    private bool enwalk = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = player.GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.y <= 54 && player.transform.position.y >= 53 && player.transform.position.x > right_btn_pos_x)
        {
            enwalk = true;
            animator.SetBool("walk", true);
            walk2btn();
        }
        else if (enwalk)
        {
            enwalk = false;
            animator.SetBool("walk", false);
            animator.SetBool("jump", true);
            try2jump();
        }
    }

    void walk2btn()
    {
        if (rb.gravityScale != 120)
        {
            rb.gravityScale = 120;
        }
        //print(player.transform.position.y);
        player.transform.position = new Vector3(player.transform.position.x + move, player.transform.position.y, player.transform.position.z);
    }

    void try2jump()
    {
        player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + move * -30, player.transform.position.z);
    }
}

