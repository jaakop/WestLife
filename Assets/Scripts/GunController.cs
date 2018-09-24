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
        RotateGun();
        
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void RotateGun()
    {
        Vector2 target = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        // Get Angle in Radians
        float AngleRad = Mathf.Atan2(target.y - transform.position.y, target.x - transform.position.x);
        // Get Angle in Degrees
        float AngleDeg = (180 / Mathf.PI) * AngleRad;
        // Rotate Object
        this.transform.rotation = Quaternion.Euler(0, 0, AngleDeg);
    }
    void Shoot()
    {
        int mask = 1 << 8;
        //mask = ~mask;
        Debug.Log("SHOT");
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up, Mathf.Infinity, mask);
        if(hit.collider != null)
        {
            Debug.Log("HIT");
        }
    }
}
