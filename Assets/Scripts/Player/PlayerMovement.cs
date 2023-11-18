using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This player controller class will update the events from the vehicle player.
/// Standar coding documentarion can be found in 
/// https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/language-specification/documentation-comments
/// </summary>
public class PlayerController : MonoBehaviour
{
    public float speed = 25.0f;
    public float turnSpeed = 120.0f;
    public float horizontalInput;
    public float forwardInput;
    private float reducedSpeed = 0.4f;
    public KeyCode speedKey;

    // Create bullets
    public GameObject bulletPrefab;
    private float timeSpan = 7f;
    private int bulletSpeed = 50;

    // Blasters
    public Transform leftBlaster;
    public Transform rightBlaster;

    // Camara Variables 
    public Camera mainCamera;
    public Camera hoodCamera;

    /// <summary>
    /// This method is called once per frame
    /// </summary>
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        if (Input.GetKey(speedKey))
        {
            transform.Translate((-Vector3.back * Time.deltaTime * speed * forwardInput) * reducedSpeed);
        }
        else
        {
            transform.Translate(-Vector3.back * Time.deltaTime * speed * forwardInput);
        }

        transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);

        // Reduce Player Speed
        if (Input.GetKey(KeyCode.Space))
        {
            SpawnBullet(leftBlaster, bulletSpeed);
            SpawnBullet(rightBlaster, bulletSpeed);
        }

        // Switch Cameras
        if (Input.GetKeyDown(KeyCode.Q))
        {
            mainCamera.enabled = !mainCamera.enabled;
            hoodCamera.enabled = !hoodCamera.enabled;
        }
    }

    /// <summary>
    /// Spawns a bullet from a specific blaster position with a given speed.
    /// </summary>
    void SpawnBullet(Transform blasterTransform, int bulletSpeed)
    {

        GameObject bullet = Instantiate(bulletPrefab, blasterTransform.position, blasterTransform.rotation);
        bullet.GetComponent<BulletMovement>().SetDirection(blasterTransform.forward, bulletSpeed);

        BulletCounter.instance.bulletCounter++;

        StartCoroutine(DestroyBullet(bullet));
    }

    IEnumerator DestroyBullet(GameObject bullet)
    {
        yield return new WaitForSeconds(timeSpan);
        Destroy(bullet);
    }

}