using UnityEditor;
using UnityEngine;

public class PrefabGeneratorWindow : EditorWindow {
    private string uiScriptPath = "Scripts/Base/UI";
    private GameObject prefabObject;

    [MenuItem("Tools/Prefab Generator")]
    public static void ShowWindow() {
        GetWindow<PrefabGeneratorWindow>("Prefab Generator");
    }

    private void OnGUI() {
        EditorGUILayout.LabelField("Prefab Generator", EditorStyles.boldLabel);

        uiScriptPath = EditorGUILayout.TextField("Prefab Path:", uiScriptPath);
        prefabObject = EditorGUILayout.ObjectField("Prefab Object:", prefabObject, typeof(GameObject), false) as GameObject;

        if (GUILayout.Button("Generate")) {
            GeneratePrefabScript();
        }
    }

    private void GeneratePrefabScript() {
        if (prefabObject == null) {
            Debug.LogError("Please assign a prefab object.");
            return;
        }

        if (string.IsNullOrEmpty(uiScriptPath)) {
            Debug.LogError("Please enter a valid prefab path.");
            return;
        }

        string prefabName = prefabObject.name;
        string scriptContent = "using UnityEngine;\n\npublic class " + prefabName + " : MonoBehaviour\n{\n\n}";

        string scriptPath = Application.dataPath + uiScriptPath + "/" + prefabName + ".cs";
        System.IO.File.WriteAllText(scriptPath, scriptContent);

        AssetDatabase.Refresh();

        Debug.Log("Prefab script generated successfully at: " + scriptPath);
    }
}