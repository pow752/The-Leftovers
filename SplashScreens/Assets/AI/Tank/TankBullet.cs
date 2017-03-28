using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankBullet : MonoBehaviour {

    private Vector2 heading = Vector2.right;
    public float angle = 0;
    public float lifetime = 3;
    public float speed = 1;
    public float damagedealt = 100.0f;
    private Transform sprite;
	// Use this for initialization
	void Start () {
        heading = (Vector2)(Quaternion.Euler(0, 0, angle) * Vector2.right);
        sprite = GetComponentInChildren<Transform>();
    }

    void OnCollisionEnter2D(Collision2D impactObject)
    {
        impactObject.gameObject.SendMessage("TakeDamage", damagedealt);
        Destroy(this.gameObject);
    }


	
	// Update is called once per frame
	void Update () {
        lifetime -= Time.deltaTime;
        if (lifetime < 0)
            Destroy(this.gameObject);
        transform.position -= new Vector3(heading.x, heading.y) * speed;
        sprite.rotation = Quaternion.Euler(0, 0, angle);
	}
}
