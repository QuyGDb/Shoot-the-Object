using UnityEngine;

[CreateAssetMenu(fileName = "ObjectsPerFiveLevels", menuName = "Scriptable Objects/ObjectsPerFiveLevels", order = 1)]
public class ObjectsPerFiveLevels : ScriptableObject
{
    public GameObject[] objects = new GameObject[3];

}
