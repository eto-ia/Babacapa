using UnityEngine;

public class StartScript : MonoBehaviour
{
    public GameObject car;
    public GameObject FPC;
    public Animator black;
    public AudioSource dialog;
    public AudioSource sfx;
    public AudioSource music;
    public GameObject hud;
    public Animator talk;
    public GameObject husband;
    public GameObject skip;
    private bool skipped = false;
    private bool canClose = false;
    public GameObject tutor;
    public Rigidbody rb;
    void Start()
    {
        hud.SetActive(false);
    }
    public void CutBeg()
    {
        rb.constraints = RigidbodyConstraints.None;
        rb.constraints = RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationX;
        rb.transform.position = new Vector3 (237.67f, 0f, 187.82f);
        MenuController._cut = true;
        sfx.volume *= 0.5f;
        sfx.clip = Resources.Load<AudioClip>("SFX/car_engine");
        sfx.Play();
        dialog.clip = Resources.Load<AudioClip>("Dialogs/initial");
        Invoke ("outBlack", 1.5f);
        Invoke ("Talk", 2f);
        Invoke ("animTalk", 8.5f);
        Invoke ("animStop", 26f);
        Invoke ("toBlack", 28.75f);
        Invoke ("tp", 30.25f);
        Invoke ("doorClose", 31.25f);
        Invoke ("outBlack", 32.25f);
        Invoke ("start", 33.75f);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && !skipped)
        {
            tp();
            start();
            skipped = true;
        }
        if (Input.GetKeyUp(KeyCode.Return) && canClose)
        {
            tutor.SetActive(false);
        }
    }
    private void outBlack()
    {
        black.Play("OutBlack");
    }
    private void toBlack()
    {
        black.Play("ToBlack");
    }
    private void Talk()
    {
        dialog.Play();
    }
    private void tp()
    {
        car.transform.position = new Vector3(245.36f, 0.62f, 195.58f);
        car.transform.rotation = Quaternion.Euler(0f, -22.34f, 0f);
        FPC.transform.position = new Vector3(243f, 0f, 195f);
        FPC.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        husband.transform.position = new Vector3(0f, 0f, 0f);
    }
    private void animTalk()
    {
        talk.SetBool("Talk", true);
    }
    private void animStop()
    {
        talk.SetBool("Talk", false);
    }
    private void doorClose()
    {
        sfx.clip = Resources.Load<AudioClip>("SFX/car_door");
        sfx.Play();
    }
    private void start()
    {
        MenuController.isMenu = false;
        tutor.SetActive(true);
        sfx.Stop();
        dialog.Stop();
        sfx.clip = null;
        dialog.clip = null;
        FirstPersonLook.checkPause = false;
        FirstPersonMovement.checkPause = false;
        Jump.checkPause = false;
        Crouch.checkPause = false;
        black.gameObject.SetActive(false);
        hud.SetActive(true);
        skip.SetActive(false);
        MenuController._cut = false;
        music.clip = Resources.Load<AudioClip>("Music/nature_forest");
        music.Play();
        Invoke("Cancel", 1f);
    }
    private void Cancel()
    {
        canClose = true;
        CancelInvoke();
    }
}
