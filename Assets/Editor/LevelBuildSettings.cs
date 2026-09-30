using System.Linq;
using UnityEditor;

// Editor-only helper: keeps every scene in Assets/Scenes in the build list,
// in number order (Level 1, Level 2, ... Level 10), so the game can load the
// next level. Make a new level by duplicating a scene (Ctrl+D) and naming it "Level 4".
[InitializeOnLoad]
public class LevelBuildSettings : AssetPostprocessor
{
    static LevelBuildSettings() => EditorApplication.delayCall += Sync;

    static void OnPostprocessAllAssets(string[] imported, string[] deleted, string[] moved, string[] movedFrom)
    {
        bool scenesChanged = imported.Concat(deleted).Concat(moved).Concat(movedFrom)
            .Any(p => p.StartsWith("Assets/Scenes/") && p.EndsWith(".unity"));
        if (scenesChanged) EditorApplication.delayCall += Sync;
    }

    static void Sync()
    {
        string[] paths = AssetDatabase.FindAssets("t:Scene", new[] { "Assets/Scenes" })
            .Select(AssetDatabase.GUIDToAssetPath)
            .OrderBy(p => p.Length).ThenBy(p => p) // "Level 2" before "Level 10"
            .ToArray();
        if (paths.Length == 0) return;

        string[] current = EditorBuildSettings.scenes.Select(s => s.path).ToArray();
        if (current.SequenceEqual(paths)) return;

        EditorBuildSettings.scenes = paths.Select(p => new EditorBuildSettingsScene(p, true)).ToArray();
    }
}
