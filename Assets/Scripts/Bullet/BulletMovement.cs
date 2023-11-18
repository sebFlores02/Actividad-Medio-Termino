using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public Vector3 direction;
    public float speed = 4f;

    /// <summary>
    /// This method is called once per frame
    /// </summary>
    void Update()
    {
        MoveInDirection();
    }

    /// <summary>
    /// This method sets the direction and speed of the bullet.
    /// </summary>
    public void SetDirection(Vector3 direction, float speed)
    {
        this.speed = speed;
        this.direction = direction.normalized;
    }

    /// <summary>
    /// This method moves the bullet in the specified direction.
    /// </summary>
    void MoveInDirection()
    {
        transform.Translate(direction * speed * Time.deltaTime, Space.World);
    }

    /// <summary>
    /// This method is responsible for the destruction of the bullet after a certain time span
    /// </summary>
    void OnDestroy()
    {
        if (BulletCounter.instance != null)
        {
            BulletCounter.instance.bulletCounter--;
        }
    }
}
