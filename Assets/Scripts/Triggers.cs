using UnityEngine;

public class Triggers : MonoBehaviour
{
    private bool brother_active = false; 
    private bool grandmother_active = false; 
    public AudioSource dialog;
    public AudioSource sfx;
    public Animator brother;  
    public Rigidbody[] books;
    public Animator lamp;
    public AudioSource lamp_sound;
    void Start()
    {
        
    }
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other) 
    {
        if (other.transform.gameObject.tag == "Brother" && !brother_active)
        {
            brother_active = true;
            dialog.clip = Resources.Load<AudioClip>("Dialogs/brother3");
            dialog.Play();
            brother.SetBool("Talk", true);
            Invoke ("Cancel", 10f);
        }
        if (other.transform.gameObject.tag == "Grandmother" && !grandmother_active)
        {

            grandmother_active = true;
            sfx.clip = Resources.Load<AudioClip>("SFX/books_fly");
            sfx.Play();
            lamp.Play("Lamp");
            lamp_sound.Play();
            Invoke ("Dialog", 1f);
            books[0].AddForce(new Vector3(-1000f, 200f, 0f), ForceMode.Force);
            books[1].AddForce(new Vector3(-1000f, 200f, 0f), ForceMode.Force);
            books[2].AddForce(new Vector3(-500f, 700f, -300f), ForceMode.Force);
        }
    }
    private void Dialog()
    {
        dialog.clip = Resources.Load<AudioClip>("Dialogs/grandmother");
        dialog.Play();
    }
    private void Cancel()
    {
        CancelInvoke();
        brother.SetBool("Talk", false);
    }
}
