using UnityEngine;
using UnityEngine.SceneManagement; // Для управління сценами

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverText; // Текст "Game Over"
    public AudioClip gameOverSound; // Звук для Game Over
    public GameObject player; // Герой
    private bool isGameOver = false; // Чи гра закінчена
    private AudioSource audioSource; // Для відтворення звуку

    void Start()
    {
        // Переконуємося, що текст "Game Over" спочатку неактивний
        if (gameOverText != null)
        {
            gameOverText.SetActive(false);
        }

        // Ініціалізуємо AudioSource
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // Якщо гра закінчена, чекаємо натискання будь-якої клавіші для перезапуску
        if (isGameOver && Input.anyKeyDown)
        {
            RestartGame();
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Перевіряємо, чи герой потрапив у лаву
        if (collision.gameObject == player)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        if (!isGameOver)
        {
            isGameOver = true;

            // Зупиняємо гру
            Time.timeScale = 0;

            // Вмикаємо текст "Game Over"
            if (gameOverText != null)
            {
                gameOverText.SetActive(true);
            }

            // Відтворюємо звук Game Over
            if (gameOverSound != null && audioSource != null)
            {
                audioSource.PlayOneShot(gameOverSound);
            }
        }
    }

    void RestartGame()
    {
        // Відновлюємо час гри
        Time.timeScale = 1;

        // Перезавантажуємо поточну сцену
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
