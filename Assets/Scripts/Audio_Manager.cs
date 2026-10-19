using UnityEngine;
using UnityEngine.SceneManagement;

public class Audio_Manager : MonoBehaviour
{
    public static Audio_Manager instance;
    public AudioSource bgm;
    private const string MuteKey = "MusicMuted";
    public bool isMuted = false;
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);

        SceneManager.sceneLoaded += OnSceneLoaded;

        bgm = GetComponent<AudioSource>();
        bgm.loop = true;                
    }
    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        bool shouldPlaying = scene.name == "MainMenu" || scene.name == "LevelSelection";

        if (shouldPlaying)
        {
            if (bgm.clip != null && !bgm.isPlaying)
            {
                bgm.Play();
            }
        }
        else {
            bgm.Stop();
        }
    }

    public void ToggleMute()
    {
        isMuted = !isMuted;
        PlayerPrefs.SetInt(
        "MusicMuted",
        bgm.mute ? 1 : 0);
    }

    public bool IsMuted()
    {
        return isMuted;
    }
}