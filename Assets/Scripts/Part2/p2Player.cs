using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class p2Player : MonoBehaviour
{
    public float walkSpeed;
    public float accel;
    public float decel;
    private Vector2 currentSpeed;
    private Animator animator;

    //This is the direction the player is facing.
    //0 is up, 1 is right, 2 is down, 3 is left.
    private int facing = 2;

    private Rigidbody2D body; //this a reference to the player's rigidbody, which is needed to apply movement in FixedUpdate.


    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        //check move controls and apply speed accordingly
        CheckMoveCtrls();
        animator.SetInteger("facingParam", facing);
        animator.SetBool("isMoving", currentSpeed.magnitude > 0);
        //move the player object
        body.MovePosition(body.position + (currentSpeed * Time.fixedDeltaTime));
    }


    void CheckMoveCtrls()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            facing = 0;
            currentSpeed.y = Mathf.Min(currentSpeed.y + (accel * Time.deltaTime), walkSpeed);
        }
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            facing = 2;
            currentSpeed.y = Mathf.Max(currentSpeed.y - (accel * Time.deltaTime), -walkSpeed);
        }
        else
        {
            currentSpeed.y = Approach(currentSpeed.y, 0, decel);
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            facing = 1;
            currentSpeed.x = Mathf.Min(currentSpeed.x + (accel * Time.deltaTime), walkSpeed);

        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            facing = 3;
            currentSpeed.x = Mathf.Max(currentSpeed.x - (accel * Time.deltaTime), -walkSpeed);
        }
        else
        {
            currentSpeed.x = Approach(currentSpeed.x, 0, decel);
        }
    }

    //We use this for deceleration (have our speed approach 0 without passing it).
    float Approach(float _start, float _end, float _value)
    {
        _value = _value * Time.deltaTime;

        if (_start < _end)
        {
            return Mathf.Min(_start + _value, _end);
        }
        else
        {
            return Mathf.Max(_start - _value, _end);
        }
    }

}

