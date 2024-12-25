using UnityEngine;

public class GameStartManager : MonoBehaviour
{
    public GameObject startText; // Текст, який потрібно сховати
    private bool gameStarted = false;

    void Start()
    {
        // Переконуємося, що гра зупинена на початку
        Time.timeScale = 0;

        // Переконуємося, що текст активний
        if (startText != null)
        {
            startText.SetActive(true);
        }
    }

    void Update()
    {
        // Якщо натиснута будь-яка клавіша і гра ще не почалася
        if (!gameStarted && Input.anyKeyDown)
        {
            StartGame();
        }
    }

    void StartGame()
    {
        gameStarted = true;

        // Ховаємо текст
        if (startText != null)
        {
            startText.SetActive(false);
        }

        // Запускаємо гру
        Time.timeScale = 1;
    }
}
