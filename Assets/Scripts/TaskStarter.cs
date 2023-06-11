using UnityEngine;

public class TaskStarter : MonoBehaviour
{
    public AudioSource dialog;
    public bool[] activeTasks = {false, false, false, false, false,};
    void Start()
    {
        
    }
    void Update()
    {
        if (TaskChanger.curTask == 2 && !activeTasks[0])
        {
            activeTasks[0] = true;
            startTask2();
        }
    }
    private void startTask2()
    {
        Invoke("firstDialog", 2f);
    }
    private void firstDialog()
    {
        dialog.clip = Resources.Load<AudioClip>("Dialogs/task2_start");
        dialog.Play();
    }
}
