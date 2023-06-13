using UnityEngine;

public class Intro : MonoBehaviour
{
    public Animator[] anims = new Animator[4];
    public GameObject[] _images = new GameObject[5];
    public GameObject _canvas;
    public AudioSource dialog;
    private float cmus;
    public AudioSource bgmusic;
    public StartScript _startScript;
    public GameObject _menu;
    public void IntroBeg()
    {
        dialog.clip = Resources.Load<AudioClip>("Dialogs/Introduction");
        Cursor.visible = false;
        bgmusic.volume *= 0.1f;
        _canvas.SetActive(true);
        animToBlack1();
        Invoke ("animOutBlack", 1.5f);
        Invoke ("Talk", 1.75f);
        Invoke ("anim1", 6.5f);
        Invoke ("anim2", 11.5f);
        Invoke ("anim3", 24.5f);
        Invoke ("animToBlack2", 32.5f);
        Invoke ("toCut", 34.5f);
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
    }
    private void animOutBlack()
    {
        _images[0].SetActive(true);
        _images[1].SetActive(true);
        _images[2].SetActive(true);
        _images[3].SetActive(true);
        anims[3].Play("OutBlack");
    }
    private void Talk()
    {
        dialog.Play();

    }
    private void toCut()
    {
        bgmusic.volume *= 10;
        bgmusic.Stop();
        _startScript.CutBeg();
        _images[0].SetActive(false);
        _images[1].SetActive(false);
        _images[2].SetActive(false);
        _images[3].SetActive(false);
        _menu.SetActive(false);
    }
}
