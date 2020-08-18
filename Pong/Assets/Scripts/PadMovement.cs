using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

/// <summary>
/// Moves the player alongside the y axis
/// </summary>
[RequireComponent(typeof(Rigidbody2D))]
public class PadMovement : MonoBehaviour
{
    public bool isPlayer1;
    //Movement velocity
    [Tooltip("Velocity in unity units: ")]
    [SerializeField]private float velocity = 0.5f;
    
    [Header("Inferior Limit:")]
    public float downLimit;

    [Header("Upper limit:")]
    public float upLimit;

    [Header("Controls For the Gamepad:")] 
    [SerializeField] public KeyCode upControl;
    [SerializeField] public KeyCode downControl ;
    
    private Rigidbody2D _rigidbody2D;

    public Vector2 startPosition;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Read Control of keys   
        //Apply Movement
        //Move UP
        if (Input.GetKey(upControl))
        {
            transform.Translate(0f,velocity,0f);
        }
        //Move DOWN
        else if (Input.GetKey(downControl))
        {
            transform.Translate(0f,-velocity,0f);
        }
        //if(!_rigidbody2D.Equals(null))
        //   _rigidbody2D.AddForce(Vector2.up,ForceMode2D.Impulse);
        //else
        //{
        //    Debug.LogWarning("The object doesnt have a rigidbody");
        //}
        
        //Limit from y-Axis
        transform.position = new Vector2(transform.position.x,Mathf.Clamp(transform.position.y, downLimit,max:upLimit));
        //transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, downLimit,max:upLimit), transform.position.z);
    }//update

    public void Reset()
    {
        _rigidbody2D.velocity = Vector2.zero;
        transform.position = startPosition;
    }
}//class
