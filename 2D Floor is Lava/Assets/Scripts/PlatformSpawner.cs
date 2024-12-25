using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject platformPrefab; // ������ ���������
    public int initialPlatformCount = 30; // ��������� ������� ��������
    public float minDistanceX = 5f; // ̳������� ������� �� ����������� �� X
    public float maxDistanceX = 10f; // ����������� ������� �� ����������� �� X
    public float minDistanceY = -3f; // ̳������� ������� �� Y
    public float maxDistanceY = 3f; // ����������� ������� �� Y
    public float firstPlatformSafeDistance = 8f; // ³������ ��� ����� ���������
    public Transform player; // ��'��� ������
    public Transform firstPlatform; // ��������� ���������

    private Vector2 lastPlatformPosition;
    private int platformsGenerated = 0;

    void Start()
    {
        // ������������ ��������� ������� ��� ���������
        if (firstPlatform != null)
        {
            lastPlatformPosition = firstPlatform.position;
        }
        else
        {
            Debug.LogError("First Platform is not assigned in the Inspector!");
            lastPlatformPosition = Vector2.zero; // ���������� ��������
        }

        // �������� ���������� ���� ��������
        for (int i = 0; i < initialPlatformCount; i++)
        {
            SpawnPlatform(i);
        }
    }

    void Update()
    {
        // �������� ��� ���������, ���� ������� ����������� �� ���� ���������
        if (player != null && player.position.x > lastPlatformPosition.x - 15f)
        {
            SpawnPlatform(platformsGenerated);
            platformsGenerated++;
        }
    }

    void SpawnPlatform(int index)
    {
        float randomX;

        // �������� ������� ��� ����� ���������
        if (index == 1)
        {
            randomX = firstPlatformSafeDistance;
        }
        else
        {
            randomX = Random.Range(minDistanceX, maxDistanceX);
        }

        // ��������� ������� �� Y
        float randomY = Random.Range(minDistanceY, maxDistanceY);

        // �����������, �� ��������� �� ����� ��������� ������
        float newYPosition = Mathf.Max(lastPlatformPosition.y + randomY, firstPlatform.position.y);

        // ���������� ���� ������� ���������
        Vector2 newPosition = new Vector2(
            lastPlatformPosition.x + randomX,
            newYPosition
        );

        // ��������� ���� ���������
        Instantiate(platformPrefab, newPosition, Quaternion.identity);

        // ��������� ������� �������
        lastPlatformPosition = newPosition;
    }
}