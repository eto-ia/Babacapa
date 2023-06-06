using UnityEngine;

public class DoorSound : MonoBehaviour
{
    public AudioSource audioOpen;
    public AudioSource audioClose;
    public static float volume;
    public void Open() 
    {
        audioOpen.volume = volume;
        audioOpen.Play();
    }
    public void Close()
    {
        audioClose.volume = volume;
        audioClose.Play();
    }
}
