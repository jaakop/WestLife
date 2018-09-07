using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovementScript : MonoBehaviour {

    Transform player;
    GameObject p;
    [SerializeField]
    float cameraSpeed;
	void Start () {
        p = GameObject.FindGameObjectWithTag("Player");
        player = p.transform;
	}
	
	void Update () {
        Vector2 direction = Vector2.Lerp(transform.position, player.position, cameraSpeed);
        transform.position = new Vector3(direction.x, direction.y, -10);
	}
}
