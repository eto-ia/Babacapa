using UnityEngine;
using UnityEngine.UI;

public class PickItem : MonoBehaviour
{
    public GameObject Camera;
    public float Distance;
    private Image[] inventoryImages = new Image[8];
    private Image[] hudImages = new Image[5];
    private Image imageHitItem;
    private Sprite tempSprite;
    public MeshFilter handFilter;
    public MeshRenderer handRenderer;
    void Start()
    {
        for (int i = 0; i < 8; i++)
        {
            inventoryImages[i] = GameObject.Find("SlotImage" + (i + 1).ToString()).GetComponent<Image>();
            inventoryImages[i].enabled = false;
        }
        for (int i = 0; i < 5; i++)
        {
            hudImages[i] = GameObject.Find("HudSlotImage" + (i + 1).ToString()).GetComponent<Image>();
            hudImages[i].enabled = false;
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
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
                imageHitItem = Item.collider.gameObject.GetComponent<Image>();
                handFilter.mesh = Item.collider.gameObject.GetComponentInChildren<MeshFilter>().mesh;
                handRenderer.material = Item.collider.gameObject.GetComponentInChildren<MeshRenderer>().material;
                if (imageHitItem != null)
                {
                    ImageSetter(imageHitItem.sprite);
                    Destroy(imageHitItem.gameObject);
                }
            }
        }
    }
    private void ImageSetter (Sprite newSprite)
    {
        foreach (Image slot in hudImages)
        {
            if (slot.sprite == null)
            {
                slot.sprite = newSprite;
                slot.enabled = true;
                break;
            }
        }
        foreach (Image slot in inventoryImages)
        {
            if (slot.sprite == null)
            {
                slot.sprite = newSprite;
                slot.enabled = true;
                break;
            }
        }
    }
}    