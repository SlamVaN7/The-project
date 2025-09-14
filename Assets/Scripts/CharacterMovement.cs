using Mono.Cecil.Cil;
using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public LayerMask groundLayer;

    public float acceleration;
    public float maxMoveSpeed;
    public float jumpHeight;
    public float fallMultiplier;
    public float groundFriction;

    private Keyboard keyboard;

    void Start()
    {
        keyboard = Keyboard.current;
    }

    void Update()
    {   
        //Horizontal movement
        if (keyboard.aKey.isPressed &&
        rb.linearVelocity.x > -maxMoveSpeed)
        {
            rb.AddForce(Vector2.left * acceleration * Time.deltaTime);
        }

        else if (keyboard.dKey.isPressed &&
        rb.linearVelocity.x < maxMoveSpeed)
        {
            rb.AddForce(Vector2.right * acceleration * Time.deltaTime);
        }


        //Jumping and gravity
        if (keyboard.spaceKey.wasPressedThisFrame && isGrounded())
        {
            rb.AddForce(new Vector2(rb.linearVelocity.x, jumpHeight));
        }

        if (rb.linearVelocity.y < 0)
        {
            rb.linearVelocity += Vector2.up * Physics2D.gravity.y * fallMultiplier * Time.deltaTime;
        }


        //Smooth stoping
        if (isGrounded() && !keyboard.aKey.isPressed && !keyboard.dKey.isPressed)
        {
            rb.linearVelocity = new Vector2(
                Mathf.Lerp(rb.linearVelocity.x, 0, groundFriction * Time.deltaTime),
                rb.linearVelocity.y
            );
        }
    }

    bool isGrounded()
    {
        return Physics2D.OverlapCapsule(new Vector2(transform.position.x, transform.position.y - 1f), new Vector2(0.93f, 0.04f), CapsuleDirection2D.Horizontal, 0, groundLayer);
    }
}
