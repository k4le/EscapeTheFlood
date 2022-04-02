using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObject : MonoBehaviour
{
    Rigidbody2D rb;
    BoxCollider2D bc;

    bool freeFall = true;
    int collisionCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        bc = GetComponent<BoxCollider2D>();

        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up * -1000f);
        //rb.velocity = new Vector2(0, -50);
    }

    // Update is called once per frame
    // void Update()
    // {
    //     if (freeFall) {
    //         transform.Translate(0, -10f * Time.deltaTime, 0);
    //     }
    // }
    void FixedUpdate()
    {
        var currentVelocity = rb.velocity;

        if (currentVelocity.y <= 0f)
            return;

        currentVelocity.y = 0f;

        rb.velocity = currentVelocity;
    }

    //void OnCollisionEnter2D(Collision2D collision)
    //{
    //    collisionCount++;
    //    freeFall = false;
    //}
    //
    //void OnCollisionExit2D(Collision2D collision)
    //{
    //    collisionCount--;
    //    if (collisionCount == 0) {
    //        Debug.Log("aaaa");
    //        freeFall = true;
    //    }
    //}
}
