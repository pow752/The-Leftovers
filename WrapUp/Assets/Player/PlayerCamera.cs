﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour {


    Transform target;
	

	void Start () {

        target = GameObject.Find("Player").transform;

    }
	
	// Update is called once per frame
	void Update () {
        if(target != null)
        transform.position = new Vector3(target.position.x, target.position.y, -100);

	}
}
