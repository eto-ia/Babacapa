using UnityEngine;
using UnityEngine.SceneManagement;

public class Resume : MonoBehaviour
{
    public GameObject menu;
    // Start is called before the first frame update
    void Start()
    {
        menu = GameObject.Find("Pause");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Resuming()
    {
        bool isPaused = menu.activeSelf;
        Time.timeScale = 1f;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.None;
        menu.SetActive(!isPaused);
    }
}
