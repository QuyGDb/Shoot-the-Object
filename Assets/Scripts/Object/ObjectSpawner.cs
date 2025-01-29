using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;

public class ObjectSpawner : MonoBehaviour
{
    public List<GameObject> objects;

    [SerializeField] private Transform leftTopTransform;
    [SerializeField] private Transform leftBottomTransform;

    [SerializeField] private Transform rightBottomTransform;
    [SerializeField] private Transform rightTopTransform;
    [SerializeField] private int numberOfObjects;
    [SerializeField] private float levelDuration;
    private void Start()
    {
        SpawnObjects(1);
    }

    private Vector3 GetSpawnObjectPosition(ObjectMovementType objectMovementType)
    {
        switch (objectMovementType)
        {
            case ObjectMovementType.HorizontalLeftToRight:
                return new Vector3(leftBottomTransform.position.x, UnityEngine.Random.Range(leftBottomTransform.position.y, leftTopTransform.position.y), 0);
            case ObjectMovementType.HorizontalRightToLeft:
                return new Vector3(rightBottomTransform.position.x, UnityEngine.Random.Range(rightBottomTransform.position.y, rightTopTransform.position.y), 0);
            case ObjectMovementType.DiagonalLeftTopToRightBottom:
                return new Vector3(leftTopTransform.position.x, leftTopTransform.position.y, 0);
            case ObjectMovementType.DiagonalRightBottomToLeftTop:
                return new Vector3(rightBottomTransform.position.x, rightBottomTransform.position.y, 0);
            case ObjectMovementType.DiagonalLeftBottomToRightTop:
                return new Vector3(leftBottomTransform.position.x, leftBottomTransform.position.y, 0);
            case ObjectMovementType.DiagonalRightTopToLeftBottom:
                return new Vector3(rightTopTransform.position.x, rightTopTransform.position.y, 0);
            default:
                throw new ArgumentOutOfRangeException();

        }
    }


    private void SpawnObjects(int level)
    {
        if (level % 10 == 1)
        {

        }

    }

    private void SetHealthForObject(int level)
    {

    }
}
