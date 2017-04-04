using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collision : MonoBehaviour
{
    public AudioSource boom;
    public GameObject explosionPrefab;
    public GameObject debris;
    public Image hitPointBar;
    public float maxHitPoints = 1000;
    public float buildingHitPoints = 1000;
    public float displayHitPoints = 0;
    bool exploshon = true;

    float timer = 0;

	// Use this for initialization
	void Start ()
    {
        Random.InitState((int)System.DateTime.Now.Ticks);
    }

    void Destruction()
    {
        boom.Play();
        if (exploshon)
        {           

            exploshon = false;
        }
    }
	void Update ()
    {
        //Controls();
        displayHitPoints = buildingHitPoints / maxHitPoints;
         if (buildingHitPoints <= 0 && exploshon)
        {
            Destruction();
        }
         if (boom.isPlaying)
        {
            timer += Time.deltaTime;

            if (timer > 0.08)
            {
                int explosionOffsetX = Random.Range(-100, 100);
                int explosionOffsetY = Random.Range(-100, 250);
                GameObject explode = Instantiate(explosionPrefab, new Vector3((transform.localPosition.x + explosionOffsetX),
                    (transform.localPosition.y + explosionOffsetY), transform.localPosition.z), Quaternion.identity) as GameObject;
                timer = 0;
            }

            
        }

        if (buildingHitPoints <= 0 && !boom.isPlaying)
        {
            GameObject makeDebris = Instantiate(debris, new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z), Quaternion.identity) as GameObject;
            DestroyImmediate(hitPointBar, true);

           

            

            GameObject RageBar = GameObject.Find("NoiseBar");
            RageBar.SendMessage("ChangeValue", 20);
            //GameObject.FindObject(NoiseBar)().value += 100;
            Destroy(gameObject);
        }
    }

   // void OnCollisionEnter2D(Collision2D col)
  //  {
   //     if (col.gameObject.tag == "")   // If the building collides with the player.
    //    {
     //       buildingHitPoints -= 100;
    //    }
        
  //  }

    public void TakeDamage(float dps)
    {
        buildingHitPoints -= dps;
    }
}
