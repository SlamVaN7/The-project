using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMovement : MonoBehaviour
{
    public float movementSpeed;
    public float jumpHeight;
    void Update()
    {
        if (InputSystem.GetDevice<Keyboard>().aKey.isPressed)
        {
            gameObject.GetComponent<Rigidbody2D>().linearVelocity += Vector2.left
                                                                    * movementSpeed
                                                                    * Time.deltaTime;
        }

        else if (InputSystem.GetDevice<Keyboard>().dKey.isPressed)
        {
            gameObject.GetComponent<Rigidbody2D>().linearVelocity += Vector2.right
                                                                    * movementSpeed
                                                                    * Time.deltaTime;
        }

        if (InputSystem.GetDevice<Keyboard>().spaceKey.wasPressedThisFrame)
        {
            gameObject.GetComponent<Rigidbody2D>().linearVelocity = Vector2.up
                                                                    * jumpHeight;
                                                                    
        }
    }
}
