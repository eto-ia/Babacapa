using UnityEngine;
using TMPro;

public class SwitchInventorySlot : MonoBehaviour
{
    public TextMeshProUGUI Name;
    public TextMeshProUGUI Description;
    public void Switch(int index)
    {
        Name.text = GameObject.Find("SlotText" + index.ToString()).GetComponent<TextMeshProUGUI>().text;
        Description.text = GameObject.Find("SlotDes" + index.ToString()).GetComponent<TextMeshProUGUI>().text;
    }
}
