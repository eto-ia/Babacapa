using UnityEngine;
using UnityEngine.UI;


public class BarnDoor : MonoBehaviour
{
    public GameObject cam;
    public GameObject padlock;
    public MeshFilter key;
    public MeshFilter hand;
    public Animator door;
    public AudioSource sfx;
    public AudioSource dialog;
    private float maxD = 3;
    public Text[] Slots = new Text[5];
    public TaskChanger tskchng;
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.E))
        {
            openBarn();
        }
    }
    private void openBarn()
    {
        RaycastHit doorhit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out doorhit, maxD))
        {
            if (doorhit.collider.tag == "Barn")
            {
                if (Slots[PickItem.activeSlot].text.Split("\n")[0] == "Ключ от амбара")
                {
                    sfx.clip = Resources.Load<AudioClip>("SFX/padlock");
                    sfx.Play();
                    Invoke ("PlayBarn", 0.5f);
                }
                else
                {
                    if(TaskChanger.curTask == 2)
                    {
                        dialog.clip = Resources.Load<AudioClip>("Dialogs/find_key");
                        dialog.Play();
                        tskchng.taskPicker(3);
                    }
                }
            }
        }
    }
    private void PlayBarn()
    {
        padlock.GetComponent<Animator>().Play("PadOpen");
        padlock.GetComponent<Rigidbody>().isKinematic = false;
        door.Play("Open7");
        DeleteItem.deleteHud();
    }
}
