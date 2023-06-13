using UnityEngine;
using UnityEngine.UI;
public class MenuController : MonoBehaviour
{
    public GameObject menuPause;
    public GameObject _Volume;
    public GameObject _Camera;
    public GameObject inventory;
    public GameObject _settings;
    public GameObject _warning;
    public GameObject notes;
    public GameObject whiteScreen;
    public GameObject _canvas;
    public Image blackScreen;
    private bool isnotPaused = true;
    private bool isInventory = false;
    private bool isSetting = false;
    public static bool isMenu = true;
    public Slider _sfx;
    public Slider music1;
    public Slider sens;
    private string _values;
    public AudioSource _Music;
    public static bool _cut = false;
    public AudioSource SFX1;
    public AudioSource Dialog;
    public GameObject _menu;
    public Rigidbody rb;
    public GameObject[] Slots = new GameObject[5];    
    void Start()
    {
        rb.transform.position = new Vector3 (0f, 0f, 0f);
        rb.constraints = RigidbodyConstraints.FreezeAll;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        menuPause.SetActive(false);
        inventory.SetActive(false);
        _settings.SetActive(false);
        _warning.SetActive(false);
        whiteScreen.SetActive(false);
        _canvas.SetActive(false);
        //blackScreen.enabled = false;
        FirstPersonLook.checkPause = true;
        FirstPersonMovement.checkPause = true;
        Jump.checkPause = true;
        Crouch.checkPause = true;
        Talking.talked[0] = 0;
        Talking.talked[1] = 0;
        Talking.talked[2] = 0;
        DoorScript.active34 = false;
        DoorScript.is34ed = false;
        isMenu = true;
        _menu.SetActive(true);
        _Music.clip = Resources.Load<AudioClip>("Music/mainMenu");
        _Music.Play();
        Dialog.Stop();
        Dialog.clip = null;
        SFX1.Stop();
        SFX1.clip = null;
        
        FirstPersonAudio.volume = _sfx.value;
        for (int i = 0; i < 5; i++)
        {
            Slots[i].GetComponent<MeshFilter>().mesh = null;
            Slots[i].GetComponent<MeshRenderer>().materials = new Material[0];
            Slots[i].GetComponent<Text>().text = null;
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !_settings.activeSelf && !_warning.activeSelf && !notes.activeSelf && !_cut && !isMenu)
        {
            inventory.SetActive(false);
            isnotPaused = menuPause.activeSelf;
            Time.timeScale = isnotPaused ? 1f : 0f;
            menuPause.SetActive(!isnotPaused);
            Cursor.visible = !isnotPaused;
            Cursor.lockState = isnotPaused ? CursorLockMode.Confined : CursorLockMode.None;
            FirstPersonAudio volume = _Volume.GetComponent<FirstPersonAudio>();
            if (volume != null)
            {
                volume.SetPlayingMovingAudio (null, true);
            }
            if (_Music.isPlaying)
            {
                _Music.Pause();
            }
            else
            {
                _Music.Play();
            }
            FirstPersonLook cam = _Camera.GetComponent<FirstPersonLook>();
            cam.Stopcam(!isnotPaused);
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (!menuPause.activeSelf && !_settings.activeSelf && !_warning.activeSelf && !notes.activeSelf && !_cut && !isMenu)
            {
                isInventory = inventory.activeSelf;
                Time.timeScale = isInventory ? 1f : 0f;
                inventory.SetActive(!isInventory);
                Cursor.visible = !isInventory;
                Cursor.lockState = isInventory ? CursorLockMode.Confined : CursorLockMode.None;
                FirstPersonAudio volume = _Volume.GetComponent<FirstPersonAudio>();
                if (volume != null)
                {
                    volume.SetPlayingMovingAudio (null, true);
                }
                _Camera.GetComponent<FirstPersonLook>().Stopcam(!isInventory);
            }
        }
    }
    public void Resuming()
    {
        isnotPaused = menuPause.activeSelf;
        Time.timeScale = 1f;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.None;
        menuPause.SetActive(!isnotPaused);
        FirstPersonLook cam = _Camera.GetComponent<FirstPersonLook>();
        cam.Stopcam(false);
        _Music.Play();
    }
    public void Options()
    {
        isSetting = !isSetting;
        _settings.SetActive(!_settings.activeSelf);
        if (!_menu)
        {
            menuPause.SetActive(_settings.activeSelf);
        }
    }
    public void SFXChanged()
    {
        FirstPersonAudio.volume = _sfx.value;
        DoorSound.volume = _sfx.value;
        LightSwitch.volume = _sfx.value;
        SFX1.volume = _sfx.value;
        Dialog.volume = _sfx.value;
    }
    public void musicChanged()
    {
        _Music.volume = music1.value;
    }
    public void sensChanged ()
    {
        FirstPersonLook.sensitivity = sens.value;
    }
    public void Warn()
    {
        _warning.SetActive(!_warning.activeSelf);
        menuPause.SetActive(!_warning.activeSelf);
    }
    public void Exit()
    {
        Start();
    }
}
