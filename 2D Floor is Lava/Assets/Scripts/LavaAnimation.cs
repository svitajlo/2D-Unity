using UnityEngine;

public class LavaAnimation : MonoBehaviour
{
    public Material lavaMaterial; // ������� ����
    public float speedX = 0.1f;   // �������� ���� �� �� X
    public float speedY = 0f;     // �������� ���� �� �� Y

    private Vector2 offset;       // ������� ��������

    void Update()
    {
        // ��������� ������� ������� �� ����
        offset.x += speedX * Time.deltaTime;
        offset.y += speedY * Time.deltaTime;

        // ������������ ������� �� ��������
        if (lavaMaterial != null)
        {
            lavaMaterial.mainTextureOffset = offset;
        }
    }
}
