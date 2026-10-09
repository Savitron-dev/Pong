using UnityEngine;
using UnityEngine.SceneManagement;

public class Button_Manager : MonoBehaviour
{
    public AudioSource click; //For Audio Clip "Click"
    public Score_Manager score;
    public GameObject pause;
    public GameObject countinue_;
    public GameObject restart;
    public GameObject cts;
    public GameObject bg;
    public TrailRenderer ballTrail; //Calls the Ball Trail
    private void Start()
    {
        click.mute = Audio_Manager.instance.isMuted;
    }

    public void Quit() //For Quit Button
    {
        click.Play();
        Time.timeScale = 1f;
        Application.Quit();
    }
    public void MenuLoad() //For Home Button
    {
        click.Play();
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
    public void Pause() //For Pause Button
    {
        click.Play();
        //Clear the Ball Trail
        ballTrail.Clear();
        Time.timeScale = 0f;
        pause.SetActive(false);
        countinue_.SetActive(true);
        restart.SetActive(true);
        bg.SetActive(true);
    }
    public void Continue() //For Continue Button
    {
        click.Play();
        
        Time.timeScale = 1f;
        pause.SetActive(true);
        countinue_.SetActive(false);
        restart.SetActive(false);
        bg.SetActive(false);
    }
    public void Restart() //For Restart Button
    {
        click.Play();
        Time.timeScale = 0f;
        cts.SetActive(true);
        score.Restart();
        countinue_.SetActive(false);
    }
}
