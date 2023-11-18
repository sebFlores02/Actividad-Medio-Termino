using TMPro;
using UnityEngine;

public class BulletCounter : MonoBehaviour
{
    public TextMeshProUGUI timeText;

    public static BulletCounter instance;

    public int bulletCounter = 0;

    /// <summary>
    /// This player controller class will update the events from the vehicle player.
    /// </summary>
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

    /// <summary>
    /// This method is called once per frame
    /// </summary>
    void Update()
    {
        timeText.text = "Número de Balas: " + bulletCounter.ToString();
    }
}
