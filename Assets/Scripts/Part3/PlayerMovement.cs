using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float walkSpeed;
    public float accel;
    public float decel;
    private Vector2 currentSpeed;

    //This is the direction the player is facing.
    //0 is up, 1 is right, 2 is down, 3 is left.
    private int facing = 0;

    private Rigidbody2D body; //this a reference to the player's rigidbody, which is needed to apply movement in FixedUpdate.
    private Animator anim; //this is a reference to the Animator component, by which we can update parameter's for the Animator state tree.
    
    // Start is called before the first frame update
    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        //check move controls and apply speed accordingly
        CheckMoveCtrls();

        //move the player object
        body.MovePosition(body.position + (currentSpeed * Time.fixedDeltaTime));

        //update animator parameters
        anim.SetInteger("facingParam", facing);
        anim.SetFloat("xSpdParam", currentSpeed.x);
        anim.SetFloat("ySpdParam", currentSpeed.y);
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
        } else
        {
            return Mathf.Max(_start - _value, _end);
        }
    }
    
}
