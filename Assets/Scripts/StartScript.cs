using UnityEngine;

public class StartScript : MonoBehaviour
{
    public GameObject car;
    public GameObject FPC;
    public Animator black;
    public AudioSource dialog;
    public AudioSource sfx;
    public GameObject hud;
    public Animator talk;
    public GameObject husband;
    public GameObject skip;
    private bool skipped = false;
    void Awake()
    {
        hud.SetActive(false);
    }
    void Start()
    {
        PauseMenu.cut = true;
        sfx.volume *= 0.5f;
        Invoke ("outBlack", 1.5f);
        Invoke ("Talk", 2f);
        Invoke ("animTalk", 8.5f);
        Invoke ("animStop", 26f);
        Invoke ("toBlack", 28.75f);
        Invoke ("tp", 30.25f);
        Invoke ("doorClose", 31.25f);
        Invoke ("outBlack", 32.25f);
        Invoke ("Cancel", 33.75f);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && !skipped)
        {
            tp();
            Cancel();
            skipped = true;
        }
    }
    private void outBlack()
    {
        black.Play("OutBlack2");
    }
    private void toBlack()
    {
        black.Play("ToBlack2");
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
        Destroy(husband);
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
    private void Cancel()
    {
        sfx.Stop();
        dialog.Stop();
        FirstPersonLook.checkPause = false;
        FirstPersonMovement.checkPause = false;
        Jump.checkPause = false;
        Crouch.checkPause = false;
        black.gameObject.SetActive(false);
        hud.SetActive(true);
        skip.SetActive(false);
        PauseMenu.cut = false;
        CancelInvoke();
    }
}
