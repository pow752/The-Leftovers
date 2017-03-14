﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour {

    public float speed;
    public Transform player;

    static public GameObject other;
    public Rigidbody2D rb = other.GetComponent<Rigidbody2D>();


    void FixedUpdate()
    {
        float z = Mathf.Atan2((player.transform.position.y - transform.position.y), (player.transform.position.x - transform.position.x)) * Mathf.Rad2Deg - 90;

        transform.eulerAngles = new Vector3(0, 0, z);
        rb.AddForce(gameObject.transform.up * speed);

    }

	
}
