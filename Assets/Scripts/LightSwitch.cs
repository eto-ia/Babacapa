using UnityEngine;

public class LightSwitch : MonoBehaviour
{
    public Light light; // Объект освещения, который вы хотите включать и выключать
    public AudioSource audioSource; // Аудио источник, который будет воспроизводить звук при включении света

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) // Проверяем, нажата ли кнопка E
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); // Создаем луч из камеры в направлении указателя мыши
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit) && hit.collider.CompareTag("Switch")) // Проверяем, что луч столкнулся с объектом выключателя
            {
                light.enabled = !light.enabled; // Инвертируем значение свойства "включено" объекта освещения
                audioSource.Play(); // Воспроизводим звук
            }
        }
    }
}
