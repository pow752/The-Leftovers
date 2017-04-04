using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {

    float timer = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if (timer < 0.1f)
        {
            transform.localScale += new Vector3(0.1f, 0.1f, 0);
        }
        else
        {
            transform.localScale -= new Vector3(0.1f, 0.1f, 0);
            if (timer > .2)
            {
                Destroy(gameObject);
            }
        }
    }
}
