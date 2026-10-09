using UnityEngine;
using UnityEngine.SceneManagement;

public class Mobile_BackButton : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            string sceneName = SceneManager.GetActiveScene().name;
            if (sceneName == "SinglePlayer" || sceneName == "MultiPlayer")
            {
                Time.timeScale = 1f;
                SceneManager.LoadScene("MainMenu");
            }
        }
    }
}
