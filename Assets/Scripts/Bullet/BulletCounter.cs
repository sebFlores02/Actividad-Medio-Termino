using TMPro;
using UnityEngine;

public class BulletCounter : MonoBehaviour
{
    public TextMeshProUGUI timeText;

    public static BulletCounter instance;

    public int bulletCounter = 0;

    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        timeText.text = "Número de Balas: " + bulletCounter.ToString();
    }
}
