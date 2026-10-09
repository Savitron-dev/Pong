using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_Manager : MonoBehaviour
{
    public AudioSource click;
    public AudioSource BGM;
    public GameObject Music_ON;
    public GameObject Music_OFF;
    public GameObject BGM_ON;
    public GameObject BGM_OFF;
    public void SinglePlayerLoad() 
    {
        click.Play();
        SceneManager.LoadScene("LevelSelection");
    }
    public void MultiPlayerLoad() 
    {
        click.Play();
        SceneManager.LoadScene("MultiPlayer");
    }
    public void MusicOFF() 
    {
        click.Play();
        Audio_Manager.instance.isMuted = true;
        click.mute = Audio_Manager.instance.isMuted;
        Music_ON.SetActive(true);
        Music_OFF.SetActive(false);
    }
    public void MusicON() 
    {
        click.Play();
        Audio_Manager.instance.isMuted = false;
        click.mute = Audio_Manager.instance.isMuted;
        click.mute = false;
        Music_ON.SetActive(false);
        Music_OFF.SetActive(true);
    }
    public void BGMOFF() 
    {
        click.Play();
        BGM.mute = true;
        BGM_ON.SetActive(true);
        BGM_OFF.SetActive(false);
    }
    public void BGMON() 
    {
        click.Play();
        BGM.mute = false;
        BGM_OFF.SetActive(true);
        BGM_ON.SetActive(false);
        Debug.Log("Game ON!!!");
    }

    public void Quit() 
    {
        click.Play();
        Application.Quit();
    }
}
