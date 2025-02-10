using UnityEditor;
using UnityEngine;
[CustomEditor(typeof(ObjectsPerFiveLevels))]
public class CustomeObjPer5Lv : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        GUILayout.Space(10);

        ObjectsPerFiveLevels objPer5LV = (ObjectsPerFiveLevels)target;

        if (GUILayout.Button("Setup"))
        {
            objPer5LV.SetHealthForLevel();
            objPer5LV.SetHealthForObject();
            objPer5LV.CalculateObjectCountForLevel4And5();
            objPer5LV.ShowHealthOfLv5();
            EditorUtility.SetDirty(objPer5LV);
        }
    }
}
