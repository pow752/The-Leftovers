using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collision : MonoBehaviour
{
    public GameObject explosionPrefab;
    public GameObject debris;
    public Image hitPointBar;
    public float maxHitPoints = 1000;
    public float buildingHitPoints = 1000;
    public float displayHitPoints = 0;

	// Use this for initialization
	void Start ()
    {
        
    }

    void Destruction()
    {
        GameObject explode = Instantiate(explosionPrefab, new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z), Quaternion.identity) as GameObject;
        GameObject makeDebris = Instantiate(debris, new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z), Quaternion.identity) as GameObject;
        DestroyImmediate(hitPointBar, true);
        Destroy(gameObject);
    }

    void Controls ()
    {
        if (Input.GetMouseButtonDown(0))
        {
            buildingHitPoints -= 100;
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        Controls();
        displayHitPoints = buildingHitPoints / maxHitPoints;
        //hitPointBar.fillAmount = Mathf.Lerp(hitPointBar.fillAmount, displayHitPoints, Time.deltaTime * 2);
        //hitPointBar.transform.localScale = new Vector3(displayHitPoints, hitPointBar.transform.localScale.y, hitPointBar.transform.localScale.z);
        if (buildingHitPoints <= 0) Destruction();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "")   // If the building collides with the player.
        {
            buildingHitPoints -= 100;
        }
        
    }
}
