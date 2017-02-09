using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deaph : MonoBehaviour {

    private float Ypos;
    private float Xpos;


	void Update ()
    {
        Ypos = transform.position.y;
        Xpos = transform.position.x;

        transform.position = new Vector3(Xpos, Ypos, Ypos);
    }
}
