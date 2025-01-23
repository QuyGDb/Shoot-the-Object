using UnityEngine;

public class Object : MonoBehaviour
{

    private LayerMask boundaryLayer;
    private string boundaryTopTag = "BoundaryTop";
    private string boundaryBottomTag = "BoundaryBottom";
    private string boundaryLeftTag = "BoundaryLeft";
    private string boundaryRightTag = "BoundaryRight";
    [SerializeField] float distanceToAvoidOverlap = 0.1f;
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
            if (other.CompareTag(boundaryTopTag))
            {
                UpdatePositionToAvoidOverlap(distanceToAvoidOverlap, BoundaryType.Top);
            }
            else if (other.CompareTag(boundaryBottomTag))
            {
                UpdatePositionToAvoidOverlap(distanceToAvoidOverlap, BoundaryType.Bottom);
            }
            else if (other.CompareTag(boundaryLeftTag))
            {
                UpdatePositionToAvoidOverlap(distanceToAvoidOverlap, BoundaryType.Left);
            }
            else if (other.CompareTag(boundaryRightTag))
            {
                UpdatePositionToAvoidOverlap(distanceToAvoidOverlap, BoundaryType.Right);
            }
        }
    }

    private void UpdatePositionToAvoidOverlap(float distance, BoundaryType boundaryType)
    {
        Vector3 newPosition = transform.position;
        switch (boundaryType)
        {
            case BoundaryType.Top:
                newPosition.y -= distance;
                break;
            case BoundaryType.Bottom:
                newPosition.y += distance;
                break;
            case BoundaryType.Left:
                newPosition.x += distance;
                break;
            case BoundaryType.Right:
                newPosition.x -= distance;
                break;
        }
        transform.position = newPosition;

    }
}
