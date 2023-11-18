using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset = new Vector3(0f, 162, 22f);

    /// <summary>
    /// LateUpdate is called every frame, after all Update functions have been called.
    /// </summary>
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;

    }
}
