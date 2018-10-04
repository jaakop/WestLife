﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour {
    public Transform position;
    [SerializeField]
    GameObject bulletTrail;
    GameObject gunPoint;
    [SerializeField]
    GameObject gunPoint1;
    [SerializeField]
    GameObject gunPoint2;
    [SerializeField]
    ParticleSystem particles;
    void Start () {
	}
	
	void Update () {
        RotateGun();
        
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
        gunPoint = gunPoint1;
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

        if(target.x < transform.position.x)
        {
            FlipGun(true);
        }
        else
        {
            FlipGun(false);
        }
    }
    void Shoot()
    {
        int mask = 1 << 0;
        //mask = ~mask;
        Debug.Log("SHOT");
<<<<<<< HEAD
        RaycastHit2D hit = Physics2D.Raycast(gunPoint.transform.position, Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position), Mathf.Infinity, mask);
        Debug.DrawRay(gunPoint.transform.position, Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position), Color.green, 10);
=======
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position), Mathf.Infinity, mask);
>>>>>>> 07ad355bced3da98a6a4dd974d2386bf70c57331
        if(hit.collider != null)
        {
            Debug.Log("HIT" + hit.collider.name);
            ParticleSystem system = Instantiate(particles, hit.point, Quaternion.identity);
            system.Play();
        }
        Instantiate(bulletTrail, gunPoint.transform.position, gunPoint.transform.rotation);
    }
    void FlipGun(bool flipped)
    {
        if (flipped)
        {
            gameObject.GetComponent<SpriteRenderer>().flipY = true;
            gunPoint = gunPoint2;
            
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().flipY = false;
            gunPoint = gunPoint1;   
        }
    }
}
