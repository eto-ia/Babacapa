using UnityEngine;

public class Music : MonoBehaviour
{
    public AudioSource musicSource;
    public static float volume = 1f;
    void Start()
    {
        musicSource.Play();
    }
    void Update() 
    {
        musicSource.volume = volume;
    }
}
