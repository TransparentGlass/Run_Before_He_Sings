using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public PlayerControl player;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * player.speed * Time.deltaTime);
    }
}
