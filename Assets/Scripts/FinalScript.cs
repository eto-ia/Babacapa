using UnityEngine;
using UnityEngine.UI;

public class FinalScript : MonoBehaviour
{
    public GameObject Camera;
    public float Distance;
    public AudioSource dialog;
    public AudioSource sfx;
    public AudioSource music;
    private bool collcheck = true;
    public Animator black;
    public Animator white;
    public GameObject whiteScreen;
    public GameObject FPC;
    public GameObject hand;
    public GameObject tbook;
    public Text[] slots;
    public GameObject cr;
    public GameObject ru;
    public GameObject n1;
    public GameObject n2;
    public GameObject n3;
    public GameObject hud;
    public Animator hus;
    public GameObject husband;
    public MenuController exit;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Ritual();
            
        }
    }
    private void Ritual()
    {
        RaycastHit grave;
        if (Physics.Raycast(Camera.transform.position, Camera.transform.forward, out grave , Distance))
        {
            if (grave.collider.tag == "Grave" && TaskChanger.curTask == 6)
            {
                for (int i = 0; i < 6; i++)
                {
                    if (!PickItem.collection[i])
                    {
                        collcheck = false;
                        break;
                    }
                }
                if (!collcheck)
                {
                    dialog.clip = Resources.Load<AudioClip>("Dialogs/no_component");
                    dialog.Play();
                    collcheck = true;
                }
                else
                {
                    for (int i = 0; i < 6; i++)
                    {
                        PickItem.collection[i] = false;
                    }
                    dialog.clip = Resources.Load<AudioClip>("Dialogs/yes_component");
                    dialog.Play();
                    Invoke ("toBlack", 3f);
                    Invoke ("place",4.6f);
                    Invoke ("outBlack", 4.7f);
                    Invoke ("dialog1", 6.2f);
                    Invoke ("rune", 7f);
                    Invoke ("crystal", 8.7f);
                    Invoke ("notes", 11f);
                    Invoke ("dialog2", 14f);
                    Invoke ("shaker", 32f);
                    Invoke ("toWhite", 34.5f);
                    Invoke ("tp", 36f);
                    Invoke ("outWhite", 38f);
                    Invoke ("toBlack", 59.45f);
                    Invoke ("toMenu", 62f);
                }
            }
        }
    }
    private void toBlack()
    {
        black.gameObject.SetActive(true);
        black.Play("ToBlack");
    }
    private void outBlack()
    {
        black.Play("OutBlack");
    }
    private void place()
    {
        FPC.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        hud.SetActive(false);
        FirstPersonLook.checkPause = true;
        FirstPersonMovement.checkPause = true;
        Jump.checkPause = true;
        Crouch.checkPause = true;
        SwitchHudSlot.cut = true;
        MenuController._cut = true;
        FPC.transform.position = new Vector3(285.17f, 0.2590001f, 249.659f);
        FPC.transform.rotation = Quaternion.Euler(0f, -90f, 0f);
        Camera.transform.localRotation = Quaternion.Euler(66.21f, 0f, 0f);
        FPC.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        for (int i = 0; i < 5; i++)
        {
            if (slots[i].text.Split("\n")[0] == "Таинственная книга")
            {
                HandSwitcher.handSwitcher(i);
            }
        }
    }
    private void dialog1()
    {
        dialog.clip = Resources.Load<AudioClip>("Dialogs/ritual1");
        dialog.Play();
        music.clip = Resources.Load<AudioClip>("Music/final");
        music.volume *= 0.1f;
        music.Play();
    }
    private void crystal()
    {
        cr.transform.position = new Vector3(285.086f, 0f, 249.358f);
        sfx.Play();
    }
    private void rune()
    {
        ru.transform.position = new Vector3(285.066f, 0f, 250.049f);
        sfx.clip = Resources.Load<AudioClip>("SFX/pickup");
        sfx.Play();
    }
    private void notes()
    {
        n1.transform.position = new Vector3(284.4379f, 0f, 249.031f);
        n2.transform.position = new Vector3(283.993f, 0f, 249.7f);
        n3.transform.position = new Vector3(284.4379f, 0f, 250.327f);
        sfx.Play();
    }
    private void dialog2()
    {
        dialog.clip = Resources.Load<AudioClip>("Dialogs/spell");
        dialog.Play();
    }
    private void toWhite()
    {
        whiteScreen.SetActive(true);
        sfx.volume *= 0.3f;
        sfx.clip = Resources.Load<AudioClip>("SFX/pain");
        sfx.Play();
        white.Play("ToWhite");
    }
    private void outWhite()
    {
        white.Play("OutWhite");
        Invoke ("afterFinal", 1f);
    }
    private void shaker()
    {
        Camera.GetComponent<Animator>().Play("Shake");
    }
    private void tp()
    {
        FPC.transform.position = new Vector3(284.5f, 0f, 248.3f);
        FPC.transform.rotation = Quaternion.Euler(0f, -99.7f, 0f);
        Camera.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
        husband.transform.position = new Vector3(283.65f, 0f, 248.17f);
        HandSwitcher.handSwitcher(-1);
    }
    private void afterFinal()
    {
        dialog.clip = Resources.Load<AudioClip>("Dialogs/afterfinal");
        dialog.Play();
        hus.SetBool("Talk", true);
    }
    private void toMenu()
    {
        collcheck = true;
        exit.Exit();
        CancelInvoke();
    }
}
