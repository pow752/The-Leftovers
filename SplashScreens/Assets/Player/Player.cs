﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public GameObject healthbar;
    public float HP = 10000;
    public float speed;
    // public Rigidbody2D rb;
    private Rigidbody2D rb;
    private BarScript hpbar;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
        hpbar = healthbar.GetComponent<BarScript>();
        hpbar.maxValue = HP;
        hpbar.value = HP;
    }


    // Update is called once per frame
    void Update () {

        if (Input.GetKey(KeyCode.UpArrow))
        {
            //transform.Translate(Vector2.up * speed);
           
           rb.AddForce(Vector2.up * speed);
            // transform.position += Vector3.right * speed;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.AddForce(Vector2.left * speed);
            // transform.position += Vector3.right * speed;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            rb.AddForce(Vector2.down * speed);
            // transform.position += Vector3.right * speed;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.AddForce(Vector2.right * speed);
            // transform.position += Vector3.right * speed;
        }

        if (Input.GetKey(KeyCode.P))
        {
            HP -= 1;
            //rb.AddForce(Vector2.right * speed);
            // transform.position += Vector3.right * speed;
        }


        if (HP <= 0)
        {
            Destroy(gameObject);
        }
        //end of update
    }

    public void TakeDamage(float dps)
    {

        HP -= dps;
        hpbar.SetValue(HP);
    }
}
