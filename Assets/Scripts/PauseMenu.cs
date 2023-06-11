using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{

    public GameObject pauseMenu;
    public GameObject Volume;
    public GameObject Camera;
    public GameObject inventory;
    public GameObject settings;
    public GameObject warning;
    public GameObject notes;
    private bool isnotPaused = true;
    private bool isInventory = true;
    public static bool isRestarted = false;
    private bool isSetting = false;
    public Slider sfx;
    public Slider music;
    public Slider sens;
    private string values;
    public AudioSource Music;
    public static bool cut = false;
    public AudioSource SFX;
    public AudioSource Dialog;
    
    void Start()
    {
        using (StreamReader reader = new StreamReader("Assets/Resources/SliderValue.txt", false))
        {
            values = reader.ReadLine();
        }
        music.value = float.Parse(values.Split(" ")[0]);
        sfx.value = float.Parse(values.Split(" ")[1]);
        sens.value = float.Parse(values.Split(" ")[2]);
        musicChanged(); SFXChanged(); sensChanged();
        FirstPersonAudio.volume = sfx.value;
        Cursor.visible = false;
        pauseMenu.SetActive(false);
        inventory.SetActive(false);
        settings.SetActive(false);
        warning.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !settings.activeSelf && !warning.activeSelf && !notes.activeSelf && !cut)
        {
            inventory.SetActive(false);
            isnotPaused = pauseMenu.activeSelf;
            Time.timeScale = isnotPaused ? 1f : 0f;
            pauseMenu.SetActive(!isnotPaused);
            Cursor.visible = !isnotPaused;
            Cursor.lockState = isnotPaused ? CursorLockMode.Confined : CursorLockMode.None;
            FirstPersonAudio volume = Volume.GetComponent<FirstPersonAudio>();
            if (volume != null)
            {
                volume.SetPlayingMovingAudio (null, true);
            }
            if (Music.isPlaying)
            {
                Music.Pause();
            }
            else
            {
                Music.Play();
            }
            FirstPersonLook cam = Camera.GetComponent<FirstPersonLook>();
            cam.Stopcam(!isnotPaused);
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (!pauseMenu.activeSelf && !settings.activeSelf && !warning.activeSelf && !notes.activeSelf && !cut)
            {
                isInventory = inventory.activeSelf;
                Time.timeScale = isInventory ? 1f : 0f;
                inventory.SetActive(!isInventory);
                Cursor.visible = !isInventory;
                Cursor.lockState = isInventory ? CursorLockMode.Confined : CursorLockMode.None;
                FirstPersonAudio volume = Volume.GetComponent<FirstPersonAudio>();
                if (volume != null)
                {
                    volume.SetPlayingMovingAudio (null, true);
                }
                Camera.GetComponent<FirstPersonLook>().Stopcam(!isInventory);
            }
        }
        if (isRestarted)
        {
            if (Time.timeScale == 0f)
            {
                Time.timeScale = 1f;
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Confined;
                FirstPersonAudio volume = Volume.GetComponent<FirstPersonAudio>();
                if (volume != null)
                {
                    volume.SetPlayingMovingAudio (null, false);
                }
            }            
            isRestarted = false;
        }
    }
    public void Resuming()
    {
        isnotPaused = pauseMenu.activeSelf;
        Time.timeScale = 1f;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.None;
        pauseMenu.SetActive(!isnotPaused);
        FirstPersonLook cam = Camera.GetComponent<FirstPersonLook>();
        cam.Stopcam(false); 
    }
    public void Options()
    {
        isSetting = !isSetting;
        settings.SetActive(isSetting);
        pauseMenu.SetActive(!isSetting);
        using (StreamWriter writer = new StreamWriter("Assets/Resources/SliderValue.txt", false))
        {
            values = music.value.ToString() + " " + sfx.value.ToString() + " " + sens.value.ToString();
            writer.WriteLine(values);
        }
    }
    public void SFXChanged()
    {
        FirstPersonAudio.volume = sfx.value;
        DoorSound.volume = sfx.value;
        LightSwitch.volume = sfx.value;
        SFX.volume = sfx.value;
        Dialog.volume = sfx.value;
    }
    public void musicChanged()
    {
        Music.volume = music.value;
    }
    public void sensChanged ()
    {
        FirstPersonLook.sensitivity = sens.value;
    }
    public void Warn()
    {
        warning.SetActive(!warning.activeSelf);
        pauseMenu.SetActive(!warning.activeSelf);
    }
}
