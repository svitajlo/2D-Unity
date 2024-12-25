using UnityEngine;
using UnityEngine.SceneManagement; // ��� ��������� �������

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverText; // ����� "Game Over"
    public AudioClip gameOverSound; // ���� ��� Game Over
    public GameObject player; // �����
    private bool isGameOver = false; // �� ��� ��������
    private AudioSource audioSource; // ��� ���������� �����

    void Start()
    {
        // ������������, �� ����� "Game Over" �������� ����������
        if (gameOverText != null)
        {
            gameOverText.SetActive(false);
        }

        // ���������� AudioSource
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // ���� ��� ��������, ������ ���������� ����-��� ������ ��� �����������
        if (isGameOver && Input.anyKeyDown)
        {
            RestartGame();
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // ����������, �� ����� �������� � ����
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

            // ��������� ���
            Time.timeScale = 0;

            // ������� ����� "Game Over"
            if (gameOverText != null)
            {
                gameOverText.SetActive(true);
            }

            // ³��������� ���� Game Over
            if (gameOverSound != null && audioSource != null)
            {
                audioSource.PlayOneShot(gameOverSound);
            }
        }
    }

    void RestartGame()
    {
        // ³��������� ��� ���
        Time.timeScale = 1;

        // ��������������� ������� �����
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
