using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject platformPrefab; // Префаб платформи
    public int initialPlatformCount = 30; // Початкова кількість платформ
    public float minDistanceX = 5f; // Мінімальна відстань між платформами по X
    public float maxDistanceX = 10f; // Максимальна відстань між платформами по X
    public float minDistanceY = -3f; // Мінімальне зміщення по Y
    public float maxDistanceY = 3f; // Максимальне зміщення по Y
    public float firstPlatformSafeDistance = 8f; // Відстань для другої платформи
    public Transform player; // Об'єкт гравця
    public Transform firstPlatform; // Початкова платформа

    private Vector2 lastPlatformPosition;
    private int platformsGenerated = 0;

    void Start()
    {
        // Встановлюємо початкову позицію для генерації
        if (firstPlatform != null)
        {
            lastPlatformPosition = firstPlatform.position;
        }
        else
        {
            Debug.LogError("First Platform is not assigned in the Inspector!");
            lastPlatformPosition = Vector2.zero; // Запобігання помилкам
        }

        // Генеруємо початковий набір платформ
        for (int i = 0; i < initialPlatformCount; i++)
        {
            SpawnPlatform(i);
        }
    }

    void Update()
    {
        // Генеруємо нові платформи, якщо гравець наближається до кінця платформи
        if (player != null && player.position.x > lastPlatformPosition.x - 15f)
        {
            SpawnPlatform(platformsGenerated);
            platformsGenerated++;
        }
    }

    void SpawnPlatform(int index)
    {
        float randomX;

        // Особлива відстань для другої платформи
        if (index == 1)
        {
            randomX = firstPlatformSafeDistance;
        }
        else
        {
            randomX = Random.Range(minDistanceX, maxDistanceX);
        }

        // Випадкове зміщення по Y
        float randomY = Random.Range(minDistanceY, maxDistanceY);

        // Забезпечуємо, що платформа не нижче початкової висоти
        float newYPosition = Mathf.Max(lastPlatformPosition.y + randomY, firstPlatform.position.y);

        // Обчислюємо нову позицію платформи
        Vector2 newPosition = new Vector2(
            lastPlatformPosition.x + randomX,
            newYPosition
        );

        // Створюємо нову платформу
        Instantiate(platformPrefab, newPosition, Quaternion.identity);

        // Оновлюємо останню позицію
        lastPlatformPosition = newPosition;
    }
}