using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_Manager : MonoBehaviour
{
    public AudioSource click;
    public Audio_Manager audio;
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
        Audio_Manager.instance.isMuted = true;
        Audio_Manager.instance.bgm.mute = true;
        PlayerPrefs.SetInt("MusicMuted", 1);
        BGM_ON.SetActive(true);
        BGM_OFF.SetActive(false);
    }
    public void BGMON() 
    {
        click.Play();
        Audio_Manager.instance.isMuted = false;
        Audio_Manager.instance.bgm.mute = false;
        PlayerPrefs.SetInt("MusicMuted", 0);
        BGM_OFF.SetActive(true);
        BGM_ON.SetActive(false);
    }

    public void Quit() 
    {
        click.Play();
        Application.Quit();
    }
}
