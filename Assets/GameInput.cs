using UnityEngine;
#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif

// Keyboard helper that works with either the new Input System or the old Input Manager.
// keyboard movements, level reset, and undo turn functions
public static class GameInput
{
    public static Vector2Int GetMoveDirection()
    {
#if ENABLE_INPUT_SYSTEM
        var k = Keyboard.current;
        if (k == null) return Vector2Int.zero;
        if (k.upArrowKey.isPressed    || k.wKey.isPressed) return Vector2Int.up;
        if (k.downArrowKey.isPressed  || k.sKey.isPressed) return Vector2Int.down;
        if (k.leftArrowKey.isPressed  || k.aKey.isPressed) return Vector2Int.left;
        if (k.rightArrowKey.isPressed || k.dKey.isPressed) return Vector2Int.right;
#else
        if (Input.GetKey(KeyCode.UpArrow)    || Input.GetKey(KeyCode.W)) return Vector2Int.up;
        if (Input.GetKey(KeyCode.DownArrow)  || Input.GetKey(KeyCode.S)) return Vector2Int.down;
        if (Input.GetKey(KeyCode.LeftArrow)  || Input.GetKey(KeyCode.A)) return Vector2Int.left;
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) return Vector2Int.right;
#endif
        return Vector2Int.zero;
    }

    public static bool RestartPressed()
    {
#if ENABLE_INPUT_SYSTEM
        return Keyboard.current != null && Keyboard.current.rKey.wasPressedThisFrame;
#else
        return Input.GetKeyDown(KeyCode.R);
#endif
    }

    // space to start the game from main menu
    public static bool spacePressed()
    {
#if ENABLE_INPUT_SYSTEM
        return Keyboard.current != null && Keyboard.current.spaceKey.wasPressedThisFrame;
#else
        return Input.GetKeyDown(KeyCode.space);
#endif
    }
}
