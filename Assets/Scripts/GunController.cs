using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

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
    [SerializeField]
    private Animator gunAnimator;
    private AudioSource audioSource;

    private GameObject cam;

    void Start () {
        cam = GameObject.FindGameObjectWithTag("MainCamera");
        audioSource = GetComponent<AudioSource>();
        gunAnimator = GetComponent<Animator>();
	}
	
	void Update () {
        RotateGun();
        
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
        gunPoint = gunPoint1;
        
        Debug.DrawRay(gunPoint.transform.position, Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position), Color.green);
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
        gunAnimator.SetTrigger("Shot");
        Debug.Log("SHOT");
        audioSource.Play();

        RaycastHit2D hit = Physics2D.Raycast(gunPoint.transform.position, Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position), Mathf.Infinity, mask);


        GameObject trail = Instantiate(bulletTrail, gunPoint.transform.position, gunPoint.transform.rotation);
        trail.GetComponent<BoxCollider2D>().enabled = false;
        if (hit.collider != null)
        {
            Debug.Log("HIT" + hit.collider.name);
            trail.GetComponent<BoxCollider2D>().enabled = true;
            ParticleSystem system = Instantiate(particles, hit.point, Quaternion.identity);
            system.Play();
        }

        cam.GetComponent<CameraShake>().shakeDuration = 0.1f;
        cam.GetComponent<CameraShake>().enabled = true;
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
