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
        //rb.AddForce(transform.up * -100f);
        //rb.velocity = new Vector2(0, -50);
    }

    // Update is called once per frame
    // void Update()
    // {
    //     if (freeFall) {
    //         
    //     }
    // }
    void FixedUpdate()
    {
        // RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y - transform.localScale.y / 2),
        //    Vector2.down,
        //    .1f);
        //
        // Debug.DrawRay(new Vector2(transform.position.x, transform.position.y - transform.localScale.y/2), Vector2.down * 0.1f, Color.red);
        //
        // if (hit.transform == null) {
        if (rb.velocity.magnitude > maxSpeed && freeFall) {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }
       
        //transform.Translate(0, -2f * Time.deltaTime, 0);

        // var currentVelocity = rb.velocity;
        //
        // if (currentVelocity.y <= 0f)
        //     return;z§
        //
        // currentVelocity.y = 0f;
        //
        // rb.velocity = currentVelocity;
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
    
    //void OnCollisionExit2D(Collision2D collision)
    //{
    //    collisionCount--;
    //    if (collisionCount == 0) {
    //        Debug.Log("aaaa");
    //        freeFall = true;
    //    }
    //}
}
