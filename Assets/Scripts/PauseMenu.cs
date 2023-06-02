using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{

    private GameObject pauseMenu;
    private GameObject Volume;
    private GameObject Camera;
    private GameObject inventory;
    private GameObject settings;
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
        FirstPersonAudio.volume = sfx.value;
        Cursor.visible = false;
        pauseMenu = GameObject.Find("Pause");
        pauseMenu.SetActive(false);
        Volume = GameObject.Find("First Person Audio");
        Camera = GameObject.Find("First Person Camera");
        inventory = GameObject.Find("Inventory");
        inventory.SetActive(false);
        settings = GameObject.Find("Settings");
        settings.SetActive(false);
    }
    void Update()
    {
<<<<<<< Updated upstream
        if (Input.GetKeyDown(KeyCode.Escape))
=======
        if (Input.GetKeyDown(KeyCode.Escape) && !settings.activeSelf)
>>>>>>> Stashed changes
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
            if (!pauseMenu.activeSelf && !settings.activeSelf)
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
            Debug.Log(isRestarted);
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
    }
    public void sensChanged ()
    {
        FirstPersonLook.sensitivity = sens.value;
    }
}
