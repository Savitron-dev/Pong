using UnityEngine;
using UnityEngine.SceneManagement;

public class Home : MonoBehaviour
{
    public AudioSource click; //For Audio Clip "Click"
    private void Start()
    {
        click.mute = Audio_Manager.instance.isMuted;
    }
    public void MenuLoad() //For Home Button
    {
        click.Play();
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}
