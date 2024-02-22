using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingMOABall : MonoBehaviour
{

/*
private float time = 0.0f;
private bool isMoving = false;
//private bool isActive = false;

[SerializeField] private Vector3 initialVelocity;
[SerializeField] private float minVelocity = 0.1f;
private Vector3 lastFrameVelocity;
private Rigidbody rb;


    // Start is called before the first frame update
    private void OnEnable() 
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = initialVelocity;
        isMoving = true;
    }

    // Update is called once per frame
    void Update()
    {
        lastFrameVelocity = rb.velocity;
        
        
    }

    private void OnCollisionEnter(Collision collision) 
    {
        Bounce(collision.contacts[0].normal)    ;
    }

    private void Bounce(Vector3 collisionNormal)
    {
        var speed = lastFrameVelocity.magnitude;
        var direction = Vector3.Reflect(lastFrameVelocity.normalized, collisionNormal);

        direction.z = 0.03f;

        rb.velocity= direction * Mathf.Max(speed, minVelocity);
    }

*/
}
