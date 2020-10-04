using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;

    public float speed = 1f;
    public float maxSpeed = 5f;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");

        Vector2 force = new Vector2(horizontal * speed, 0);

        rb.AddForce(force);

        float vel = rb.velocity.x;
        if (vel > maxSpeed)
        {
            rb.velocity = new Vector2(maxSpeed, rb.velocity.y);
        }
        else if(vel < (-1 * maxSpeed))
        {
            rb.velocity = new Vector2(-maxSpeed, rb.velocity.y);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Teleporter"))
        {
            Teleporter teleInfo = collision.gameObject.GetComponent<Teleporter>();
            TimeLoopController.Teleport(teleInfo.targetScene, teleInfo.spawnX);
        }
    }
}
