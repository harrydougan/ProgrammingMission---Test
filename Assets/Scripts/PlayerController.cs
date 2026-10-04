using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    //Movement Tuning (Inspector)
    public float speed = 5.0f;
    public float turnSpeed = 100f;
    //Input System action exposed in Inspector for Binding (WASD)
    public InputAction moveAction;
    //Current Values (x = left/right, y = forward/back), private for internal use
    private Vector2 moveInput;

    private float Test;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Enable moveAction so it starts reading the input
        moveAction.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        //Read the 2D Vector from the moveAction (x: horizontal, y: vertical)
        moveInput = moveAction.ReadValue<Vector2>();
        // Move the vehicle forward along z using the y component 
        transform.Translate(Vector3.forward * Time.deltaTime * speed * moveInput.y);
        // Move vehicle left/right (Rotate around local (yaw) using the x component)
        transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * moveInput.x);
    }
}
