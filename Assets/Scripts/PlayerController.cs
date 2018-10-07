using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    Animator playerAnim;

	void Start () {
		playerAnim = GetComponent<Animator>();
	}

	void Update () {
        playerAnim.SetFloat("Direction", GetRotationToMouse());
	}

    float GetRotationToMouse()
    {

        Vector2 target = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        // Get Angle in Radians
        float AngleRad = Mathf.Atan2(target.y - transform.position.y, target.x - transform.position.x);
        // Get Angle in Degrees
        float AngleDeg = (180 / Mathf.PI) * AngleRad;

        return AngleDeg;
    }

}
