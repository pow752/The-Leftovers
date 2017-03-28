using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour {

    public float speed;
    float UpdateTimer;
    public float UpdateTime=2;
    public bool atackPlayer = false;
    public float Dps = 0.5f;
    public GameObject playerDps;
    public Transform Tformplayer;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {

        if (!atackPlayer)
        {
            float z = Mathf.Atan2((Tformplayer.transform.position.y - transform.position.y), (Tformplayer.transform.position.x - transform.position.x)) * Mathf.Rad2Deg - 90;
            transform.eulerAngles = new Vector3(0, 0, z);
            rb.AddForce(gameObject.transform.up * speed);
        }
        else
        {
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
