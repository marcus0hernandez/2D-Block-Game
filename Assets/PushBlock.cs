using UnityEngine;

// A block the player can push one square at a time.
public class PushBlock : MonoBehaviour
{
    public float moveSpeed = 8f;
    Vector3 target;
    SpriteRenderer spriteRenderer;

    void Start()
    {
        target = transform.position;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, moveSpeed * Time.deltaTime);
    }

    // Called by the player. Returns true if the block could move.
    public bool TryPush(Vector2Int dir)
    {
        if (transform.position != target) return false; // still sliding

        Vector3 next = target + new Vector3(dir.x, dir.y, 0);
        if (Physics2D.OverlapPoint(next) != null) return false; // wall or another block

        target = next;
        return true;
    }

    public void SetColor(Color color)
    {
        if (spriteRenderer != null) spriteRenderer.color = color;
    }
}
