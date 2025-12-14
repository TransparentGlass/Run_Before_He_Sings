
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using Unity;


public class ObstacleSpawner : MonoBehaviour
{

    public Obstacle[] obstacles;
    float minDelay = 1.5f;
    float maxDelay = 3f;
    float Obstacle_timer;
    float nextSpawn;
    public static float game_timer { get; private set; }

    float height;
    float width;
    float right;
    float bottom_map;
    void Awake()
    {
        game_timer = 0f;
    }


    void Start()
    {
        Camera cam = Camera.main;
        Vector3 camPos = cam.transform.position;

        height = cam.orthographicSize * 2;
        width = height * cam.aspect;
        right = camPos.x + width / 2;
        bottom_map = (float)-2.561;

        nextSpawn = Random.Range(minDelay, maxDelay);

    }

    public Obstacle GetRandomObstacle()
    {
        int index = Random.Range(0, obstacles.Length);
        return obstacles[index];
    }

    void Update()
    {

        Obstacle_timer += Time.deltaTime;
        game_timer += Time.deltaTime;


        if (Obstacle_timer >= nextSpawn)
        {
            Obstacle_timer = 0f;
            nextSpawn = Random.Range(minDelay, maxDelay);
            Spawn();
        }
    }

    void Spawn()
    {
        Obstacle obs = GetRandomObstacle();
        GameObject go = new(obs.name);
        SpriteRenderer sr = go.AddComponent<SpriteRenderer>();
        sr.sprite = obs.sprite;
        sr.sortingOrder = 10;




        go.transform.position = new Vector3(
            right + 5f,     // X
            bottom_map, // Y
            0f              // Z
        );

        go.AddComponent<ObstacleMover>();
    }



}
