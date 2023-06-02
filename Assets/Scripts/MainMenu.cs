using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject set;
    public GameObject menu;
    public Slider music;
    public Slider sfx;
    public Slider sens;
    bool isSet = false;
    string values;
    void Start()
    {
        set.SetActive(false);
        using (StreamReader reader = new StreamReader("Assets/Resources/SliderValue.txt", false))
        {
            values = reader.ReadLine();
        }
        music.value = float.Parse(values.Split(" ")[0]);
        sfx.value = float.Parse(values.Split(" ")[1]);
        sens.value = float.Parse(values.Split(" ")[2]);
    }
    public void settings()
    {
        isSet = !set.activeSelf;
        set.SetActive(isSet);
        menu.SetActive(!isSet);
    }
    public void SFXChanged()
    {
        FirstPersonAudio.volume = sfx.value;
    }
    public void sensChanged()
    {
        FirstPersonLook.sensitivity = sens.value;
    }
}
