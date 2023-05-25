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
    private Slider slidersfx;
    // Start is called before the first frame update
    void Start()
    {
        slidersfx = GameObject.Find("SliderSFX").GetComponent<Slider>();
        FirstPersonAudio.volume = slidersfx.value;
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
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
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
            if (isnotPaused)
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
        FirstPersonAudio.volume = slidersfx.value;
    }
}
