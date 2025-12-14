using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float smoothSpeed = 0.1f;
    [SerializeField] private Vector3 offset;

    void LateUpdate()
    {
        Vector3 desiredPos = new Vector3(
            target.position.x + offset.x,
            transform.position.y,
            transform.position.z
        );

        transform.position = Vector3.Lerp(
            transform.position,
            desiredPos,
            smoothSpeed
        );
    }
}
