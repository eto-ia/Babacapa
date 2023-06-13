using UnityEngine;
using UnityEngine.UI;

public class LightSwitch : MonoBehaviour
{
    public Transform PlayerCamera;
    public float MaxDistance = 3;
    public Light[] lamps = new Light[6];
    private AudioSource audioOn;
    private AudioSource audioOff; 
    private Animator anim;
    private int indexLamp;
    public static float volume = 1f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) 
        {
            RaycastHit switchhit;
            if (Physics.Raycast(PlayerCamera.transform.position, PlayerCamera.transform.forward, out switchhit, MaxDistance))
            {
                if (switchhit.transform.tag == "Switch")
                {
                    audioOn = switchhit.transform.Find("On").GetComponent<AudioSource>();
                    audioOff = switchhit.transform.Find("Off").GetComponent<AudioSource>();
                    indexLamp = int.Parse(switchhit.transform.GetComponentInParent<Text>().text);
                    
                    if (lamps[indexLamp].enabled)
                    {
                        audioOff.volume = volume;
                        audioOff.Play();
                    }
                    else
                    {
                        audioOn.volume = volume;
                        audioOn.Play();
                    }

                    lamps[indexLamp].enabled = !lamps[indexLamp].enabled;
                    if (indexLamp != 3)
                    {
                        anim = switchhit.transform.GetComponentInChildren<Animator>();
                        anim.SetBool("On", lamps[indexLamp].enabled);
                        anim.SetBool("Off", !lamps[indexLamp].enabled);
                    }   
                }
            }
        }
    }
}
