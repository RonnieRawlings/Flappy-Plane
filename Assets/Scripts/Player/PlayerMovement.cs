// Author - Ronnie Rawlings.

using UnityEngine;
using System.Collections;

using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    // Speed of rotation up and down.
    private float rotSpeed = 200, moveSpeed = 7;

    // Upwards force when flapping.
    private float flapForce = 12f;

    // Rigidbody2D component for physics-based movement.
    private Rigidbody2D rb;

    // Velocity threshold for rotating downwards.
    private float downVelocityThreshold = -4f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    /// <summary>
    /// FlapUp method takes user input and gives a boost upwards.
    /// </summary>
    private void FlapUp()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Apply an instant upwards force
            rb.velocity = new Vector2(rb.velocity.x, flapForce);
        }
    }

    /// <summary>
    /// Rotate the player based on their vertical velocity.
    /// </summary>
    private void RotatePlayer()
    {
        float targetAngle;

        if (rb.velocity.y > 0)
        {
            targetAngle = 45;
        }
        else if (rb.velocity.y < downVelocityThreshold)
        {
            targetAngle = -90;
        }
        else
        {
            return; // No significant downward velocity, so no rotation change
        }

        transform.rotation = Quaternion.RotateTowards(transform.rotation,
            Quaternion.Euler(0, 0, targetAngle), rotSpeed * Time.deltaTime);
    }

    // FixedUpdate is called once per physics frame
    void FixedUpdate()
    {
        // Apply constant downward force (gravity-like effect)
        rb.AddForce(Vector2.down * moveSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        // Flaps the player upwards.
        FlapUp();

        // Rotate the player based on movement direction.
        RotatePlayer();
    }
}
