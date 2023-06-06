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
    private bool isnotPaused = true;
    private bool isInventory = true;
    public static bool isRestarted = false;
    private bool isSetting = false;
    public Slider sfx;
    public Slider music;
    public Slider sens;
    private string values;
    
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
        if (Input.GetKeyDown(KeyCode.Escape) && !settings.activeSelf && !warning.activeSelf)
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
            FirstPersonLook cam = Camera.GetComponent<FirstPersonLook>();
            cam.Stopcam(!isnotPaused);
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (!pauseMenu.activeSelf && !settings.activeSelf && !warning.activeSelf)
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
                FirstPersonLook cam = Camera.GetComponent<FirstPersonLook>();
                cam.Stopcam(!isInventory);
            }
        }
        if (isRestarted)
        {
            Time.timeScale = 1f;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.None;
            FirstPersonAudio volume = Volume.GetComponent<FirstPersonAudio>();
            if (volume != null)
            {
                volume.SetPlayingMovingAudio (null, false);
            }
            FirstPersonLook cam = Camera.GetComponent<FirstPersonLook>();
            cam.Stopcam(false);
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
    }
    public void SFXChanged()
    {
        FirstPersonAudio.volume = sfx.value;
        DoorSound.volume = sfx.value;
        LightSwitch.volume = sfx.value;
    }
    public void musicChanged()
    {

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
