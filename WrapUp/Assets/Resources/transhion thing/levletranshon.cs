using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levletranshon : MonoBehaviour {
    public float UpdateTime;
    public GameObject fade;
    public GameObject ShitBar;
    public GameObject text;

    public int swich = 0;
    public string nextlv = "";


    public float alfa =1;
    private float UpdateTimer;


    // Use this for initialization
    void Start () {
		
	}
	
	void Update () {

        if (ShitBar.GetComponent<BarScript>().value == ShitBar.GetComponent<BarScript>().maxValue)
        {
            text.SetActive(true);
            if (Input.GetKey(KeyCode.Space))
            {
                swich = 2;
            }
        }

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
                SceneManager.LoadScene(nextlv);
            }
        }

    }
}
