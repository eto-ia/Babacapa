using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class TaskChanger : MonoBehaviour
{
    public static int curTask = 1;
    public TextMeshProUGUI taskText;
    public Image taskImage;
    private float width;
    private string ctext;
    void Start()
    {
        widthSetter();
    }
    public void taskPicker (int index)
    {
        switch (index)
        {
            case 2:
                ctext = "Текущее задание: осмотреть особняк и территорию";
                break;
            case 3:
                ctext = "Текущее задание: узнать, где находится ключ";
                break;
            case 4:
                ctext = "Текущее задание: обыскать амбар";
                break;
            case 5:
                ctext = "Текущее задание: откопать книгу и руну в саду";
                break;
            case 6:
                ctext = "Текущее задание: изгнать демона";
                break;
        }
        curTask = index;
        textSetter(ctext);
    }
    public void textSetter(string text)
    {
        taskText.text = text;
        widthSetter();
    }
    private void widthSetter()
    {
        width = taskText.preferredWidth;
        RectTransform trt = taskText.rectTransform;
        trt.sizeDelta = new Vector2(width, trt.sizeDelta.y);
        RectTransform tri = taskImage.rectTransform;
        tri.sizeDelta = new Vector2(width + 20, tri.sizeDelta.y);
    }
}
