using UnityEditor;
using UnityEngine;

public class OpenDirectoryShortcut : EditorWindow {
    [MenuItem("Custom/Open Directory Shortcut %g")]
    private static void OpenDirectory() {
        string relativePath = "../DataManager/Table";
        string absolutePath = Application.dataPath + "/" + relativePath;

        EditorUtility.RevealInFinder(absolutePath);
    }
}