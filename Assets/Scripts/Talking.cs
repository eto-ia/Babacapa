using UnityEngine;

public class Talking : MonoBehaviour
{
    public GameObject Camera;
    public float Distance;
    public AudioSource dialog;
    public Animator animHus;
    public static int[] talked = {0, 0, 0};
    public TaskChanger ctskchng;
    public static TaskChanger tskchng;
    void Start()
    {
        tskchng = ctskchng;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            StartDialog();
        }
    }
    private void StartDialog()
    {
        RaycastHit Person;
        if (Physics.Raycast(Camera.transform.position, Camera.transform.forward, out Person , Distance))
        {
            if (Person.transform.tag == "Talkable")
            {
                if (Person.transform.gameObject.name == "Wife" && talked[1] < 1)
                {
                    talked[1] += 1;
                    dialog.clip = Resources.Load<AudioClip>("Dialogs/wife");
                    dialog.Play();
                }
                if (Person.transform.gameObject.name == "Husband")
                {
                    if (talked[0] == 0)
                    {
                        talked[0] = 1;
                        dialog.clip = Resources.Load<AudioClip>("Dialogs/husband");
                        dialog.Play();
                        animHus.SetBool("Talk", true);
                        Invoke ("Cancel", 13f);
                    }
                    if (talked[0] == 1 && TaskChanger.curTask == 3)
                    {
                        talked[0] = 2;
                        DoorScript.active34 = true;
                        dialog.clip = Resources.Load<AudioClip>("Dialogs/hus_key_ask");
                        dialog.Play();
                        animHus.SetBool("Move", true);
                        Invoke ("Cancel", 8f);
                    }
                }
                if (Person.transform.gameObject.name == "Brother")
                {
                    
                }
                taskChecker();
            }
        }        
    }
    public static void taskChecker()
    {
        if (talked[0] > 0 && talked[1] > 0 && talked[2] > 0 && TaskChanger.curTask == 1)
        {
            tskchng.taskPicker(2);
        }
    }
    private void Cancel()
    {
        animHus.SetBool("Talk", false);
        animHus.SetBool("Move", false);
        CancelInvoke();
    }
}
