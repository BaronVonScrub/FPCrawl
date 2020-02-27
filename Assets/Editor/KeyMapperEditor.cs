using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(KeyMapper))]
public class LookAtPointEditor : Editor
{
    SerializedProperty mappingList;

    void OnEnable()
    {
        mappingList = serializedObject.FindProperty("mappingList");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        EditorGUILayout.PropertyField(mappingList);
        serializedObject.ApplyModifiedProperties();
    }
}

//I have no clue what I'm doing here.