﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    bool dying;
    public GameObject healthbar;
    public float HP = 10000;
    public float speed;
    public float UpdateTime = 0.75f;
    public AudioSource Atack1;
    public AudioSource Atack2;
    public AudioSource Atack3;
    public AudioSource Atack4;
    // public Rigidbody2D rb;

    private float UpdateTimer;
    private Rigidbody2D rb;
    private BarScript hpbar;
    private Vector2 heading;
    private Animator anim;
    public GameObject triggerfeaild;
    
    bool atacking = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
        hpbar = healthbar.GetComponent<BarScript>();
        hpbar.maxValue = HP;
        hpbar.value = HP;
        anim = GetComponent<Animator>();

    }


    // Update is called once per frame
    void Update () {

        heading = new Vector2(0, 0);
        if(!dying)
        {

            if (Input.GetKey(KeyCode.UpArrow))
            {
                //transform.Translate(Vector2.up * speed);
            
               rb.AddForce(Vector2.up * speed);
                heading += (Vector2.up * speed);
                // transform.position += Vector3.right * speed;
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                rb.AddForce(Vector2.left * speed);
                heading += (Vector2.left * speed);
                // transform.position += Vector3.right * speed;
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                rb.AddForce(Vector2.down * speed);
                heading += (Vector2.down * speed);
                // transform.position += Vector3.right * speed;
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                rb.AddForce(Vector2.right * speed);
                heading += (Vector2.right * speed);
                // transform.position += Vector3.right * speed;

            }
            if(heading != new Vector2(0,0))
            {
                anim.SetFloat("Xheading", heading.x);
                anim.SetFloat("Yheading", heading.y);
                anim.SetBool("Walking", true);
            }
            else
            {
                anim.SetBool("Walking", false);
            }




            //atacks
            if (Input.GetKey(KeyCode.Q))
            {
                if (!Atack1.isPlaying)
                {
                    //trigger anamashon 
                    anim.SetBool("Attacking", true);
                    Atack1.Play();
                    Atack1.volume = 0.3f;
                    UpdateTimer = UpdateTime;
                    atacking = true;
                }
            }
            if (Input.GetKey(KeyCode.W))
            {
                if (!Atack2.isPlaying)
                {
                    //trigger anamashon 
                    //Atack2.Play();
                }
            }
            if (Input.GetKey(KeyCode.E))
            {
                //trigger anamashon 
                
            }
            if (Input.GetKey(KeyCode.R))
            {
                //trigger anamashon 


            }
            if (atacking)
            {
                triggerfeaild.SetActive(true);


                if(anim.GetFloat("Yheading") > 0)
                    triggerfeaild.transform.localPosition = new Vector2(anim.GetFloat("Xheading"),anim.GetFloat("Yheading"))/10000 - new Vector2(0,0.5f);

                if (anim.GetFloat("Yheading") < 0)
                    triggerfeaild.transform.localPosition = new Vector2(anim.GetFloat("Xheading"), anim.GetFloat("Yheading")) / 10000 + new Vector2(0, 0.3f);

                UpdateTimer -= Time.deltaTime;
                if (UpdateTimer < 0)
                {
                    //UpdateTimer += UpdateTime;
                    anim.SetBool("Attacking", false);
                    atacking = false;

                }
                //playerDps.GetComponent<Player>().TakeDamage(Dps);
                //firing.Play();  UpdateTimer < 0 && 

            }
            else
            {
                triggerfeaild.SetActive(false);
                triggerfeaild.transform.localPosition = new Vector2(0, 0);

            }

            //end of atacks

            //if (Input.GetKey(KeyCode.P))
            //{
            //    HP -= 1;
            //rb.AddForce(Vector2.right * speed);
            // transform.position += Vector3.right * speed;
            //  }
        }



        if (HP <= 0)
        {
            Destroy(gameObject, 3);
            anim.SetBool("Dead", true);
            dying = true;
        }
        //end of update
    }

    public void TakeDamage(float dps)
    {
        HP -= dps;
        hpbar.SetValue(HP);
    }

}