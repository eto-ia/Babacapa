using UnityEngine;
using UnityEngine.UI;

public class Shoveling : MonoBehaviour
{
    public Text[] Slots = new Text[5];
    public GameObject cam;
    private RaycastHit bedHit;
    private float maxD = 3;
    private GameObject cbed;
    public MeshRenderer[] meshes;
    public Material mat;
    public AudioSource sfx;
    void Start()
    {
        
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            shovel();
        }
    }
    private void shovel()
    {
        if (Slots[PickItem.activeSlot].text.Split("\n")[0] == "Лопата")
        {
            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out bedHit, maxD))
            {
                if (bedHit.transform.tag == "Row")
                {
                    if (bedHit.transform.gameObject.name == "Flowerbed6")
                    {
                        meshes[0].enabled = true;
                    }
                    if (bedHit.transform.gameObject.name == "Flowerbed11")
                    {
                        meshes[1].enabled = true;
                    }
                    bedHit.transform.Find("dirt").GetComponent<MeshRenderer>().material = mat;
                    sfx.clip = Resources.Load<AudioClip>("SFX/shovel");
                    sfx.Play();
                }
            }
        }
    }
}
