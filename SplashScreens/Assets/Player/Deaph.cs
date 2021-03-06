﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deaph : MonoBehaviour {
    private float Ypos;
    private float Xpos;
    private int Zpos;
    public int offset = 0;
    private Collider2D hitCollider;


    void Start()
    {
        if (hitCollider == null)
            hitCollider = GetComponent<BoxCollider2D>();
        if (hitCollider == null)
            hitCollider = GetComponent<CircleCollider2D>();
        if (hitCollider == null)
            hitCollider = GetComponent<PolygonCollider2D>();
    }

    void FixedUpdate()
    {
        if(hitCollider != null)
        {
            Ypos = hitCollider.bounds.center.y;
            Xpos = hitCollider.bounds.center.x;
            Zpos = (int)hitCollider.bounds.center.y + offset;
        }
        else
        {
            Ypos = transform.position.y;
            Xpos = transform.position.x;
            Zpos = (int)transform.position.y + offset;
        }

        GetComponent<SpriteRenderer>().sortingOrder = -Zpos;
    }

    void Update()
    {

    }
}
