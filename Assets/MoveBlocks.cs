using UnityEngine;

public class MoveBlocks : MonoBehaviour
{
    public float moveSpeed = 5;
    public float deadZone = -10;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // move screen position the same no matter frame rate
        transform.position += (Vector3.left * moveSpeed) * Time.deltaTime;
        if(transform.position.x < deadZone)
        {
            Destroy(gameObject);
        }
    }
}
