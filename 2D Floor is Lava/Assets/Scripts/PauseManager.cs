using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public GameObject pauseText; // Текст для паузи
    public AudioClip pauseSound; // Звук для паузи
    public AudioClip resumeSound; // Звук для відновлення

    private AudioSource audioSource;
    private bool isPaused = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        pauseText.SetActive(false); // Спочатку текст прихований
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0f; // Зупиняємо час
        pauseText.SetActive(true); // Показуємо текст
        audioSource.PlayOneShot(pauseSound); // Відтворюємо звук паузи
    }

    void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1f; // Відновлюємо час
        pauseText.SetActive(false); // Приховуємо текст
        audioSource.PlayOneShot(resumeSound); // Відтворюємо звук відновлення
    }
}
