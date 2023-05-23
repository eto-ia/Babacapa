using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GameObject inventory;
    private GameObject Camera;
    // Start is called before the first frame update
    void Start()
    {
        inventory=GameObject.Find("Inventory");
        inventory.SetActive(false);
        Camera = GameObject.Find("First Person Camera");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            bool isPaused = inventory.activeSelf;
            inventory.SetActive(!isPaused);
            Cursor.visible = !isPaused;
            Cursor.lockState = isPaused ? CursorLockMode.Locked : CursorLockMode.None;
            FirstPersonLook cam = Camera.GetComponent<FirstPersonLook>();
            cam.Stopcam(!isPaused);
        }
        
    }
}
