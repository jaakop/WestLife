using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTrailController : MonoBehaviour {

    private const float speed = 50;
    private float lifeTime = 2;

	void Start () {
		
	}
	
	void Update () {
        lifeTime -= Time.deltaTime;
        if(lifeTime <= 0)
        {
            Destroy(gameObject);
        }
        transform.Translate(Vector3.right * Time.deltaTime * speed);
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "Player")
        {
            Destroy(gameObject);
        }
    }
}
