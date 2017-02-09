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

        transform.position = target.position + new Vector3(0, 0, -10);

	}
}
