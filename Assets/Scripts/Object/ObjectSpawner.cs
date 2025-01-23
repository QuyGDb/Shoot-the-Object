using System;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public List<GameObject> objects;

    [SerializeField] private Transform leftTopTransform;
    [SerializeField] private Transform leftBottomTransform;

    [SerializeField] private Transform rightBottomTransform;
    [SerializeField] private Transform rightTopTransform;

    private void Start()
    {
        SpawnObjects(1);
    }

    private Vector3 GetSpawnObjectPositon()
    {
        float x = UnityEngine.Random.Range(leftTopTransform.position.x, rightTopTransform.position.x);
        float y = UnityEngine.Random.Range(leftBottomTransform.position.y, leftTopTransform.position.y);
        return new Vector3(x, y, leftBottomTransform.position.z);
    }
    private void SpawnObjects(int level)
    {
        PoolManager.Instance.ReuseComponent(objects[0], leftTopTransform.position, Quaternion.identity);
    }
}
