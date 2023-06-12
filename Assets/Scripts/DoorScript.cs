using UnityEngine;
using UnityEngine.UI;

public class DoorScript : MonoBehaviour
{
    public Transform PlayerCamera;
    public float MaxDistance = 3;
    private bool opened = false;
    private Animator anim;
    private string index;
    public AudioSource sfx;
    public AudioSource dialog;
    private RaycastHit doorhit;
    public static bool active34 = false;
    private bool is34ed = false;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Pressed();
        }
    }

    void Pressed()
    {
        if (Physics.Raycast(PlayerCamera.transform.position, PlayerCamera.transform.forward, out doorhit, MaxDistance))
        {
            if (doorhit.transform.tag == "Door")
            {
                index = doorhit.transform.gameObject.GetComponentInChildren<Text>().text;
                if (index == "34")
                {
                    if (active34 && !is34ed)
                    {
                        is34ed = true;
                        dialog.clip = Resources.Load<AudioClip>("Dialogs/brother2");
                        dialog.Play();
                        Invoke ("PlayAnim", 5.5f);
                    }
                    else if (is34ed)
                    {
                        anim = doorhit.transform.GetComponentInParent<Animator>();
                        anim.Play("Open3");
                    }
                    else
                    {
                        Talking.talked[2] = 1;
                        sfx.clip = Resources.Load<AudioClip>("SFX/knock");
                        sfx.Play();
                        Invoke("PlayDialog", 1.75f);
                    }
                    return;
                }
                anim = doorhit.transform.GetComponentInParent<Animator>();
                anim.Play("Open" + doorhit.transform.gameObject.GetComponentInChildren<Text>().text);
            }
        }
    }
    private void PlayAnim()
    {
        anim = doorhit.transform.GetComponentInParent<Animator>();
        anim.Play("Open3");
    }
    private void PlayDialog()
    {
        dialog.clip = Resources.Load<AudioClip>("Dialogs/brother1");
        dialog.Play();
        Talking.taskChecker();
    }
}