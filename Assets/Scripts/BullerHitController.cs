using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BullerHitController : MonoBehaviour {
    private float lifetime = 1;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        lifetime -= Time.deltaTime;
        if (lifetime <= 0)
            Destroy(gameObject);
	}
}
