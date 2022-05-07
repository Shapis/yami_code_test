using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionChecker : MonoBehaviour
{
    private Rigidbody2D _collidingRigidBody2d;

    private void OnTriggerEnter2D(Collider2D other)
    {
        _collidingRigidBody2d = other.GetComponent<Rigidbody2D>();
        CollisionObjectName(other.gameObject);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        _collidingRigidBody2d = null;
    }

    private string CollisionObjectName(GameObject _go)
    {
        this.GetComponent<Renderer>().material.color = Random.ColorHSV();
        return _go.name;
    }
}
