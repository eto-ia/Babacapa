using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    public AudioSource bgmusic;
    public Slider sfx;
    public Slider music;
    public Slider sens;
    private string values;
    public void SceneLoad(int index)
    {
        if (index > 0)
        {
            SceneManager.LoadScene("main");
            PauseMenu.isRestarted = true;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
        }
        bgmusic.Stop();
        using (StreamWriter writer = new StreamWriter("Assets/Resources/SliderValue.txt", false))
        {
            values = music.value.ToString() + " " + sfx.value.ToString() + " " + sens.value.ToString();
            writer.WriteLine(values);
        }
    }
}
