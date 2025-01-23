using UnityEngine;

public class Object : MonoBehaviour
{

    private LayerMask boundaryLayer;
    private ObjectMovementType objectMovementType;

    private void Awake()
    {
        boundaryLayer = LayerMask.GetMask("Boundary");
    }
    public void InitializeObject()
    {
        gameObject.SetActive(true);
    }


    private void OnTriggerStay(Collider other)
    {
        if ((boundaryLayer & 1 << other.gameObject.layer) > 0)
        {
            UpdatePositionToAvoidOverlap(Axis.X, 0.1f, objectMovementType);
        }
    }

    private void UpdatePositionToAvoidOverlap(Axis axis, float distance, ObjectMovementType objectMovementType)
    {
        if (objectMovementType == ObjectMovementType.MoveLeft)
        {
            distance = -distance;
        }
        switch (axis)
        {
            case Axis.X:
                transform.position = new Vector3(transform.position.x + distance, transform.position.y, transform.position.z);
                break;
            case Axis.Y:
                transform.position = new Vector3(transform.position.x, transform.position.y + distance, transform.position.z);
                break;
            case Axis.Z:
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + distance);
                break;
        }
    }
}
