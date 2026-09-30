using UnityEngine;

// Moves one grid square at a time and pushes blocks.
public class PlayerCircle : MonoBehaviour
{
    public float moveSpeed = 8f;
    Vector3 target; // the square youre moving to

    void Start() => target = transform.position;

    void Update()
    {
        // Slide towards the target square, and wait until we get there
        transform.position = Vector3.MoveTowards(transform.position, target, moveSpeed * Time.deltaTime);
        if (transform.position != target) return;
        if (LevelManager.levelWon) return;

        Vector2Int dir = GameInput.GetMoveDirection();
        if (dir == Vector2Int.zero) return;

        Vector3 next = target + new Vector3(dir.x, dir.y, 0);
        Physics2D.SyncTransforms(); // make sure physics knows where everything is right now
        Collider2D hit = Physics2D.OverlapPoint(next);

        if (hit == null)
        {
            target = next; // walk into it
        }
        else
        {
            PushBlock block = hit.GetComponent<PushBlock>();
            if (block != null && block.TryPush(dir))
                target = next; // pushed a block: follow it unless it is a wall then dont move
        }
    }
}
