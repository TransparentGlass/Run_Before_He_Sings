
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using Unity;


public class ObstacleSpawner : MonoBehaviour
{

    public GameObject[] obstaclePrefabs;
    float minDelay = 1.5f;
    float maxDelay = 3f;
    float Obstacle_timer;
    float nextSpawn;
    public static float game_timer { get; private set; }

    float height;
    float width;
    float right;
    float bottom_map;

    [SerializeField] public static float speed = 5f;
    [SerializeField] public static float acceleration = 1.2f;
    void Awake()
    {
        game_timer = 0f;
    }


    void Start()
    {


        nextSpawn = Random.Range(minDelay, maxDelay);

    }

    public GameObject GetRandomObstacle()
    {
        int index = Random.Range(0, obstaclePrefabs.Length);
        return obstaclePrefabs[index];
    }

    void Update()
    {
        Camera cam = Camera.main;
        Vector3 camPos = cam.transform.position;

        height = cam.orthographicSize * 2;
        width = height * cam.aspect;
        right = camPos.x + width / 2;
        bottom_map = (float)-2.561;

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
        GameObject prefab = GetRandomObstacle();

        GameObject go = Instantiate(prefab);

        go.transform.position = new Vector3(
            right + 5f,
            bottom_map,
            0f
        );
    }



}
