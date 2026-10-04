using UnityEngine;

public class FollowPLayer : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public GameObject player;
    private Vector3 offset = new Vector3(0, 6, -9);

    // Update is called once per frame
    void LateUpdate()
    {
        // Offset cameras position behind player by adding player position
        transform.position = player.transform.position + offset;
    }
}
