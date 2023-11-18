using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public KeyCode enterKey;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            LoadGameScene();
        }
    }

    public void LoadGameScene()
    {
        SceneManager.LoadScene("Main");

        if (Input.GetKey(enterKey))
        {
            SceneManager.LoadScene("Main");
        }
    }
}
