using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public Transform PlayerCamera;
    public float MaxDistance = 3;
    private bool opened = false;
    private Animator anim;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Pressed();
        }
    }

    void Pressed()
    {
        RaycastHit doorhit;
        if (Physics.Raycast(PlayerCamera.transform.position, PlayerCamera.transform.forward, out doorhit, MaxDistance))
        {
            if (doorhit.transform.tag == "Door")
            {
                anim = doorhit.transform.GetComponentInParent<Animator>();
                opened = !opened;
                anim.SetBool("Opened", opened);
            }
        }
    }
}