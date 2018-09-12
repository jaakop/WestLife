using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour {

    Rigidbody2D rb;
    public float playerMovementSpeed;
    public float rollSpeed;
    [Header("Movement Keys")]
    [SerializeField]
    KeyCode up;
    [SerializeField]
    KeyCode down;
    [SerializeField]
    KeyCode left;
    [SerializeField]
    KeyCode right;

    private Vector2 direction;
    private bool rolling;
    private float rollingTime;

    private bool rollingStop;
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        direction = new Vector2(0, 0);
	}
	
	void Update () {
        rollingTime -= Time.deltaTime;
        if (rolling && rollingTime < 0)
        {
            rolling = false;
            if (rollingStop)
            {
                Move(new Vector2(0, 0));
                rollingStop = false;
            }
        }
        if (Input.GetKey(up) && !rolling)
        {
            Move(new Vector2(rb.velocity.x, playerMovementSpeed));
            direction = new Vector2(direction.x, 1);
        }
        else if (Input.GetKey(down) && !rolling)
        {
            Move(new Vector2(rb.velocity.x, -playerMovementSpeed));
            direction = new Vector2(direction.x, -1);
        }
        else if (!rolling)
        {
            Move(new Vector2(rb.velocity.x, 0));
            direction = new Vector2(direction.x, 0);
        }
        if (Input.GetKey(right) && !rolling)
        {
            Move(new Vector2(playerMovementSpeed, rb.velocity.y));
            direction = new Vector2(1, direction.y);
        }
        else if (Input.GetKey(left) && !rolling)
        {
            Move(new Vector2(-playerMovementSpeed, rb.velocity.y));
            direction = new Vector2(-1, direction.y);
        }
        else if (!rolling)
        { 
       
            Move(new Vector2(0, rb.velocity.y));
            direction = new Vector2(0, direction.y);
        }
        if(Input.GetKey(KeyCode.Mouse1) && !rolling)
        {
            if (rb.velocity.x != 0 || rb.velocity.y != 0)
            {
                Debug.Log("Roll");
                rolling = true;
                Move(direction * rollSpeed);
                rollingTime = .3f;
                rollingStop = true;
            }
        }
    }

    void Move(Vector2 direction)
    {
        rb.velocity = direction;
    }

}
