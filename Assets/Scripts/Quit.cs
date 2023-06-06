using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class Quit : MonoBehaviour
{
    public Slider sfx;
    public Slider music;
    public Slider sens;
    private string values;
    public void QuitGame()
    {
        using (StreamWriter writer = new StreamWriter("Assets/Resources/SliderValue.txt", false))
        {
            values = music.value.ToString() + " " + sfx.value.ToString() + " " + sens.value.ToString();
            writer.WriteLine(values);
        }
        if (Application.isEditor)
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }
        else
        {
            Application.Quit();
        }
    }
}
