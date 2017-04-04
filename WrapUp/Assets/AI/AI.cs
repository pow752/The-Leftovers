using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour {


    public float HP=50;
    public float speed;
    public float UpdateTime=2f;
    public bool atackPlayer = false;
    public float Dps = 1f;
    public GameObject player;
    public AudioSource firing;

    /// <summary>
    /// cats
    /// </summary>
  
    private float UpdateTimer;
    private Player playerDps;
    private Transform Tformplayer;
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
        if(player != null)
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
                //firing.Play();

                if (UpdateTimer < 0)
                {
                    firing.Play();
                    UpdateTimer += UpdateTime;
                    playerDps.GetComponent<Player>().TakeDamage(Dps);

                }
                 //playerDps.GetComponent<Player>().TakeDamage(Dps);
                //player.GetComponent<player>().MyFunction()
            }

            if (HP <= 0)
            {
                Destroy(gameObject);
            }
        }
    }//end of update

    public void TakeDamage(float dps)
    {
        HP -= dps;
    }

    void StartAttacking()
    {
        atackPlayer = true;
    }

    void StopAttacking()
    {
        atackPlayer = false;
    }

}
