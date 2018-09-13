using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour {
    GameObject player;
    public Transform position;
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	void Update () {
        Vector2 target = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        // Get Angle in Radians
        float AngleRad = Mathf.Atan2(target.y - transform.position.y, target.x - transform.position.x);
        // Get Angle in Degrees
        float AngleDeg = (180 / Mathf.PI) * AngleRad;
        // Rotate Object
        this.transform.rotation = Quaternion.Euler(0, 0, AngleDeg);
    }
}
