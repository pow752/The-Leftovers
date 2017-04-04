using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiAttackRange : MonoBehaviour {
    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "Player")
        {
            this.gameObject.transform.parent.SendMessage("StartAttacking");

            // GameObject.Find("badguy").GetComponent<Ai>().seePlayer = true;
        }
    }



    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            this.gameObject.transform.parent.SendMessage("StopAttacking");

        }
    }




}
