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
            PauseMenu.isRestarted = true;
        }
        bgmusic.Stop();
        using (StreamWriter writer = new StreamWriter("Assets/Resources/SliderValue.txt", false))
        {
            values = music.value.ToString() + " " + sfx.value.ToString() + " " + sens.value.ToString();
            writer.WriteLine(values);
        }
        SceneManager.LoadScene(index);
    }
}
