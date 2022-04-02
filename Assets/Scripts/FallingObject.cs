using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObject : MonoBehaviour
{
    Rigidbody2D rb;
    BoxCollider2D bc;

    bool freeFall = true;
    int collisionCount = 0;
    public float maxSpeed = 100;
    // Start is called before the first frame update
    void Start()
    {
        bc = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (rb.velocity.magnitude > maxSpeed && freeFall) {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.contacts.Length > 0) {
            ContactPoint2D contact = collision.contacts[0];
            Debug.Log(contact.collider.tag);
            if (Vector3.Dot(contact.normal, Vector3.up * -1) > transform.localScale.y / 2 && contact.collider.tag != "Player") {
                freeFall = false;
                rb.velocity = new Vector2(0.0f, 0.0f);
                rb.gravityScale = 0.0f;
                rb.mass = 1999;
            }
        }
    }
}
