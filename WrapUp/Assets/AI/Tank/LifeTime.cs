using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeTime : MonoBehaviour {

    public float lifetime = 0.3333f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        lifetime -= Time.deltaTime;
        if (lifetime < 0)
            Destroy(this.gameObject);
	}
}
