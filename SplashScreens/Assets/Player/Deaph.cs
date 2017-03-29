using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deaph : MonoBehaviour {
    private float Ypos;
    private float Xpos;
    private int Zpos;
    public int offset = 0;


    void FixedUpdate()
    {
        Ypos = transform.position.y;
        Xpos = transform.position.x;
        Zpos = (int)transform.position.y + offset;

        GetComponent<SpriteRenderer>().sortingOrder = -Zpos;
        //transform.position = new Vector3(Xpos, Ypos, Ypos);
    }

    void Update()
    {

    }
}
