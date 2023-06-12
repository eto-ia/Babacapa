using UnityEngine;

public class TaskStarter : MonoBehaviour
{
    public AudioSource dialog;
    public bool[] activeTasks = {false, false, false, false, false};
    void Start()
    {
        
    }
    void Update()
    {
        if (TaskChanger.curTask == 2 && !activeTasks[0])
        {
            activeTasks[0] = true;
            if (dialog.isPlaying)
            {
                Invoke ("firstDialog", dialog.clip.length-dialog.time);
            }
            else
            {
                Invoke ("firstDialog", 0.5f);
            }
        }
        if (TaskChanger.curTask == 4 && !activeTasks[2])
        {
            activeTasks[2] = true;
            if (dialog.isPlaying)
            {
                Invoke ("secondDialog", dialog.clip.length-dialog.time);
            }
            else
            {
                Invoke ("secondDialog", 0.5f);
            }
        }
        if (TaskChanger.curTask == 5 && !activeTasks[3])
        {
            activeTasks[3] = true;
            if (dialog.isPlaying)
            {
                Invoke ("thirdDialog", dialog.clip.length-dialog.time);
            }
            else
            {
                Invoke ("thirdDialog", 0.5f);
            }
        }
        if (TaskChanger.curTask == 6 && !activeTasks[4])
        {
            activeTasks[4] = true;
            if (dialog.isPlaying)
            {
                Invoke ("fourthDialog", dialog.clip.length-dialog.time);
            }
            else
            {
                Invoke ("fourthDialog", 0.5f);
            }
        }
    }
    private void firstDialog()
    {
        dialog.clip = Resources.Load<AudioClip>("Dialogs/task2_start");
        dialog.Play();
        CancelInvoke();
    }
    private void secondDialog()
    {
        dialog.clip = Resources.Load<AudioClip>("Dialogs/task4_start");
        dialog.Play();
        CancelInvoke();
    }
    private void thirdDialog()
    {
        dialog.clip = Resources.Load<AudioClip>("Dialogs/task5_start");
        dialog.Play();
        CancelInvoke();
    }
    private void fourthDialog()
    {
        dialog.clip = Resources.Load<AudioClip>("Dialogs/task6_start");
        dialog.Play();
        CancelInvoke();
    }
}
