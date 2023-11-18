using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject bulletPrefab;
    private float timeSpan = 7f;

    private float patternTimer = 0f;
    private int currentPattern = 0;

    private float lastShotTime = 0f;
    private float angleIncrement = 6f;

    private float currentAngle1 = 0f;
    private float angleIncrement_patter3 = 10f;

    void Update()
    {
        patternTimer += Time.deltaTime;

        if (patternTimer >= 10f)
        {
            patternTimer = 0f;
            currentPattern = (currentPattern + 1) % 3;
        }

        switch (currentPattern)
        {
            case 0:
                Pattern1(5, 5, 0.7f);
                break;
            case 1:
                Pattern2(4, 3, 4, 0.7f);
                break;
            case 2:
                Pattern3(20, 4, 1);
                break;
        }
    }

    void Pattern1(int streams, int speed, float shotInterval)
    {
        if (Time.time - lastShotTime >= shotInterval)
        {
            lastShotTime = Time.time;

            for (int i = 0; i < streams; i++)
            {
                float angle = currentAngle1 + i * (360f / streams);
                GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);


                Vector3 bulletDirection = new Vector3(Mathf.Cos(angle * Mathf.Deg2Rad), 0, Mathf.Sin(angle * Mathf.Deg2Rad));
                bullet.GetComponent<BulletMovement>().direction = bulletDirection.normalized * speed;

                BulletCounter.instance.bulletCounter++;
                DestroyBullet(bullet);
            }

            for (int i = 0; i < streams; i++)
            {
                float angle = -currentAngle1 + i * (360f / streams);
                GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);


                Vector3 bulletDirection = new Vector3(Mathf.Cos(angle * Mathf.Deg2Rad), 0, Mathf.Sin(angle * Mathf.Deg2Rad));
                bullet.GetComponent<BulletMovement>().direction = bulletDirection.normalized * speed;

                BulletCounter.instance.bulletCounter++;
                DestroyBullet(bullet);
            }

            currentAngle1 += angleIncrement;
        }
    }

    void Pattern2(int streams, int batches, float speed, float shotInterval)
    {
        if (Time.time - lastShotTime >= shotInterval)
        {
            lastShotTime = Time.time;

            for (int i = 0; i < streams; i++)
            {
                for (int j = 0; j < batches; j++)
                {
                    // Calculate the angle for each bullet in a stream
                    float angle = currentAngle1 + i * (360f / streams) + j * angleIncrement_patter3;

                    GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

                    Vector3 bulletDirection = new Vector3(Mathf.Cos(angle * Mathf.Deg2Rad), 0, Mathf.Sin(angle * Mathf.Deg2Rad));
                    bullet.GetComponent<BulletMovement>().direction = bulletDirection.normalized * speed;

                    BulletCounter.instance.bulletCounter++;
                    DestroyBullet(bullet);
                }
            }

            // Increment the base angle for the next shot
            currentAngle1 += angleIncrement_patter3;
        }
    }

    void Pattern3(int streams, int speed, float shotInterval)
    {
        if (Time.time - lastShotTime >= shotInterval)
        {
            lastShotTime = Time.time;

            for (int i = 0; i < streams; i++)
            {
                float angle = currentAngle1 + i * (360f / streams);
                GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

                Vector3 bulletDirection = new Vector3(Mathf.Cos(angle * Mathf.Deg2Rad), 0, Mathf.Sin(angle * Mathf.Deg2Rad));
                bullet.GetComponent<BulletMovement>().direction = bulletDirection.normalized * speed;

                BulletCounter.instance.bulletCounter++;
                DestroyBullet(bullet);
            }

            currentAngle1 += angleIncrement;
        }
    }

    void DestroyBullet(GameObject bullet)
    {
        Destroy(bullet, timeSpan);
    }
}
