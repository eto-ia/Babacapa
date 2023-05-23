using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{

    public GameObject pauseMenu;
    public GameObject Volume;
    public GameObject Camera;
    public GameObject inventory;
    private bool isPaused = true;
    private bool isInventory = true;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        pauseMenu = GameObject.Find("Pause");
        pauseMenu.SetActive(false);
        Volume = GameObject.Find("First Person Audio");
        Camera = GameObject.Find("First Person Camera");
        inventory=GameObject.Find("Inventory");
        inventory.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            inventory.SetActive(false);
            isPaused = pauseMenu.activeSelf;
            Time.timeScale = isPaused ? 1f : 0f;
            pauseMenu.SetActive(!isPaused);
            Cursor.visible = !isPaused;
            Cursor.lockState = isPaused ? CursorLockMode.Confined : CursorLockMode.None;
            FirstPersonAudio volume = Volume.GetComponent<FirstPersonAudio>();
            if (volume != null)
            {
                volume.SetPlayingMovingAudio (null, true);
            }
            FirstPersonLook cam = Camera.GetComponent<FirstPersonLook>();
            cam.Stopcam(!isPaused);
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (isPaused)
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
    }
    public void Resuming()
    {
        isPaused = pauseMenu.activeSelf;
        Time.timeScale = 1f;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.None;
        pauseMenu.SetActive(!isPaused);
        FirstPersonLook cam = Camera.GetComponent<FirstPersonLook>();
        cam.Stopcam(false); 
    }
}
