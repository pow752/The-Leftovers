using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAtack : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "BADThings")
        {
            other.gameObject.SendMessage("TakeDamage", 500.0f);

            // GameObject.Find("badguy").GetComponent<Ai>().seePlayer = true;
        }
    }
}
