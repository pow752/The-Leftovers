using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour {

    public float speed;
    float UpdateTimer;
    public float UpdateTime=2;
    public bool atackPlayer = false;
    public float Dps = 1.0f;
    private Player playerDps;
    private Transform Tformplayer;

    public GameObject player;

    private Animator animator;
    private Vector2 heading;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        Tformplayer = player.GetComponent<Transform>();
        playerDps = player.GetComponent<Player>();
    }

    void FixedUpdate()
    {

        if (!atackPlayer)
        {
            float z = Mathf.Atan2((Tformplayer.transform.position.y - transform.position.y), (Tformplayer.transform.position.x - transform.position.x)) * Mathf.Rad2Deg - 90;
            //transform.eulerAngles = new Vector3(0, 0, z);
            heading = Tformplayer.transform.position - transform.position;
            heading.Normalize();
            animator.SetFloat("Xheading", heading.x);
            animator.SetFloat("Yheading", heading.y);
            rb.AddForce(heading * speed);
            animator.SetBool("Firing", false);
        }
        else
        {
            heading = Tformplayer.transform.position - transform.position;
            heading.Normalize();
            animator.SetFloat("Xheading", heading.x);
            animator.SetFloat("Yheading", heading.y);

            animator.SetBool("Firing", true);
            UpdateTimer -= Time.deltaTime;
            if (UpdateTimer < 0)
            {
                UpdateTimer += UpdateTime;
                playerDps.GetComponent<Player>().TakeDamage(Dps);
            }
             //playerDps.GetComponent<Player>().TakeDamage(Dps);
            //player.GetComponent<player>().MyFunction()
        }
        
       

    }



}
