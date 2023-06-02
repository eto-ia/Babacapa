using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DeleteItem : MonoBehaviour
{
    private Text[] hudInfo = new Text[5];
    private MeshFilter[] hudMeshF = new MeshFilter[5];
    private MeshRenderer[] hudMeshR = new MeshRenderer[5];
    private Image[] hudImages = new Image[5];
    public TextMeshProUGUI Name;
    public TextMeshProUGUI Description;
    private int curSlot;
    private int curActiveSlots = 0;
    private string targetText;
    private int curSlotInv;
    private int curActiveSlotsInv = 0;
    void Awake() 
    {
        for (int i = 0; i < 5; i++)
        {
            hudInfo[i] = GameObject.Find("SlotInfo" + (i + 1).ToString()).GetComponent<Text>();
            hudMeshF[i] = GameObject.Find("SlotInfo" + (i + 1).ToString()).GetComponent<MeshFilter>();
            hudMeshR[i] = GameObject.Find("SlotInfo" + (i + 1).ToString()).GetComponent<MeshRenderer>();
            hudImages[i] = GameObject.Find("HudSlotImage" + (i + 1).ToString()).GetComponent<Image>();
        }
    }
    public void deleteHud()
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
            hudMeshR[curSlot].material = null;
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
            hudMeshR[curSlot + curActiveSlots].material = null;
            hudImages[curSlot + curActiveSlots].enabled = false;
            PickItem.activeSlots[curSlot + curActiveSlots] = false;
            PickItem.activeSlot = 0;
            HandSwitcher.handSwitcher(PickItem.activeSlot);
        }
        curActiveSlots = 0;
        deleteInventory();
    }
    private void switchSlot(int index)
    {
        hudInfo[index].text = hudInfo[index + 1].text;
        hudMeshF[index].mesh = hudMeshF[index + 1].mesh;
        hudMeshR[index].material = hudMeshR[index + 1].material;
        hudImages[index].sprite = hudImages[index + 1].sprite;
    }
    private void deleteInventory()
    {
        Debug.Log(targetText);
        for (int i = 0; i < 8; i++)
        {
            if (PickItem.inventoryName[i].text == targetText)
            {
                curSlotInv = i;
            }
        }
        Debug.Log(curSlotInv);
        for (int i = curSlotInv + 1; i < 8; i++)
        {
            if (PickItem.inventoryImages[i].sprite != null)
            {
                curActiveSlotsInv += 1;
            }
            else break;
        }
        Debug.Log(curSlotInv + "  " + curActiveSlotsInv);
        if (curSlotInv == 0 && curActiveSlotsInv == 0)
        {
            PickItem.inventoryImages[curSlotInv].sprite = null;
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
    private void switchSlotInv(int index)
    {
        PickItem.inventoryImages[index].sprite = PickItem.inventoryImages[index + 1].sprite;
        PickItem.inventoryName[index].text = PickItem.inventoryName[index + 1].text;
        PickItem.inventoryDes[index].text = PickItem.inventoryDes[index + 1].text;
    }
}
