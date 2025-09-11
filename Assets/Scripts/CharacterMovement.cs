using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMovement : MonoBehaviour
{
    public float movementSpeed = 1f;
    void Update()
    {
        if (InputSystem.GetDevice<Keyboard>().leftArrowKey.isPressed)
        {
            gameObject.GetComponent<Rigidbody2D>().linearVelocity += Vector2.left
                                                                    * movementSpeed
                                                                    * Time.deltaTime;
        }

        else if (InputSystem.GetDevice<Keyboard>().rightArrowKey.isPressed)
        {
            gameObject.GetComponent<Rigidbody2D>().linearVelocity += Vector2.right
                                                                    * movementSpeed
                                                                    * Time.deltaTime;
        }
    }
}
