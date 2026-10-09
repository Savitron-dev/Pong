using UnityEngine;

public class Audio_Manager : MonoBehaviour
{
    public static Audio_Manager instance;
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
    }

    public void ToggleMute()
    {
        isMuted = !isMuted;
    }

    public bool IsMuted()
    {
        return isMuted;
    }
}