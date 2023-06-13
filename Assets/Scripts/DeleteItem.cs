using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DeleteItem : MonoBehaviour
{
    public TextMeshProUGUI namer;
    public TextMeshProUGUI desna;
    private static Text[] hudInfo = new Text[5];
    private static MeshFilter[] hudMeshF = new MeshFilter[5];
    private static MeshRenderer[] hudMeshR = new MeshRenderer[5];
    private static Image[] hudImages = new Image[5];
    public static TextMeshProUGUI Name;
    public static TextMeshProUGUI Description;
    private static int curSlot;
    private static int curActiveSlots = 0;
    private static string targetText;
    private static int curSlotInv;
    private static int curActiveSlotsInv = 0;
    void Start() 
    {
        for (int i = 0; i < 5; i++)
        {
            hudInfo[i] = GameObject.Find("SlotInfo" + (i + 1).ToString()).GetComponent<Text>();
            hudMeshF[i] = GameObject.Find("SlotInfo" + (i + 1).ToString()).GetComponent<MeshFilter>();
            hudMeshR[i] = GameObject.Find("SlotInfo" + (i + 1).ToString()).GetComponent<MeshRenderer>();
            hudImages[i] = GameObject.Find("HudSlotImage" + (i + 1).ToString()).GetComponent<Image>();
        }
        Name = namer;
        Description = desna;
    }
    public static void deleteHud()
    {
        curSlot = PickItem.activeSlot;
        targetText = hudInfo[curSlot].text.Split("\n")[0];
        for (int i = curSlot + 1; i < 5; i++)
        {
            if(PickItem.activeSlots[i])
            {
                curActiveSlots += 1;
            }
        }
        if (curSlot == 0 && curActiveSlots == 0)
        {
            hudInfo[curSlot].text = null;
            hudMeshF[curSlot].mesh = null;
            hudMeshR[curSlot].materials = new Material[0];
            hudImages[curSlot].enabled = false;
            PickItem.activeSlots[curSlot] = false;
            PickItem.activeSlot = 0;
            HandSwitcher.handSwitcher(-1);
        }
        else
        {
            for (int i = curSlot; i < curSlot + curActiveSlots; i++)
            {
                switchSlot(i);
            }
            hudInfo[curSlot + curActiveSlots].text = null;
            hudMeshF[curSlot + curActiveSlots].mesh = null;
            hudMeshR[curSlot + curActiveSlots].materials = new Material[0];;
            hudImages[curSlot + curActiveSlots].enabled = false;
            PickItem.activeSlots[curSlot + curActiveSlots] = false;
            PickItem.activeSlot = 0;
            HandSwitcher.handSwitcher(PickItem.activeSlot);
        }
        curActiveSlots = 0;
        deleteInventory();
    }
    public static void switchSlot(int index)
    {
        hudInfo[index].text = hudInfo[index + 1].text;
        hudMeshF[index].mesh = hudMeshF[index + 1].mesh;
        hudMeshR[index].materials = hudMeshR[index + 1].materials;
        hudImages[index].sprite = hudImages[index + 1].sprite;
    }
    public static void deleteInventory()
    {
        for (int i = 0; i < 8; i++)
        {
            if (PickItem.inventoryName[i].text == targetText)
            {
                curSlotInv = i;
            }
        }
        for (int i = curSlotInv + 1; i < 8; i++)
        {
            if (PickItem.inventoryImages[i].sprite != null)
            {
                curActiveSlotsInv += 1;
            }
            else break;
        }
        if (curSlotInv == 0 && curActiveSlotsInv == 0)
        {
            PickItem.inventoryImages[curSlotInv].sprite = null;
            PickItem.inventoryBG[curSlotInv].enabled = false;
            PickItem.inventoryName[curSlotInv].text = null;
            PickItem.inventoryDes[curSlotInv].text = null;
            PickItem.inventoryImages[curSlotInv].enabled = false;
        }
        else
        {
            for (int i = curSlotInv; i < curSlotInv + curActiveSlotsInv; i++)
            {
                switchSlotInv(i);
            }
            PickItem.inventoryImages[curSlotInv + curActiveSlotsInv].sprite = null;
            PickItem.inventoryName[curSlotInv + curActiveSlotsInv].text = null;
            PickItem.inventoryDes[curSlotInv + curActiveSlotsInv].text = null;
            PickItem.inventoryImages[curSlotInv + curActiveSlotsInv].enabled = false;
        }
        curActiveSlotsInv = 0;
        Name.text = null;
        Description.text = null;
    }
    public static void switchSlotInv(int index)
    {
        PickItem.inventoryImages[index].sprite = PickItem.inventoryImages[index + 1].sprite;
        PickItem.inventoryName[index].text = PickItem.inventoryName[index + 1].text;
        PickItem.inventoryDes[index].text = PickItem.inventoryDes[index + 1].text;
    }
}
