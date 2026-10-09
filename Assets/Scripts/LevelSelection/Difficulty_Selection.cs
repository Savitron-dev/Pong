using UnityEngine;
using UnityEngine.SceneManagement;

public class Difficulty_Selection : MonoBehaviour
{
    public AudioSource click;
    public void SelectEasy()
    {
        PlayerPrefs.SetInt("Difficulty", 0);
        SceneManager.LoadScene("SinglePlayer");
    }

    public void SelectMedium()
    {
        PlayerPrefs.SetInt("Difficulty", 1);
        SceneManager.LoadScene("SinglePlayer");
    }

    public void SelectHard()
    {
        PlayerPrefs.SetInt("Difficulty", 2);
        SceneManager.LoadScene("SinglePlayer");
    }
    public void Home() 
    {
        click.Play();
        click.mute = Audio_Manager.instance.isMuted;
        SceneManager.LoadScene("MainMenu");
    }
}
