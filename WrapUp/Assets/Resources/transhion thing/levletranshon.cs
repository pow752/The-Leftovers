using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levletranshon : MonoBehaviour {
    public float UpdateTime;
    public GameObject fade;
    public int swich = 0;
    public int nextlv = 0;


    public float alfa =1;
    private float UpdateTimer;


    // Use this for initialization
    void Start () {
		
	}
	
	void Update () {


        if (swich==1)
        {
            UpdateTimer -= Time.deltaTime;

            if (UpdateTimer < 0)
            {
                alfa -= .010f;
               fade.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, alfa);
                UpdateTimer += UpdateTime;

                //  SpriteRenderer.color = new Color(1f, 1f, 1f, 1f);
            }

            if (alfa<=-0.001)
            {
                swich = 0;

            }
        }



        if (swich == 2)
        {
            UpdateTimer -= Time.deltaTime;

            if (UpdateTimer < 0)
            {
                alfa += .010f;
                fade.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, alfa);
                UpdateTimer += UpdateTime;

                //  SpriteRenderer.color = new Color(1f, 1f, 1f, 1f);
            }

            if (alfa >= 1.001)
            {
                swich = 0;
                Application.LoadLevel(nextlv);
            }
        }

    }
}
