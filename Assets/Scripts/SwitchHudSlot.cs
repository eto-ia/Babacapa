using UnityEngine;
using UnityEngine.UI;

public class SwitchHudSlot : MonoBehaviour
{
    private GameObject hand;
    private string[] cpos;
    private string[] crot;
    private string[] cscale;
    private float[] pos = new float[3];
    private float[] rot = new float[3];
    private float[] scale = new float[3];
    private string[] itemInfo = new string[5];
    private Text[] hudInfo = new Text[5];
    private MeshFilter[] hudMeshF = new MeshFilter[5];
    private MeshRenderer[] hudMeshR = new MeshRenderer[5];
    public GameObject inv;
    public GameObject pause;
    public GameObject set;
    void Awake() 
    {
        hand = GameObject.Find("Hand");
        for (int i = 0; i < 5; i++)
        {
            hudInfo[i] = GameObject.Find("SlotInfo" + (i + 1).ToString()).GetComponent<Text>();
            hudMeshF[i] = GameObject.Find("SlotInfo" + (i + 1).ToString()).GetComponent<MeshFilter>();
            hudMeshR[i] = GameObject.Find("SlotInfo" + (i + 1).ToString()).GetComponent<MeshRenderer>();
        }
    }
    void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") != 0f && !pause.activeSelf && !inv.activeSelf && !set.activeSelf)
        {
            if (Input.GetAxis("Mouse ScrollWheel") > 0f)
            {
                if (PickItem.activeSlot < 4 && PickItem.activeSlots[PickItem.activeSlot + 1])
                {
                    PickItem.activeSlot += 1;
                    HandSwitcher.handSwitcher(PickItem.activeSlot);
                    
                }   
            }
            if (Input.GetAxis("Mouse ScrollWheel") < 0f)
            {
                if (PickItem.activeSlot > 0)
                {
                    PickItem.activeSlot -= 1;
                    HandSwitcher.handSwitcher(PickItem.activeSlot);
                } 
            }
        }
    }
}
