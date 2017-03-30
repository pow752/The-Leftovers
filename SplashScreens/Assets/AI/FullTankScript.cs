using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullTankScript : MonoBehaviour {

    public float speed;
    float UpdateTimer;
    public float UpdateTime = 2;
    public bool atackPlayer = false;
    public float Dps = 1.0f;
    private Player playerDps;
    private Transform Tformplayer;

    public float HP = 100;

    private static Vector2 barrelOffsetUp = new Vector2(1, 50);
    private static Vector2 barrelOffsetLeft = new Vector2(-80, 4);
    private static Vector2 barrelOffsetRight = new Vector2(80, 3);
    private static Vector2 barrellOffsetDown = new Vector2(-1, -50.0f);

    public GameObject player;

    private Animator animator;
    public Animator turretAnimator;
    private Vector2 heading;

    Rigidbody2D rb;

    void StartAttacking()
    {
        atackPlayer = true;
    }

    void StopAttacking()
    {
        atackPlayer = false;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        Tformplayer = player.GetComponent<Transform>();
        playerDps = player.GetComponent<Player>();
    }

    void FireShell()
    {
        GameObject shell = Instantiate(Resources.Load("TankShellPrefab")) as GameObject;
        TankBullet shellScript = shell.GetComponent<TankBullet>();
        shell.GetComponent<Transform>().position = transform.position + new Vector3(heading.x,heading.y)*100;
        shellScript.angle = Mathf.Atan2((Tformplayer.transform.position.y - transform.position.y), (Tformplayer.transform.position.x - transform.position.x)) * Mathf.Rad2Deg + 180;
        shellScript.lifetime = 3;
        shellScript.speed = 10;
    }


    void TakeDamage(float dps)
    {
        HP -= dps;
        if (HP < 0)
            Destroy(this.gameObject);
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
            
            }
            else
            {
                heading = Tformplayer.transform.position - transform.position;
                heading.Normalize();
                turretAnimator.SetFloat("Xheading", heading.x);
                turretAnimator.SetFloat("Yheading", heading.y);

                UpdateTimer -= Time.deltaTime;
                if (UpdateTimer < 0)
                {
                    UpdateTimer += UpdateTime;
                    //playerDps.GetComponent<Player>().TakeDamage(Dps);

                    FireShell();

                }
            }
        }
    }
}
