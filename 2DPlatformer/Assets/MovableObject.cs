using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableObject : MonoBehaviour {
    Rigidbody2D rb;
    public Vector3 startPos;
    public Quaternion startRot;
    public float startGrav;
    public float startRotVel;
    public Vector2 startVel;
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startPos = transform.position;
        startGrav = rb.gravityScale;
        startRot = transform.rotation;
        startRotVel = rb.angularVelocity;
        startVel = rb.velocity;
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Die();
        }
	}

    void Die()
    {
        transform.position = startPos;
        transform.rotation = startRot;
        rb.gravityScale = startGrav;
        rb.velocity = startVel;
        rb.angularVelocity = startRotVel;
    }
}
