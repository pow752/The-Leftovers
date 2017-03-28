using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiAttackRange : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "Player")
        {
             this.transform.parent.GetComponent<AI>().atackPlayer = true;

            // GameObject.Find("badguy").GetComponent<Ai>().seePlayer = true;
        }
    }



    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            this.transform.parent.GetComponent<AI>().atackPlayer = false;

        }
    }
    



}
