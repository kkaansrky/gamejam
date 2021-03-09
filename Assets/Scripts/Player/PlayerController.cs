using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 5f;
    private float turnSpeed = 20f;
    private float horizontalInput;
    private float forwardInput;
    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);
    }


}
