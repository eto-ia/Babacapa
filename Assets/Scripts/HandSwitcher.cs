using UnityEngine;
using UnityEngine.UI;

public class HandSwitcher : MonoBehaviour
{
    public static GameObject hand;
    public static string[] cpos;
    public static string[] crot;
    public static string[] cscale;
    public static float[] pos = new float[3];
    public static float[] rot = new float[3];
    public static float[] scale = new float[3];
    public static string[] itemInfo = new string[5];
    public static Text[] hudInfo = new Text[5];
    public static MeshFilter[] hudMeshF = new MeshFilter[5];
    public static MeshRenderer[] hudMeshR = new MeshRenderer[5];
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
    public static void handSwitcher (int slotIndex)
    {
        if (slotIndex < 0)
        {
            hand.transform.localPosition = new Vector3(0f, 0f, 0f);
            hand.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
            hand.transform.localScale = new Vector3(0f, 0f, 0f);
            hand.GetComponent<MeshFilter>().mesh = null;
            hand.GetComponent<MeshRenderer>().material = null;
            return;
        }
        hand.GetComponent<MeshFilter>().mesh = hudMeshF[slotIndex].mesh;
        hand.GetComponent<MeshRenderer>().material = hudMeshR[slotIndex].material;
        itemInfo = hudInfo[slotIndex].text.Split("\n");
        cpos = itemInfo[2].Split(" ");
        crot = itemInfo[3].Split(" ");
        cscale = itemInfo[4].Split(" ");
        for (int i = 0; i < 3; i++)
        {
            pos[i] = float.Parse(cpos[i]);
            rot[i] = float.Parse(crot[i]);
            scale[i] = float.Parse(cscale[i]);
        }
        hand.transform.localPosition = new Vector3(pos[0], pos[1], pos[2]);
        hand.transform.localRotation = Quaternion.Euler(rot[0], rot[1], rot[2]);
        hand.transform.localScale = new Vector3(scale[0], scale[1], scale[2]);
    }
}
