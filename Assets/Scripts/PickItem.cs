using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PickItem : MonoBehaviour
{
    public GameObject Camera;
    public float Distance;
    public static Image[] inventoryImages = new Image[8];
    public static TextMeshProUGUI[] inventoryName = new TextMeshProUGUI[8];
    public static TextMeshProUGUI[] inventoryDes = new TextMeshProUGUI[8];
    private Image[] hudImages = new Image[5];
    private Image imageHitItem;
    public GameObject hand;
    public MeshFilter handFilter;
    public MeshRenderer handRenderer;
    public TextMeshProUGUI Name;
    public TextMeshProUGUI Description;
    private Text[] hudInfo = new Text[5];
    private MeshFilter[] hudMeshF = new MeshFilter[5];
    private MeshRenderer[] hudMeshR = new MeshRenderer[5];
    public static bool[] activeSlots = {false, false, false, false, false};
    private string[] itemInfo = new string[5];
    private string[] cpos;
    private string[] crot;
    private string[] cscale;
    private float[] pos = new float[3];
    private float[] rot = new float[3];
    private float[] scale = new float[3];
    public static int activeSlot = 0;
    private int SlotInv = 0;
    void Awake()
    {
        for (int i = 0; i < 8; i++)
        {
            inventoryImages[i] = GameObject.Find("SlotImage"+(i + 1).ToString()).GetComponent<Image>();
            inventoryImages[i].enabled = (false);
            inventoryName[i] = GameObject.Find("SlotText" + (i + 1).ToString()).GetComponent<TextMeshProUGUI>();
            inventoryDes[i] = GameObject.Find("SlotDes" + (i + 1).ToString()).GetComponent<TextMeshProUGUI>();
        }
        for (int i = 0; i < 5; i++)
        {
            hudImages[i] = GameObject.Find("HudSlotImage" + (i + 1).ToString()).GetComponent<Image>();
            hudImages[i].enabled = false;
            hudInfo[i] = GameObject.Find("SlotInfo" + (i + 1).ToString()).GetComponent<Text>();
            hudMeshF[i] = GameObject.Find("SlotInfo" + (i + 1).ToString()).GetComponent<MeshFilter>();
            hudMeshR[i] = GameObject.Find("SlotInfo" + (i + 1).ToString()).GetComponent<MeshRenderer>();
        }        
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            ObjectGetter();
        }
    }
    private void ObjectGetter()
    {
        RaycastHit Item;
        if (Physics.Raycast(Camera.transform.position, Camera.transform.forward, out Item , Distance))
        {
            if (Item.transform.tag == "PickableItem")
            {
                for (int i = 0; i < 5; i++)
                {
                    if (!activeSlots[i])
                    {
                        activeSlots[i] = true;
                        activeSlot = i;
                        break;
                    }
                }
                imageHitItem = Item.collider.gameObject.GetComponent<Image>();
                handFilter.mesh = Item.collider.gameObject.GetComponentInChildren<MeshFilter>().mesh;
                handRenderer.materials = Item.collider.gameObject.GetComponentInChildren<MeshRenderer>().materials;
                itemInfo = Item.collider.gameObject.GetComponentInChildren<Text>().text.Split("\n");
                hudInfo[activeSlot].text = Item.collider.gameObject.GetComponentInChildren<Text>().text;
                hudMeshF[activeSlot].mesh = Item.collider.gameObject.GetComponentInChildren<MeshFilter>().mesh;
                hudMeshR[activeSlot].materials = Item.collider.gameObject.GetComponentInChildren<MeshRenderer>().materials;
                hudImages[activeSlot].sprite = Item.collider.gameObject.GetComponent<Image>().sprite;
                hudImages[activeSlot].enabled = true;
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
                ItemSetter(imageHitItem.sprite, itemInfo[0], itemInfo[1]);
                Destroy(imageHitItem.gameObject);
            }
        }
    }
    private void ItemSetter (Sprite newSprite, string newName, string newDes)
    {
        foreach (Image slot in inventoryImages)
        {
            if (slot.sprite == null)
            {
                slot.sprite = newSprite;
                slot.enabled = true;
                inventoryName[SlotInv].text = newName;
                inventoryDes[SlotInv].text = newDes;
                break;
            }
            SlotInv += 1;
        }
        if (inventoryName[0].text.Length > 0)
        {
            Name.text = inventoryName[0].text;
            Description.text = inventoryDes[0].text;
        }
        SlotInv = 0;
    }
}    