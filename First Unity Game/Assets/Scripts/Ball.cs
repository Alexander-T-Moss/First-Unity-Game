using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    
    
    private float _speed = 20f;
    private Rigidbody _rigidbody;
    private Vector3 _velocity;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.velocity = Vector3.down * _speed;
    }


    // Runs once per physics update ( default is 100hz )
    void FixedUpdate()
    {
        _rigidbody.velocity = _rigidbody.velocity.normalized * _speed; // normalized converts a velocity to having a magnitude of 1
        _velocity = _rigidbody.velocity;

    }

    private void OnCollisionEnter(Collision collision)
    {
        _rigidbody.velocity = Vector3.Reflect(_velocity, collision.contacts[0].normal);
    }
}
