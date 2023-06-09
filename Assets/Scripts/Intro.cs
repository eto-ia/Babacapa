using UnityEngine;
using UnityEngine.UI;

public class Intro : MonoBehaviour
{
    public SceneLoader scene;
    public Animator[] anims = new Animator[4];
    public Image[] images = new Image[5];
    public GameObject canvas;
    public AudioSource voice;
    private float cmus;
    public AudioSource bgmusic;
    void Awake()
    {
        canvas.SetActive(false);
    }
    public void startIntro()
    {
        cmus = Music.volume;
        Music.volume *= 0.1f;
        canvas.SetActive(true);
        images[4].enabled = true;
        animToBlack1();
        Invoke ("animOutBlack", 1.5f);
        Invoke ("Talk", 1.75f);
        Invoke ("anim1", 6.5f);
        Invoke ("anim2", 11.5f);
        Invoke ("anim3", 24.5f);
        Invoke ("animToBlack2", 32.5f);
        Invoke ("LoadScene", 34.5f);
    }
    private void anim1()
    {
        anims[0].Play("To01");
    }
    private void anim2()
    {
        anims[1].Play("To02");
    }
    private void anim3()
    {
        anims[2].Play("To03");
    }
    private void animToBlack1()
    {
        anims[3].Play("ToBlack");
    }
    private void animToBlack2()
    {
        anims[3].Play("ToBlack");
        Music.volume = cmus;
    }
    private void animOutBlack()
    {
        anims[3].Play("OutBlack");
        images[0].enabled = true;
        images[1].enabled = true;
        images[2].enabled = true;
        images[3].enabled = true;
    }
    private void Talk()
    {
        voice.Play();
    }
    private void LoadScene()
    {
        Music.volume = cmus;
        bgmusic.Stop();
        scene.SceneLoad(1);
    }
}
