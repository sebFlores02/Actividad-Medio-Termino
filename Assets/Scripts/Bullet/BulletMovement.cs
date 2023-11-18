using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public Vector3 direction;
    public float speed = 4f;

    void Update()
    {
        MoveInDirection();
    }

    public void SetDirection(Vector3 direction, float speed)
    {
        this.speed = speed;
        this.direction = direction.normalized;
    }

    void MoveInDirection()
    {
        transform.Translate(direction * speed * Time.deltaTime, Space.World);
    }

    void OnDestroy()
    {
        if (BulletCounter.instance != null)
        {
            BulletCounter.instance.bulletCounter--;
        }
    }
}
