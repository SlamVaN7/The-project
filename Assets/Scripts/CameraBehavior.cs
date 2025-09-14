using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;

    public float cameraMoveSpeed;
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position,
                                          player.position + offset,
                                          Time.deltaTime * cameraMoveSpeed);
    }
}
