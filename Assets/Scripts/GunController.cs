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
        Vector2 mousePos = Input.mousePosition;
        float AngleRad = Mathf.Atan2(mousePos.y - position.transform.position.y, mousePos.x - position.transform.position.x);
        float AngleDeg = (180 / Mathf.PI) * AngleRad;
        transform.rotation = Quaternion.Euler(0, 0, AngleDeg);
        transform.LookAt(new Vector3(mousePos.x, mousePos.y,0));
	}
}
