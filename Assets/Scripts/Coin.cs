using UnityEngine;

public class Coin : MonoBehaviour
{
    public float rotateSpeed;
    public Vector3 rotationDirection = new Vector3();

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(rotateSpeed * rotationDirection * Time.deltaTime);
    }
}
