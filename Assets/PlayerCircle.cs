using UnityEngine;

public class PlayerCircle : MonoBehaviour
{

    public Rigidbody2D myRigidBody; // establishes outside connection for script

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        // Jump with spacebar
         if(Input.GetKeyDown(KeyCode.Space) == true)
         {
            myRigidBody.linearVelocity = Vector2.up * 3;
         }
       
    }
}
