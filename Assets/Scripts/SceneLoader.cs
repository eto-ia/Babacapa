using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    public Slider sfx;
    public Slider music;
    public Slider sens;
    public int index;
    private string values;
    public void SceneLoad()
    {
        if (index > 0)
        {
            PauseMenu.isRestarted = true;
        }
        using (StreamWriter writer = new StreamWriter("Assets/Resources/SliderValue.txt", false))
        {
            values = music.value.ToString() + " " + sfx.value.ToString() + " " + sens.value.ToString();
            writer.WriteLine(values);
        }
        SceneManager.LoadScene(index);
    }
}
