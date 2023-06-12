using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PickItem : MonoBehaviour
{
    public GameObject Camera;
    public GameObject Volume;
    public float Distance;
    public GameObject noteScreen;
    public Image note;
    public static Image[] inventoryImages = new Image[8];
    public static Image[] inventoryBG = new Image[8];
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
    public static bool[] collection = {false, false, false, false, false, false};
    private bool[] task4 = {false, false};
    private bool[] task5 = {false, false};
    public static int activeSlot = 0;
    private int SlotInv = 0;
    public AudioSource sfx;
    public Slider sfxs;
    public AudioSource dialog;
    public TaskChanger tskchng;
    public GameObject tbook;
    void Awake()
    {
        for (int i = 0; i < 8; i++)
        {
            inventoryImages[i] = GameObject.Find("SlotImage"+(i + 1).ToString()).GetComponent<Image>();
            inventoryBG[i] = GameObject.Find("SlotBg"+(i + 1).ToString()).GetComponent<Image>();
            inventoryImages[i].enabled = (false);
            inventoryBG[i].enabled = (false);
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
        noteScreen.SetActive(false);     
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
        if (noteScreen.activeSelf == true)
        {
            Time.timeScale = 1f;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.None;
            Camera.GetComponent<FirstPersonLook>().Stopcam(false);
            noteScreen.SetActive(false);
        }
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
                sfx.volume = sfxs.value;
                hudMeshF[activeSlot].mesh = Item.collider.gameObject.GetComponentInChildren<MeshFilter>().mesh;
                hudMeshR[activeSlot].materials = Item.collider.gameObject.GetComponentInChildren<MeshRenderer>().materials;
                if (Item.transform.gameObject.name == "Rune")
                {
                    sfx.clip = Resources.Load<AudioClip>("SFX/rune");
                    collection[5] = true;
                    task5[0] = true;
                    sfx.Play();
                    taskChecker(5);
                }
                else if (Item.transform.gameObject.name == "Crystal")
                {
                    sfx.clip = Resources.Load<AudioClip>("SFX/crystal");
                    collection[4] = true;
                    sfx.Play();
                }
                else if (Item.transform.gameObject.name == "Shovel")
                {
                    dialog.clip = Resources.Load<AudioClip>("Dialogs/shovel");
                    dialog.Play();
                    sfx.clip = Resources.Load<AudioClip>("SFX/pickup");
                    sfx.Play();
                    task4[1] = true;
                    taskChecker(4);
                }
                else if (Item.transform.gameObject.name == "Book_closed")
                {
                    dialog.clip = Resources.Load<AudioClip>("Dialogs/book");
                    dialog.Play();
                    collection[3] = true; 
                    task5[1] = true;
                    handFilter.mesh = tbook.GetComponent<MeshFilter>().mesh;
                    handRenderer.materials = tbook.GetComponent<MeshRenderer>().materials;
                    hudMeshF[activeSlot].mesh = tbook.GetComponent<MeshFilter>().mesh;
                    hudMeshR[activeSlot].materials = tbook.GetComponent<MeshRenderer>().materials;
                    taskChecker(5);
                }
                else if (Item.transform.gameObject.name == "Key")
                {
                    sfx.clip = Resources.Load<AudioClip>("SFX/pickup");
                    tskchng.taskPicker(4);
                    sfx.Play();
                }
                hudInfo[activeSlot].text = Item.collider.gameObject.GetComponentInChildren<Text>().text;
                
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
            else if (Item.transform.tag == "Note")
            {
                imageHitItem = Item.collider.gameObject.GetComponent<Image>();
                itemInfo = Item.collider.gameObject.GetComponentInChildren<Text>().text.Split("\n");
                sfx.clip = Resources.Load<AudioClip>("SFX/note");
                sfx.Play();
                if (Item.transform.gameObject.name == "Note1")
                {
                    dialog.clip = Resources.Load<AudioClip>("Dialogs/note1");
                    dialog.Play();
                    collection[0] = true;
                }
                else if (Item.transform.gameObject.name == "Note2")
                {
                    dialog.clip = Resources.Load<AudioClip>("Dialogs/note2");
                    dialog.Play();
                    collection[1] = true;
                }
                else if (Item.transform.gameObject.name == "Note3")
                {
                    dialog.clip = Resources.Load<AudioClip>("Dialogs/note3");
                    dialog.Play();
                    collection[2] = true;
                    task4[0] = true;
                    taskChecker(4);
                }
                note.sprite = imageHitItem.sprite;
                noteScreen.SetActive(true);
                Time.timeScale = 0f;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.Confined;
                Camera.GetComponent<FirstPersonLook>().Stopcam(true);
                ItemSetter(Resources.Load<Sprite>("notes/note_bg"), itemInfo[0], itemInfo[1]);
                Destroy(imageHitItem.gameObject);
                FirstPersonAudio volume = Volume.GetComponent<FirstPersonAudio>();
                if (volume != null)
                {
                    volume.SetPlayingMovingAudio (null, true);
                }
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
                inventoryBG[SlotInv].enabled = true;
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
    private void taskChecker(int index)
    {
        if (index == 4)
        {
            if (task4[0] && task4[1])
            {
                tskchng.taskPicker(5);
            }
        }
        if (index == 5)
        {
            if (task5[0] && task5[1])
            {
                tskchng.taskPicker(6);
            }
        }
    }
}    