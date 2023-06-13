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
        Application.Quit();
    }
}
