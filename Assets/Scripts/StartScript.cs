using UnityEngine;

public class StartScript : MonoBehaviour
{
    public GameObject car;
    public GameObject FPC;
    public Animator black;
    public AudioSource dialog;
    public GameObject hud;
    void Awake()
    {
        hud.SetActive(false);
    }
    void Start()
    {
        Invoke ("outBlack", 1.5f);
        Invoke ("Talk", 2f);
        Invoke ("toBlack", 10f);
        Invoke ("tp", 11.5f);
        Invoke ("outBlack", 13.5f);
        Invoke ("Cancel", 13.5f);
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
        //dialog.Play();
    }
    private void tp()
    {
        car.transform.position = new Vector3(245.36f, 0.62f, 195.58f);
        car.transform.rotation = Quaternion.Euler(0f, -22.34f, 0f);
        FPC.transform.position = new Vector3(243f, 0f, 195f);
        
    }
    private void Cancel()
    {
        FirstPersonLook.checkPause = false;
        FirstPersonMovement.checkPause = false;
        Jump.checkPause = false;
        Crouch.checkPause = false;
        black.gameObject.SetActive(false);
        hud.SetActive(true);
        CancelInvoke();
    }
}
