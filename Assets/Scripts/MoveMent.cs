using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMent : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed = 10f;
    public float horizontalMovement = 0f;
    public float verticalMovement = 0f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMovement = Input.GetAxisRaw("Horizontal") * speed;
        verticalMovement = Input.GetAxisRaw("Vertical") * speed;
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontalMovement * Time.fixedDeltaTime, verticalMovement * Time.fixedDeltaTime);
        // Debug.Log(rb.velocity);
    }
}
