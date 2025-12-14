using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] private Transform cam;
    [Range(0f, 1f)]
    [SerializeField] public float parallaxEffect;

    private float length;
    private float lastCamX;

    void Start()
    {
        length = GetComponent<SpriteRenderer>().bounds.size.x;
        lastCamX = cam.position.x;
    }

    void LateUpdate() // IMPORTANT
    {
        float deltaX = cam.position.x - lastCamX;

        transform.position += new Vector3(deltaX * parallaxEffect, 0f, 0f);

        lastCamX = cam.position.x;

        // Looping
        if (Mathf.Abs(cam.position.x - transform.position.x) >= length)
        {
            float offset = (cam.position.x - transform.position.x) > 0 ? length : -length;
            transform.position += new Vector3(offset, 0f, 0f);
        }
    }
}
