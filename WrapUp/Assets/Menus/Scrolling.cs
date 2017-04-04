using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scrolling : MonoBehaviour {

    public float speed = 0.5f;
    private Renderer scroll;
    private Vector2 offset;
	// Use this for initialization
	void Start () {
        scroll = GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {
        offset = new Vector2(Time.time * speed, 0);

        scroll.material.mainTextureOffset = offset;
        
	}
}
