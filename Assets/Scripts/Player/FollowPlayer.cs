using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset = new Vector3(0f, 162, 22f);


    void LateUpdate()
    {
        transform.position = player.transform.position + offset;

    }
}
