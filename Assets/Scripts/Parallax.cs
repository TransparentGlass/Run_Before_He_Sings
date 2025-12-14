using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float length, startpos;
    public GameObject cam;
    public float parallaxEffect;

    void Start()
    {
        // Store the starting X position of this GameObject
        startpos = transform.position.x;
        // Get the width of the sprite attached to this GameObject
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update()
    {
        // Calculate temporary offset based on camera movement for looping
        float temp = (cam.transform.position.x * (1 - parallaxEffect));
        // Calculate the distance the background should move based on parallax effect
        float dist = (cam.transform.position.x * parallaxEffect);

        // Update the position of the background along X-axis
        transform.position = new Vector3(startpos + dist, transform.position.y, transform.position.z);

        // Check if the camera has moved past the sprite's width to loop the background
        if (temp > startpos + length) startpos += length;
        else if (temp < startpos - length) startpos -= length;
    }
}