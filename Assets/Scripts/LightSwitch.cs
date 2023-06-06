using UnityEngine;

public class LightSwitch : MonoBehaviour
{
    public Light light; // ������ ���������, ������� �� ������ �������� � ���������
    public AudioSource audioSource; // ����� ��������, ������� ����� �������������� ���� ��� ��������� �����

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) // ���������, ������ �� ������ E
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); // ������� ��� �� ������ � ����������� ��������� ����
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit) && hit.collider.CompareTag("Switch")) // ���������, ��� ��� ���������� � �������� �����������
            {
                light.enabled = !light.enabled; // ����������� �������� �������� "��������" ������� ���������
                audioSource.Play(); // ������������� ����
            }
        }
    }
}
