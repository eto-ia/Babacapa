using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    // Start is called before the first frame update
    void Start()
    {
        pauseMenu = GameObject.Find("Pause");
        pauseMenu.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                bool isPaused = pauseMenu.activeSelf;
                Time.timeScale = isPaused ? 1f : 0f;
                pauseMenu.SetActive(!isPaused);
                Cursor.visible = !isPaused;
                Cursor.lockState = isPaused ? CursorLockMode.None : CursorLockMode.Locked;
            }
        }
    }
}
