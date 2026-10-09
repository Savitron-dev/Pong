using UnityEngine;
using UnityEngine.SceneManagement;

public class Mobile_BackButton : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            string sceneName = SceneManager.GetActiveScene().name;
            if (sceneName == "LevelSelection" || sceneName == "MultiPlayer")
            {
                Time.timeScale = 1f;
                SceneManager.LoadScene("MainMenu");
            }
            if (sceneName == "SinglePlayer") 
            {
                Time.timeScale = 1f;
                SceneManager.LoadScene("LevelSelection");
            }
        }
    }
}
