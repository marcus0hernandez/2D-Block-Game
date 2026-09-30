using UnityEngine;

// A square is used to indicate the goal point
public class Goal : MonoBehaviour
{
    // Returns the block sitting on this goal or null if it's empty
    public PushBlock GetBlock()
    {
        Collider2D hit = Physics2D.OverlapPoint(transform.position);
        return hit != null ? hit.GetComponent<PushBlock>() : null;
    }
}
