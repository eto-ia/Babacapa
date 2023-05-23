using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private GameObject Volume;
    private GameObject Camera;
    void Start()
    {
        Volume = GameObject.Find("First Person Audio");
        Camera = GameObject.Find("First Person Camera");
    }
    public void SceneLoad(int index)
    {
        if (index > 0)
        {
            PauseMenu.isRestarted = true;
        }
        SceneManager.LoadScene(index);
    }
}
